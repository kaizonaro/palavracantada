using Etnia.classe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais
{
    public partial class enviar_foto : System.Web.UI.Page
    {
        private utils objUtils = new utils();
        private bd objBD = new bd();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void gravar(object sender, EventArgs e)
        {
            if (FOT_IMAGEM.HasFile)
            {

                string arquivo = "NULL", nome = "", filename = "", extensao = "";
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        if (FOT_IMAGEM.PostedFile.ContentType == "image/jpeg" || FOT_IMAGEM.PostedFile.ContentType == "image/png" || FOT_IMAGEM.PostedFile.ContentType == "image/gif" || FOT_IMAGEM.PostedFile.ContentType == "image/bmp")
                        {
                            //Pega o nome do arquivo
                            nome = System.IO.Path.GetFileName(hpf.FileName);
                            //Pega a extensão do arquivo
                            extensao = Path.GetExtension(hpf.FileName);
                            //Gera nome novo do Arquivo numericamente
                            filename = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");

                            //cria a pasta se a mesma nao existir
                            if (Directory.Exists(Server.MapPath("~/upload/imagens/usuario/galeria")) == false)
                            {
                                Directory.CreateDirectory(Server.MapPath("~/upload/imagens/usuario/galeria"));
                            }

                            //Caminho a onde será salvo
                            hpf.SaveAs(Server.MapPath("~/upload/imagens/usuario/galeria") + filename + extensao);

                            var prefixo = "thumb-";
                            //pega o arquivo já carregado
                            string pth = Server.MapPath("~/upload/imagens/usuario/galeria") + filename + extensao;

                            //Redefine altura e largura da imagem e Salva o arquivo + prefixo
                            Redefinir.resizeImageAndSave(pth, 196, 110, prefixo);

                            // Salvar no BD
                            objBD.ExecutaSQL("EXEC admin_piuUsuarioFotos '" + Request["FOT_ID"] + "','" + Session["usuID"] + "', '" + filename + extensao + "','" + Request["FOT_LEGENDA"] + "'");

                            // File.Delete(Server.MapPath("~/upload/imagens/" + rsSize["PAG_PASTA"] + "/") + filename + i + extensao);
                            break;
                        }
                    }

                }
                /**/
            }

            //Retornar para a Listagem
            Response.Redirect("Minha-Galeria.aspx.aspx");
            Response.End();

        }
    }
}