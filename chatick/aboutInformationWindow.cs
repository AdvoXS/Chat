using System;
using System.Windows.Forms;
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
        
        async void bdConnect()
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
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            bdConnect();
            
        }
    }
   
}
