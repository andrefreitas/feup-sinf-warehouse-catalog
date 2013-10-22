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
    public class ArtigosController : ApiController
    {
        //
        // GET: /Artigos/
        // Na pesquisa por id substituir o "." por "!" 


        public IEnumerable<Lib_Primavera.Model.Artigo> Get()
        {
            return Lib_Primavera.Comercial.ListaArtigos();
        }

        public Artigo Get(string id)
        {
            id = id.Replace("!", ".");

            Lib_Primavera.Model.Artigo artigo = Lib_Primavera.Comercial.GetArtigo(id);
            if (artigo == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return artigo;
            }
        }

    }
}
