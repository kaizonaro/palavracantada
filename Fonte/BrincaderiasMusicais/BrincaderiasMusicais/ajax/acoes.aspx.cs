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

namespace BrincaderiasMusicais.ajax
{
    public partial class acoes : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLogin, rsCadastro, rsArtigos;
        int registro = 1;
        string conteudoPaginacao = "", retorno = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();
            
            string acao = Request["acao"];

            switch (acao)
            {
                case "FazerLogin":
                    FazerLogin();
                    break;
                
                case "completarCadastro":
                    completarCadastro();
                    break;

                case "logout":
                    logout();
                    break;

                default:
                    // PopularBlog();
                    // PopularVideos();
                    break;
            }
        }

        public void FazerLogin()
        {

            rsLogin = objBD.ExecutaSQL("EXEC site_psUsuarioPorEmaileSenha '" + objUtils.TrataSQLInjection(Request["email"]) + "','" + objUtils.TrataSQLInjection(objUtils.getMD5Hash(Request["senha"])) + "'");

            if (rsLogin == null)
            {
                throw new Exception();
            }
            if (rsLogin.HasRows)
            {
                rsLogin.Read();
                //Salvar as Session do usuário
                Session["nomeUsuario"] = rsLogin["USU_NOME"].ToString();
                Session["nomeInstituicao"] = rsLogin["RED_TITULO"].ToString();
                Session["redeID"] = rsLogin["RED_ID"].ToString();
                Session["redeTitulo"] = objUtils.GerarURLAmigavel(rsLogin["RED_TITULO"].ToString());

                //Salva no log
                objBD.ExecutaSQL("EXEC psLog '" + rsLogin["USU_ID"] + "',null,'Login efetuado no sistema'");

                Response.Redirect("/rede/" + objUtils.GerarURLAmigavel(rsLogin["RED_TITULO"].ToString()));
                Response.End();
               
            }
            else
            {
                Response.Redirect("/default.aspx?msg=erroLogin");
            }

            rsLogin.Dispose();
            rsLogin.Close();

        }

        public void completarCadastro()
        {
            rsCadastro = objBD.ExecutaSQL("EXEC site_puCastro '" + Request["TOK_TOKEN"] + "','" + Request["USU_NOME"] + "','" + Request["USU_EMAIL"] + "','" + Request["CAR_ID"] + "','" + objUtils.TrataSQLInjection(objUtils.getMD5Hash(Request["USU_SENHA"])) + "'");

            if (rsCadastro == null)
            {
                throw new Exception();
            }
            if (rsCadastro.HasRows)
            {
                rsCadastro.Read();

                //Salvar as Categorias
                foreach (string categoria in Request["CAT_ID"].Split(Convert.ToChar(",")))
                {
                    objBD.ExecutaSQL("EXEC site_piuUsuarioCategoria " + rsCadastro["USU_ID"] + ", " + Convert.ToInt32(objUtils.SimpleSplitter(categoria, 0)));
                }

                //Salvar as Session do usuário
                Session["nomeUsuario"] = rsCadastro["USU_NOME"].ToString();
                Session["nomeInstituicao"] = rsCadastro["RED_TITULO"].ToString();
                Session["redeID"] = rsCadastro["RED_ID"].ToString();
                Session["redeTitulo"] = objUtils.GerarURLAmigavel(rsCadastro["RED_TITULO"].ToString());

                //Salva no log
                objBD.ExecutaSQL("EXEC psLog '" + rsCadastro["USU_ID"] + "',null,'Login efetuado no sistema'");

                Response.Redirect("/rede/" + objUtils.GerarURLAmigavel(rsCadastro["RED_TITULO"].ToString()));
                Response.End();

            }
            else
            {
                Response.Redirect("/");
            }

            rsCadastro.Dispose();
            rsCadastro.Close();
        }

        public void logout()
        {
            Session.Abandon();
            Response.Redirect("/");
        }

    }
}