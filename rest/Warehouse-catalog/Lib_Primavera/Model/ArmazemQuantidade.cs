using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Warehouse_catalog.Lib_Primavera.Model
{
    public class ArmazemQuantidade
    {
        public string CodArmazem
        {
            get;
            set;
        }

        public string DescArmazem
        {
            get;
            set;
        }

        public string Localidade
        {
            get;
            set;
        }

        public double StkArmazem
        {
            get;
            set;
        }
    }
}