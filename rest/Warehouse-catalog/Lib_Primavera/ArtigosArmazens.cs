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
    public class ArtigosArmazens
    {
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

                    artigo = Artigos.GetArtigo(objList.Valor("Artigo"));
                    armazem = Armazens.GetArmazem(objList.Valor("Armazem"));


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

                Model.Armazem armazem = Armazens.GetArmazem(codArmazem);

                while (!objList.NoFim())
                {
                    Model.ArtigoArmazem artigo_armazem = new Model.ArtigoArmazem();
                    Model.Artigo artigo = Artigos.GetArtigo(objList.Valor("Artigo"));

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
    }
}