using System;
using System.IO;
namespace chatick.Logs
{
    class LogClass
    {
        string LogMessage;
        public LogClass(string typeOfLog, string exceptionMessage)
        {
            LogMessage = DateTime.Now + " " + exceptionMessage;
            DirectoryInfo directoryInfo = new DirectoryInfo(@"Logs");
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();//создание папки Logs(если таковой не имеется)
            }
            switch (typeOfLog)
            {
                case "DB": write_Db_log();
                    break;
                default: write_System_log();
                    break;
            }
        }
        void write_Db_log()//запись ошибок базы данных
        {
            string path = @"Logs/DB_Log.txt";
            if (!File.Exists(path))
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            StreamWriter streamWriter = new StreamWriter(path,true);
            streamWriter.WriteLine(LogMessage);
            streamWriter.Close();
        }
        void write_System_log()//запись остальных ошибок
        {
            string path = @"Logs/System_Log.txt";
            if (!File.Exists(path))
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            StreamWriter streamWriter = new StreamWriter(path,true);
            streamWriter.WriteLine(LogMessage);
            streamWriter.Close();
        }
    }
}
