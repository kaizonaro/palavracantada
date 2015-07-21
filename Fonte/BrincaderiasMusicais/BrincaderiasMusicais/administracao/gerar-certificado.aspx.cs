using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BrincaderiasMusicais.administracao
{
    public partial class gerar_certificado : System.Web.UI.Page
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
                case "gerar":
                   
                    break;
                case "SalvaObservacao":
                    objBD.ExecutaSQL("UPDATE Usuario set USU_CERTIFICADO_OBSERVACOES = '" + Request["USU_CERTIFICADO_OBSERVACOES"] + "' where USU_ID = " + Request["USU_ID"]);
                    break;
                case "SalvarData":
                    objBD.ExecutaSQL("UPDATE Usuario set USU_DATA_CERTIFICADO = convert(datetime,'" + Request["USU_DATA_CERTIFICADO"] + "',103) where USU_ID = " + Request["USU_ID"]);
                    objBD.ExecutaSQL("UPDATE Usuario set USU_CERTIFICADO = 1 where USU_ID = " + Request["USU_ID"]);
                    break;
                default:
                    PopulaLista();
                    PopularRedes();
                    break;
            }
        }

     

        public void PopularRedes()
        {
            OleDbDataReader rsRede = objBD.ExecutaSQL("EXEC admin_psRedesPorAtivo 1");
            if (rsRede == null)
            {
                throw new Exception();
            }
            if (rsRede.HasRows)
            {
                while (rsRede.Read())
                {
                    System.Web.UI.WebControls.ListItem R = new System.Web.UI.WebControls.ListItem();
                    R.Value = rsRede["RED_ID"].ToString();
                    R.Text = rsRede["RED_CIDADE"].ToString() + " | " + rsRede["RED_UF"].ToString();
                    RED_ID.Items.Add(R);
                }
            }
            rsRede.Close();
            rsRede.Dispose();
        }

        public void PopulaLista()
        {
            string objetolista = "";
            objetolista = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("Exec Certificadoredes " + Request["RED_ID"]);
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                objetolista += " <thead>";
                objetolista += "     <tr>";
                objetolista += "         <th style=\"width:60px;\">ID</th>";
                objetolista += "         <th style=\"width:60px;\">Nome</th>";
                objetolista += "         <th style=\"width:600px;\">Tipo</th>";
                objetolista += "         <th style=\"width:600px;\">Rede</th>";
                objetolista += "         <th style=\"width:600px;\">Horas Presenciais</th>";
                objetolista += "         <th style=\"width:600px;\">Horas a Distância</th>";
                objetolista += "         <th style=\"width:600px;\">Status</th>";
                objetolista += "         <th style=\"width:600px;\">Observações</th>";
                objetolista += "         <th style=\"width:90px;\">Ações</th>";
                objetolista += "     </tr>";
                objetolista += " </thead>";

                objetolista += " <tbody>";

                while (rsLista.Read())
                {
                    objetolista += " <tr id='tr_" + rsLista["USU_ID"].ToString() + "' class=\"\">";
                    objetolista += "     <td>" + rsLista["USU_ID"].ToString() + "</td>";
                    objetolista += "     <td>" + rsLista["NOME"].ToString() + "</td>";
                    objetolista += "     <td>" + rsLista["TIPO"].ToString() + "</td>";
                    objetolista += "     <td>" + rsLista["REDE"].ToString() + "</td>";
                    objetolista += "     <td>" + rsLista["HORAS_PRESENCIAIS"].ToString() + "</td>";
                    objetolista += "     <td>" + rsLista["TOTAL_HORAS"].ToString() + "/" + rsLista["HORAS_DISTANCIA"].ToString() + "</td>";
                    var msg = Convert.ToBoolean(rsLista["GERADO"].ToString()) ? "Certificado Gerado" : "Certificado Não Gerado";
                    objetolista += "     <td>" + msg + "</td>";
                    int TH = 0, HD = 0;
                    TH = Convert.ToInt32(string.IsNullOrWhiteSpace(rsLista["TOTAL_HORAS"].ToString()) ? 0 : Convert.ToInt32(rsLista["TOTAL_HORAS"].ToString()));
                    HD = Convert.ToInt32(string.IsNullOrWhiteSpace(rsLista["HORAS_DISTANCIA"].ToString()) ? 0 : Convert.ToInt32(rsLista["HORAS_DISTANCIA"].ToString()));
                    objetolista += "     <td><input type='text' class='input' value='" + rsLista["OBSERVACOES"].ToString() + "' onchange='SalvaObservacao(this," + rsLista["USU_ID"].ToString() + ")' /></td>";
                    objetolista += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0)\" id='" + rsLista["USU_ID"].ToString() + "' onclick='LiberarCertificado(this.id," + TH + "," + HD + ");' class=\"img_edit\"><img src=\"images/editar.png\"></a></li></ul>";


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


    }
}