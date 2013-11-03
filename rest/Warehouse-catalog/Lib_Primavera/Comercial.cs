using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interop.ErpBS800;
using Interop.StdPlatBS800;
using Interop.StdBE800;
using Interop.GcpBE800;
using ADODB;
using Interop.IGcpBS800;

namespace Warehouse_catalog.Lib_Primavera
{
    public class Comercial
    {
       
       
        #region ArtigoArmazem

       


        #endregion ArtigoArmazem

        #region quantidadeArtigoArmazem

        public static List<Model.ArmazemQuantidade> GetQuantidadeArtigoArmazem(string codArtigo)
        {
            ErpBS objMotor = new ErpBS();
            StdBELista objList;

            List<Model.ArmazemQuantidade> listQtArmazens = new List<Model.ArmazemQuantidade>();

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT ARMAZENS.Armazem, ARMAZENS.Descricao, ARMAZENS.Localidade, ARTIGOARMAZEM.StkActual FROM ARTIGOARMAZEM, ARMAZENS WHERE ARTIGOARMAZEM.Artigo = '" + codArtigo + "' AND ARMAZENS.Armazem = ARTIGOARMAZEM.Armazem");

                while (!objList.NoFim())
                {
                    Model.ArmazemQuantidade arm_quant = new Model.ArmazemQuantidade();

                    arm_quant.CodArmazem = objList.Valor("Armazem");
                    arm_quant.DescArmazem = objList.Valor("Descricao");
                    arm_quant.Localidade = objList.Valor("Localidade");
                    arm_quant.StkArmazem = objList.Valor("StkActual");

                    listQtArmazens.Add(arm_quant);

                    objList.Seguinte();
                }

                return listQtArmazens;
            }
            else
                return null;
        }

        #endregion quantidadeArtigoArmazem
    }
}