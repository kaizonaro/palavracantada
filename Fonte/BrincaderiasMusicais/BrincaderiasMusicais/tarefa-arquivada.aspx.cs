using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais
{
    public partial class tarefa_arquivada : System.Web.UI.Page
    {
        utils objUtils = new utils();
        bd objBD = new bd();
        OleDbDataReader rsListar;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            //Verificar se ainda está logado
            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
            {
                switch (Request["acao"])
                {
                    case ("comentarTarefa"):
                        objBD.ExecutaSQL("exec Site_piComentario '" + Request["idCDO"] + "',null,'" + Session["usuID"] + "',null,'" + Request["comentarioTarefa"] + "'");
                        Response.Redirect("/tarefa-arquivada/" + Request["idCDO"] +"?alert=Comentário enviado com sucesso!");
                        break;

                    case ("comentarRelato"):

                        // Response.Write("exec Site_piComentario null,'" + Request["idREL"] + "','" + Session["usuID"] + "',null,'" + Request["comentarioRelato"] + "'");
                        //  Response.End();

                        objBD.ExecutaSQL("exec Site_piComentario null,'" + Request["idREL"] + "','" + Session["usuID"] + "',null,'" + Request["comentarioRelato"] + "'");
                        Response.Redirect("/tarefa-arquivada/" + Request["idCDO1"] +"?alert=Comentário enviado com sucesso!");
                        break;

                    default:
                        PopulaTela();
                        Relatos();
                        break;
                }

            }
            else
            {
                //DESLOGADO
                Response.Redirect("/");
            }
        }


        public void PopulaTela()
        {
            rsListar = objBD.ExecutaSQL("EXEC site_psCriacaoDocumentadasPorID '" + Request["CDO_ID"] + "' ");

            if (rsListar == null)
            {
                throw new Exception();
            }
            if (rsListar.HasRows)
            {
                rsListar.Read();

                titu_criacoes.InnerHtml = objUtils.RemoveHTML(rsListar["CDO_TAREFA"].ToString());
                criador.InnerHtml = rsListar["ADM_NOME"].ToString();
                data.InnerHtml = rsListar["CDO_DATA"].ToString();
                box_descritivo.InnerHtml = rsListar["CDO_DESCRITIVO"].ToString();
                divDevolutiva.InnerHtml = rsListar["CDO_DEVOLUTIVA"].ToString();
                if (!string.IsNullOrWhiteSpace(rsListar["CDO_VIDEO"].ToString()))
                {
                    video_criacoes.Attributes.Add("src", "https://www.youtube.com/embed/" + rsListar["CDO_VIDEO"].ToString());
                }
                else
                {
                    titulovideo.Visible = false;
                    video_criacoes.Visible = false;
                }
                if (!string.IsNullOrWhiteSpace(rsListar["CDO_VIDEO_DEVOLUTIVA"].ToString()))
                {
                    video_devolutiva.Attributes.Add("src", "https://www.youtube.com/embed/" + rsListar["CDO_VIDEO_DEVOLUTIVA"].ToString());
                }
                else
                {
                    titulovideodevolutiva.Visible = false;
                    video_criacoesdevolutiva.Visible = false;
                }


                idCDO.Attributes.Add("value", Request["CDO_ID"].ToString());
                idCDO1.Attributes.Add("value", Request["CDO_ID"].ToString());

                relato_detalhe.InnerHtml = "<strong>" + rsListar["TOTAL_RELATOS"].ToString() + " Relatos Enviados</strong>";

                totalComentarios.InnerHtml = "<a href='javascript:void(0)' onClick='verComentarios2(1," + Request["CDO_ID"] + ");'> " + rsListar["TOTAL_COMENTARIOS"].ToString() + " Comentário";

                if (Convert.ToInt16(rsListar["TOTAL_COMENTARIOS"]) > 1)
                {
                    totalComentarios.InnerHtml += "s";
                }
                totalComentarios.InnerHtml += "</a>";

            }
            else
            {
                Response.Redirect("/criacoes-documentadas");
            }

            rsListar.Close();
            rsListar.Dispose();
        }

        public void Relatos()
        {
            rsListar = objBD.ExecutaSQL("EXEC site_psCriacoes_Documentadas_RelatosPorID '" + Request["CDO_ID"] + "'");

            if (rsListar == null)
            {
                throw new Exception();
            }
            if (rsListar.HasRows)
            {
                ulRelatos.InnerHtml = "";
                while (rsListar.Read())
                {
                    ulRelatos.InnerHtml += " <li>";
                    ulRelatos.InnerHtml += "    <div class=\"box_criacoes\">" + rsListar["CDR_RELATO"] + "</div>";
                    ulRelatos.InnerHtml += "    <div class=\"sub_criacoes\">";
                    ulRelatos.InnerHtml += "        <div class=\"left\">";
                    ulRelatos.InnerHtml += "            <div class=\"detalhes_autor\">";
                    ulRelatos.InnerHtml += "                <span class=\"comentario_detalhe\">Relato enviado por: <br /><strong>" + rsListar["USU_NOME"] + "</strong></span><br>";
                    ulRelatos.InnerHtml += "                <span class=\"comentario_detalhe\">Data: <strong>" + rsListar["CDR_DATA"] + "</strong></span><br>";
                    if (Convert.ToInt16(rsListar["TOTAL_COMENTARIOS"]) < 1)
                    {
                        ulRelatos.InnerHtml += "                <span class=\"comentario_detalhe\">Este relato possui: <strong>" + rsListar["TOTAL_COMENTARIOS"] + " comentario</strong></span><br>";
                    }
                    else
                    {
                        ulRelatos.InnerHtml += "                <span class=\"comentario_detalhe\">Este relato possui: <strong>" + rsListar["TOTAL_COMENTARIOS"] + " comentarios</strong></span><br>";
                    }
                    ulRelatos.InnerHtml += "            </div>";
                    ulRelatos.InnerHtml += "            <a href=\"javascript:void(0);\" onclick='verComentarios(1," + rsListar["CDR_ID"] + ");' class=\"btn_comentario2 abre_relatos\">Ver comentários</a>";
                    ulRelatos.InnerHtml += "            <a href=\"javascript:void(0);\" onclick='teste(" + rsListar["CDR_ID"] + ");' class=\"btn_relato2 abre_comentario2\">Comente este relato</a>";
                    ulRelatos.InnerHtml += "        </div>";

                    if (string.IsNullOrWhiteSpace(rsListar["CDR_VIDEO"].ToString()) == false)
                    {
                        ulRelatos.InnerHtml += "        <div class=\"right\">";
                        ulRelatos.InnerHtml += "            <p class=\"titu_criacoes\"> Vídeo deste relato:</p>";
                        ulRelatos.InnerHtml += "            <iframe width=\"240px\" height=\"135px\" src=\"https://www.youtube.com/embed/" + rsListar["CDR_VIDEO"] + "\" frameborder=\"0\" allowfullscreen></iframe>";
                        ulRelatos.InnerHtml += "        </div>";
                    }

                    ulRelatos.InnerHtml += "    </div>";
                    ulRelatos.InnerHtml += " </li>";
                }
            }
            else
            {
                divRelatos.Visible = false;
            }
        }
    }

}