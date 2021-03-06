﻿using System;
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
        private OleDbDataReader rsLista, rsGravar, rsNotificar, Categoria, rsRedes;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {
                case ("editarPost"):
                    rsLista = objBD.ExecutaSQL("exec admin_editarpost " + Request["POS_ID"]);
                    if (rsLista == null)
                    {
                        throw new Exception();
                    }
                    if (rsLista.HasRows)
                    {
                        rsLista.Read();
                        Response.Write(rsLista["POS_ID"] + "|" + rsLista["POS_TITULO"] + "|" + rsLista["POS_TEXTO"] + "|" + rsLista["POS_IMPORTANTE"] + "|" + rsLista["POS_CATEGORIA"] + "|" + "<img width='150px' src='/upload/imagens/blog/thumb-" + rsLista["POS_IMAGEM"].ToString() + "'>" + "|" + rsLista["RED_ID"].ToString());
                    }
                    break;
                case ("excluirPost"):
                    objBD.ExecutaSQL("admin_pudExcluirPostBlog " + Request["POS_ID"]);
                    break;
                case ("ativarPost"):
                    rsLista = objBD.ExecutaSQL("UPDATE PostBlog set POS_ATIVO = 1 where POS_ID ='" + Request["POS_ID"] + "'");
                    break;
                case ("FiltrarPesquisa"):
                    Response.Write(PopulaLista(1, Request["RED_ID"], Request["POS_TITULO"]));
                    Response.End();
                    break;
                case ("VerDetalhes"):
                    Response.Write(VerDetalhes(Request["POS_ID"]));
                    Response.End();
                    break;
                default:
                    populacategorias();
                    PopulaLista();
                    PopulaLista(0);
                    ListarRedes();
                    break;
            }
        }

        private string VerDetalhes(string id)
        {
            string retorno = "";
            OleDbDataReader rsResposta = objBD.ExecutaSQL("exec psDetalhesPost " + id);
            if (rsResposta == null)
            {
                throw new Exception();
            }
            if (rsResposta.HasRows)
            {
                int contador = 0;

                while (rsResposta.Read())
                {
                    retorno += "<table><tbody>";
                    // retorno += "<tr><td><img style='width:50%;' src='/upload/imagens/blog/" + rsResposta["POS_IMAGEM"] + " /></td></tr>";
                    retorno += "<tr><td><b>" + rsResposta["POS_TITULO"] + "<b></td></tr>";
                    retorno += "<tr><td><b>Categoria: </b>" + rsResposta["PCA_TITULO"] + "</td></tr>";
                    retorno += "<tr><td><b>Publicado as : </b>" + rsResposta["POS_DH_PUBLICACAO"] + " por  " + ("" + rsResposta["ADM_NOME"]).isNull("" + rsResposta["USU_NOME"], false) + "</td></tr>";
                    retorno += "<tr><td><br><br>" + rsResposta["POS_TEXTO"] + "</td></tr>";
                    retorno += "</tbody></table>";
                }
            }
            rsResposta.Close();
            rsResposta.Dispose();
            return retorno;
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

        public string PopulaLista(int ativo = 1, string RED_ID = "NULL", string POS_TITULO = "")
        {
            string objeto = "";
            objeto = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psPostBlogPorAtivo2 " + ativo + "," + RED_ID + ",'" + POS_TITULO + "'");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                objeto += " <thead>";
                objeto += "     <tr>";
                objeto += "         <th style=\"width:30px;\">ID</th>";
                objeto += "         <th style=\"width:120px;\">Imagem</th>";
                objeto += "         <th>Título</th>";
                objeto += "         <th>Rede</th>";
                objeto += "         <th>Usuário</th>";
                objeto += "         <th style=\"width:115px;\">Data Publicação</th>";
                objeto += "         <th style=\"width:85px;\">Ações</th>";
                objeto += "     </tr>";
                objeto += " </thead>";

                objeto += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    string tr = "tr_";

                    if (ativo == 0)
                    {
                        tr = "xtr_";
                    }

                    objeto += " <tr id='" + tr + rsLista["POS_ID"].ToString() + "' class=\"\">";
                    objeto += "     <td>" + rsLista["POS_ID"].ToString() + "</td>";
                    objeto += "     <td><img width='150px' src='/upload/imagens/blog/thumb-" + rsLista["POS_IMAGEM"].ToString() + "'></td>";
                    objeto += "     <td><a href='javascript:void(0)' onclick='VerDetalhes(" + rsLista["POS_ID"] + ")'>" + rsLista["POS_TITULO"].ToString() + "</a></td>";
                    objeto += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    objeto += "     <td>" + rsLista["USU_NOME"].ToString() + "</td>";
                    objeto += "     <td>" + rsLista["POS_DH_PUBLICACAO"].ToString() + "</td>";
                    if (ativo == 1)
                    {
                        //objeto += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["POS_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["POS_ID"].ToString() + "' onclick='excluirPost(this.id,\"desativar\");' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
                        objeto += "     <td><ul class=\"icons_table\">";
                        if (string.IsNullOrWhiteSpace(rsLista["USU_ID"].ToString()) == true)
                        {
                            objeto += "         <li><a href=\"javascript:void(0);\" id='" + rsLista["POS_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li>";
                        }
                        objeto += "         <li><a id='" + rsLista["POS_ID"].ToString() + "' onclick='excluirPost(this.id,\"desativar\");' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li>";
                        objeto += "    </td>";

                    }
                    else
                    {
                        objeto += "     <td><ul><li><a id='" + rsLista["POS_ID"].ToString() + "' onclick='restorePost(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/restore.png\"></a></li><li><a id='" + rsLista["POS_ID"].ToString() + "' onclick='excluirPost(this.id,\"excluir permanentemente\");' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul></td>";
                    }
                    objeto += " </tr>";
                }

                objeto += " </tbody>";
            }

            else
            {
                objeto += " <thead>";
                objeto += "     <tr>";
                objeto += "         <th>Nenhum registro cadastrado até o momento!</th>";
                objeto += "     </tr>";
                objeto += " </thead>";
            }
            rsLista.Close();
            rsLista.Dispose();

            objeto += "</table>";
            if (ativo == 1)
            {
                divLista.InnerHtml = objeto;
            }
            else
            {
                divExcluidos.InnerHtml = objeto;
            }
            return objeto;
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
                    FL_REDE_ID.Items.Add(C);

                }

            }
            rsRedes.Close();
            rsRedes.Dispose();
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
                                            var prefixoG = "big-";

                                            //pega o arquivo já carregado
                                            string pth = Server.MapPath("~/upload/imagens/blog/") + filename + i + extensao;

                                            //Redefine altura e largura da imagem e Salva o arquivo + prefixo
                                            Redefinir.resizeImageAndSave(pth, 190, 132, prefixoP);
                                            Redefinir.resizeImageAndSave(pth, 478, 332, prefixoG);

                                            // Salvar no BD
                                            rsGravar = objBD.ExecutaSQL("EXEC admin_piuPostBlog '" + Request["POS_ID"] + "',NULL, " + Request["RED_ID"] + ", " + Session["id"] + ",'" + Request["POS_TITULO"] + "','" + filename + i + extensao + "','" + Request["POS_TEXTO"].Replace("'", "\"") + "','" + Request["POS_IMPORTANTE"] + "', " + Request["PCA_ID"]);
                                            notificacoes();
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
                    else
                    {
                        rsGravar = objBD.ExecutaSQL("EXEC admin_piuPostBlog '" + Request["POS_ID"] + "',NULL, " + Request["RED_ID"] + ", " + Session["id"] + ",'" + Request["POS_TITULO"] + "',NULL,'" + Request["POS_TEXTO"].Replace("'", "\"") + "','" + Request["POS_IMPORTANTE"] + "', " + Request["PCA_ID"]);
                        notificacoes();
                        Response.Redirect("blog.aspx");
                    }

                }

                catch (Exception)
                {
                    Response.Write("Imagem não pode ser superior a 8 MB");
                }
            }
        }

        public void notificacoes()
        {
            rsNotificar = objBD.ExecutaSQL("EXEC admin_psNotificarPost '" + Request["POS_IMPORTANTE"] + "'," + Request["RED_ID"]);
            if (rsNotificar == null)
            {
                throw new Exception();
            }
            if (rsNotificar.HasRows)
            {

                while (rsNotificar.Read())
                {
                    if (Request["POS_IMPORTANTE"].ToString() == "1")
                    {
                        if (objUtils.EnviaEmail(rsNotificar["USU_EMAIL"].ToString(), Request["POS_TITULO"], "<center><h3>" + Request["POS_TITULO"] + "</h3></center><br>" + Request["POS_TEXTO"]) == false)
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        if (objUtils.EnviaEmail(rsNotificar["USU_EMAIL"].ToString(), "Novo post no portal Brincadeiras Musicais", "Um novo Post foi publicado no portal Brincadeiras Musicais da Palavra Cantada, confira agora mesmo no link: <a href=\"http://www.projetopalavracantada.net/post/" + objUtils.GerarURLAmigavel(Request["POS_TITULO"].ToString()) + "\">" + Request["POS_TITULO"] + "</a>") == false)
                        {
                            throw new Exception();
                        }
                    }
                }


            }
        }

    }
}