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
    public partial class postar_forum : System.Web.UI.Page
    {
        private utils objUtils = new utils();
        private bd objBD = new bd();
        private OleDbDataReader rsMedalhas;

        private string url = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            FTO_ID.Value = Request["FTO_ID"];
            REDIRECT.Value = Request["REDIRECT"];
        }


        protected void pub_Click(object sender, EventArgs e)
        {
            objBD.ExecutaSQL("INSERT INTO ForumMensagem (USU_ID, FME_MENSAGEM, FTO_ID) values ('" + Session["usuID"] + "','" + Request["FME_MENSAGEM"] + "', '" + Request["FTO_ID"] + "')");
            Response.Redirect(Request["REDIRECT"]);
        }
    }
}