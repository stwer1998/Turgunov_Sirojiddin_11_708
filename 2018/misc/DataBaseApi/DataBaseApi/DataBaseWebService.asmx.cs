using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Services;
using System.Collections.ObjectModel;
using System.Collections;

namespace DataBaseApi
{
    /// <summary>
    /// Сводное описание для DataBaseWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class DataBaseWebService : WebService
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["DataBaseConnection"].ConnectionString;

        [WebMethod]
        public List<string> GetTables()
        {
            //no 1
            List<string> result = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DataTable table = connection.GetSchema("Tables");
                    foreach (DataRow row in table.Rows)
                    {
                        result.Add(row[2].ToString());
                    }
                }
                catch (Exception ex) { return new List<string> { ("Что то не так") }; }
                return result;
            }
        }
        [WebMethod]
        public List<string> GetColumn(string table)
        {
            if (CheckSqlInjection(table) && GetTables().Contains(table))
            {
                List<string> result = new List<string>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Console.WriteLine();
                    var sel = ("SELECT * FROM " + table);
                    SqlCommand command = new SqlCommand(sel, connection);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            result.Add(reader.GetName(i));
                        }
                    }
                    catch (Exception ex) { return new List<string> { ("Что то не так") }; }
                    return result;
                }
            }
            else return new List<string> { ("Что то не так") };
        }
        [WebMethod]
        public List<string> GetVAlues(string tablename, string condition)
        {
            List<string> result = new List<string>();
            if (CheckSqlInjection(tablename) && CheckSqlInjection(condition) && GetTables().Contains(tablename))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //var sel = "select * from Movies as*\/* m where m.Year<'1999-01-01'";
                    var sel = "SELECT * FROM " + tablename + " WHERE " + condition;
                    SqlCommand command = new SqlCommand(sel, connection);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                result.Add(reader[i].ToString());
                            }
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        return new List<string> { ("Что то не так") };
                    }
                    return result;
                }
            }
            else return new List<string> { ("Что то не так") };
        }
        public static bool CheckSqlInjection(string str)
        {
            char semicolon = ';';
            char slash = '\'';
            char hypen = '-';
            bool c = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == semicolon)
                {
                    if (c) { return true; }
                    return false;
                }
                if (str[i] == slash)
                {
                    if (c) { c = false; }
                    else c = true;
                }
                if (i != str.Length-2&&(str[i]==hypen&&str[i+1]==hypen)||(str[i]=='/'&&str[i+1]=='*'))
                {
                    if (c) { return true; }
                    return false;
                }
            }
            return true;
        }
    }
}
