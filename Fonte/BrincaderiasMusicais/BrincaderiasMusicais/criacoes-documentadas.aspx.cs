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

namespace BrincaderiasMusicais
{
    public partial class criacoes_documentas : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsListar;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            //Verificar se ainda está logado
            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
            {
                PopularTabelas();
            }
            else
            {
                //DESLOGADO
                Response.Redirect("/");
            }
        }

        public void PopularTabelas()
        {
            rsListar = objBD.ExecutaSQL("EXEC site_psCriacoesDocumentadas '" + Session["redeID"] + "' ");

            if (rsListar == null)
            {
                throw new Exception();
            }
            if (rsListar.HasRows)
            {
                tbAtiva.InnerHtml += "<table class=\"tabela\">";
                tbAtiva.InnerHtml += "  <tr>";
                tbAtiva.InnerHtml += "      <th style='min-width: 242px;'>Tarefa</th>";
                tbAtiva.InnerHtml += "      <th style='min-width: 65px;'>Data</th>";
                tbAtiva.InnerHtml += "      <th>Relatos</th>";
                tbAtiva.InnerHtml += "      <th>Visualizar</th>";
                tbAtiva.InnerHtml += " </tr>";

                while (rsListar.Read())
                {
                    tbAtiva.InnerHtml += " <tr>";
                    tbAtiva.InnerHtml += "  <td>" + rsListar["CDO_TAREFA"] + "</td>";
                    tbAtiva.InnerHtml += "  <td>" + rsListar["CDO_DATA"] + "</td>";
                    tbAtiva.InnerHtml += "  <td>" + rsListar["TOTAL_RELATOS"] + "</td>";
                    tbAtiva.InnerHtml += "  <td><a href=\"/tarefa-ativa/" + rsListar["CDO_ID"] + "\">Visualizar Tarefa</a></td>";
                    tbAtiva.InnerHtml += " </tr>";
                }
                tbAtiva.InnerHtml += "</table>";

                //Próxima tabela
                rsListar.NextResult();
                tbArquivada.InnerHtml += "<table class=\"tabela2\">";
                tbArquivada.InnerHtml += "  <tr>";
                tbArquivada.InnerHtml += "      <th style='min-width: 242px;'>Tarefa</th>";
                tbArquivada.InnerHtml += "      <th style='min-width: 65px;'>Data</th>";
                tbArquivada.InnerHtml += "      <th>Relatos</th>";
                tbArquivada.InnerHtml += "      <th>Visualizar</th>";
                tbArquivada.InnerHtml += " </tr>";

                while (rsListar.Read())
                {
                    tbArquivada.InnerHtml += " <tr>";
                    tbArquivada.InnerHtml += "  <td>" + rsListar["CDO_TAREFA"] + "</td>";
                    tbArquivada.InnerHtml += "  <td>" + rsListar["CDO_DATA"] + "</td>";
                    tbArquivada.InnerHtml += "  <td>" + rsListar["TOTAL_RELATOS"] + "</td>";
                    tbArquivada.InnerHtml += "  <td><a href=\"/tarefa-arquivada/" + rsListar["CDO_ID"] + "\">Visualizar Tarefa</a></td>";
                    tbArquivada.InnerHtml += " </tr>";
                }
                tbArquivada.InnerHtml += "</table>";
            }
        }
    }
}