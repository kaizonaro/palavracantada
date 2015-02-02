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
    public partial class artigos : System.Web.UI.Page
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
                case ("editarArtigo"):
                    rsLista = objBD.ExecutaSQL("EXEC admin_psEditarArtigo " + Request["ART_ID"]);
                    if (rsLista == null)
                    {
                        throw new Exception();
                    }
                    if (rsLista.HasRows)
                    {
                        rsLista.Read();
                        Response.Write(rsLista["ART_ID"] + "|" + rsLista["ART_TITULO"] + "|" + rsLista["ART_DESCRICAO"]);
                    }
                    break;
                case ("AtivarArtigo"):
                    objBD.ExecutaSQL("UPDATE Artigo set ART_ATIVO = 1 where ART_ID = " + Request["ART_ID"]);
                    break;
                case ("ExcluirArtigo"):
                    objBD.ExecutaSQL("UPDATE Artigo set ART_ATIVO = 0 where ART_ID = " + Request["ART_ID"]);
                    break;
                default:
                    PopulaLista();
                    PopulaListaExcluidos();
                    break;
            }
        }

        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psArtigoPorAtivo 1");
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
                divLista.InnerHtml += "         <th style=\"width:115px;\">Data Publicação</th>";
                divLista.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["ART_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["ART_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><img width='150px' src='../upload/imagens/artigo/thumb-" + rsLista["ART_IMAGEM"].ToString() + "'></td>";
                    divLista.InnerHtml += "     <td>" + rsLista["ART_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["ART_DH_PUBLICACAO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["ART_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["ART_ID"].ToString() + "' onclick='excluirArtigo(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

        public void PopulaListaExcluidos()
        {
            divExcluidos.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psArtigoPorAtivo 0");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th style=\"width:30px;\">ID</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:120px;\">Imagem</th>";
                divExcluidos.InnerHtml += "         <th>Título</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:115px;\">Data Publicação</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";

                divExcluidos.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divExcluidos.InnerHtml += " <tr id='tr_" + rsLista["ART_ID"].ToString() + "' class=\"\">";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["ART_ID"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><img width='150px' src='../upload/imagens/artigo/thumb-" + rsLista["ART_IMAGEM"].ToString() + "'></td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["ART_TITULO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["ART_DH_PUBLICACAO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><a href=\"javascript:void(0)\" id='" + rsLista["ART_ID"].ToString() + "' onclick='restoreArtigo(this.id);' class=\"img_del\"><img src=\"images/restore.png\"></a>";
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

        public void FiltrarPesquisa()
        {
            string retorno  = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psArtigoPorAtivo 1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                retorno  += " <thead>";
                retorno  += "     <tr>";
                retorno  += "         <th style=\"width:30px;\">ID</th>";
                retorno  += "         <th style=\"width:120px;\">Imagem</th>";
                retorno  += "         <th>Título</th>";
                retorno  += "         <th style=\"width:115px;\">Data Publicação</th>";
                retorno  += "         <th style=\"width:85px;\">Ações</th>";
                retorno  += "     </tr>";
                retorno  += " </thead>";

                retorno  += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    retorno  += " <tr id='tr_" + rsLista["ART_ID"].ToString() + "' class=\"\">";
                    retorno  += "     <td>" + rsLista["ART_ID"].ToString() + "</td>";
                    retorno  += "     <td><img width='150px' src='../upload/imagens/artigo/thumb-" + rsLista["ART_IMAGEM"].ToString() + "'></td>";
                    retorno  += "     <td>" + rsLista["ART_TITULO"].ToString() + "</td>";
                    retorno  += "     <td>" + rsLista["ART_DH_PUBLICACAO"].ToString() + "</td>";
                    retorno  += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["ART_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["ART_ID"].ToString() + "' onclick='excluirArtigo(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
                    retorno  += " </tr>";
                }

                retorno  += " </tbody>";
            }

            else
            {
                retorno  += " <thead>";
                retorno  += "     <tr>";
                retorno  += "         <th>Nenhum registro cadastrado até o momento!</th>";
                retorno  += "     </tr>";
                retorno  += " </thead>";
            }
            rsLista.Close();
            rsLista.Dispose();

            retorno  += "</table>";
            Response.Write(retorno);
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
            string nome = "", filename = "", extensao = "", nomepdf = "";

            if (ART_IMAGEM.PostedFile.ContentLength < 8388608)
            {
                try
                {
                    if (ART_IMAGEM.HasFile)
                    {
                        try
                        {

                            HttpFileCollection hfc = Request.Files;
                            for (int i = 0; i < hfc.Count; i++)
                            {
                                HttpPostedFile hpf = hfc[i];
                                if (hpf.ContentLength > 0)
                                {
                                    if (ART_IMAGEM.PostedFile.ContentType == "image/jpeg" || ART_IMAGEM.PostedFile.ContentType == "image/png" || ART_IMAGEM.PostedFile.ContentType == "image/gif" || ART_IMAGEM.PostedFile.ContentType == "image/bmp")
                                    {

                                        //Pega o nome do arquivo
                                        nome = System.IO.Path.GetFileName(hpf.FileName);
                                        //Pega a extensão do arquivo
                                        extensao = Path.GetExtension(hpf.FileName);
                                        //Gera nome novo do Arquivo numericamente
                                        filename = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
                                        //Caminho a onde será salvo
                                        hpf.SaveAs(Server.MapPath("~/upload/imagens/artigo/") + filename + i + extensao);

                                        //Prefixo p/ img pequena
                                        var prefixoP = "thumb-";
                                        var prefixoG = "big-";

                                        //pega o arquivo já carregado
                                        string pth = Server.MapPath("~/upload/imagens/artigo/") + filename + i + extensao;

                                        //Redefine altura e largura da imagem e Salva o arquivo + prefixo
                                        Redefinir.resizeImageAndSave(pth, 200, 130, prefixoP);
                                        Redefinir.resizeImageAndSave(pth, 600, 390, prefixoG);
                                        break;
                                    }

                                    // Salvar no BD


                                }
                            }
                            nomepdf = Request["ART_TITULO"] + "_" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "") + ".pdf";
                            ART_PDF.SaveAs(Server.MapPath("~/upload/imagens/artigo/pdf/") + nomepdf);

                            rsGravar = objBD.ExecutaSQL("EXEC admin_piuArtigos '" + Request["ART_ID"] + "', '" + Request["ART_TITULO"] + "', '" + Session["id"] + "', '" + Request["ART_DESCRICAO"] + "', '" + filename + extensao + "', '" + nomepdf + "'");

                            // Mensagem se tudo ocorreu bem
                            // Response.Redirect("artigos.aspx");
                            Response.End();

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