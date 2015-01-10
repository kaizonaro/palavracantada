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
       
        protected void Page_Load(object sender, EventArgs e)
        {
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
            box_logado.InnerHtml += "   <li class=\"conheca pequeno\"><a href=\"/galeria-colaborativa\" title=\"Galeria Colaborativa\">Galeria Colaborativa</a></li>";
            box_logado.InnerHtml += "   <li class=\"conheca medio\"><a href=\"/blog-regional\" title=\"Blog Regional\">Blog Regional</a></li>";
            box_logado.InnerHtml += "   <li class=\"conheca\"><a href=\"/forum\" title=\"Fórum\">Fórum</a></li>";
            box_logado.InnerHtml += "   <li class=\"conheca grande\"><a href=\"/criacoes-documentadas\" title=\"Criações Documentadas\">Criações Documentadas</a></li>";
            box_logado.InnerHtml += "</ul>";
        }
    }
}