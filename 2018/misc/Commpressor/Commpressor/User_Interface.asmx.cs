using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Commpressor
{
    /// <summary>
    /// Сводное описание для User_Interface
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class User_Interface : System.Web.Services.WebService
    {

        [WebMethod]
        public string Commpress(string path, string commpresstype)
        {
            var a = new Brain();
            return a.Compress(path, commpresstype);
        }
        [WebMethod]
        public string Decommpres(string path, string commpresstype)
        {
            var a = new Brain();
            return a.Decompress(path, commpresstype);
        }
        
    }
}
