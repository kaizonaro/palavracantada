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
    public partial class usuarios : System.Web.UI.Page
    {

        private bd objBD;
        private utils objUtils;
        private OleDbDataReader rsLista, rsRede, rsGravaUsuario, rsEditar, rsUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUtils = new utils();
            objBD = new bd();

            switch (Request["acao"])
            {
                case ("ValidarUsuario"):
                    ValidarUsuario();
                    break;
                case ("gravarUsuario"):
                    gravarUsuario();
                    break;
                case ("excluirUsuario"):
                    excluirUsuario();
                    break;
                case ("AtivarUsuario"):
                    AtivarUsuario();
                    break;
                case ("FiltrarPesquisa"):
                    FiltrarPesquisa(Request["RED_ID"], Request["USU_NOME"], Request["USU_EMAIL"]);
                    break;

                default:
                    PopulaLista();
                    PopularRedes();
                    PopulaExcluidos();
                    break;
            }

        }

        public void PopulaLista()
        {
            divLista.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psUsusarioPorAtivo 1");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divLista.InnerHtml += " <thead>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <th style=\"width:8px;\">ID</th>";
                divLista.InnerHtml += "         <th style=\"width:120px;\">Nome</th>";
                divLista.InnerHtml += "         <th>E-Mail</th>";
                divLista.InnerHtml += "         <th>Acessos</th>";
                divLista.InnerHtml += "         <th style=\"width:80px;\">Último Acesso</th>";
                divLista.InnerHtml += "         <th>Rede</th>";
                divLista.InnerHtml += "         <th style=\"width:61px;\">Ações</th>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </thead>";

                divLista.InnerHtml += " <tbody id=\"tbCentral\">";

                while (rsLista.Read())
                {
                    divLista.InnerHtml += " <tr id='tr_" + rsLista["USU_ID"].ToString() + "' class=\"\">";
                    divLista.InnerHtml += "     <td>" + rsLista["USU_ID"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["USU_NOME"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["USU_EMAIL"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["USU_QTD_ACESSO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["USU_DH_ULTIMO_ACESSO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divLista.InnerHtml += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["USU_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["USU_ID"].ToString() + "' onclick='excluirUsuario(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
                    divLista.InnerHtml += " </tr>";
                }

                divLista.InnerHtml += " </tbody>";
            }

            else
            {
                divLista.InnerHtml += " <tbody>";
                divLista.InnerHtml += "     <tr>";
                divLista.InnerHtml += "         <td colspan=\"7\">Nenhum registro cadastrado até o momento!</td>";
                divLista.InnerHtml += "     </tr>";
                divLista.InnerHtml += " </tbody>";
            }
            rsLista.Close();
            rsLista.Dispose();

            divLista.InnerHtml += "</table>";
        }

        public void PopulaExcluidos()
        {
            divExcluidos.InnerHtml = "<table class=\"table\" id=\"tabela\" cellspacing=\"0\">";

            rsLista = objBD.ExecutaSQL("EXEC admin_psUsusarioINATIVO");
            if (rsLista == null)
            {
                throw new Exception();
            }
            if (rsLista.HasRows)
            {
                divExcluidos.InnerHtml += " <thead>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th style=\"width:8px;\">ID</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:120px;\">Nome</th>";
                divExcluidos.InnerHtml += "         <th>E-Mail</th>";
                divExcluidos.InnerHtml += "         <th>Acessos</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:80px;\">Último Acesso</th>";
                divExcluidos.InnerHtml += "         <th>Rede</th>";
                divExcluidos.InnerHtml += "         <th style=\"width:61px;\">Ações</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </thead>";

                divExcluidos.InnerHtml += " <tbody>";

                while (rsLista.Read())
                {
                    divExcluidos.InnerHtml += " <tr id='tr_" + rsLista["USU_ID"].ToString() + "' class=\"\">";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["USU_ID"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["USU_NOME"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["USU_EMAIL"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["USU_QTD_ACESSO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["USU_DH_ULTIMO_ACESSO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    divExcluidos.InnerHtml += "     <td><a href=\"javascript:void(0)\" id='" + rsLista["USU_ID"].ToString() + "' onclick='restoreUsuario(this.id);' class=\"img_del\"><img src=\"images/restore.png\"></a>";
                    divExcluidos.InnerHtml += " </tr>";
                }

                divExcluidos.InnerHtml += " </tbody>";
            }

            else
            {
                divExcluidos.InnerHtml += " <tbody>";
                divExcluidos.InnerHtml += "     <tr>";
                divExcluidos.InnerHtml += "         <th>Nenhum registro cadastrado até o momento!</th>";
                divExcluidos.InnerHtml += "     </tr>";
                divExcluidos.InnerHtml += " </tbody>";
            }
            rsLista.Close();
            rsLista.Dispose();

            divExcluidos.InnerHtml += "</table>";
        }

        public void PopularRedes()
        {
            rsRede = objBD.ExecutaSQL("EXEC admin_psRedesPorAtivo 1");
            if (rsRede == null)
            {
                throw new Exception();
            }
            if (rsRede.HasRows)
            {
                while (rsRede.Read())
                {
                    System.Web.UI.WebControls.ListItem R = new System.Web.UI.WebControls.ListItem();
                    R.Value = rsRede["RED_ID"].ToString();
                    R.Text = rsRede["RED_CIDADE"].ToString() + " | " + rsRede["RED_UF"].ToString();
                    RED_ID.Items.Add(R);
                    FL_REDE_ID.Items.Add(R);
                }
            }
            rsRede.Close();
            rsRede.Dispose();
        }

        public void gravarUsuario()
        {

            string filename = "NULL", nome = "", extensao = "";
            HttpFileCollection hfc = Request.Files;
            for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                if (hpf.ContentLength > 0)
                {
                    if (USU_FOTO.PostedFile.ContentType == "image/jpeg" || USU_FOTO.PostedFile.ContentType == "image/png" || USU_FOTO.PostedFile.ContentType == "image/gif" || USU_FOTO.PostedFile.ContentType == "image/bmp")
                    {
                        //Pega o nome do arquivo
                        nome = System.IO.Path.GetFileName(hpf.FileName);
                        //Pega a extensão do arquivo
                        extensao = Path.GetExtension(hpf.FileName);
                        //Gera nome novo do Arquivo numericamente
                        if (Convert.ToInt32(Request["USU_ID"].ToString()) == 0)
                        {
                            filename = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
                        }
                        else
                        {
                            filename = Request["USU_ID"].ToString() + "_" + Request["USU_NOME"].ToString();
                        }
                        //cria a pasta se a mesma nao existir
                        if (Directory.Exists(Server.MapPath("~/upload/imagens/usuarios/")) == false)
                        {
                            Directory.CreateDirectory(Server.MapPath("~/upload/imagens/usuarios/"));
                        }

                        //Caminho a onde será salvo
                        hpf.SaveAs(Server.MapPath("~/upload/imagens/usuarios/") + filename + extensao);
                        break;
                    }
                }
            }
            if (filename != "NULL")
            {
                filename = "'" + filename + extensao + "'";
            }

            // Salvar no BD
            string cmd = "EXEC admin_piuUsuario '" + Request["USU_ID"] + "','" + Request["RED_ID"] + "', '" + Request["USU_NOME"] + "','" + Request["USU_EMAIL"] + "','" + objUtils.getMD5Hash(Request["USU_SENHA"]) + "','" + Request["USU_BIOGRAFIA"] + "', " + filename + ", " + Request["USU_PRESENCIAL"] + ", " + Request["USU_ATIVO"] + ",'" + Request["USU_USUARIO"] + "'";
            objBD.ExecutaSQL(cmd);
            Response.Redirect("usuarios.aspx");
            Response.End();
        }

        public void excluirUsuario()
        {
            objBD.ExecutaSQL("update Usuario set USU_ATIVO = 0 where USU_ID ='" + Request["USU_ID"] + "'");
            PopulaLista();
            PopulaExcluidos();
        }

        public void AtivarUsuario()
        {
            objBD.ExecutaSQL("update Usuario set USU_ATIVO = 1 where USU_ID ='" + Request["USU_ID"] + "'");
            PopulaLista();
            PopulaExcluidos();
        }

        public void FiltrarPesquisa(string RED_ID, string USU_NOME, string USU_EMAIL)
        {
            rsLista = objBD.ExecutaSQL("EXEC admin_psUsusarioFiltro '" + RED_ID + "', '" + USU_NOME + "', '" + USU_EMAIL + "' ");
            if (rsLista == null)
            {
                throw new Exception();
            }
            string resposta = "";
            if (rsLista.HasRows)
            {

                resposta += " <thead>";
                resposta += "     <tr>";
                resposta += "         <th style=\"width:8px;\">ID</th>";
                resposta += "         <th style=\"width:120px;\">Nome</th>";
                resposta += "         <th>E-Mail</th>";
                resposta += "         <th>Acessos</th>";
                resposta += "         <th style=\"width:80px;\">Último Acesso</th>";
                resposta += "         <th>Rede</th>";
                resposta += "         <th style=\"width:61px;\">Ações</th>";
                resposta += "     </tr>";
                resposta += " </thead>";

                resposta += " <tbody>";
                
                while (rsLista.Read())
                {
                    resposta += " <tr id='tr_" + rsLista["USU_ID"].ToString() + "' class=\"\">";
                    resposta += "     <td>" + rsLista["USU_ID"].ToString() + "</td>";
                    resposta += "     <td>" + rsLista["USU_NOME"].ToString() + "</td>";
                    resposta += "     <td>" + rsLista["USU_EMAIL"].ToString() + "</td>";
                    resposta += "     <td>" + rsLista["USU_QTD_ACESSO"].ToString() + "</td>";
                    resposta += "     <td>" + rsLista["USU_DH_ULTIMO_ACESSO"].ToString() + "</td>";
                    resposta += "     <td>" + rsLista["RED_TITULO"].ToString() + "</td>";
                    resposta += "     <td><ul class=\"icons_table\"><li><a href=\"javascript:void(0);\" id='" + rsLista["USU_ID"].ToString() + "' onclick='popularFormulario(this.id);' class=\"img_edit\"><img src=\"images/editar.png\"></a></li><li><a id='" + rsLista["USU_ID"].ToString() + "' onclick='excluirUsuario(this.id);' href=\"javascript:void(0)\" class=\"img_del\"><img src=\"images/lixo.png\"></a></li></ul>";
                    resposta += " </tr>";
                }

                resposta += " </tbody>";

            }
            else
            {
                resposta += "     <tr>";
                resposta += "         <td colspan=\"7\">Nenhum resultado para esta pesquisa</td>";
                resposta += "     </tr>";
            }

            Response.Write(resposta);
            Response.End();

            rsLista.Close();
            rsLista.Dispose();
        }

        protected void Incluir_Click(object sender, EventArgs e)
        {
            gravarUsuario();
        }

        public void ValidarUsuario()
        {
            try
            {
                rsUsuario = objBD.ExecutaSQL("EXEC admin_VerificaExistenciaUsuario '" + Request["USU_USUARIO"] + "'");

                if (rsUsuario == null)
                {
                    throw new Exception();
                }
                if (rsUsuario.HasRows)
                {
                    rsUsuario.Read();
                    Response.Write(rsUsuario["MENSAGEM"] + "|" + rsUsuario["VALIDO"]);
                }

                //Libera o BD e Memória
                rsUsuario.Close();
                rsUsuario.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}