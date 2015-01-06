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
    public partial class blog : System.Web.UI.Page
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
                case ("editarPost"):
                    rsLista = objBD.ExecutaSQL("select POS_ID, POS_TITULO, POS_TEXTO, POS_IMPORTANTE from  PostBlog where POS_ID ='" + Request["POS_ID"] + "'");
                    if (rsLista == null)
                    {
                        throw new Exception();
                    }
                    if (rsLista.HasRows)
                    {
                        rsLista.Read();
                        Response.Write(rsLista["POS_ID"] + "|" + rsLista["POS_TITULO"] + "|" + rsLista["POS_TEXTO"] + "|" + rsLista["POS_IMPORTANTE"]);
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

            rsLista = objBD.ExecutaSQL("EXEC admin_psPostBlogPorAtivo 1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:30px;\">ID</th>";
                divLista.InnerHtml += "         <th style=\"width:120px;\">Imagem</th>";
                divLista.InnerHtml += "         <th>Título</th>";
                divLista.InnerHtml += "         <th>Rede</th>";
                divLista.InnerHtml += "         <th style=\"width:115px;\">Data Publicação</th>";
                divLista.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["POS_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["POS_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><img width='150px' src='/upload/imagens/blog/thumb-" + rsLista["POS_IMAGEM"].ToString() + "'></td>";
                    divLista.InnerHtml += "     <td>" + rsLista["POS_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["POS_DH_PUBLICACAO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["POS_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["POS_ID"].ToString() + "' onclick='excluirPost(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

        public Int64 GerarID()
        {
            try
            {
                DateTime data = new DateTime();
                data = DateTime.Now;
                string s = data.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
                return Convert.ToInt64(s);
            }
            catch (Exception erro)
            {
                throw;
            }
        }

        public void gravar(object sender, EventArgs e)
        {
            if (POS_IMAGEM.PostedFile.ContentLength < 8388608)
            {
                try
                {
                    if (POS_IMAGEM.HasFile)
                    {
                        try
                        {
                            //Aqui ele vai filtrar pelo tipo de arquivo
                            if (POS_IMAGEM.PostedFile.ContentType == "image/jpeg" || POS_IMAGEM.PostedFile.ContentType == "image/png" || POS_IMAGEM.PostedFile.ContentType == "image/gif" || POS_IMAGEM.PostedFile.ContentType == "image/bmp")
                            {
                                try
                                {
                                    HttpFileCollection hfc = Request.Files;
                                    for (int i = 0; i < hfc.Count; i++)
                                    {
                                        HttpPostedFile hpf = hfc[i];
                                        if (hpf.ContentLength > 0)
                                        {
                                            //Pega o nome do arquivo
                                            string nome = System.IO.Path.GetFileName(hpf.FileName);
                                            //Pega a extensão do arquivo
                                            string extensao = Path.GetExtension(hpf.FileName);
                                            //Gera nome novo do Arquivo numericamente
                                            string filename = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
                                            //Caminho a onde será salvo
                                            hpf.SaveAs(Server.MapPath("~/upload/imagens/blog/") + filename + i + extensao);

                                            //Prefixo p/ img pequena
                                            var prefixoP = "thumb-";
                                            var prefixoG = "";

                                            //pega o arquivo já carregado
                                            string pth = Server.MapPath("~/upload/imagens/blog/") + filename + i + extensao;

                                            //Redefine altura e largura da imagem e Salva o arquivo + prefixo
                                            Redefinir.resizeImageAndSave(pth, 200, 130, prefixoP);
                                            Redefinir.resizeImageAndSave(pth, 600, 390, prefixoG);

                                            // Salvar no BD
                                            rsGravar = objBD.ExecutaSQL("EXEC admin_piuPostBlog '" + Request["POS_ID"] + "',NULL, NULL, '" + Session["id"] + "','" + Request["POS_TITULO"] + "','" + filename + i + extensao + "','" + Request["POS_TEXTO"] + "','" + Request["POS_IMPORTANTE"] + "' ");

                                            // inicia as notificações
                                            rsNotificar = objBD.ExecutaSQL("EXEC admin_psNotificarPost " + Request["POS_IMPORTANTE"]);
                                            if (rsNotificar == null)
                                            {
                                                throw new Exception();
                                            }
                                            if (rsNotificar.HasRows)
                                            {
                                                string destinatarios = "";
                                                while (rsNotificar.Read())
                                                {
                                                    destinatarios = rsNotificar["USU_EMAIL"] + ", ";
                                                }

                                                if (objUtils.EnviaEmail(destinatarios, "Novo post no portal Brincadeiras Musicais", "<h1>Acabamos de postar: <a href='#'>" + Request["POS_TITULO"] + "</a>") == false)
                                                {
                                                    throw new Exception();
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception)
                                {

                                }
                                // Mensagem se tudo ocorreu bem
                                Response.Redirect("blog.aspx");
                                Response.End();
                            }
                            else
                            {
                                // Mensagem notifica que é permitido carregar apenas as imagens definidas lá em cima

                            }
                        }
                        catch (Exception ex)
                        {
                            // Mensagem notifica quando ocorre erros
                            Response.Write(ex);
                            Response.End();
                        }
                    }
                }
                catch (Exception)
                {
                    Response.Write("Imagem não pode ser superior a 8 MB");
                }
            }
        }

    }
}