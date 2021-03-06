﻿using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace chatick
{
    
    public partial class aboutInformationWindow : Form
    {
        
        string Nick;
        List<string> aboutUserList = null;
        public aboutInformationWindow(string nick)
        {
            InitializeComponent();
            Nick = nick;
            get_info_user();
            textBox1.Text = aboutUserList[1];
            textBox2.Text = aboutUserList[2];
            textBox3.Text = Convert.ToString(aboutUserList[3]);
        }

        void get_info_user()
        {
            
                 try
                 {
                     aboutUserList = DataBasePostgres.get_information_user(Nick);
                 }
                 catch (Npgsql.PostgresException ex)
                 {
                     MessageBox.Show("Ошибка соединения с базой данных");
                     Logs.LogClass logClass = new Logs.LogClass("DB", "Получение данных пользователя о себе(из списка пользователей). Ошибка postgres: " + ex.MessageText);
                 }
                 catch (Npgsql.NpgsqlException ex)
                 {
                     MessageBox.Show("Ошибка соединения с базой данных");
                     Logs.LogClass logClass = new Logs.LogClass("DB", "Получение данных пользователя о себе(из списка пользователей). Ошибка связи: " + ex.Message);
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Неизвестная ошибка");
                     Logs.LogClass logClass = new Logs.LogClass("System", "Имя объекта вызвавшего ошибку: " + ex.Source + " Ошибка " + ex.Message);
                 }
            }
        async void bdConnectPostgr_async()
        {
                await Task.Run(() =>
                {
                    try
                    {
                        DataBasePostgres.create_information_about_user_async(Nick,
                         textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));
                        MessageBox.Show("Информация добавлена!");

                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Введены некорректные данные!");
                    }
                    catch (Npgsql.PostgresException ex)
                    {
                        MessageBox.Show("Ошибка соединения с базой данных");
                        Logs.LogClass logClass = new Logs.LogClass("DB", "Изменение данных пользователя о себе. Ошибка postgres: " + ex.MessageText);
                    }
                    catch (Npgsql.NpgsqlException ex)
                    {
                        MessageBox.Show("Ошибка соединения с базой данных");
                        Logs.LogClass logClass = new Logs.LogClass("DB", "Изменение данных пользователя о себе. Ошибка связи: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неизвестная ошибка");
                        Logs.LogClass logClass = new Logs.LogClass("System", "Имя объекта вызвавшего ошибку: " + ex.Source + " Ошибка " + ex.Message);
                    }
                }
                );
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bdConnectPostgr_async();
        }
    }
   
}
