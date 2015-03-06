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
    public partial class quem_somos : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsEditar, rsGravaUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();
            PopulaLista();

            if (Request["acao"] == "editar")
            {
                rsEditar = objBD.ExecutaSQL("select * from SobreProjeto where SOB_ID = 2");
                if (rsEditar == null)
                {
                    throw new Exception();
                }
                if (rsEditar.HasRows)
                {
                    rsEditar.Read();
                    Response.Write(rsEditar["SOB_ID"] + "|" + rsEditar["SOB_TITULO"] + "|" + rsEditar["SOB_TEXTO_INICIAL"] + "|" + rsEditar["SOB_TEXTO_FINAL"]);
                }

            }
        }

        public void PopulaLista()
        {
            string objetolista = "";
            objetolista = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("select * from SobreProjeto where SOB_ID = 2");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                objetolista += " <thead>";
                objetolista += "     <tr>";
                objetolista += "         <th style=\"width:60px;\">ID</th>";
                objetolista += "         <th style=\"width:600px;\">Titulo</th>";
                objetolista += "         <th style=\"width:90px;\">Ações</th>";
                objetolista += "     </tr>";
                objetolista += " </thead>";

                objetolista += " <tbody>";

                while (rsLista.Read())
                {
                    objetolista += " <tr id='tr_" + rsLista["SOB_ID"].ToString() + "' class=\"\">";
                    objetolista += "     <td>" + rsLista["SOB_ID"].ToString() + "</td>";
                    objetolista += "     <td>" + rsLista["SOB_TITULO"].ToString() + "</td>";

                    objetolista += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0)\" id='" + rsLista["SOB_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li></ul>";


                    objetolista += " </tr>";
                }

                objetolista += " </tbody>";
            }

            else
            {
                objetolista += " <thead>";
                objetolista += "     <tr>";
                objetolista += "         <th>Nenhum registro cadastrado até o momento!</th>";
                objetolista += "     </tr>";
                objetolista += " </thead>";
            }
            rsLista.Close();
            rsLista.Dispose();

            objetolista += "</table>";

            divLista.InnerHtml = objetolista;

        }

        public void gravar(object sender, EventArgs e)
        {
            rsGravaUsuario = objBD.ExecutaSQL("EXEC admin_piuSobreProjeto '2', '" + Request["SOB_TITULO"] + "', '" + Request["SOB_TEXTO_INICIAL"] + "', '" + Request["SOB_TEXTO_FINAL"] + "'");
            if (rsGravaUsuario == null)
            {
                throw new Exception();
            }
            Response.Redirect("quem-somos.aspx");
        }
    }
}