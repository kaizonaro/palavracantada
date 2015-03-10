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
    public partial class equipe : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsGravar;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {
                case ("editar"):
                    rsLista = objBD.ExecutaSQL("select EQU_ID, EQU_NOME, EQU_DESCRICAO from  Equipe where EQU_ID ='" + Request["EQU_ID"] + "'");
                    if (rsLista == null)
                    {
                        throw new Exception();
                    }
                    if (rsLista.HasRows)
                    {
                        rsLista.Read();
                        Response.Write(rsLista["EQU_ID"] + "|" + rsLista["EQU_NOME"] + "|" + rsLista["EQU_DESCRICAO"]);
                    }
                    break;
                case ("ativar"):
                    objBD.ExecutaSQL("update equipe set EQU_ativo = 1 where EQU_ID = " + Convert.ToInt16(Request["EQU_ID"].ToString()));
                    break;
                case ("desativar"):
                    objBD.ExecutaSQL("admin_pudExcluirEquipe " + Convert.ToInt16(Request["EQU_ID"].ToString()));
                    break;

                default:
                    PopulaLista();
                    PopulaExcluidos();
                    break;
            }
        }



        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("SELECT * from Equipe where EQU_ATIVO =  1 and EQU_MANAGER = 0");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:30px;\">ID</th>";
                divLista.InnerHtml += "         <th style=\"width:120px;\">Foto</th>";
                divLista.InnerHtml += "         <th>Nome</th>";
                divLista.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["EQU_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["EQU_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><img width='150px' src='/upload/imagens/equipe/" + rsLista["EQU_FOTO"].ToString() + "'></td>";
                    divLista.InnerHtml += "     <td>" + rsLista["EQU_NOME"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["EQU_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["EQU_ID"].ToString() + "' onclick='excluirPost(this.id,\"desativar\");' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

            rsLista = objBD.ExecutaSQL("SELECT * from Equipe where EQU_ATIVO =  0");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th style=\"width:30px;\">ID</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:120px;\">Foto</th>";
                divExcluidos.InnerHtml += "         <th>Nome</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";

                divExcluidos.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divExcluidos.InnerHtml += " <tr id='tr_" + rsLista["EQU_ID"].ToString() + "' class=\"\">";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["EQU_ID"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><img width='150px' src='/upload/imagens/equipe/" + rsLista["EQU_FOTO"].ToString() + "'></td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["EQU_NOME"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><li><a id='" + rsLista["EQU_ID"].ToString() + "' onclick='restorePost(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/restore.png\"></a></li><li><a id='" + rsLista["EQU_ID"].ToString() + "' onclick='excluirPost(this.id,\"excluir definitivamente\");' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

            if (EQU_FOTO.PostedFile.ContentLength < 8388608)
            {
                try
                {
                    if (EQU_FOTO.HasFile)
                    {
                        try
                        {
                            //Aqui ele vai filtrar pelo tipo de arquivo
                            if (EQU_FOTO.PostedFile.ContentType == "image/jpeg" || EQU_FOTO.PostedFile.ContentType == "image/png" || EQU_FOTO.PostedFile.ContentType == "image/gif" || EQU_FOTO.PostedFile.ContentType == "image/bmp")
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
                                            string filename = Request["EQU_NOME"].ToString().Replace(" ", "_");
                                            //Caminho a onde será salvo
                                            hpf.SaveAs(Server.MapPath("~/upload/imagens/equipe/") + filename + extensao);

                                            rsGravar = objBD.ExecutaSQL("EXEC admin_piuEquipe  '" + Request["EQU_ID"] + "', '" + Request["EQU_NOME"] + "', '" + filename + extensao + "', '" + Request["EQU_DESCRICAO"] + "'");

                                        }
                                    }
                                }
                                catch (Exception)
                                {

                                }
                                // Mensagem se tudo ocorreu bem
                                Response.Redirect("equipe.aspx");
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
                        if (Convert.ToInt32(Request["EQU_ID"].ToString()) > 0)
                        {
                            rsGravar = objBD.ExecutaSQL("EXEC admin_piuEquipe  '" + Request["EQU_ID"] + "', '" + Request["EQU_NOME"] + "', NULL, '" + Request["EQU_DESCRICAO"] + "'");
                        }
                        else
                        {
                            rsGravar = objBD.ExecutaSQL("EXEC admin_piuEquipe  '" + Request["EQU_ID"] + "', '" + Request["EQU_NOME"] + "', 'sem-foto.png', '" + Request["EQU_DESCRICAO"] + "'");
                        }

                    }
                }
                catch (Exception)
                {
                    Response.Write("Imagem não pode ser superior a 8 MB");
                }
            }

            else
            {
                if (Convert.ToInt32(Request["EQU_ID"].ToString()) > 0)
                {
                    rsGravar = objBD.ExecutaSQL("EXEC admin_piuEquipe  '" + Request["EQU_ID"] + "', '" + Request["EQU_NOME"] + "', NULL, '" + Request["EQU_DESCRICAO"] + "'");
                }
                else
                {
                    rsGravar = objBD.ExecutaSQL("EXEC admin_piuEquipe  '" + Request["EQU_ID"] + "', '" + Request["EQU_NOME"] + "', 'sem-foto.png', '" + Request["EQU_DESCRICAO"] + "'");
                }
            }
            Response.Redirect("equipe.aspx");
        }

    }
}