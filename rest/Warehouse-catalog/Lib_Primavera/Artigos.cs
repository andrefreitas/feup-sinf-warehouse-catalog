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

            if (PriEngine.InitializeCompany(ConfigurationConstants.NAME_COMPANY, ConfigurationConstants.USERNAME, ConfigurationConstants.PASSWORD) == true)
            {

                //objList = PriEngine.Engine.Comercial.Artigos.LstArtigos();

                objList = PriEngine.Engine.Consulta("SELECT ARTIGO.Artigo AS Artigo, ARTIGO.Descricao AS Descricao, PVP1, Iva, FAMILIAS.Descricao AS Familia, STKActual, ANEXOS.Id AS Id, ANEXOS.FicheiroOrig AS FicheiroOrig, ANEXOS.Descricao AS AnexosDesc "
                                                  + "FROM ARTIGO, ARTIGOMOEDA, FAMILIAS, ANEXOS "
                                                  + "WHERE ARTIGO.Artigo = ARTIGOMOEDA.Artigo AND FAMILIAS.Familia = ARTIGO.Familia AND ANEXOS.Chave = ARTIGO.Artigo");

                while (!objList.NoFim())
                {
                    artigo = new Model.Artigo();
                    artigo.CodArtigo = objList.Valor("Artigo");
                    artigo.Descricao = objList.Valor("Descricao");
                    artigo.Preco = objList.Valor("PVP1");
                    artigo.IVA = objList.Valor("Iva");
                    artigo.Familia = objList.Valor("Familia");
                    artigo.StkAtual = objList.Valor("STKActual");
                    artigo.Imagem = objList.Valor("Id") + '.' + objList.Valor("FicheiroOrig").Split('.')[1];
                    artigo.DescricaoImg = objList.Valor("AnexosDesc");

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

            Model.Artigo myArtigo = new Model.Artigo();

            if (PriEngine.InitializeCompany(ConfigurationConstants.NAME_COMPANY, ConfigurationConstants.USERNAME, ConfigurationConstants.PASSWORD) == true)
            {

                if (PriEngine.Engine.Comercial.Artigos.Existe(codArtigo) == true)
                {
                    StdBELista objArtigo = PriEngine.Engine.Consulta("SELECT ARTIGO.Artigo AS Artigo, ARTIGO.Descricao AS Descricao, PVP1, Iva, FAMILIAS.Descricao AS Familia, STKActual, ANEXOS.Id AS Id, ANEXOS.FicheiroOrig AS FicheiroOrig, ANEXOS.Descricao AS AnexosDesc "
                                                  + "FROM ARTIGO, ARTIGOMOEDA, FAMILIAS, ANEXOS "
                                                  + "WHERE ARTIGO.Artigo = '" + codArtigo + "' AND ARTIGO.Artigo = ARTIGOMOEDA.Artigo AND FAMILIAS.Familia = ARTIGO.Familia AND ANEXOS.Chave = ARTIGO.Artigo");

                    myArtigo.CodArtigo = objArtigo.Valor("Artigo");
                    myArtigo.Descricao = objArtigo.Valor("Descricao");
                    myArtigo.Preco = objArtigo.Valor("PVP1");
                    myArtigo.IVA = objArtigo.Valor("Iva");
                    myArtigo.StkAtual = objArtigo.Valor("STKActual");
                    myArtigo.Familia = objArtigo.Valor("Familia");
                    myArtigo.Imagem = objArtigo.Valor("Id") + '.' + objArtigo.Valor("FicheiroOrig").Split('.')[1];
                    myArtigo.DescricaoImg = objArtigo.Valor("AnexosDesc");
             
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