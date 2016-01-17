using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace BrincaderiasMusicais
{
    public partial class galeria_geral : System.Web.UI.Page
    {
        private bd objBD = new bd();
        private utils objUtils = new utils();
        private OleDbDataReader rsGaleria;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["acao"] == "gravavideo")
            {
                gravavideo();
                Response.Redirect("galeria-geral.aspx?sucesso=2&alert=Seu video foi enviado com sucesso e passará pelo processo de moderação dos administradores do Projeto Brincadeiras Musicais da Palavra Cantada. Agradecemos a sua participação!");

            }

            switch (Convert.ToInt32(Request["sucesso"]))
            {

                case 1:
                    fotodiv.InnerHtml = "<p class='pAvisoGaleria'>Sua foto foi enviada com sucesso e passará pelo processo de moderação dos administradores do Projeto Brincadeiras Musicais da Palavra Cantada. Agradecemos a sua participação!</p>";
                    fotodiv.InnerHtml += "<button class=\"btn_back up_forum\" style=\"margin-top: 20px; margin-bottom: 20px; cursor: pointer;\" onclick=\"location.href='/galeria-colaborativa'; return false;\">Voltar</button>";
                    break;
                case 2:
                    videodiv.InnerHtml = "<p class='pAvisoGaleria'>Seu vídeo foi enviado com sucesso e passará pelo processo de moderação dos administradores do Projeto Brincadeiras Musicais da Palavra Cantada. Agradecemos a sua participação!</p>";
                    videodiv.InnerHtml += "<button class=\"btn_back up_forum\" style=\"margin-top: 20px; margin-bottom: 20px; cursor: pointer;\" onclick=\"location.href='/galeria-colaborativa'; return false;\">Voltar</button>";
                    break;
                default:
                    break;
            }

            rsGaleria = objBD.ExecutaSQL("EXEC psGaleriaColaborativa " + Session["redeID"]);
            if (rsGaleria == null) { throw new Exception(); }
            if (rsGaleria.HasRows)
            {
                while (rsGaleria.Read())
                {
                    ulFotos.InnerHtml += "<li><a href=\"/upload/imagens/galeriacolaborativa/" + rsGaleria["COF_IMAGEM"] + "\">" +
                    "<img src=\"/upload/imagens/galeriacolaborativa/thumb-" + rsGaleria["COF_IMAGEM"] + "\" alt=\" " + rsGaleria["COF_LEGENDA"] + "\"></a>" +
                    "<p>:: " + rsGaleria["COF_LEGENDA"] + " ::</p>" +                    
                    "</li>";

                }
            }

            rsGaleria.NextResult();

            if (rsGaleria.HasRows)
            {

                while (rsGaleria.Read())
                {
                    ulVideos.InnerHtml += "<li class=\"\" style=\"width: 196px;\"><a href=\"" + rsGaleria["COV_VIDEO_ID"] + "\">" +
                    "<img src=\"http://i.ytimg.com/vi/" + rsGaleria["COV_VIDEO_ID"] + "/mqdefault.jpg\" alt=\"" + rsGaleria["COV_TITULO"] + "\">" +
                    "</a>" +
                    "<p>:: " + rsGaleria["COV_TITULO"] + " ::</p>" +
                    "<span>" + rsGaleria["COV_DESCRICAO"].ToString() + "</span>" +
                    "</li>";
                }
            }

            rsGaleria.NextResult();

            if (rsGaleria.HasRows)
            {

                rsGaleria.Read();
                nomerede1.InnerText = rsGaleria["RED_TITULO"].ToString();
                nomerede2.InnerText = rsGaleria["RED_TITULO"].ToString();
            }

        }

        private void gravavideo()
        {
            string videoid = objUtils.getYoutubeVideoId(Request["COV_LINK"]);
            if (string.IsNullOrWhiteSpace(videoid))
            {
                Response.Write("insira um video do youtube válido");
            }
            else
            {
                objBD.ExecutaSQL("insert into ColaborativaVideos (RED_ID, USU_ID, COV_TITULO, COV_DESCRICAO, COV_VIDEO_ID) values ('" + Session["redeID"] + "','" + Session["usuID"] + "', '" + Request["COV_TITULO"] + "','" + Request["COV_DESCRICAO"] + "', '" + videoid + "')");
                string mensagem = "O usuario "+Session["nomeUsuario"].ToString()+ " enviou um novo <a href='https://www.youtube.com/watch?v="+videoid+"' target='_blank'>video</a>. Entre na area administrativa para aprovar ou reprovar.";
                objUtils.EnviaEmail("zonaro@outlook.com", "Galeria Colaborativa | Video", mensagem, nome: Session["nomeUsuario"].ToString());
            }
        }


        public void gravar(object sender, EventArgs e)
        {
            if (COF_IMAGEM.HasFile)
            {

                string arquivo = "NULL", nome = "", filename = "", extensao = "";
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        if (COF_IMAGEM.PostedFile.ContentType == "image/jpeg" || COF_IMAGEM.PostedFile.ContentType == "image/png" || COF_IMAGEM.PostedFile.ContentType == "image/gif" || COF_IMAGEM.PostedFile.ContentType == "image/bmp")
                        {
                            //Pega o nome do arquivo
                            nome = System.IO.Path.GetFileName(hpf.FileName);
                            //Pega a extensão do arquivo
                            extensao = Path.GetExtension(hpf.FileName);
                            //Gera nome novo do Arquivo numericamente
                            filename = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");

                            //cria a pasta se a mesma nao existir
                            if (Directory.Exists(Server.MapPath("~/upload/imagens/galeriacolaborativa/")) == false)
                            {
                                Directory.CreateDirectory(Server.MapPath("~/upload/imagens/galeriacolaborativa/"));
                            }

                            //Caminho a onde será salvo
                            hpf.SaveAs(Server.MapPath("~/upload/imagens/galeriacolaborativa/") + filename + extensao);

                            //pega o arquivo já carregado
                            string pth = Server.MapPath("~/upload/imagens/galeriacolaborativa/") + filename + extensao;

                            //Redefine altura e largura da imagem e Salva o arquivo + prefixo
                            Redefinir.resizeImageAndSave(pth, 196, 110, "thumb-");

                            // Salvar no BD
                            objBD.ExecutaSQL("insert into ColaborativaFotos (RED_ID, USU_ID, COF_IMAGEM, COF_LEGENDA) values ('" + Session["redeID"] + "','" + Session["usuID"] + "', '" + filename + extensao + "','" + Request["COF_LEGENDA"] + "')");
                            string mensagem = "O usuario " + Session["nomeUsuario"].ToString() + " enviou uma nova foto. Entre na area administrativa para aprovar ou reprovar.";
                            objUtils.EnviaEmail("zonaro@outlook.com", "Galeria Colaborativa | Foto", mensagem, nome: Session["nomeUsuario"].ToString());
           
                            // File.Delete(Server.MapPath("~/upload/imagens/" + rsSize["PAG_PASTA"] + "/") + filename + i + extensao);
                            break;
                        }
                    }

                }
                /**/
            }

            //Retornar para a Listagem
            Response.Redirect("galeria-geral.aspx?sucesso=1&alert=Sua foto foi enviada com sucesso e passará pelo processo de moderação dos administradores do Projeto Brincadeiras Musicais da Palavra Cantada. Agradecemos a sua participação!");
            Response.End();

        }

    }
}



