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
    public partial class meuperfil : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsUsuario, rsMedalhas;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            //Verificar se ainda está logado
            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
            {
                if (Request["usuario"] != null && Request["usuario"].ToString().Length > 1)
                {
                    rsUsuario = objBD.ExecutaSQL("select USU_ID, RED_ID, USU_CERTIFICADO from usuario where USU_USUARIO = '" + Request["usuario"].ToString() + "'");

                    if (rsUsuario == null)
                    {
                        throw new Exception();
                    }
                    if (rsUsuario.HasRows)
                    {
                        rsUsuario.Read();

                        if (rsUsuario["USU_ID"].ToString() == Session["usuID"].ToString())
                        {
                            bool cert = false;
                            Boolean.TryParse("" + rsUsuario["USU_CERTIFICADO"], out cert);
                            divcertificado.Visible = cert;
                            botaocertificado_frente.HRef = "/administracao/certificado.aspx?Tipo=frente&USU_ID=" + Session["usuID"].ToString();
                         
                            botaocertificado_verso.HRef = "/administracao/certificado.aspx?Tipo=verso&USU_ID=" + Session["usuID"].ToString();
                           
                        }
                        else if ((rsUsuario["USU_ID"].ToString() != Session["usuID"].ToString()) && rsUsuario["RED_ID"].ToString() == Session["redeID"].ToString())
                        {
                            Response.Redirect("/perfil/" + Request["usuario"].ToString());
                            Response.End();

                        }
                        else
                        {
                            // Response.Write("outro e rede diferente");
                        }
                    }
                     
                    rsUsuario.Close();
                    rsUsuario.Dispose();
                   
                }

                VerificarMedalhas();
            }
            else
            {
                //DESLOGADO
                Response.Redirect("/");
            }

            string msg = Request["mensagem"];
            if (!string.IsNullOrWhiteSpace(msg))
            {
                Response.Write("<script>alert('" + msg + "');</script>");
            }
        }

        public void VerificarMedalhas()
        {
            rsMedalhas = objBD.ExecutaSQL("Exec psMedalhasLis " + Session["usuID"].ToString() + "");

            if (rsMedalhas == null)
            {
                throw new Exception();
            }
            if (rsMedalhas.HasRows)
            {
                rsMedalhas.Read();

                if (Convert.ToInt16(rsMedalhas["TOTAL_LOGIN"]) > 2)
                {
                    liDedicado.Attributes.Add("class", "ativo");
                    imgDedicado.Attributes.Add("src", "/images/medalha1_ok.png");
                }

                if (Convert.ToInt16(rsMedalhas["TOTAL_POST_BLOG"]) > 2)
                {
                    liBlogueiro.Attributes.Add("class", "ativo");
                    imgBlogueiro.Attributes.Add("src", "/images/medalha2_ok.png");
                }

                if (Convert.ToInt16(rsMedalhas["TOTAL_FOTOS"]) > 2)
                {
                    liFotografo.Attributes.Add("class", "ativo");
                    imgFotografo.Attributes.Add("src", "/images/medalha3_ok.png");
                }

                if (Convert.ToInt16(rsMedalhas["TOTAL_VIDEOS"]) > 2)
                {
                    liProdutor.Attributes.Add("class", "ativo");
                    imgProdutor.Attributes.Add("src", "/images/medalha4_ok.png");
                }

                if (Convert.ToInt16(rsMedalhas["TOTAL_FORUM"]) > 1 && Convert.ToInt16(rsMedalhas["TOTAL_RELATOS"]) > 1)
                {
                    liExperiente.Attributes.Add("class", "ativo");
                    imgExperiente.Attributes.Add("src", "/images/medalha5_ok.png");
                }
            }
            rsMedalhas.Close();
            rsMedalhas.Dispose();
        }
    }
}