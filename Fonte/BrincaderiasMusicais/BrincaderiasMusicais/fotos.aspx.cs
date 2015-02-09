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
    public partial class fotos1 : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsGaleria;
        private int aux = 1;
        string retorno = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();
            

            string acao = Request["acao"];

            switch (acao)
            {
                case "mudarGaleria":
                    mudarGaleria(Convert.ToInt16(Request["galeria"]));
                    break;

                default:
                    populaGaleria();
                    break;
            }

        }

        public void populaGaleria()
        {
            rsGaleria = objBD.ExecutaSQL("select AFO_ID, AFO_TITULO, AFO_KEY from AlbumFotos where afo_ativo = 1 order by AFO_DH_CADASTRO desc");
            if (rsGaleria == null)
            {
                throw new Exception();
            }
            if (rsGaleria.HasRows)
            {
                while (rsGaleria.Read())
                {
                    if (aux == 1)
                    {
                        objVideo.InnerHtml += "<object width=\"468\" height=\"297\">";
                        objVideo.InnerHtml += " <param name=\"flashvars\" value=\"offsite=true&lang=en-us&page_show_url=%2Fphotos%2Fbrincamusicais%2Fsets%2F" + rsGaleria["AFO_KEY"] + "%2Fshow%2F&page_show_back_url=%2Fphotos%2Fbrincamusicais%2Fsets%2F" + rsGaleria["AFO_KEY"] + "%2F&set_id=" + rsGaleria["AFO_KEY"] + "&jump_to=\"></param>";
                        objVideo.InnerHtml += " <param name=\"movie\" value=\"https://www.flickr.com/apps/slideshow/show.swf?v=1811922554\"></param>";
                        objVideo.InnerHtml += " <param name=\"allowFullScreen\" value=\"true\"></param>";
                        objVideo.InnerHtml += " <embed type=\"application/x-shockwave-flash\" src=\"https://www.flickr.com/apps/slideshow/show.swf?v=1811922554\" allowfullscreen=\"true\" flashvars=\"offsite=true&lang=en-us&page_show_url=%2Fphotos%2Fbrincamusicais%2Fsets%2F" + rsGaleria["AFO_KEY"] + "%2Fshow%2F&page_show_back_url=%2Fphotos%2Fbrincamusicais%2Fsets%2F" + rsGaleria["AFO_KEY"] + "%2F&set_id=" + rsGaleria["AFO_KEY"] + "&jump_to=\" width=\"468\" height=\"297\"></embed>";
                        objVideo.InnerHtml += "</object>";
                    }

                    System.Web.UI.WebControls.ListItem R = new System.Web.UI.WebControls.ListItem();
                    R.Value = rsGaleria["AFO_ID"].ToString();
                    R.Text = rsGaleria["AFO_TITULO"].ToString();
                    slGaleria.Items.Add(R);
                    aux++;
                }
            }
            rsGaleria.Close();
            rsGaleria.Dispose();
            
        }

        public void mudarGaleria(int id)
        {
            rsGaleria = objBD.ExecutaSQL("select AFO_ID, AFO_TITULO, AFO_KEY from AlbumFotos where AFO_ID = "+id+" order by AFO_DH_CADASTRO desc");

            if (rsGaleria == null)
            {
                throw new Exception();
            }

            if (rsGaleria.HasRows)
            {
                rsGaleria.Read();

                retorno += "<object width=\"468\" height=\"297\">";
                retorno += " <param name=\"flashvars\" value=\"offsite=true&lang=en-us&page_show_url=%2Fphotos%2Fbrincamusicais%2Fsets%2F" + rsGaleria["AFO_KEY"] + "%2Fshow%2F&page_show_back_url=%2Fphotos%2Fbrincamusicais%2Fsets%2F" + rsGaleria["AFO_KEY"] + "%2F&set_id=" + rsGaleria["AFO_KEY"] + "&jump_to=\"></param>";
                retorno += " <param name=\"movie\" value=\"https://www.flickr.com/apps/slideshow/show.swf?v=1811922554\"></param>";
                retorno += " <param name=\"allowFullScreen\" value=\"true\"></param>";
                retorno += " <embed type=\"application/x-shockwave-flash\" src=\"https://www.flickr.com/apps/slideshow/show.swf?v=1811922554\" allowfullscreen=\"true\" flashvars=\"offsite=true&lang=en-us&page_show_url=%2Fphotos%2Fbrincamusicais%2Fsets%2F" + rsGaleria["AFO_KEY"] + "%2Fshow%2F&page_show_back_url=%2Fphotos%2Fbrincamusicais%2Fsets%2F" + rsGaleria["AFO_KEY"] + "%2F&set_id=" + rsGaleria["AFO_KEY"] + "&jump_to=\" width=\"468\" height=\"297\"></embed>";
                retorno += "</object>";
                retorno += "|";
                retorno += ""+id+"";
                retorno += "|";
            }

            Response.Write(retorno);

            rsGaleria.Close();
            rsGaleria.Dispose();
        }
    }
}