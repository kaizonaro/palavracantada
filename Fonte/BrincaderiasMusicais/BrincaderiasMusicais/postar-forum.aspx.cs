﻿using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais
{
    public partial class postar_forum : System.Web.UI.Page
    {
        private utils objUtils = new utils();
        private bd objBD = new bd();
        private OleDbDataReader rsMedalhas, rsForum;

        private string url = "";
        protected void Page_Load(object sender, EventArgs e)
        { 
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            FTO_ID.Value = Request["FTO_ID"];
            REDIRECT.Value = Request["REDIRECT"];

            bd banco = new bd();
            OleDbDataReader rsForum = banco.ExecutaSQL("select FTO_ID, FTO_TITULO from ForumTopicos where FTO_ID = " + textInfo.ToTitleCase(Request["REDIRECT"].Substring(Request["REDIRECT"].LastIndexOf('/') + 1)).Replace("-", " ") + "");
            
            if (rsForum == null)
            {
                throw new Exception();
            }
            if (rsForum.HasRows)
            {
                rsForum.Read();
                titulobrd.InnerText = rsForum["FTO_TITULO"].ToString();
                titulo.InnerText = rsForum["FTO_TITULO"].ToString();
            }

           // titulo.InnerText = textInfo.ToTitleCase(Request["REDIRECT"].Substring(Request["REDIRECT"].LastIndexOf('/') + 1)).Replace("-", " ");
            //titulobrd.InnerText = textInfo.ToTitleCase(Request["REDIRECT"].Substring(Request["REDIRECT"].LastIndexOf('/') + 1)).Replace("-", " ");
        }


        protected void pub_Click(object sender, EventArgs e)
        {
            objBD.ExecutaSQL("INSERT INTO ForumMensagem (USU_ID, FME_MENSAGEM, FTO_ID) values ('" + Session["usuID"] + "','" + Request["FME_MENSAGEM"] + "', '" + Request["FTO_ID"] + "')");
            notificacoes();
            Response.Redirect(Request["REDIRECT"]);
        }

        public void notificacoes()
        {
            bd banco = new bd();
            OleDbDataReader rsNotificar = banco.ExecutaSQL("EXEC admin_psNotificarForum " + Session["usuID"]);
            if (rsNotificar == null)
            {
                throw new Exception();
            }
            if (rsNotificar.HasRows)
            {
                
                while (rsNotificar.Read())
                {
                    if (objUtils.EnviaEmail(rsNotificar["USU_EMAIL"].ToString(), "Novo post no forum Brincadeiras Musicais", "Nova mensagem no forum: " + Request["FME_MENSAGEM"]) == false)
                    {
                        throw new Exception();
                    }
                }

               
            }
        }
    }
}