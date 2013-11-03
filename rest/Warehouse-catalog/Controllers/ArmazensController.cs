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
    public class ArmazensController : ApiController
    {
        //
        // GET: /Armazens/

        public IEnumerable<Lib_Primavera.Model.Armazem> Get()
        {
            return Lib_Primavera.Armazens.ListaArmazens();
        }

        public Armazem Get(string id)
        {
            Lib_Primavera.Model.Armazem armazem = Lib_Primavera.Armazens.GetArmazem(id);
            if (armazem == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return armazem;
            }
        }

    }
}
