using Etnia.classe;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrincaderiasMusicais
{
    public partial class editar_config : System.Web.UI.Page
    {
        utils objUtils;
        bd objBD;
        OleDbDataReader rsConfig, rsCargo, rsCat;


        protected void Page_Load(object sender, EventArgs e)
        {
            objBD = new bd();
            objUtils = new utils();

            if (Request["acao"] != "gravar")
            {
                ListarCargo();
                ListarConfig(Session["usuID"].ToString());
            }
           

        }

        public void ListarCargo()
        {
            rsCargo = objBD.ExecutaSQL("SELECT * FROM CARGO WHERE CAT_ATIVO = 1");
            if (rsCargo == null)
            {
                throw new Exception();
            }
            if (rsCargo.HasRows)
            {
                while (rsCargo.Read())
                {
                    CAR_ID.Items.Add(new ListItem(rsCargo["CAR_TITULO"].ToString(), rsCargo["CAR_ID"].ToString()));
                }

            }
        }

        public void ListarConfig(string ID)
        {

            if (string.IsNullOrWhiteSpace(ID) == false)
            {
                rsConfig = objBD.ExecutaSQL("EXEC site_psListarConfig " + ID);
                if (rsConfig == null)
                {
                    throw new Exception();
                }
                if (rsConfig.HasRows)
                {
                    rsConfig.Read();
                    USU_ID.Attributes.Add("value", rsConfig["USU_ID"].ToString());
                    USU_NOME.Attributes.Add("value", rsConfig["USU_NOME"].ToString());
                    USU_EMAIL.Attributes.Add("value", rsConfig["USU_EMAIL"].ToString());

                    ListItem li = CAR_ID.Items.FindByValue(rsConfig["CAR_ID"].ToString());
                    li.Selected = true;
                    
                    //pivacidade
                    if (rsConfig["PRI_PERFIL"].ToString() == "True") { sim_perfil.Checked = true; } else { nao_perfil.Checked = true; }
                    if (rsConfig["PRI_BLOG"].ToString() == "True") { sim_blog.Checked = true; } else { nao_blog.Checked = true; }
                    if (rsConfig["PRI_FOTOS"].ToString() == "True") { sim_midia.Checked = true; } else { nao_midia.Checked = true; }
                    if (rsConfig["PRI_FOTOS"].ToString() == "True") { sim_video.Checked = true; } else { nao_video.Checked = true; }
                    //notificaoes
                    if (rsConfig["NOT_BLOG"].ToString() == "True") { sim_blog2.Checked = true; } else { nao_blog2.Checked = true; }
                    if (rsConfig["NOT_GALERIA"].ToString() == "True") { sim_galeria.Checked = true; } else { nao_galeria.Checked = true; }
                    if (rsConfig["NOT_FORUM"].ToString() == "True") { sim_forum.Checked = true; } else { nao_forum.Checked = true; }
                    if (rsConfig["NOT_DOCUMENTADAS"].ToString() == "True") { sim_criacao.Checked = true; } else { nao_criacao.Checked = true; }

                    InsereCategoria(infantil);
                    InsereCategoria(fundamental);
                }
            }
        }

        public void InsereCategoria(System.Web.UI.HtmlControls.HtmlInputCheckBox chk)
        {
            
            rsCat = objBD.ExecutaSQL("SELECT * FROM UsuarioCategoria WHERE USU_ID = " + Session["usuID"].ToString() + " and CAT_ID = (SELECT CAT_ID from CATEGORIA WHERE CAT_TITULO = '" + chk.Value + "')");
            if (rsCat.HasRows)
            {
                chk.Checked = true;
            }
        }

        protected void salvar_Click(object sender, EventArgs e)
        {
            string senha = Request["USU_SENHA"];
            if (string.IsNullOrWhiteSpace(senha) == false)
            {
                senha = "'" + objUtils.getMD5Hash(senha) + "'";
            }
            else
            {
                senha = "NULL";
            }

            objBD.ExecutaSQL("EXEC piuConfiguracoes " + Session["usuID"] + ", '" + Request["USU_NOME"] + "', '" + Request["USU_EMAIL"] + "', '" + Request["CAR_ID"] + "', '" + Request["PRI_BLOG"] + "', '" + Request["PRI_PERFIL"] + "', '" + Request["PRI_FOTOS"] + "', '" + Request["PRI_VIDEOS"] + "', '" + Request["NOT_BLOG"] + "', '" + Request["NOT_GALERIA"] + "', '" + Request["NOT_FORUM"] + "', '" + Request["NOT_DOCUMENTADAS"] + "'," + senha);
            if (infantil.Checked)
            {
                objBD.ExecutaSQL("insert into UsuarioCategoria(USU_ID,CAT_ID) values (" + Session["usuID"].ToString() + ", 1)");
            }

            if (fundamental.Checked)
            {
                objBD.ExecutaSQL("insert into UsuarioCategoria(USU_ID,CAT_ID) values (" + Session["usuID"].ToString() + ", 2)");
            }
            //Response.Redirect("meu-perfil");
            Session["nomeUsuario"] = Request["USU_NOME"].ToString();
            Response.Redirect("editar-configuracoes");
        }
    }
}
