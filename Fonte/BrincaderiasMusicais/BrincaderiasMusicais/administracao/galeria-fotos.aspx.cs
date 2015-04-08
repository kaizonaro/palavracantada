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
    public partial class galeria_fotos : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista;

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
                case ("Aprovar"):
                    objBD.ExecutaSQL("update ColaborativaFotos set COF_STATUS = 'Aprovado' where COF_ID = " + Convert.ToInt16(Request["COF_ID"].ToString()));
                    break;
                case ("Reprovar"):
                    objBD.ExecutaSQL("update ColaborativaFotos set COF_STATUS = 'Reprovado' where COF_ID = " + Convert.ToInt16(Request["COF_ID"].ToString()));
                    File.Delete(Server.MapPath("~/upload/imagens/galeriacolaborativa/thumb-" + Request["imagem"].ToString() + ""));
                    File.Delete(Server.MapPath("~/upload/imagens/galeriacolaborativa/" + Request["imagem"].ToString() + ""));
                    break;
                default:
                    PopulaLista();
                    //PopulaExcluidos();
                    break;
            }
        }

        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("select C.COF_ID, C.COF_IMAGEM, C.COF_LEGENDA, R.RED_TITULO, U.USU_NOME from ColaborativaFotos  C INNER JOIN Rede R ON (R.RED_ID = C.RED_ID) INNER JOIN Usuario U ON (U.USU_ID = C.USU_ID) where C.COF_STATUS = 'Aguardando Aprovação' ORDER BY C.COF_ID DESC");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:30px;\">ID</th>";
                divLista.InnerHtml += "         <th style=\"width:120px;\">Foto</th>";
                divLista.InnerHtml += "         <th  style=\"width:200px;\">Legenda</th>";
                divLista.InnerHtml += "         <th  style=\"width:200px;\">Rede</th>";
                divLista.InnerHtml += "         <th  style=\"width:200px;\">Usuário</th>";
                divLista.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["COF_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["COF_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><img width='150px' src='/upload/imagens/galeriacolaborativa/thumb-" + rsLista["COF_IMAGEM"].ToString() + "'></td>";
                    divLista.InnerHtml += "     <td>" + rsLista["COF_LEGENDA"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["USU_NOME"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["COF_ID"].ToString() + "' onclick='Aprovar(this.id);' class=\"img_edit\"><img src=\"images/aprovar.png\"></a></li><li><a id='" + rsLista["COF_ID"].ToString() + "' onclick='Reprovar(this.id,\"" + rsLista["COF_IMAGEM"].ToString() + "\");' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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
        }
    }
}