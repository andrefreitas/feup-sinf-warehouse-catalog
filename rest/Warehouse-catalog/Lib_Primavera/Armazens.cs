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
    public class Armazens
    {
        public static List<Model.Armazem> ListaArmazens()
        {
            ErpBS objMotor = new ErpBS();
            StdBELista objList;

            Model.Armazem armazem = new Model.Armazem();
            List<Model.Armazem> listArmazens = new List<Model.Armazem>();

            if (PriEngine.InitializeCompany(ConfigurationConstants.NAME_COMPANY, ConfigurationConstants.USERNAME, ConfigurationConstants.PASSWORD) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = PriEngine.Engine.Consulta("SELECT Armazem, Descricao, Morada, Localidade, Cp, CpLocalidade, Telefone, Fax, Distrito, Pais FROM  ARMAZENS");

                while (!objList.NoFim())
                {
                    armazem = new Model.Armazem();
                    armazem.CodArmazem = objList.Valor("Armazem");
                    armazem.Descricao = objList.Valor("Descricao");
                    armazem.Morada = objList.Valor("Morada");
                    armazem.Localidade = objList.Valor("Localidade");
                    armazem.CodPostal = objList.Valor("Cp");
                    armazem.CodPostalLocalidade = objList.Valor("CpLocalidade");
                    armazem.Telefone = objList.Valor("Telefone");
                    armazem.Fax = objList.Valor("Fax");
                    armazem.Pais = objList.Valor("Pais");

                    string codDistr = objList.Valor("Distrito");

                    StdBELista lstDistr = PriEngine.Engine.Consulta("SELECT Descricao FROM Distritos WHERE Distrito = '" + codDistr + "'");

                    if (lstDistr.NumLinhas() > 0)
                    {
                        armazem.Distrito = lstDistr.Valor("Descricao");
                    }

                    else
                    {
                        armazem.Distrito = null;
                    }

                    listArmazens.Add(armazem);
                    objList.Seguinte();
                }

                return listArmazens;
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.Armazem GetArmazem(string codArmazem)
        {
            ErpBS objMotor = new ErpBS();


            Model.Armazem myArmazem = new Model.Armazem();
            StdBELista objList;

            if (PriEngine.InitializeCompany(ConfigurationConstants.NAME_COMPANY, ConfigurationConstants.USERNAME, ConfigurationConstants.PASSWORD) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT Armazem, Descricao, Morada, Localidade, Cp, CpLocalidade, Telefone, Fax, Distrito, Pais FROM ARMAZENS WHERE Armazem = '" + codArmazem + "'");

                myArmazem.CodArmazem = objList.Valor("Armazem");
                myArmazem.Descricao = objList.Valor("Descricao");
                myArmazem.Morada = objList.Valor("Morada");
                myArmazem.Localidade = objList.Valor("Localidade");
                myArmazem.CodPostal = objList.Valor("Cp");
                myArmazem.CodPostalLocalidade = objList.Valor("CpLocalidade");
                myArmazem.Telefone = objList.Valor("Telefone");
                myArmazem.Fax = objList.Valor("Fax");
                myArmazem.Distrito = objList.Valor("Distrito");
                myArmazem.Pais = objList.Valor("Pais");
                return myArmazem;


            }
            else
                return null;
        }
    }
}