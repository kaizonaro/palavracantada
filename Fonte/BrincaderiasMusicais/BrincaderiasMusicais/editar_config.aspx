<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editar_config.aspx.cs" Inherits="BrincaderiasMusicais.editar_config" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>
<%@ Register Src="~/inc/headerperfil.ascx" TagPrefix="brincadeira" TagName="headerperfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">


    <title>Palavra Cantada - Redes</title>
    <!--FACEBOOK-->
    <meta property="og:title" content="Projeto Brincadeiras Musicais da Palavra Cantada - Artigos" />
    <meta property="og:image" content="http://projetopalavracantada.net/images/logo-fb.png" />
    <meta property="og:description" content="Página de Artigos" />
    <meta property="og:url" content="http://projetopalavracantada.net/artigos" />

    <brincadeira:script runat="server" ID="script" />

</head>
<body>

    <!--TOPO-->
    <brincadeira:header runat="server" ID="header" />
    <!--FIM DO TOPO-->

    <!--MENU-->
    <brincadeira:menu runat="server" ID="menu" />
    <!--FIM DO MENU-->

    <!-- CONTEUDO-->
    <section class="all">
        <div class="all_center">

            <!--CONTEUDO INTERNO (ARTIGOS)-->
            <div id="meuperfil" class="interna">
                <brincadeira:headerperfil runat="server" ID="headerperfil" />
                <img src="/images/linha.png" class="linha" />

                <form id="setup" runat="server">
                    <div class="titu_setup">Suas Configurações</div>
                    <div class="left">
                        <input type="hidden" name="acao" value="gravar" runat="server" id="acao" />
                        <input type="hidden" value="0" runat="server" id="USU_ID" />
                        <label class="label">Nome:</label>
                        <input type="text" class="input obg" runat="server" id="USU_NOME" />
                        <label class="label">Cargo:</label>
                        <select id="CAR_ID" name="CAR_ID" class="input obg" runat="server">
                            <option value="">Selecione um cargo</option>
                        
                        </select>
                    </div>
                    <div class="right">
                        <label class="label">E-mail:</label>
                        <input class="input email obg" type="text" runat="server" id="USU_EMAIL"  />
                        <label class="label">Categoria:</label>
                        <input type="checkbox" name="categoria" id="infantil" class="esconde check" value="Ensino Infantil" runat="server" />
                        <label for="infantil">Ensino Infantil</label>
                        <input type="checkbox" name="categoria" id="fundamental" class="esconde check" value="Ensino Fundamental" runat="server" />
                        <label for="fundamental">Ensino Fundamental</label>
                    </div>
                    <div class="full">
                        <p class="label">Trocar senha <em>(digite a nova senha abaixo - deixe em branco para manter a senha atual)</em></p>
                        <div class="left">
                            <input type="password" class="input senha2" id="USU_SENHA" name="USU_SENHA" placeholder="Nova senha" />
                        </div>
                        <div class="right">
                            <input type="password" class="input senha2" placeholder="Confirme a nova senha" />
                        </div>
                    </div>
                    <div class="left">
                        <div class="titu_setup">Opções de Privacidade:</div>
                        <label class="label">Perfil privado?</label>
                        <input type="radio" value="1" id="sim_perfil" name="PRI_PERFIL" class="radio esconde" runat="server" />
                        <label for="sim_perfil">SIM (visível somente para você)</label><br />
                        <input type="radio" value="0" id="nao_perfil" name="PRI_PERFIL" class="radio esconde" runat="server" />
                        <label for="nao_perfil">NÃO (perfil público para sua região)</label><br />
                        <br />
                        <br />

                        <label class="label">Blog pessoal privado?</label>
                        <input type="radio" value="1" id="sim_blog" name="PRI_BLOG" class="radio esconde" runat="server" />
                        <label for="sim_blog">SIM (visível somente para você)</label><br />
                        <input type="radio" value="0" id="nao_blog" name="PRI_BLOG" class="radio esconde" runat="server" />
                        <label for="nao_blog">NÃO (perfil público para sua região)</label><br />
                        <br />
                        <br />

                        <label class="label">Fotos privadas?</label>
                        <input type="radio" value="1" id="sim_midia" name="PRI_FOTOS" class="radio esconde" runat="server" />
                        <label for="sim_midia">SIM (visível somente para você)</label><br />
                        <input type="radio" value="0" id="nao_midia" name="PRI_FOTOS" class="radio esconde" runat="server" />
                        <label for="nao_midia">NÃO (perfil público para sua região)</label><br />
                        <br />
                        <br />

                        <label class="label">Vídeos privados?</label>
                        <input type="radio" value="1" id="sim_video" name="PRI_VIDEOS" class="radio esconde" runat="server" />
                        <label for="sim_video">SIM (visível somente para você)</label><br />
                        <input type="radio" value="0" id="nao_video" name="PRI_VIDEOS" class="radio esconde" runat="server" />
                        <label for="nao_video">NÃO (perfil público para sua região)</label>
                    </div>
                    <div class="right">
                        <div class="titu_setup">Opções de notificação de e-mail:</div>
                        <label class="label">Notificações do blog regional (novidades):</label>
                        <input type="radio" value="1" id="sim_blog2" name="NOT_BLOG" class="radio esconde" runat="server" />
                        <label for="sim_blog2">SIM, RECEBER</label>
                        <input type="radio" value="0" id="nao_blog2" name="NOT_BLOG" class="radio esconde" runat="server" />
                        <label for="nao_blog2">NÃO RECEBER</label><br />
                        <br />
                        <br />

                        <label class="label">Notificações da galeria colaborativa:</label>
                        <input type="radio" value="1" id="sim_galeria" name="NOT_GALERIA" class="radio esconde" runat="server" />
                        <label for="sim_galeria">SIM, RECEBER</label>
                        <input type="radio" value="0" id="nao_galeria" name="NOT_GALERIA" class="radio esconde" runat="server" />
                        <label for="nao_galeria">NÃO RECEBER</label><br />
                        <br />
                        <br />

                        <label class="label">Notificações das atividades do fórum:</label>
                        <input type="radio" value="1" id="sim_forum" name="NOT_FORUM" class="radio esconde" runat="server" />
                        <label for="sim_forum">SIM, RECEBER</label>
                        <input type="radio" value="0" id="nao_forum" name="NOT_FORUM" class="radio esconde" runat="server" />
                        <label for="nao_forum">NÃO RECEBER</label><br />
                        <br />
                        <br />

                        <label class="label">Notificações das criações documentadas:</label>
                        <input type="radio" value="1" id="sim_criacao" name="NOT_DOCUMENTADAS" class="radio esconde" runat="server" />
                        <label for="sim_criacao">SIM, RECEBER</label>
                        <input type="radio" value="0" id="nao_criacao" name="NOT_DOCUMENTADAS" class="radio esconde" runat="server"/>
                        <label for="nao_criacao">NÃO RECEBER</label>
                    </div>
                    <div class="full">
                        <div class="left">
                            <button class="btn_back" onclick="window.history.go(-1); return false;"><< voltar</button>
                        </div>
                        <div class="right">
                            <asp:Button ID="salvar" runat="server" Text="salvar alterações" CssClass="btn_save" OnClick="salvar_Click" />

                            
                            
                        </div>
                    </div>
                </form>
            </div>
            <!--FIM DO CONTEUDO INTERNO (ARTIGOS)-->

            <!--BOX LOGIN-->
            <brincadeira:login runat="server" ID="login" />

            <!--BLOG-->
            <brincadeira:blog runat="server" ID="blog" />

        </div>
    </section>
    <!--FIM DO CONTEUDO-->

    <!--RODAPÉ-->
    <brincadeira:footer runat="server" ID="footer" />
    <!--FIM DO RODAPÉ-->
</body>
</html>

