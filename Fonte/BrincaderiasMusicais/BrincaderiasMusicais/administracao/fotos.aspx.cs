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
    public partial class fotos : System.Web.UI.Page
    {
        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsRedes, rsGravar;


        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {
                case ("excluirFoto"):
                    objBD.ExecutaSQL("UPDATE GaleriaFotos set GFO_ATIVO = 0 where GFO_ID = '" + Request["GFO_ID"] + "'");
                    break;
                case ("restaurarFoto"):
                    objBD.ExecutaSQL("UPDATE GaleriaFotos set GFO_ATIVO = 1 where GFO_ID = '" + Request["GFO_ID"] + "'");
                    break;

                default:
                    PopulaLista();
                    PopulaListaExcluidos();
                //    PopularRedes();
                    break;
            }
        }

        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psGaleriaFotosPorAtivo 1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:60px;\">ID</th>";
                divLista.InnerHtml += "         <th style=\"width:160px;\">Imagem</th>";
                divLista.InnerHtml += "         <th>Legenda</th>";
                divLista.InnerHtml += "         <th>Rede</th>";
                divLista.InnerHtml += "         <th style=\"width:175px;\">Data Publicação</th>";
                divLista.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["GFO_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["GFO_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><img width='150px' src='/upload/imagens/galeria/thumb-" + rsLista["GFO_IMAGEM"].ToString() + "'></td>";
                    divLista.InnerHtml += "     <td>" + rsLista["GFO_LEGENDA"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["GFO_DH_PUBLICACAO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["GFO_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["GFO_ID"].ToString() + "' onclick='excluirFoto(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
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

            rsLista = objBD.ExecutaSQL("EXEC admin_psGaleriaFotosPorAtivo 0");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th style=\"width:60px;\">ID</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:160px;\">Imagem</th>";
                divExcluidos.InnerHtml += "         <th>Legenda</th>";
                divExcluidos.InnerHtml += "         <th>Rede</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:175px;\">Data Publicação</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:85px;\">Ações</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";

                divExcluidos.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divExcluidos.InnerHtml += " <tr id='tr_" + rsLista["GFO_ID"].ToString() + "' class=\"\">";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["GFO_ID"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><img width='150px' src='/upload/imagens/galeria/thumb-" + rsLista["GFO_IMAGEM"].ToString() + "'></td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["GFO_LEGENDA"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["GFO_DH_PUBLICACAO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><ul class=\"icons_table\"><li><a id='" + rsLista["GFO_ID"].ToString() + "' onclick='restaurarFoto(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/restore.png\"></a></li></ul>";
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

        /*public void PopularRedes()
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
        } */

        public void gravar(object sender, EventArgs e)
        {
            if (GFO_IMAGEM.HasFile)
            {
                /*
                string arquivo = GFO_IMAGEM.FileName.Replace(" ", "-");

                GFO_IMAGEM.SaveAs(Server.MapPath("~/upload/imagens/galeria") + "/" + arquivo);

                rsGravar = objBD.ExecutaSQL("EXEC admin_piuGaleriaFotos '" + Request["GFO_ID"] + "'," + Request["RED_ID"] + ", '" + arquivo + "','" + Request["GFO_LEGENDA"] + "'");

                if (rsGravar == null)
                {
                    throw new Exception();
                }

                if (rsGravar.HasRows)
                {
                    rsGravar.Read();
                }

                //Libera o BD e Memória
                rsGravar.Close();
                rsGravar.Dispose();

                //Retornar para a Listagem
                Response.Redirect("fotos.aspx");
                Response.End();
                */
                string arquivo = "NULL", nome = "", filename = "", extensao = "";
                HttpFileCollection hfc = Request.Files;
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        if (GFO_IMAGEM.PostedFile.ContentType == "image/jpeg" || GFO_IMAGEM.PostedFile.ContentType == "image/png" || GFO_IMAGEM.PostedFile.ContentType == "image/gif" || GFO_IMAGEM.PostedFile.ContentType == "image/bmp")
                        {
                            //Pega o nome do arquivo
                            nome = System.IO.Path.GetFileName(hpf.FileName);
                            //Pega a extensão do arquivo
                            extensao = Path.GetExtension(hpf.FileName);
                            //Gera nome novo do Arquivo numericamente
                            filename = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
                            
                            //cria a pasta se a mesma nao existir
                            if (Directory.Exists(Server.MapPath("~/upload/imagens/galeria/")) == false)
                            {
                                Directory.CreateDirectory(Server.MapPath("~/upload/imagens/galeria/"));
                            }

                            //Caminho a onde será salvo
                            hpf.SaveAs(Server.MapPath("~/upload/imagens/galeria/") + filename + extensao);

                            var prefixo = "thumb-";
                            //pega o arquivo já carregado
                            string pth = Server.MapPath("~/upload/imagens/galeria/") + filename + extensao;

                            //Redefine altura e largura da imagem e Salva o arquivo + prefixo
                            Redefinir.resizeImageAndSave(pth, 196, 110, prefixo);

                            // Salvar no BD
                            objBD.ExecutaSQL("EXEC admin_piuGaleriaFotos '" + Request["GFO_ID"] + "',null, '" + filename + extensao + "','" + Request["GFO_LEGENDA"] + "'");

                            // File.Delete(Server.MapPath("~/upload/imagens/" + rsSize["PAG_PASTA"] + "/") + filename + i + extensao);
                            arquivo = filename + extensao;
                            break;
                        }
                    }

                }
                /**/
            }

            //Retornar para a Listagem
            Response.Redirect("fotos.aspx");
            Response.End();

        }
    }
}