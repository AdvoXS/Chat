using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace chatick
{
    public partial class getInfoAboutUser : Form
    {
        string nick;
        public getInfoAboutUser(string getNick)
        {
           
            InitializeComponent();
            nick = getNick;
            get_info_BD();
        }
        async void get_info_BD()
        {
            bool finded = false;
            var client = new MongoClient("mongodb+srv://user:user@kantian-bbnou.mongodb.net/test?retryWrites=true");
            var database = client.GetDatabase("Chat_TCP");
            var collection = database.GetCollection<Person>("user_data");
            var filter = new BsonDocument();
            var people = await collection.Find(filter).ToListAsync();
            foreach (Person document in people)
            {
                if (document.nickname == nick)
                {
                    finded = true;
                    label1.Text = "Никнейм: "+nick;
                    label2.Text = "Имя: " + document.firstName;
                    label3.Text = "Фамилия: " + document.secondName;
                    label4.Text = "Возраст: " + Convert.ToString(document.age);
                    break;
                }
            }
            if (finded)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = false;
            }
            else
            {
                label5.Text = "К сожалению пользователь еще не рассказал о себе :(";
            }
        }
    }
}
