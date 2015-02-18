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
    public partial class contato : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsGravar, rsNotificar;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {
                case ("editarPost"):
                    rsLista = objBD.ExecutaSQL("select POS_ID, POS_TITULO, POS_TEXTO, POS_IMPORTANTE from  PostBlog where POS_ID ='" + Request["POS_ID"] + "'");
                    if (rsLista == null)
                    {
                        throw new Exception();
                    }
                    if (rsLista.HasRows)
                    {
                        rsLista.Read();
                        Response.Write(rsLista["POS_ID"] + "|" + rsLista["POS_TITULO"] + "|" + rsLista["POS_TEXTO"] + "|" + rsLista["POS_IMPORTANTE"]);
                    }
                    break;

                default:
                    PopulaLista();
                    break;
            }
        }

        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("SELECT * FROM FormularioContato ORDER BY FORM_DH_CONTATO");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:30px;\">ID</th>";
                divLista.InnerHtml += "         <th style=\"width:120px;\">Nome</th>";
                divLista.InnerHtml += "         <th>Email</th>";
                divLista.InnerHtml += "         <th style=\"width:115px;\">Data</th>";
                divLista.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["FORM_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["FORM_ID"].ToString() + "</td>";                    
                    divLista.InnerHtml += "     <td>" + rsLista["FORM_NOME"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["FORM_EMAIL"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + Convert.ToDateTime(rsLista["FORM_DH_CONTATO"].ToString()).ToShortDateString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><a href=\"javascript:void(0);\" id='" + rsLista["FORM_ID"].ToString() + "' onclick='visualizar(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></ul>";
                    divLista.InnerHtml += " </tr>";
                }

                divLista.InnerHtml += " </tbody>";
            }

            else
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th>Nenhum registro cadastrado até o momento!</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";
            }
            rsLista.Close();
            rsLista.Dispose();

            divLista.InnerHtml += "</table>";
        }

        public Int64 GerarID()
        {
            try
            {
                DateTime data = new DateTime();
                data = DateTime.Now;
                string s = data.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
                return Convert.ToInt64(s);
            }
            catch (Exception erro)
            {
                throw;
            }
        }

 

    }
}