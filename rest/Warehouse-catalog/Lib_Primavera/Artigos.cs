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
    public class Artigos
    {
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
    }
}