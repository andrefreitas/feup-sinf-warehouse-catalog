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
    public class Utilizadores
    {
        public static string LoginUtilizador(string email, string password)
        {
            ErpBS objMotor = new ErpBS();
            StdBELista objList;

            if (PriEngine.InitializeCompany(ConfigurationConstants.NAME_COMPANY, ConfigurationConstants.USERNAME, ConfigurationConstants.PASSWORD) == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT Nome, CDU_Password FROM Clientes WHERE CDU_Email = '" + email + "'");

                if (!objList.Vazia())
                {
                    string bd_password = objList.Valor("CDU_Password");
                    string bd_nome = objList.Valor("Nome");

                    if (bd_password.Equals(Lib_Primavera.PriEngine.Platform.Criptografia.Encripta(password, 30)))
                        return bd_nome;

                    return null;
                }


            }

            return null;
        }

        public static string MostraPassword(string email)
        {
            ErpBS objMotor = new ErpBS();
            StdBELista objList;

            if (PriEngine.InitializeCompany(ConfigurationConstants.NAME_COMPANY, ConfigurationConstants.USERNAME, ConfigurationConstants.PASSWORD) == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT CDU_Password FROM Clientes WHERE CDU_Email = '" + email + "'");

                if (!objList.Vazia())
                {
                    return Lib_Primavera.PriEngine.Platform.Criptografia.Encripta(objList.Valor("CDU_Password"), 30);
                }


            }

            return null;
        }

        public static string ObterPasswordOriginal(string email)
        {
            ErpBS objMotor = new ErpBS();
            StdBELista objList;

            if (PriEngine.InitializeCompany(ConfigurationConstants.NAME_COMPANY, ConfigurationConstants.USERNAME, ConfigurationConstants.PASSWORD) == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT CDU_Password FROM Clientes WHERE CDU_Email = '" + email + "'");

                if (!objList.Vazia())
                {
                    return Lib_Primavera.PriEngine.Platform.Criptografia.Descripta(objList.Valor("CDU_Password"), 30);
                }


            }

            return null;
        }
    }
}