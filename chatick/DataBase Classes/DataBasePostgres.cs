using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace chatick
{
    static class DataBasePostgres
    {
        //Класс - реализация взаимодействия с БД (соединение,запросы)
        static NpgsqlConnection NpgConnection;
         private static void connection_db_open()
        {
            string connectionString = "Server=104.197.156.11;Port=5432;User Id=postgres;Password=HelloSql1;Database=postgres;Timeout=15;";
            NpgConnection = new NpgsqlConnection(connectionString);
            NpgConnection.Open();
        }
        private static void connection_db_close()
        {
            if (NpgConnection != null)
            {
                NpgConnection.Close();
            }
        }
        public static List<string> read_all_nicks_participants()
        {
            connection_db_open();
            NpgsqlCommand com = new NpgsqlCommand("select nick from public.user_info", NpgConnection);

            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            List<string> result = new List<string>();
            while (reader.Read())
            {
                try
                {
                    result.Add(reader.GetString(0));//Получаем значение из первого столбца! Первый это (0)!
                }
                catch(Npgsql.NpgsqlException ex)
                {
                    Logs.LogClass log = new Logs.LogClass("DB", "Считывание ников ВСЕХ пользователей " + ex.Message);
                }
            }

            connection_db_close();
            return result;
        }
       async public static void add_message_user_async(string nick,string date,string message)
        {
            connection_db_open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgConnection;
                cmd.CommandText = "INSERT INTO public.history_messages (id,date_out,message) " +
                    "VALUES ((Select id from user_info where @n=nick),to_timestamp(@d,'dd.mm.yyyy HH24:MI:SS'),@m)";
                cmd.Parameters.AddWithValue("n", nick);
                cmd.Parameters.AddWithValue("d", date);
                cmd.Parameters.AddWithValue("m", message);
                await cmd.ExecuteNonQueryAsync();
            }
            connection_db_close();
        }

        async public static void create_information_about_user_async(string nick, string first_name,string second_name,int age)
        {
            connection_db_open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = NpgConnection;
                    cmd.CommandText = "INSERT INTO user_info (nick,first_name,second_name,age) VALUES (@n,@f,@s,@a) " +
                    "ON Conflict (nick) DO UPDATE SET first_name = @f,second_name = @s, age=@a; ";
                    cmd.Parameters.AddWithValue("n", nick);
                    cmd.Parameters.AddWithValue("f", first_name);
                    cmd.Parameters.AddWithValue("s", second_name);
                    cmd.Parameters.AddWithValue("a", age);
                    await cmd.ExecuteNonQueryAsync();
                }
            connection_db_close();
        }
        public static List<string> get_history_message_to_view(string date_in,string date_out)
        {
            connection_db_open();
            NpgsqlCommand com = new NpgsqlCommand("select nick,message,to_char(date_out, 'dd.mm.yyyy') as myDate, to_char(date_out, 'hh24:mi:ss') as myTime" +
                " from public.history_messages mes" +
                ", public.user_info us where us.id=mes.id " +
                "and date_out::date>=to_date(@i,'dd.mm.yyy') and date_out::date<=to_date(@o,'dd.mm.yyyy') order by date_out", NpgConnection);
            com.Parameters.AddWithValue("i", date_in);
            com.Parameters.AddWithValue("o", date_out);
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            List<string> result = new List<string>();
            while (reader.Read())
            {
                try
                {
                    result.Add(reader.GetString(3) +" "+ reader.GetString(0)+":"+ reader.GetString(1));
                }
                catch (Npgsql.NpgsqlException ex)
                {
                    Logs.LogClass logClass = new Logs.LogClass("DB", "Считывание истории сообщений " + ex.Message);
                }
            }
            connection_db_close();
           return result;
        }
        public static string login_user(string nick, string pass)
        {
            
            NpgsqlDataReader reader;
            string salt = "";
            //получаем соль пользователя
            using (NpgsqlCommand com1 = new NpgsqlCommand())
            {
                connection_db_open();
                com1.CommandText = "SELECT salt FROM user_info,user_pass " +
                "where user_info.id = user_pass.id and nick = @n";
                com1.Connection= NpgConnection;
                com1.Parameters.AddWithValue("n", nick);
                reader = com1.ExecuteReader();
                if (reader.Read())
                {
                    salt = reader.GetString(0);
                }
                connection_db_close();
            }
            Security.SecurityClass security = new Security.SecurityClass();
            string password = security.password_MD5Hash_open(pass, salt);

            //проверяем пароль

            using (NpgsqlCommand com = new NpgsqlCommand())
            {
                connection_db_open();
                com.CommandText="SELECT nick FROM user_info,user_pass " +
                  "where user_info.id = user_pass.id and nick = @n and @p=password";
                com.Connection = NpgConnection;
                com.Parameters.AddWithValue("n", nick);
                com.Parameters.AddWithValue("p", password);

                reader = com.ExecuteReader();
                if (reader.Read())
                {
                    string nickName = reader.GetString(0);
                    connection_db_close();
                    return nickName;
                }
                else
                {
                    connection_db_close();
                    return "0";
                }
            }
        }
        public static bool registration_user(string nick,string pass,string salt,string first_name, string second_name, int age)
        {
            connection_db_open();

            NpgsqlCommand com = new NpgsqlCommand("SELECT @n where @n in (SELECT nick FROM user_info)", NpgConnection);
            com.Parameters.AddWithValue("n", nick);
            NpgsqlDataReader reader;
            reader = com.ExecuteReader();
            if (!reader.Read())
            {
                connection_db_close();
                connection_db_open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = NpgConnection;
                    cmd.CommandText = "INSERT INTO user_info (nick,first_name,second_name,age) VALUES (@n,@f,@s,@a)";
                    cmd.Parameters.AddWithValue("n", nick);
                    cmd.Parameters.AddWithValue("f", first_name);
                    cmd.Parameters.AddWithValue("s", second_name);
                    cmd.Parameters.AddWithValue("a", age);
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = NpgConnection;
                    cmd.CommandText = "INSERT INTO user_pass (id,password,salt) VALUES ((SELECT id from user_info where @n=nick),@p,@s)";
                    cmd.Parameters.AddWithValue("n", nick);
                    cmd.Parameters.AddWithValue("p", pass);
                    cmd.Parameters.AddWithValue("s", salt);
                    cmd.ExecuteNonQuery();
                }
                connection_db_close();
                return true;
            }
            else
            {
                connection_db_close();
                return false;
            }
        }

        public static List<string> get_information_user(string nick)
        {
            connection_db_open();

            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgConnection;
                cmd.CommandText = "Select nick,first_name,second_name,age from user_info where @n=nick";
                cmd.Parameters.AddWithValue("n", nick);
                NpgsqlDataReader reader;
                List<string> listInfo = new List<string>();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    listInfo.Add(reader.GetString(0));
                    listInfo.Add(reader.GetString(1));
                    listInfo.Add(reader.GetString(2));
                    listInfo.Add(Convert.ToString(reader.GetInt32(3)));
                    connection_db_close();
                    return listInfo;
                }
                else
                {
                    connection_db_close();
                    return new List<string>(0);
                }
            }
        }
    }
    
}
