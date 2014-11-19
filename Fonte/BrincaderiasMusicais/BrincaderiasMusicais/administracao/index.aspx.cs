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
    public partial class index : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLogin;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            if (Request.Form["acao"] != null)
            {
                FazerLogin();
            }
            
        }

        public void FazerLogin()
        {
            try
            {
                rsLogin = objBD.ExecutaSQL("EXEC psLoginAdministradoPorEmaileSenha '" + objUtils.TrataSQLInjection(Request["login"]) + "','" + objUtils.TrataSQLInjection(objUtils.getMD5Hash(Request["senha"])) + "'");

                if (rsLogin == null)
                {
                    throw new Exception();
                }
                if (rsLogin.HasRows)
                {
                    rsLogin.Read();
                    //Salvar as Session do administrador
                    Session["id"] = rsLogin["ADM_ID"].ToString();
                    Session["nome"] = rsLogin["ADM_NOME"].ToString();
                    Session["email"] = rsLogin["ADM_EMAIL"].ToString();
                    Session["data"] = rsLogin["ADM_DT_ACESSO"].ToString();
                    Session["hora"] = rsLogin["ADM_HS_ACESSO"].ToString();
                    
                    //Salva no log
                    objBD.ExecutaSQL("EXEC piLog @ADM_ID = '" + Session["id"] + "',@LOG_ACONTECIMENTO = 'Login efetuado no sistema'");

                    //Atualiza o último acesso
                    objBD.ExecutaSQL("update Administrador set ADM_DH_ACESSO = GETDATE() where ADM_ID = '" + Session["id"] + "'");

                    //Redereciona para a "home" logada
                    Response.Redirect("home.aspx");
                }
                else
                {
                    Response.Redirect("index.aspx");
                }

                rsLogin.Close();
                rsLogin.Dispose();
            }
            catch (Exception ex)
            {
               /* objUtils.Feedbacker(ex);
                Response.Redirect("erro.aspx");
                Response.End();
                throw;*/
            }
        }
    }
}