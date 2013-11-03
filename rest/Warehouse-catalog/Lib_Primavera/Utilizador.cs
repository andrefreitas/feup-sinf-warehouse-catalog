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
    public class Utilizador
    {
        public static bool LoginUtilizador(string email, string password)
        {
            ErpBS objMotor = new ErpBS();
            StdBELista objList;

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT CDU_Password FROM Clientes WHERE CDU_Email = '" + email + "'");

                if (!objList.Vazia())
                {
                    string bd_password = objList.Valor("CDU_Password");

                    if (bd_password.Equals(Lib_Primavera.PriEngine.Platform.Criptografia.Encripta(password, 30)))
                        return true;

                    return false;
                }


            }

            return false;
        }

        public static string MostraPassword(string email)
        {
            ErpBS objMotor = new ErpBS();
            StdBELista objList;

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT CDU_Password FROM Clientes WHERE CDU_Email = '" + email + "'");

                if (!objList.Vazia())
                {
                    return Lib_Primavera.PriEngine.Platform.Criptografia.Encripta(objList.Valor("CDU_Password"), 30);
                }


            }

            return null;
        }
    }
}