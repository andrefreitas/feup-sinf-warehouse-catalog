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
        #region Armazem

        public static List<Model.Armazem> ListaArmazens()
        {
            ErpBS objMotor = new ErpBS();
            StdBELista objList;

            Model.Armazem armazem = new Model.Armazem();
            List<Model.Armazem> listArmazens = new List<Model.Armazem>();

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
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
                    armazem.Distrito = objList.Valor("Distrito");
                    armazem.Pais = objList.Valor("Pais");

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
            GcpBEArmazem objArmazem = new GcpBEArmazem();


            Model.Armazem myArmazem = new Model.Armazem();

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
            {

                if (PriEngine.Engine.Comercial.Armazens.Existe(codArmazem) == true)
                {
                    objArmazem = PriEngine.Engine.Comercial.Armazens.Edita(codArmazem);
                    myArmazem.CodArmazem = objArmazem.get_Armazem();
                    myArmazem.Descricao = objArmazem.get_Descricao();
                    myArmazem.Morada = objArmazem.get_Morada();
                    myArmazem.Localidade = objArmazem.get_Localidade();
                    myArmazem.CodPostal = objArmazem.get_CodigoPostal();
                    myArmazem.CodPostalLocalidade = objArmazem.get_LocalidadeCodigoPostal();
                    myArmazem.Telefone = objArmazem.get_Telefone();
                    myArmazem.Fax = objArmazem.get_Fax();
                    myArmazem.Distrito = objArmazem.get_Distrito();
                    myArmazem.Pais = objArmazem.get_Pais();
                    return myArmazem;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        #endregion Armazem

        #region Artigo

        public static List<Model.Artigo> ListaArtigos()
        {
            ErpBS objMotor = new ErpBS();
            StdBELista objList;

            Model.Artigo artigo = new Model.Artigo();
            List<Model.Artigo> listArtigos = new List<Model.Artigo>();

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
            {

                //objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();

                objList = PriEngine.Engine.Consulta("SELECT Artigo, Descricao, PCMedio, Iva, Familia FROM  ARTIGO");

                while (!objList.NoFim())
                {
                    artigo = new Model.Artigo();
                    artigo.CodArtigo = objList.Valor("Artigo");
                    artigo.Descricao = objList.Valor("Descricao");
                    artigo.Preco = objList.Valor("PCMedio");
                    artigo.IVA = objList.Valor("Iva");
                    artigo.Familia = objList.Valor("Familia");

                    listArtigos.Add(artigo);
                    objList.Seguinte();
                }

                return listArtigos;
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.Artigo GetArtigo(string codArtigo)
        {
            ErpBS objMotor = new ErpBS();
            GcpBEArtigo objArtigo = new GcpBEArtigo();

          //  Console.Write("OLA");

            Model.Artigo myArtigo = new Model.Artigo();

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
            {
                
                if (PriEngine.Engine.Comercial.Artigos.Existe(codArtigo) == true)
                {
                    objArtigo = PriEngine.Engine.Comercial.Artigos.Edita(codArtigo);
                    myArtigo.CodArtigo = objArtigo.get_Artigo();
                    myArtigo.Descricao = objArtigo.get_Descricao();
                    myArtigo.Preco = objArtigo.get_PCMedio();
                    myArtigo.IVA = objArtigo.get_IVA();
                    myArtigo.Familia = objArtigo.get_Familia();
                    
                    return myArtigo;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }


        #endregion Artigo
    }
}