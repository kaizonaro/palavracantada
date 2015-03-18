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
    public partial class editar_foto : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rs;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            //Verificar se ainda está logado
            if (Session["nomeUsuario"] != null && Session["nomeUsuario"].ToString().Length > 1)
            {
                switch (Request["acao"])
                {
                    case ("ExcluirFoto"):
                        ExcluirFoto();
                        break;
                    default:
                        PopulaFotos();
                        break;
                }
            }
            else
            {
                //DESLOGADO
                Response.Redirect("/");
            }
        }

        public void PopulaFotos()
        {
            rs = objBD.ExecutaSQL("select USU_FOTO from Usuario where USU_ID = '" + Session["usuID"] + "' ");

            if (rs == null)
            {
                throw new Exception();
            }
            if (rs.HasRows)
            {
                rs.Read();

                if (rs["USU_FOTO"].ToString().Length < 1)
                {
                    mini_txt.InnerHtml += "Você ainda não definiu uma foto para o seu perfil.";
                }
                else
                {
                    FotoPerfil.Attributes.Add("src", "/upload/imagens/usuarios/" + rs["USU_FOTO"].ToString() + "");
                }
            }
        }

        public void gravar(object sender, EventArgs e)
        {
            if (upload_foto.HasFile)
            {

                string arquivo = "NULL", nome = "", filename = "", extensao = "";
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        if (upload_foto.PostedFile.ContentType == "image/jpeg" || upload_foto.PostedFile.ContentType == "image/png" || upload_foto.PostedFile.ContentType == "image/gif" || upload_foto.PostedFile.ContentType == "image/bmp")
                        {
                            //Pega o nome do arquivo
                            nome = System.IO.Path.GetFileName(hpf.FileName);
                            //Pega a extensão do arquivo
                            extensao = Path.GetExtension(hpf.FileName);
                            //Gera nome novo do Arquivo numericamente
                            filename = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");

                            //cria a pasta se a mesma nao existir
                            if (Directory.Exists(Server.MapPath("~/upload/imagens/usuarios/")) == false)
                            {
                                Directory.CreateDirectory(Server.MapPath("~/upload/imagens/usuarios/"));
                            }

                            //Caminho a onde será salvo
                            hpf.SaveAs(Server.MapPath("~/upload/imagens/usuarios/") + filename + extensao);

                            var prefixo = Session["usuID"]+"_";
                            //pega o arquivo já carregado
                            string pth = Server.MapPath("~/upload/imagens/usuarios/") + filename + extensao;

                            //Redefine altura e largura da imagem e Salva o arquivo + prefixo
                            Redefinir.resizeImageAndSave(pth, 140, 140,prefixo);
                            
                            
                            // Salvar no BD
                            objBD.ExecutaSQL("update Usuario set USU_FOTO = '" + prefixo +  filename + extensao + "' where USU_ID = '" + Session["usuID"] + "'");

                           // File.Delete(Server.MapPath("~/upload/imagens/usuarios/" + filename + extensao));
                            break;
                        }
                    }

                }
                /**/
            }
            //Retornar para a Listagem
            Response.Redirect("editar-foto-perfil");
            Response.End();
        }

        public void ExcluirFoto()
        {
            rs = objBD.ExecutaSQL("select USU_ID, USU_FOTO from Usuario where USU_ID = '" + Session["usuID"] + "' ");

            if (rs == null)
            {
                throw new Exception();
            }
            if (rs.HasRows)
            {
                rs.Read();

                if (rs["USU_FOTO"].ToString().Length < 1)
                {
                    Response.Redirect("editar-foto-perfil");
                    Response.End();
                }
                else
                {
                    //Excluir a foto fisicamente
                    //File.Delete(Server.MapPath("~/upload/imagens/usuarios/" + rs["USU_FOTO"].ToString()));
                    //File.Delete(Server.MapPath("~/upload/imagens/usuarios/" + rs["USU_FOTO"].ToString().Replace("" + rs["USU_ID"] + "_", "")));

                    //Excluir a foto do BD;
                    objBD.ExecutaSQL("update Usuario set USU_FOTO = null where USU_ID = '" + Session["usuID"] + "' ");
                }
            }

            //Retornar para a Listagem
            Response.Redirect("editar-foto-perfil");
            Response.End();

        }
    }
}