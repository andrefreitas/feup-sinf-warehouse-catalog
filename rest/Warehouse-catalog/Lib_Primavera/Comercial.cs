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

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
            {

                    objList = PriEngine.Engine.Consulta("SELECT Armazem, Descricao, Morada, Localidade, Cp, CpLocalidade, Telefone, Fax, Distrito, Pais FROM  ARMAZENS WHERE Armazem = '" + codArmazem + "'");
                    
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

        #endregion Armazem

        #region Artigo

        public static List<Model.Artigo> ListaArtigos()
        {
            ErpBS objMotor = new ErpBS();
            StdBELista objList;

            Model.Artigo artigo = new Model.Artigo();
            List<Model.Artigo> listArtigos = new List<Model.Artigo>();
            GcpBEFamilia objFamilia = new GcpBEFamilia();

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
            {

                //objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();

                objList = PriEngine.Engine.Consulta("SELECT Artigo, Descricao, PCMedio, Iva, Familia, STKActual FROM  ARTIGO");
                
                while (!objList.NoFim())
                {
                    string codFamilia = objList.Valor("Familia");

                    if (PriEngine.Engine.Comercial.Familias.Existe(codFamilia) == true)
                    {

                        objFamilia = PriEngine.Engine.Comercial.Familias.Edita(codFamilia);
                        artigo = new Model.Artigo();
                        artigo.CodArtigo = objList.Valor("Artigo");
                        artigo.Descricao = objList.Valor("Descricao");
                        artigo.Preco = objList.Valor("PCMedio");
                        artigo.IVA = objList.Valor("Iva");
                        artigo.Familia = objFamilia.get_Descricao();
                        artigo.StkAtual = objList.Valor("STKActual");

                        StdBELista anexosList = PriEngine.Engine.Consulta("SELECT Id, FicheiroOrig, Descricao FROM Anexos WHERE Chave = '" + objList.Valor("Artigo") + "'");

                        if (anexosList.NumLinhas() > 0)
                        {
                            artigo.Imagem = anexosList.Valor("Id") + '.' + anexosList.Valor("FicheiroOrig").Split('.')[1];
                            artigo.DescricaoImg = anexosList.Valor("Descricao");
                        }
                        else {
                            artigo.Imagem = null;
                            artigo.DescricaoImg = "Sem imagem";
                        }

                        listArtigos.Add(artigo);
                        objList.Seguinte();

                    }
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

            Model.Artigo myArtigo = new Model.Artigo();
            GcpBEFamilia objFamilia = new GcpBEFamilia();

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
            {
                
                if (PriEngine.Engine.Comercial.Artigos.Existe(codArtigo) == true)
                {

                    objArtigo = PriEngine.Engine.Comercial.Artigos.Edita(codArtigo);
                    myArtigo.CodArtigo = objArtigo.get_Artigo();
                    myArtigo.Descricao = objArtigo.get_Descricao();
                    myArtigo.Preco = objArtigo.get_PCMedio();
                    myArtigo.IVA = objArtigo.get_IVA();
                    myArtigo.StkAtual = objArtigo.get_StkActual();

                    string codFamilia = objArtigo.get_Familia();
                    if (PriEngine.Engine.Comercial.Familias.Existe(codFamilia) == true)
                    {
                        objFamilia = PriEngine.Engine.Comercial.Familias.Edita(codFamilia);
                        myArtigo.Familia = objFamilia.get_Descricao();
                    }

                    StdBELista anexosList = PriEngine.Engine.Consulta("SELECT Id, FicheiroOrig, Descricao FROM Anexos WHERE Chave = '" + objArtigo.get_Artigo() + "'");

                    if (anexosList.NumLinhas() > 0)
                    {
                        myArtigo.Imagem = anexosList.Valor("Id") + '.' + anexosList.Valor("FicheiroOrig").Split('.')[1];
                        myArtigo.DescricaoImg = anexosList.Valor("Descricao");
                    }
                    else
                    {
                        myArtigo.Imagem = null;
                        myArtigo.DescricaoImg = "Sem imagem";
                    }
                    
                    
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

        #region ArtigoArmazem

        public static List<Model.ArtigoArmazem> ListaArtigosArmazens()
        {
            ErpBS objMotor = new ErpBS();
            StdBELista objList;

            Model.ArtigoArmazem artigo_armazem = new Model.ArtigoArmazem();
            List<Model.ArtigoArmazem> listArtigosArmazens = new List<Model.ArtigoArmazem>();

            Model.Armazem armazem;
            Model.Artigo artigo;

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
            {

                //objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();

                objList = PriEngine.Engine.Consulta("SELECT Artigo, Armazem, StkActual FROM  ARTIGOARMAZEM");

                while (!objList.NoFim())
                {
                    artigo_armazem = new Model.ArtigoArmazem();

                    artigo = GetArtigo(objList.Valor("Artigo"));
                    armazem = GetArmazem(objList.Valor("Armazem"));
                    
                    
                    artigo_armazem.CodArtigo = artigo.CodArtigo;
                    artigo_armazem.DescArtigo = artigo.Descricao;
                    artigo_armazem.Preco = artigo.Preco;
                    artigo_armazem.IVA = artigo.IVA;
                    artigo_armazem.Familia = artigo.Familia;
                    artigo_armazem.Imagem = artigo.Imagem;
                    artigo_armazem.StkAtual = artigo.StkAtual;
                    artigo_armazem.DescricaoImg = artigo.DescricaoImg;

                    artigo_armazem.CodArmazem = armazem.CodArmazem;
                    artigo_armazem.DescArmazem = armazem.Descricao;
                    artigo_armazem.Morada = armazem.Morada;
                    artigo_armazem.Localidade = armazem.Localidade;
                    artigo_armazem.CodPostal = armazem.CodPostal;
                    artigo_armazem.CodPostalLocalidade = armazem.CodPostalLocalidade;
                    artigo_armazem.Telefone = armazem.Telefone;
                    artigo_armazem.Fax = armazem.Fax;
                    artigo_armazem.Distrito = armazem.Distrito;
                    artigo_armazem.Pais = armazem.Pais;
 
                    artigo_armazem.StkArmazem = objList.Valor("StkActual");

                    listArtigosArmazens.Add(artigo_armazem);
                    objList.Seguinte();
                }

                return listArtigosArmazens;
            }
            else
                return null;
        }

        public static List<Model.ArtigoArmazem> GetArtigosPorArmazem(string codArmazem)
        {
            ErpBS objMotor = new ErpBS();
            StdBELista objList;

            Model.ArtigoArmazem artigo_armazem = new Model.ArtigoArmazem();
            List<Model.ArtigoArmazem> listArtigosArmazens = new List<Model.ArtigoArmazem>();

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
            {

                //objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();

                objList = PriEngine.Engine.Consulta("SELECT Artigo, Armazem, Lote, StkActual FROM  ARTIGOARMAZEM WHERE Armazem = '" + codArmazem + "'");

                while (!objList.NoFim())
                {
                    artigo_armazem = new Model.ArtigoArmazem();
                    //artigo_armazem.Artigo = objList.Valor("Artigo");
                    //artigo_armazem.Armazem = objList.Valor("Armazem");
                    //artigo_armazem.Lote = objList.Valor("Lote");
                    //artigo_armazem.StockAtual = objList.Valor("StkActual");

                    listArtigosArmazens.Add(artigo_armazem);
                    objList.Seguinte();
                }

                return listArtigosArmazens;
            }
            else
                return null;
        }

        
        #endregion ArtigoArmazem
    }
}