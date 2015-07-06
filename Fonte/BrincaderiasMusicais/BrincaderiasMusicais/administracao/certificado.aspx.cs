using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BrincaderiasMusicais.administracao
{
    public partial class certificado : System.Web.UI.Page
    {
        public utils objUtils = new utils();
        public bd objBD = new bd();


        public string secretaria, aluno, dia, mes, ano, horas_presenciais, horas_distancia, diretor, obs;


        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            OleDbDataReader rsCertificado = objBD.ExecutaSQL("exec admin_ValidarCertificado " + Request["USU_ID"]);
            if (rsCertificado == null)
            {
                throw new Exception();
            }
            if (rsCertificado.HasRows)
            {

                while (rsCertificado.Read())
                {
                    obs = "" + rsCertificado["OBSERVACOES"];
                    secretaria = "" + rsCertificado["REDE"];
                    aluno = "" + rsCertificado["nome"];
                    DateTime datafinal = DateTime.Now;
                    string novadata = "" + Request["data_certificado"];
                    if (!string.IsNullOrWhiteSpace(novadata))
                    {
                        datafinal = Convert.ToDateTime(novadata);
                    }

                    dia = "" + datafinal.Day.ToString();
                    mes = "" + objUtils.MesExtenso(datafinal.Month);
                    ano = "" + datafinal.Year.ToString();
                    horas_presenciais = "" + rsCertificado["horas_presenciais"];
                    int hp = Convert.ToInt32(horas_presenciais);

                    if (hp == 0)
                    {
                        pres.Visible = false;
                    }

                    horas_distancia = "" + rsCertificado["horas_distancia"];
                    diretor = "" + rsCertificado["NOME_DIRETOR"];
                    assinatura2.Src = "data:image/png;base64," + rsCertificado["assinatura"];
                    brasao2.Src = "data:image/png;base64," + rsCertificado["brasao"];
                    assinatura.Src = "data:image/png;base64," + rsCertificado["assinatura"];
                    brasao.Src = "data:image/png;base64," + rsCertificado["brasao"];
                    if (string.IsNullOrWhiteSpace(obs))
                    {
                        folha2.Visible = false;
                    }

                    objBD.ExecutaSQL("UPDATE Usuario Set USU_CERTIFICADO = 1 where USU_ID = " + Request["USU_ID"]);
                }
            }
            rsCertificado.Close();
            rsCertificado.Dispose();


        }


        public void W(string words)
        {
            Response.Write(words);
        }





    }
}



