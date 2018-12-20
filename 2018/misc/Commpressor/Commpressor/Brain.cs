using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Commpressor
{
    public class Brain
    {
        public string Compress(string addres,string nameCompressor)
        {
            //после получение пути мы определяем тип файла
            //я не ограничил пользователя несколькими типами 
            //хотел чтобы программа могла сжимать всё осталось толко добавить алгоритмы
            var type = GetType(addres);
            if (type == "text" && nameCompressor == "LZW")
            {
                //после определение типа отправляем алгоритму
                var doc = new TextDocument(addres);
                var com = new LZWCompressor();
                var result = com.Commpres(doc);
                //после сжатие записываем в бд
                HistoryWrite(addres, result, doc.Name);
                return result;
            }
            return null;

        }

        public string Decompress(string addres, string nameCompressor)
        {
            var type = GetType(addres);
            if (type == "text" && nameCompressor == "LZW")
            {
                var doc = new TextDocument(addres);
                var com = new LZWCompressor();
                return com.DeCommpress(doc);
            }
            return null;
        }

        public void HistoryWrite(string before,string after,string name)
        {
            //здесь происходит простой insert потом все буду передалять на linq запросы
            FileInfo file1 = new FileInfo(before);
            FileInfo file2 = new FileInfo(after);
            string f1 = file1.Length.ToString();
            string f2 = file2.Length.ToString();
            string con = ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;
            string sel = @"INSERT INTO History_Convert(DateConvert,NameDocument,SizeBefore,SizeAfter)
                               values('" + DateTime.Now.ToString() + "','" + name + "'," + f1 + "," + f2 + ");";
            using (SqlConnection connection = new SqlConnection(con))
            {
                
                connection.Open();
                SqlCommand command = new SqlCommand(sel, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public string GetType(string obj)
        {
            //в пути указан тип файла но так как у нас doc,docx,txt все текстовые то алгоритм будет
            //один в базе хранится 2 таблиц соеденены многи ко многим отправляем запрос и получаем 
            //наш тип
            var type = obj.Split('.');
            var doctype = type[type.Length - 1];

            string con = ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;
            string result=string.Empty;
            using (SqlConnection connection = new SqlConnection(con))
            {
                try
                {
                    connection.Open();
                    string sel = @"SELECT m.Mytype FROM Mytype m
                       WHERE EXISTS(SELECT c.Mytype_ID FROM Converter c
                        WHERE EXISTS(SELECT * FROM Doctype d
                        WHERE d.Doctype='txt'))";
                    SqlCommand command = new SqlCommand(sel, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result = reader[0].ToString();
                        //for (int i = 0; i < reader.FieldCount; i++)
                        //{
                        //    result.Add(reader[i].ToString());
                        //}
                    }
                    reader.Close();
                }
                catch
                {

                }
            }
            return result;
        }

    }
}