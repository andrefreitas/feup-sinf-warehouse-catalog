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
    public class QuantidadeArtigoArmazensController : ApiController
    {
        //
        // GET: /Armazens/

        public IEnumerable<Lib_Primavera.Model.ArmazemQuantidade> Get()
        {
            return null;
        }

        public IEnumerable<Lib_Primavera.Model.ArmazemQuantidade> Get(string id)
        {
            // ! substitui .

            id = id.Replace('!', '.');
            
            return Lib_Primavera.Comercial.GetQuantidadeArtigoArmazem(id);
        }

    }
}
