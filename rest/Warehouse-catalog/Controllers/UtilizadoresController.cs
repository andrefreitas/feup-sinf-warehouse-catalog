using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Warehouse_catalog.Lib_Primavera.Model;


namespace Warehouse_catalog.Controllers
{
    public class UtilizadoresController : ApiController
    {

        public class UtilizadorData
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        public class StatusAnswer
        {
            public string status { get; set; }
        }
        
        //
        // GET: /Utilizadores/

        public StatusAnswer Get(string id)
        {
            //O ! substitui o .

            string temp = id.Replace('!', '.');

            string[] args = temp.Split('=');
            StatusAnswer toReturn = new StatusAnswer();

            if (args.Length == 2)
            {
                string key = args[1];

                if (key.Equals("BqdNvUKuFTo82lTdQeRuJ1crEvg4ZYt1"))
                {
                    string password = Lib_Primavera.Utilizadores.ObterPasswordOriginal(args[0]);

                    if (password == null)
                        toReturn.status = "error";

                    else toReturn.status = password;
                }

                else toReturn.status = "error";
            }

            else toReturn.status = "error";

            return toReturn;
        }

        // POST /Utilizadores/
        public StatusAnswer Post(UtilizadorData id)
        {
           // json : { "email" : "abc@abc.pt" , "password": "123456" }

            StatusAnswer toReturn = new StatusAnswer();

            string username = Lib_Primavera.Utilizadores.LoginUtilizador(id.email, id.password);

            if (username != null)
            {
                toReturn.status = username;
            }

            else
            {
                toReturn.status = "error";
            }
            
            return toReturn;
        }

    }
}
