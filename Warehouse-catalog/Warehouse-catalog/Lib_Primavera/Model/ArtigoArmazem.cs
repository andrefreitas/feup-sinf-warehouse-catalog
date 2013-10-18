using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_catalog.Lib_Primavera.Model
{
    public class ArtigoArmazem
    {
        public string Artigo
        {
            get;
            set;
        }

        public string Armazem
        {
            get;
            set;
        }

        public string Lote
        {
            get;
            set;
        }

        public double StockAtual
        {
            get;
            set;
        }
    }
}