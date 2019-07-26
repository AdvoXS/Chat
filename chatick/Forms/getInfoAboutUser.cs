using System;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
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
        void get_info_BD()
        {
            List<string> list = null;
            Task task =new Task(() =>
            {
                DataBasePostgres dataBase = new DataBasePostgres();
                list = dataBase.get_information_user(nick);
            
            if (list.Count>0)
            {
                    Action actVis1True = () => label1.Visible = true;
                    Action actVis2True = () => label2.Visible = true;
                    Action actVis3True = () => label3.Visible = true;
                    Action actVis4True = () => label4.Visible = true;
                    Action actVisFalse = () => label5.Visible = false;
                    Action actLab1Pr = () => label1.Text = "Nickname: "+ list[0];
                    Action actLab2Pr = () => label2.Text = "First name: " + list[1];
                    Action actLab3Pr = () => label3.Text = "Second name: " + list[2];
                    Action actLab4Pr = () => label4.Text = "Age: " + list[3];

                    label5.Invoke(actVisFalse);
                    label1.Invoke(actLab1Pr);
                    label2.Invoke(actLab2Pr);
                    label3.Invoke(actLab3Pr);
                    label4.Invoke(actLab4Pr);
                    label1.Invoke(actVis1True);
                    label2.Invoke(actVis2True);
                    label3.Invoke(actVis3True);
                    label4.Invoke(actVis4True);
                }
            else
            {

                Action act = ()=> label5.Text = "Данных о пользователе не обнаружено!";
                    label5.Invoke(act);
            }
            });
            task.Start();
        }
    }
}
