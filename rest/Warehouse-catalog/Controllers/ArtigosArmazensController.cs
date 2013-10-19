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
    public class ArtigosArmazensController : ApiController
    {
        //
        // GET: /ArtigosArmazens/

        public IEnumerable<Lib_Primavera.Model.ArtigoArmazem> Get()
        {
            return Lib_Primavera.Comercial.ListaArtigosArmazens();
        }

        public IEnumerable<Lib_Primavera.Model.ArtigoArmazem> Get(string id)
        {
            return Lib_Primavera.Comercial.GetArtigosPorArmazem(id);
        }

        
    }
}
