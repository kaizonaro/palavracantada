﻿using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais.administracao
{
    public partial class banners : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsRedes, rsGravaBanner;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            try
            {
                switch (Request["acao"])
                {
                    case ("excluirBanner"):

                        objBD.ExecutaSQL("update Banner set BAN_ATIVO = 0 where BAN_ID ='" + Request["BAN_ID"] + "'");

                        break;
                    case ("restoreBanner"):
                        objBD.ExecutaSQL("update Banner set BAN_ATIVO = 1 where BAN_ID ='" + Request["BAN_ID"] + "'");

                        break;
                    case ("editarBanner"):
                        rsLista = objBD.ExecutaSQL("select RED_ID, BAN_ID, BAN_LEGENDA, BAN_LINK from  Banner where BAN_ID ='" + Request["BAN_ID"] + "'");
                        if (rsLista == null)
                        {
                            throw new Exception();
                        }
                        if (rsLista.HasRows)
                        {
                            rsLista.Read();
                            Response.Write(rsLista["RED_ID"] + "|" + rsLista["BAN_ID"] + "|" + rsLista["BAN_LEGENDA"] + "|" + rsLista["BAN_LINK"]);
                        }
                        break;
                    default:
                        PopulaLista();
                        PopulaExcluidos();
                        ListarRedes();
                        break;
                }
            }
            catch (Exception)
            {
                Response.Redirect("erro.aspx");
                throw;
            }
        }

        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psBannerPorAtivo 1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:8px;\">ID</th>";
                divLista.InnerHtml += "         <th style=\"width:300px;\">Imagem</th>";
                divLista.InnerHtml += "         <th>Legenda</th>";
                divLista.InnerHtml += "         <th>Rede</th>";
                divLista.InnerHtml += "         <th>Link</th>";
                divLista.InnerHtml += "         <th style=\"width:71px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody>";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["BAN_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["BAN_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><img src=\"/upload/imagens/banners/" + rsLista["BAN_IMAGEM"].ToString() + "\" style=\"width:300px;height:100px\" /></td>";
                    divLista.InnerHtml += "     <td>" + rsLista["BAN_LEGENDA"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["BAN_LINK"].ToString().Replace("javascript:void(0)", "-") + "</td>";

                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0)\" id='" + rsLista["BAN_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["BAN_ID"].ToString() + "' onclick='excluirBanner(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
                    divLista.InnerHtml += " </tr>";
                }

                divLista.InnerHtml += " </tbody>";
            }

            else
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th>Nenhum registro cadastrado até o momento!</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";
            }
            rsLista.Close();
            rsLista.Dispose();

            divLista.InnerHtml += "</table>";
        }
     
        public void PopulaExcluidos()
        {
            divExcluidos.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psBannerPorAtivo 0");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th style=\"width:8px;\">ID</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:300px;\">Imagem</th>";
                divExcluidos.InnerHtml += "         <th>Legenda</th>";
                divExcluidos.InnerHtml += "         <th>Rede</th>";
                divExcluidos.InnerHtml += "         <th>Link</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:71px;\">Ações</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";

                divExcluidos.InnerHtml += " <tbody>";

                while (rsLista.Read())
                {
                    divExcluidos.InnerHtml += " <tr id='tr_" + rsLista["BAN_ID"].ToString() + "' class=\"\">";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["BAN_ID"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><img src=\"/upload/imagens/banners/" + rsLista["BAN_IMAGEM"].ToString() + "\" style=\"width:300px;height:100px\" /></td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["BAN_LEGENDA"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["BAN_LINK"].ToString().Replace("javascript:void(0)", "-") + "</td>";

                    divExcluidos.InnerHtml += "     <td><a href=\"javascript:void(0)\" id='" + rsLista["BAN_ID"].ToString() + "' onclick='restoreBanner(this.id);' class=\"img_del\"><img src=\"images/restore.png\"></a>";
                    divExcluidos.InnerHtml += " </tr>";
                }

                divExcluidos.InnerHtml += " </tbody>";
            }

            else
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th>Nenhum registro cadastrado até o momento!</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";
            }
            rsLista.Close();
            rsLista.Dispose();

            divExcluidos.InnerHtml += "</table>";
        }

        public void ListarRedes()
        {
            rsRedes = objBD.ExecutaSQL("EXEC ADMIN_psRedesPorAtivo 1");
            if (rsRedes == null)
            {
                throw new Exception();
            }
            if (rsRedes.HasRows)
            {

                while (rsRedes.Read())
                {
                    ListItem C = new ListItem();
                    C.Value = rsRedes["RED_ID"].ToString();
                    C.Text = rsRedes["RED_TITULO"].ToString();
                    RED_ID.Items.Add(C);


                }

            }
            rsRedes.Close();
            rsRedes.Dispose();
        }

        public void gravarBanner(object sender, EventArgs e)
        {
            try
            {
                if (BAN_IMAGEM.HasFile)
                {
                    string arquivo = BAN_IMAGEM.FileName.Replace(" ", "_");

                    BAN_IMAGEM.SaveAs(Server.MapPath("~/upload/imagens/banners") + "/" + arquivo);
                    string link = Request["BAN_LINK"];
                    if (link == null || link == "")
                    {
                        link = "javascript:void(0)";
                    }

                    rsGravaBanner = objBD.ExecutaSQL("EXEC admin_piuBanner " + Request["BAN_ID"] + ", " + Request["RED_ID"] + ", '" + Request["BAN_LEGENDA"] + "','" + arquivo + "', '" + link + "'");
                    if (rsGravaBanner == null)
                    {
                        throw new Exception();
                    }

                    //Libera o BD e Memória
                    rsGravaBanner.Close();
                    rsGravaBanner.Dispose();

                    //Retornar para a Listagem
                    Response.Redirect("fotos.aspx");
                    Response.End();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}