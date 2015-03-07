using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Etnia.classe;
using System.Data.OleDb;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace BrincaderiasMusicais.administracao
{
    public partial class videos : System.Web.UI.Page
    {

        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsRede, rsGravar;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {
                case("gravarVideo"):
                    gravarVideo();
                    break;

                case ("excluirVideo"):
                    excluirVideo();
                    break;

                case("ativarVideo"):
                    ativarVideo();
                    break;

                default:
                    PopulaLista();
                    PopulaListaExcluidos();
                   // PopularRedes();
                    break;
            }
        }

        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psGaleriaVideosPorAtivo 1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:60px;\">ID</th>";
                divLista.InnerHtml += "         <th style=\"width:160px;\">Thumb</th>";
                divLista.InnerHtml += "         <th>Título</th>";
                divLista.InnerHtml += "         <th>Rede</th>";
                divLista.InnerHtml += "         <th style=\"width:175px;\">Data Publicação</th>";
                divLista.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["GVI_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["GVI_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><img width='150px' src=" + rsLista["GVI_IMAGEM"].ToString() + "></td>";
                    divLista.InnerHtml += "     <td>" + rsLista["GVI_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["GVI_DH_PUBLICACAO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["GVI_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["GVI_ID"].ToString() + "' onclick='excluirVideo(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

        public void PopulaListaExcluidos()
        {
            divExcluidos.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psGaleriaVideosPorAtivo 0");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th style=\"width:60px;\">ID</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:160px;\">Thumb</th>";
                divExcluidos.InnerHtml += "         <th>Título</th>";
                divExcluidos.InnerHtml += "         <th>Rede</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:175px;\">Data Publicação</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";

                divExcluidos.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divExcluidos.InnerHtml += " <tr id='tr_" + rsLista["GVI_ID"].ToString() + "' class=\"\">";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["GVI_ID"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><img width='150px' src=" + rsLista["GVI_IMAGEM"].ToString() + "></td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["GVI_TITULO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["GVI_DH_PUBLICACAO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><a href=\"javascript:void(0)\" id='" + rsLista["GVI_ID"].ToString() + "' onclick='restoreVideo(this.id);' class=\"img_del\"><img src=\"images/restore.png\"></a>";
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

        public void PopularRedes()
        {
            rsRede = objBD.ExecutaSQL("EXEC admin_psRedesPorAtivo 1");
            if (rsRede == null)
            {
                throw new Exception();
            }
            if (rsRede.HasRows)
            {
                while (rsRede.Read())
                {
                    System.Web.UI.WebControls.ListItem R = new System.Web.UI.WebControls.ListItem();
                    R.Value = rsRede["RED_ID"].ToString();
                    R.Text = rsRede["RED_CIDADE"].ToString() + " | " + rsRede["RED_UF"].ToString();
                    RED_ID.Items.Add(R);
                }
            }
            rsRede.Close();
            rsRede.Dispose();
        }

        public void gravarVideo()
        {
            try
            {
                rsGravar = objBD.ExecutaSQL("EXEC admin_piuGaleriaVideos '" + Request["GVI_ID"] + "',null, '" + Request["GVI_TITULO"] + "','" + Request["GVI_LINK"].Replace("http://youtu.be/", "").Replace("https://www.youtube.com/watch?v=", "") + "','" + Request["GVI_LINK"].Replace("http://youtu.be/", "http://i.ytimg.com/vi/").Replace("https://www.youtube.com/watch?v=", "http://i.ytimg.com/vi/") + "/mqdefault.jpg'");

                if (rsGravar == null)
                {
                    throw new Exception();
                }

                if (rsGravar.HasRows)
                {
                    rsGravar.Read();
                }

                //Libera o BD e Memória
                rsGravar.Close();
                rsGravar.Dispose();

                //Retornar para a Listagem
                Response.Redirect("videos.aspx");
                Response.End();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void excluirVideo()
        {
            objBD.ExecutaSQL("update GaleriaVideos set GVI_ATIVO = 0 where GVI_ID ='" + Request["GVI_ID"] + "'");
            PopulaLista();
            PopulaListaExcluidos();
        }

        public void ativarVideo()
        {
            objBD.ExecutaSQL("update GaleriaVideos set GVI_ATIVO = 1 where GVI_ID ='" + Request["GVI_ID"] + "'");
            PopulaLista();
            PopulaListaExcluidos();
        }
    }
}