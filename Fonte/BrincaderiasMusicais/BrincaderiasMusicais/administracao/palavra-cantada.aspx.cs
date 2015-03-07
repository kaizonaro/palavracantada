using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais.administracao
{
    public partial class palavra_cantada : System.Web.UI.Page
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
                case ("editar"):
                    rsLista = objBD.ExecutaSQL("select EQU_ID, EQU_NOME, EQU_DESCRICAO from  Equipe where EQU_ID ='" + Request["EQU_ID"] + "'");
                    if (rsLista == null)
                    {
                        throw new Exception();
                    }
                    if (rsLista.HasRows)
                    {
                        rsLista.Read();
                        Response.Write(rsLista["EQU_ID"] + "|" + rsLista["EQU_NOME"] + "|" + rsLista["EQU_DESCRICAO"]);
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

            rsLista = objBD.ExecutaSQL("SELECT * from Equipe where EQU_MANAGER =  1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:30px;\">ID</th>";
                divLista.InnerHtml += "         <th>Nome</th>";
                divLista.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["EQU_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["EQU_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["EQU_NOME"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["EQU_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li></ul>";
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



        public void gravar(object sender, EventArgs e)
        {
            rsGravar = objBD.ExecutaSQL("EXEC admin_piuEquipe  '" + Request["EQU_ID"] + "', '" + Request["EQU_NOME"] + "', NULL, '" + Request["EQU_DESCRICAO"] + "'");
            Response.Redirect("palavra-cantada.aspx");
        }
    }
}