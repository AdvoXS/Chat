using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
namespace chatick
{
    
    public partial class aboutInformationWindow : Form
    {
        
        string Nick;
        public aboutInformationWindow(string nick)
        {
            InitializeComponent();
            Nick = nick;
        }
        async void bdConnectPostgr_async()
        {
            DataBasePostgres dataBase = new DataBasePostgres();
            try
            {
                await Task.Run(() => dataBase.create_information_about_user_async(Nick,
                    textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text)));
                
            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Ошибка при добавлении информации. Удостоверьтесь, что вы ранее не добавляли!");
            }
            MessageBox.Show("Информация добавлена!");
        }
        /*async void bdConnect()   // Подключение к MongoDB
        {
            bool finded = false;
            var client = new MongoClient("mongodb+srv://user:user@kantian-bbnou.mongodb.net/test?retryWrites=true");
            var database = client.GetDatabase("Chat_TCP");
            var collection = database.GetCollection<Person>("user_data");
            var filter = new BsonDocument();
            var people = await collection.Find(filter).ToListAsync();
            foreach (Person document in people)
                    {
                        if (document.nickname == Nick)
                        {
                    finded = true;
                        }
                   
            }
            if (!finded)
            {
                Person n = new Person { nickname = Nick, firstName = textBox1.Text, secondName = textBox2.Text, age = Convert.ToInt32(textBox3.Text) };
                await collection.InsertOneAsync(n);
                button1.Enabled = false;
                button1.Visible = false;
                label5.Visible = true;
            }
            else
            {
                button1.Enabled = false;
                button1.Visible = false;
                label5.Visible = true;
                label5.Text = "Информация уже существует! Изменение пока невозможно";
            }
        }*/
        
        private void button1_Click(object sender, EventArgs e)
        {
            // bdConnect();
            bdConnectPostgr_async();
        }
    }
   
}
