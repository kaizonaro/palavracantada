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
    public partial class videos : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsPlay;
        private int aux = 1;
        string retorno = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            string acao = Request["acao"];

            switch (acao)
            {
                case "mudarPlayList":
                    mudarPlayList(Convert.ToInt16(Request["lista"]));
                    break;

                default:
                    populaLista();
                    break;
            }
        }

        public void populaLista()
        {
            rsPlay = objBD.ExecutaSQL("select PLI_ID, PLI_TITULO, PLI_URL from PlayList where PLI_ATIVO = 1 order by PLI_DH_CADASTRO desc");
            if (rsPlay == null)
            {
                throw new Exception();
            }
            if (rsPlay.HasRows)
            {
                while (rsPlay.Read())
                {
                    if (aux == 1)
                    {
                        objVideo.InnerHtml += "<iframe width=\"480\" height=\"269\" src=\""+rsPlay["PLI_URL"].ToString()+"\" frameborder=\"0\" allowfullscreen></iframe>";
                    }

                    System.Web.UI.WebControls.ListItem R = new System.Web.UI.WebControls.ListItem();
                    R.Value = rsPlay["PLI_ID"].ToString();
                    R.Text = rsPlay["PLI_TITULO"].ToString();
                    slPlayList.Items.Add(R);
                    aux++;
                }
            }
            rsPlay.Close();
            rsPlay.Dispose();

        }

        public void mudarPlayList(int id)
        {
            rsPlay = objBD.ExecutaSQL("select PLI_ID, PLI_TITULO, PLI_URL from PlayList where PLI_ID = "+id+"");

            if (rsPlay == null)
            {
                throw new Exception();
            }

            if (rsPlay.HasRows)
            {
                rsPlay.Read();

                retorno += "<iframe width=\"480\" height=\"269\" src=\"" + rsPlay["PLI_URL"].ToString() + "\" frameborder=\"0\" allowfullscreen></iframe>";
                retorno += "|";
                retorno += "" + id + "";
                retorno += "|";
            }

            Response.Write(retorno);

            rsPlay.Close();
            rsPlay.Dispose();
        }
    }
}