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
        #region Utilizador

        

        #endregion

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

                objList = PriEngine.Engine.Consulta("SELECT ARTIGO.Artigo, Descricao, PVP1, Iva, Familia, STKActual FROM ARTIGO, ARTIGOMOEDA WHERE ARTIGO.Artigo = ARTIGOMOEDA.Artigo");

                while (!objList.NoFim())
                {
                    string codFamilia = objList.Valor("Familia");

                    if (PriEngine.Engine.Comercial.Familias.Existe(codFamilia) == true)
                    {
                        StdBELista objFamilia = PriEngine.Engine.Consulta("SELECT Descricao FROM Familias WHERE Familia = '" + codFamilia + "'");

                        artigo = new Model.Artigo();
                        artigo.CodArtigo = objList.Valor("Artigo");
                        artigo.Descricao = objList.Valor("Descricao");
                        artigo.Preco = objList.Valor("PVP1");
                        artigo.IVA = objList.Valor("Iva");
                        artigo.Familia = objFamilia.Valor("Descricao");
                        artigo.StkAtual = objList.Valor("STKActual");

                        StdBELista anexosList = PriEngine.Engine.Consulta("SELECT Id, FicheiroOrig, Descricao FROM Anexos WHERE Chave = '" + objList.Valor("Artigo") + "'");

                        if (anexosList.NumLinhas() > 0)
                        {
                            artigo.Imagem = anexosList.Valor("Id") + '.' + anexosList.Valor("FicheiroOrig").Split('.')[1];
                            artigo.DescricaoImg = anexosList.Valor("Descricao");
                        }
                        else
                        {
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

            Model.Artigo myArtigo = new Model.Artigo();

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
            {

                if (PriEngine.Engine.Comercial.Artigos.Existe(codArtigo) == true)
                {
                    StdBELista objArtigo = PriEngine.Engine.Consulta("SELECT ARTIGO.Artigo, Descricao, PVP1, Iva, Familia, STKActual FROM ARTIGO, ARTIGOMOEDA WHERE ARTIGO.Artigo = '" + codArtigo + "' AND ARTIGO.Artigo = ARTIGOMOEDA.Artigo");

                    myArtigo.CodArtigo = objArtigo.Valor("Artigo");
                    myArtigo.Descricao = objArtigo.Valor("Descricao");
                    myArtigo.Preco = objArtigo.Valor("PVP1");
                    myArtigo.IVA = objArtigo.Valor("Iva");
                    myArtigo.StkAtual = objArtigo.Valor("STKActual");

                    string codFamilia = objArtigo.Valor("Familia");
                    if (PriEngine.Engine.Comercial.Familias.Existe(codFamilia) == true)
                    {
                        StdBELista objFamilia = PriEngine.Engine.Consulta("SELECT Descricao FROM Familias WHERE Familia = '" + codFamilia + "'");

                        myArtigo.Familia = objFamilia.Valor("Descricao");
                    }

                    StdBELista anexosList = PriEngine.Engine.Consulta("SELECT Id, FicheiroOrig, Descricao FROM Anexos WHERE Chave = '" + objArtigo.Valor("Artigo") + "'");

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

            List<Model.ArtigoArmazem> listArtigosArmazens = new List<Model.ArtigoArmazem>();

            if (PriEngine.InitializeCompany("BELAFLOR", "admin", "admin") == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT Artigo, Armazem, StkActual FROM ARTIGOARMAZEM WHERE Armazem = '" + codArmazem + "'");

                Model.Armazem armazem = GetArmazem(codArmazem);

                while (!objList.NoFim())
                {
                    Model.ArtigoArmazem artigo_armazem = new Model.ArtigoArmazem();
                    Model.Artigo artigo = GetArtigo(objList.Valor("Artigo"));

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