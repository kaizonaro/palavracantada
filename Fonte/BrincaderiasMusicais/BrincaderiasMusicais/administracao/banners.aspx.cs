using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Etnia.classe;
using System.Data.OleDb;
using System.Web.Configuration;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace BrincaderiasMusicais.administracao
{
    public partial class banners : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsRedes, rsGravaBanner, rsPagina, rsSize;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            try
            {
                switch (Request["acao"])
                {
                    case ("excluirBanner"):

                        objBD.ExecutaSQL("update Banner set BAN_ATIVO = 0 where BAN_ID ='" + Request["BAN_ID"] + "'");

                        break;
                    case ("restoreBanner"):
                        objBD.ExecutaSQL("update Banner set BAN_ATIVO = 1 where BAN_ID ='" + Request["BAN_ID"] + "'");

                        break;
                    case ("editarBanner"):
                        rsLista = objBD.ExecutaSQL("select RED_ID, BAN_ID, BAN_LEGENDA, BAN_LINK, PAG_ID from  Banner where BAN_ID ='" + Request["BAN_ID"] + "'");
                        if (rsLista == null)
                        {
                            throw new Exception();
                        }
                        if (rsLista.HasRows)
                        {
                            rsLista.Read();
                            Response.Write(rsLista["RED_ID"] + "|" + rsLista["BAN_ID"] + "|" + rsLista["BAN_LEGENDA"] + "|" + rsLista["BAN_LINK"] + "|" + rsLista["PAG_ID"]);
                        }
                        break;
                    default:
                        PopulaLista();
                        PopulaExcluidos();
                        ListarRedes();
                        PopulaPaginas();
                        break;
                }
            }
            catch (Exception)
            {
                Response.Redirect("erro.aspx");
                throw;
            }
        }

        public void PopulaPaginas()
        {
            rsPagina = objBD.ExecutaSQL("SELECT PAG_ID, PAG_TITULO from Paginas");
            if (rsPagina == null)
            {
                throw new Exception();
            }
            if (rsPagina.HasRows)
            {
                while (rsPagina.Read())
                {
                    ListItem C = new ListItem();
                    C.Value = rsPagina["PAG_ID"].ToString();
                    C.Text = rsPagina["PAG_TITULO"].ToString();
                    PAG_ID.Items.Add(C);
                }
            }
        }

        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psBannerPorAtivo 1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:8px;\">ID</th>";
                divLista.InnerHtml += "         <th style=\"width:300px;\">Imagem</th>";
                divLista.InnerHtml += "         <th>Legenda</th>";
                divLista.InnerHtml += "         <th>Rede</th>";
                divLista.InnerHtml += "         <th>Link</th>";
                divLista.InnerHtml += "         <th style=\"width:71px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody>";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["BAN_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["BAN_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><img src=\"/upload/imagens/" + rsLista["PAG_PASTA"].ToString() + "/" + rsLista["BAN_IMAGEM"].ToString() + "\" style=\"width:300px;height:100px\" /></td>";
                    divLista.InnerHtml += "     <td>" + rsLista["BAN_LEGENDA"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["BAN_LINK"].ToString().Replace("javascript:void(0)", "-") + "</td>";

                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0)\" id='" + rsLista["BAN_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["BAN_ID"].ToString() + "' onclick='excluirBanner(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

        public void PopulaExcluidos()
        {
            divExcluidos.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psBannerPorAtivo 0");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th style=\"width:8px;\">ID</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:300px;\">Imagem</th>";
                divExcluidos.InnerHtml += "         <th>Legenda</th>";
                divExcluidos.InnerHtml += "         <th>Rede</th>";
                divExcluidos.InnerHtml += "         <th>Link</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:71px;\">Ações</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";

                divExcluidos.InnerHtml += " <tbody>";

                while (rsLista.Read())
                {
                    divExcluidos.InnerHtml += " <tr id='tr_" + rsLista["BAN_ID"].ToString() + "' class=\"\">";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["BAN_ID"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><img src=\"/upload/imagens/banners/" + rsLista["BAN_IMAGEM"].ToString() + "\" style=\"width:300px;height:100px\" /></td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["BAN_LEGENDA"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["BAN_LINK"].ToString().Replace("javascript:void(0)", "-") + "</td>";

                    divExcluidos.InnerHtml += "     <td><a href=\"javascript:void(0)\" id='" + rsLista["BAN_ID"].ToString() + "' onclick='restoreBanner(this.id);' class=\"img_del\"><img src=\"images/restore.png\"></a>";
                    divExcluidos.InnerHtml += " </tr>";
                }

                divExcluidos.InnerHtml += " </tbody>";
            }

            else
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th>Nenhum registro cadastrado até o momento!</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";
            }
            rsLista.Close();
            rsLista.Dispose();

            divExcluidos.InnerHtml += "</table>";
        }

        public void ListarRedes()
        {
            rsRedes = objBD.ExecutaSQL("EXEC ADMIN_psRedesPorAtivo 1");
            if (rsRedes == null)
            {
                throw new Exception();
            }
            if (rsRedes.HasRows)
            {

                while (rsRedes.Read())
                {
                    ListItem C = new ListItem();
                    C.Value = rsRedes["RED_ID"].ToString();
                    C.Text = rsRedes["RED_TITULO"].ToString();
                    RED_ID.Items.Add(C);


                }

            }
            rsRedes.Close();
            rsRedes.Dispose();
        }

        ImageFormat porextensao(FileUpload arq)
        {
            string ext = arq.FileName.Substring(arq.FileName.Length - Math.Min(3, arq.FileName.Length));
            switch (ext)
            {
                case "png":
                    return ImageFormat.Png;
                    break;
                case "gif":
                    return ImageFormat.Gif;
                    break;
                default:
                    return ImageFormat.Jpeg;
                    break;
            }
        }

        public void gravarBanner(object sender, EventArgs e)
        {
            try
            {

                string arquivo = "NULL", nome = "", filename = "", extensao = "";

                rsSize = objBD.ExecutaSQL("SELECT PAG_ALTURABANNER, PAG_LARGURABANNER, PAG_PASTA from Paginas where PAG_ID = " + Request["PAG_ID"]);
                if (rsSize == null) { throw new Exception(); }
                if (rsSize.HasRows)
                {
                    rsSize.Read();

                    int ALTURA = Convert.ToInt32(rsSize["PAG_ALTURABANNER"].ToString());
                    int LARGURA = Convert.ToInt32(rsSize["PAG_LARGURABANNER"].ToString());

                    if (BAN_IMAGEM.HasFile)
                    {
                        /* VERSÃO ZONARO
                         arquivo = BAN_IMAGEM.FileName.Replace(" ", "_");
                         System.Drawing.Image image = System.Drawing.Image.FromStream(BAN_IMAGEM.PostedFile.InputStream);
                         Graphics thumbnailGraph = Graphics.FromImage(image);
                         thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
                         thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
                         thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                         var imageRectangle = new Rectangle(0, 0, LARGURA, ALTURA);
                         Bitmap thumbnailBitmap = new Bitmap(LARGURA, ALTURA);
                         thumbnailGraph.DrawImage(image, imageRectangle);
                         thumbnailBitmap.Save(Server.MapPath("~/upload/imagens/banners") + "/" + arquivo, porextensao(BAN_IMAGEM));
                         thumbnailGraph.Dispose();
                         thumbnailBitmap.Dispose();
                         image.Dispose();
                         arquivo = "'" + arquivo + "'";*/

                        /*  VERSÃO FERNANDO */
                        HttpFileCollection hfc = Request.Files;
                        for (int i = 0; i < hfc.Count; i++)
                        {
                            HttpPostedFile hpf = hfc[i];
                            if (hpf.ContentLength > 0)
                            {
                                if (BAN_IMAGEM.PostedFile.ContentType == "image/jpeg" || BAN_IMAGEM.PostedFile.ContentType == "image/png" || BAN_IMAGEM.PostedFile.ContentType == "image/gif" || BAN_IMAGEM.PostedFile.ContentType == "image/bmp")
                                {
                                    //Pega o nome do arquivo
                                    nome = System.IO.Path.GetFileName(hpf.FileName);
                                    //Pega a extensão do arquivo
                                    extensao = Path.GetExtension(hpf.FileName);
                                    //Gera nome novo do Arquivo numericamente
                                    filename = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
                                    
                                    //cria a pasta se a mesma nao existir (por Zonaro)
                                    if (Directory.Exists(Server.MapPath("~/upload/imagens/" + rsSize["PAG_PASTA"] + "/")) == false)
                                    {
                                        Directory.CreateDirectory(Server.MapPath("~/upload/imagens/" + rsSize["PAG_PASTA"] + "/"));
                                    }

                                    //Caminho a onde será salvo
                                    hpf.SaveAs(Server.MapPath("~/upload/imagens/" + rsSize["PAG_PASTA"] + "/") + filename + i + extensao);

                                    var prefixo = "ban-";
                                    //pega o arquivo já carregado
                                    string pth = Server.MapPath("~/upload/imagens/" + rsSize["PAG_PASTA"] + "/") + filename + i + extensao;

                                    //Redefine altura e largura da imagem e Salva o arquivo + prefixo
                                    Redefinir.resizeImageAndSave(pth, LARGURA, ALTURA, prefixo);

                                    // File.Delete(Server.MapPath("~/upload/imagens/" + rsSize["PAG_PASTA"] + "/") + filename + i + extensao);
                                    arquivo = "ban-" + filename + i + extensao;
                                    break;
                                }
                            }
                        }
                    }
                }

                string link = Request["BAN_LINK"];
                if (link == null || link == "")
                {
                    link = "javascript:void(0)";
                }

                if (arquivo != "NULL" && arquivo != null) { arquivo = " '" + arquivo + "' "; }

                rsGravaBanner = objBD.ExecutaSQL("EXEC admin_piuBanner " + Request["BAN_ID"] + ", " + Request["RED_ID"] + ", '" + Request["BAN_LEGENDA"] + "', " + arquivo + ", '" + link + "', '" + Request["PAG_ID"] + "'");
                if (rsGravaBanner == null)
                {
                    throw new Exception();
                }

                //Libera o BD e Memória
                rsGravaBanner.Close();
                rsGravaBanner.Dispose();

                //Retornar para a Listagem
                Response.Redirect("banners.aspx");
                Response.End();
            }

            catch (Exception)
            {
                throw;
            }

        }

    }
}