﻿using System;
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
        private OleDbDataReader rsLogin;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();
            
            FazerLogin();
        }


      
        public void FazerLogin()
        {
            try
            { 
                rsLogin = objBD.ExecutaSQL("EXEC sites_psUsuarioPorEmaileSenha '" + objUtils.TrataSQLInjection(Request["email"]) + "','" + objUtils.TrataSQLInjection(objUtils.getMD5Hash(Request["senha"])) + "'");

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

                    //Salva no log
                    objBD.ExecutaSQL("EXEC psLog '" + rsLogin["USU_ID"] + "',null,'Login efetuado no sistema'");
                    
                    //Redereciona para a "home" logada
                    Response.Redirect("/rede/" + objUtils.GerarURLAmigavel(rsLogin["RED_TITULO"].ToString()));
                    Response.End();
                }
                else
                {
                    Response.Redirect("/");
                }
            }
            catch (Exception ex)
            {
                objUtils.Feedbacker(ex);
                //throw;
            }
        }
    }
}