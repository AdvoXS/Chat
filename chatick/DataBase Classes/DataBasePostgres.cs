using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace chatick
{
    class DataBasePostgres
    {
        //Класс - реализация взаимодействия с БД (соединение,запросы)
        NpgsqlConnection NpgConnection;
        public DataBasePostgres()
        {
        }
         private void connection_db_open()
        {
            string connectionString = "Server=104.197.156.11;Port=5432;User Id=postgres;Password=752257mm;Database=postgres;";
            NpgConnection = new NpgsqlConnection(connectionString);
            NpgConnection.Open();
        }
        private void connection_db_close()
        {
            if (NpgConnection != null)
            {
                NpgConnection.Close();
            }
        }
        public List<string> read_all_nicks_participants()
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
                catch { }
            }

            connection_db_close();
            return result;
        }
       async public void add_message_user_async(string nick,string date,string message)
        {
            connection_db_open();
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = NpgConnection;
                cmd.CommandText = "INSERT INTO public.history_messages (id,date_out,message) " +
                    "VALUES ((Select id from user_info where @n=nick and nick is not null),to_timestamp(@d,'dd.mm.yyyy HH24:MI:SS'),@m)";
                cmd.Parameters.AddWithValue("n", nick);
                cmd.Parameters.AddWithValue("d", date);
                cmd.Parameters.AddWithValue("m", message);
                await cmd.ExecuteNonQueryAsync();
            }
            connection_db_close();
        }

        async public void create_information_about_user_async(string nick, string first_name,string second_name,int age)
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
        public List<string> get_history_message_to_view(string date_in,string date_out)
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
                catch { }
            }
            connection_db_close();
           return result;
        }
        public string login_user(string nick, string pass)
        {
            connection_db_open();

            NpgsqlCommand com = new NpgsqlCommand("SELECT nick FROM user_info,user_pass " +
                "where user_info.id = user_pass.id and nick = @n and @p=password", NpgConnection);
            com.Parameters.AddWithValue("n", nick);
            com.Parameters.AddWithValue("p",pass);
            NpgsqlDataReader reader;
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
        public bool registration_user(string nick,string pass,string first_name, string second_name, int age)
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
                    cmd.CommandText = "INSERT INTO user_pass (id,password) VALUES ((SELECT id from user_info where @n=nick),@p)";
                    cmd.Parameters.AddWithValue("n", nick);
                    cmd.Parameters.AddWithValue("p", pass);
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
    }
    
}
