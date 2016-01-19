using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;

namespace BrincaderiasMusicais
{
    public partial class enviar_post : System.Web.UI.Page
    {
        private utils objUtils = new utils();
        private bd objBD = new bd();
        private OleDbDataReader rsGravar, Categoria, rsTrazer, rsMedalhas, rsPosts;


        protected void Page_Load(object sender, EventArgs e)
        {
            objBD = new bd();
            objUtils = new utils();
            switch (Request["acao"])
            {
                case "validapost":
                    rsPosts = objBD.ExecutaSQL("SELECT POS_TITULO from PostBlog where POS_TITULO='" + Request["POS_TITULO"] + "'");
                    if (rsPosts.HasRows)
                    {
                        Response.Write("FAIL");
                    }
                    else
                    {
                        Response.Write("PASS");
                    }
                    Response.End();
                    break;

                default:
                    break;
            }
            populacategorias();

            if (string.IsNullOrWhiteSpace(Request["POS_ID"]) == false)
            {
                rsTrazer = objBD.ExecutaSQL("EXEC psPostBlogPorID " + Request["POS_ID"]);
                if (rsTrazer == null)
                {
                    throw new Exception();
                }

                if (rsTrazer.HasRows)
                {
                    rsTrazer.Read();
                    POS_TITULO.Attributes.Add("value", rsTrazer["POS_TITULO"].ToString());
                    POS_TEXTO.InnerText = rsTrazer["POS_TEXTO"].ToString();
                    PCA_ID.Value = rsTrazer["PCA_ID"].ToString();
                    posID.Value = Request["POS_ID"];

                }
            }
        }

        public void populacategorias()
        {
            bd objBd = new bd();
            Categoria = objBd.ExecutaSQL("SELECT * FROM PostCategoria");
            if (Categoria == null)
            {
                throw new Exception();
            }
            if (Categoria.HasRows)
            {
                while (Categoria.Read())
                {
                    PCA_ID.Items.Add(new ListItem(Categoria["PCA_TITULO"].ToString(), Categoria["PCA_ID"].ToString()));
                }
            }
        }

        public void gravar(object sender, EventArgs e)
        {
            if (POS_IMAGEM.PostedFile.ContentLength < 8388608)
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
                                        var prefixoG = "big-";

                                        //pega o arquivo já carregado
                                        string pth = Server.MapPath("~/upload/imagens/blog/") + filename + i + extensao;

                                        //Redefine altura e largura da imagem e Salva o arquivo + prefixo
                                        Redefinir.resizeImageAndSave(pth, 190, 132, prefixoP);
                                        Redefinir.resizeImageAndSave(pth, 478, 332, prefixoG);

                                        // Salvar no BD
                                        rsGravar = objBD.ExecutaSQL("EXEC admin_piuPostBlog '" + Request["POS_ID"] + "','" + Session["usuID"] + "', '" + Session["redeID"] + "', null, '" + Request["POS_TITULO"] + "', '" + filename + i + extensao + "','" + Request["POS_TEXTO"] + "',0," + Request["PCA_ID"]);
                                        objUtils.EnviaEmail(Session["usuEmail"].ToString(), "Post Publicado com sucesso!", "Parabéns, seu post acabou de ser publicado!");
                                        VerificarMedalhas();
                                        Response.Redirect("./meu-perfil/" + Session["usuUsuario"].ToString() + "?alert=Post publicado com sucesso!");

                                    }
                                }
                            }
                            catch (Exception)
                            {

                            }

                            // Mensagem se tudo ocorreu bem
                            // Response.Redirect("meu-perfil");
                            Response.Redirect("/meu-post/" + objUtils.GerarURLAmigavel(Request["POS_TITULO"].ToString()) + "?alert=Post publicado com sucesso!");
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
                else
                {
                    rsGravar = objBD.ExecutaSQL("EXEC admin_piuPostBlog '" + Request["POS_ID"] + "','" + Session["usuID"] + "','" + Session["redeID"] + "', null,'" + Request["POS_TITULO"] + "',NULL,'" + Request["POS_TEXTO"].Replace("'", "\"") + "','0', " + Request["PCA_ID"]);
                    objUtils.EnviaEmail(Session["usuEmail"].ToString(), "Post Enviado com sucesso!", "Parabéns, seu post  acabou de ser enviado!");
                    VerificarMedalhas();
                    Response.Clear();
                    Response.Redirect("./meu-perfil/" + Session["usuUsuario"].ToString() + "?alert=Post publicado com sucesso!");
                }
                //notificacoes();
            }


        }
    

    public void VerificarMedalhas()
    {
        rsMedalhas = objBD.ExecutaSQL("SELECT COUNT(*) as TOTAL_BLOG FROM PostBlog where USU_ID = " + Session["usuID"] + "");

        if (rsMedalhas == null)
        {
            throw new Exception();
        }
        if (rsMedalhas.HasRows)
        {
            rsMedalhas.Read();
            if (Convert.ToInt16(rsMedalhas["TOTAL_BLOG"]) == 3)
            {
                objBD.ExecutaSQL("insert into Log (USU_ID, LOG_ACONTECIMENTO, LOG_EXIBIR) VALUES ('" + Session["usuID"] + "','Parabéns! Você ganhou a medalha BLOGUEIRO por publicar 3 posts em seu blog pessoal.','1')");
            }
        }
    }
}
}