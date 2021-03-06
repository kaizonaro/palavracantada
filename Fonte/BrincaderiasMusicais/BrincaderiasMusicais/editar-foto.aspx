﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editar-foto.aspx.cs" Inherits="BrincaderiasMusicais.editar_foto" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>
<%@ Register Src="~/inc/headerperfil.ascx" TagPrefix="brincadeira" TagName="headerperfil" %>
<%@ Register Src="~/inc/menuperfil.ascx" TagPrefix="brincadeira" TagName="menuperfil" %>
<%@ Register Src="~/inc/blogPessoal.ascx" TagPrefix="brincadeira" TagName="blogPessoal" %>

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

    <script type="text/javascript">
        function excluirFoto() {
            decisao = confirm("Deseja excluir a foto atual?");
            if (decisao){
                window.location.href = 'editar-foto.aspx?acao=ExcluirFoto';
            }
            else {
                return false;
            }
        }
    </script>

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

                <brincadeira:menuperfil runat="server" ID="menuperfil" />

                <div class="medalhas_perfil">
                    <p class="sub_perfil">Editar foto de perfil</p>
                    <p class="txt">
                        Carregue uma nova foto ou exclua a foto atual.
                    </p>
                    <form id="foto" class="form" runat="server">
                        <div class="left">
                            <b>Foto Atual:</b>
                            <div class="editar_img">
                                <img src="/images/img_perfil.jpg" id="FotoPerfil" runat="server"/>
                            </div>
                        </div>
                        <div class="right">
                            <label for="upload_foto"  class="btn_save subir_foto">Carregar nova foto</label>
                            <asp:FileUpload ID="upload_foto" runat="server" CssClass="esconde" />
                            <button class="btn_save excluir_foto" onclick="excluirFoto(); return false;">Excluir Foto Atual</button>
                           
                        </div>
                        <div class="mini_txt" id="mini_txt" runat="server"></div>
                        <button class="btn_back" onclick="window.history.go(-1); return false;"><< voltar</button>
                        <asp:Button ID="PublicarFoto" class="btn_save" runat="server" Text="salvar alterações" OnClick="gravar" />
                    </form>
                </div>
                <img src="/images/linha.png" class="linha" />
                
                <!-- BLOG-->
                <brincadeira:blogPessoal runat="server" ID="blogPessoal" />

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


