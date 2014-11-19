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
    public partial class home : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsGeral;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            popularGeral();
        }

        public void popularGeral()
        {
            rsGeral = objBD.ExecutaSQL("exec psAdminPainelLis " + Session["id"] + " ");

            if (rsGeral == null)
            {
                throw new Exception();
            }
            if (rsGeral.HasRows)
            {
                while (rsGeral.Read())
                {
                    ulGeral.InnerHtml += "<li><p>Administradores:</p> <b>" + rsGeral["Total Administradores"].ToString() + "</b></li>";
                    ulGeral.InnerHtml += "<li><p>Usuários:</p> <b>" + rsGeral["Total Usuários"].ToString() + "</b></li>";
                    ulGeral.InnerHtml += "<li><p>Redes:</p> <b>" + rsGeral["Total Redes"].ToString() + "</b></li>";

                    ulAdmin.InnerHtml += "<li><p>Tarefas:</p> <b>" + rsGeral["Total Tarefas"].ToString() + "</b></li>";
                    ulAdmin.InnerHtml += "<li><p>Comentários:</p> <b>" + rsGeral["Total Comentarios"].ToString() + "</b></li>";
                    ulAdmin.InnerHtml += "<li><p>Posts:</p> <b>" + rsGeral["Total Post"].ToString() + "</b></li>";
                }
            }
        }
    }

}