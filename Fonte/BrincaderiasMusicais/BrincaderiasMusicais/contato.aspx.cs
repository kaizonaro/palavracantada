using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Etnia.classe;

namespace BrincaderiasMusicais
{
    public partial class contato : System.Web.UI.Page
    {
        utils objUtils;
        bd objBD;
        protected void Page_Load(object sender, EventArgs e)
        {

            switch (Request["acao"])
            {
                case ("enviar"):
                    EnviarContato();
                    break;
                case("sucesso"):
                    Sucesso();
                    break;
                default:
                    break;
            }
        }

        private void EnviarContato()
        {

            objUtils = new utils();
            string msg = "<table><tr><td>Nome:</td><td>" + Request["nome"] + "</td></tr>";
            msg += "<tr><td>Email:</td><td>" + Request["email"] + "</td></tr>";
            msg += "<tr><td>Data e Hora:</td><td>" + DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToLongTimeString() + "</td></tr>";
            msg += "<tr><td>Mensagem:</td><td>" + Request["mensagem"] + "</td></tr></table>";
            
            //ERRO
            if (objUtils.EnviaEmail("fernando@agenciaetnia.com.br, zonaro@outlook.com.br, renato@toy.com.br", "Contato Projeto Brincadeiras Musicais da Palavra Cantada", msg, remetente: Request["email"], nome: Request["nome"]) == false)
            {
                Response.Write("<script>alert('Erro ao enviar o email!');</script>");
            }
            //SUCESSO
            else
            {
                objBD = new bd();
                objBD.ExecutaSQL("EXEC piContatoSite '"+Request["nome"]+"', '"+Request["email"]+"', '"+Request["mensagem"]+"'");
                Response.Redirect("/sucesso");
            }
        }

        private void Sucesso()
        {
            sucesso.Attributes["style"] = "display:block";
            divContato.Attributes["style"] = "display:none";
        }
    }
}