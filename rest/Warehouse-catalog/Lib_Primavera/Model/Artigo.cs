using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_catalog.Lib_Primavera.Model
{
    public class Artigo
    {
        public string CodArtigo
        {
            get;
            set;
        }

        public string Descricao
        {
            get;
            set;
        }

        public double Preco
        {
            get;
            set;
        }

        public string IVA
        {
            get;
            set;
        }

        public string Familia
        {
            get;
            set;
        }

        public string Imagem
        {
            get;
            set;
        }

        public double StkAtual
        {
            get;
            set;
        }

        public string DescricaoImg
        {
            get;
            set;
        }
    }
}