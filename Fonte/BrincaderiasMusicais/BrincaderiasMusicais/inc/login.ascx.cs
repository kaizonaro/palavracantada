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

namespace BrincaderiasMusicais.inc
{
    public partial class login : System.Web.UI.UserControl
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader Categoria, Datas, rsBanner, rsNotificacoes;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                objUtils = new utils();
                objBD = new bd();

                populacategorias();
                populardatas();
                populaBanner();
                if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
                {
                    //LOGADO
                    box_logado.Attributes.Add("class", "box_logado");
                    banner_sidebar.Attributes.Add("class", "esconde");
                    box_login.Attributes.Add("class", "esconde");

                    populuarBoxLogado();

                }
                else
                {
                    //DESLOGADO
                    if (Request["msg"] != null && Request["msg"].ToString().Length > 1)
                    {
                        msgErro.InnerHtml = "<br/>Usuário e/ou senha inválida";
                    }
                }

                string urlCompleta = Request.Url.AbsoluteUri;
                string paginaAtual = Request.CurrentExecutionFilePath;
                paginaAtual = paginaAtual.Remove(0, paginaAtual.LastIndexOf("/") + 1);

                switch (paginaAtual)
                {
                    case "blog.aspx":
                    case "blog-regional.aspx":
                        divBlog.Attributes.Remove("class");
                        divBlog.Attributes["class"] = "box_login";

                        banner_sidebar.Attributes.Remove("class");
                        banner_sidebar.Attributes["class"] = "esconde";
                        break;
                }
            }
            
        }

        public void populuarBoxLogado()
        {
            box_logado.InnerHtml += "<p>Olá <strong>" + Session["nomeUsuario"] + "</strong>, seja bem vindo a área restrita da rede <strong>" + Session["nomeInstituicao"] + "</strong>.</p>";
            box_logado.InnerHtml += "<input type=\"button\" onClick='sair()' class=\"btn\" value=\"SAIR\"/>";
            box_logado.InnerHtml += "<p class=\"titu_logado\">Selecione no menu abaixo qual sessão deseja visitar:</p>";
            box_logado.InnerHtml += "<ul class=\"opcao_logado\">";
            box_logado.InnerHtml += "   <li class=\"conheca\"><a href=\"/meu-perfil\" title=\"Meu perfil\">Meu perfil</a></li>";
            box_logado.InnerHtml += "   <li class=\"conheca\"><a href=\"/agenda\" title=\"Agenda\">Agenda</a></li>";
            box_logado.InnerHtml += "   <li class=\"conheca\"><a href=\"/faq\" title=\"FAQ\">FAQ</a></li>";
            box_logado.InnerHtml += "   <li class=\"conheca pequeno\"><a href=\"javascript:void(0)\" title=\"Galeria Colaborativa\">Galeria Colaborativa</a></li>";
            box_logado.InnerHtml += "   <li class=\"conheca medio\"><a href=\"/blog-regional\" title=\"Blog Regional\">Blog Regional</a></li>";
            box_logado.InnerHtml += "   <li class=\"conheca\"><a href=\"javascript:void(0)\" title=\"Fórum\">Fórum</a></li>";
            box_logado.InnerHtml += "   <li class=\"conheca grande\"><a href=\"javascript:void(0)\" title=\"Criações Documentadas\">Criações Documentadas</a></li>";
            box_logado.InnerHtml += "</ul>";

            box_logado.InnerHtml += "<div class=\"notificacoes_logado\">";
            box_logado.InnerHtml += "   <p>Notificações recentes:</p>";
            box_logado.InnerHtml += "   <img src=\"/images/arrow_left.png\" class=\"left_logado\" />";
            box_logado.InnerHtml += "   <img src=\"/images/arrow_right.png\" class=\"right_logado\" />";
            box_logado.InnerHtml += "   <ul class=\"notificacao\">";

            rsNotificacoes = objBD.ExecutaSQL("select TOP 5 LOG_ACONTECIMENTO from log WHERE LOG_EXIBIR = 1 AND (USU_ID = " + Session["usuID"] + " OR USU_ID IS NULL) ORDER BY LOG_DH_ACONTECIMENTO DESC");

            if (rsNotificacoes == null)
            {
                throw new Exception();
            }
            if (rsNotificacoes.HasRows)
            {
                while (rsNotificacoes.Read())
                {
                    box_logado.InnerHtml += "       <li>" + rsNotificacoes["LOG_ACONTECIMENTO"] + "</li>";
                }
            }

            else
            {
                box_logado.InnerHtml += "       <li>Não há notificações disponíveis!</li>";
            }
            rsNotificacoes.Close();
            rsNotificacoes.Dispose();
            box_logado.InnerHtml += "   </ul>";
            box_logado.InnerHtml += "</div>";
        }

        public void populardatas()
        {
            bd objBd = new bd();
            Datas = objBd.ExecutaSQL("exec site_post_data_lis");
            if (Datas == null)
            {
                throw new Exception();
            }
            if (Datas.HasRows)
            {
                while (Datas.Read())
                {
                    POS_DH_CRIACAO.Items.Add(new ListItem(Convert.ToDateTime(Datas["data"].ToString()).ToShortDateString(), Datas["data"].ToString()));
                }
            }
        }

        public void populacategorias()
        {
            bd objBd = new bd();
            Categoria = objBd.ExecutaSQL("SELECT PCA_ID, PCA_TITULO FROM PostCategoria where PCA_ATIVO = 1 order by PCA_ORDEM;");
            if (Categoria == null)
            {
                throw new Exception();
            }
            if (Categoria.HasRows)
            {
                while (Categoria.Read())
                {
                    PCA_ID.Items.Add(new ListItem(Categoria["PCA_TITULO"].ToString(), Categoria["PCA_ID"].ToString()));
                }
            }
        }

        public void populaBanner()
        {
            rsBanner = objBD.ExecutaSQL("select top 1 * from Banner where PAG_ID  =3");

            if (rsBanner == null)
            {
                throw new Exception();
            }
            if (rsBanner.HasRows)
            {
                while (rsBanner.Read())
                {
                    banner_sidebar.InnerHtml += "<a href='http://palavracantada.com.br' title='Conmheça o site oficial do palalavra cantada' target='_blank'>";
                    banner_sidebar.InnerHtml += "    <img src='/upload/imagens/banners/" + rsBanner["BAN_IMAGEM"] + "' alt='Conmheça o site oficial do palalavra cantada' />";
                    banner_sidebar.InnerHtml += "</a>";
                }
            }
            rsBanner.Close();
            rsBanner.Dispose();
        }
    }
}