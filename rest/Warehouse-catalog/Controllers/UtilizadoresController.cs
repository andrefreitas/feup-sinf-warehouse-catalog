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
        //
        // GET: /Utilizadores/

       public bool Get(string id)
        {
            //Aqui o " delimita o email da password
            //O ! substitui o .

            id = id.Replace('!', '.');
            
            string[] separValue = id.Split('"');

            if (separValue.Length != 2)
                return false;

            string email = separValue[0];
            string password = separValue[1];
            
            return Lib_Primavera.Comercial.LoginUtilizador(email, password);
        }

    }
}
