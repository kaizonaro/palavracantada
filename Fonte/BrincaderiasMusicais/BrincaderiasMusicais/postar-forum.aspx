<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="postar-forum.aspx.cs" Inherits="BrincaderiasMusicais.postar_forum"   %>


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
            <div id="sobre" class="interna">
                <div class="titu">
                    Fórum
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a>  &gt;&gt; <a href="forum" title="Fórum">Fórum</a> &gt;&gt; <strong>Conteúdos transversais / Interdisciplinaridade</strong>
                </div>
                <form method="post" action="postar-forum.aspx" id="up_foto" enctype="multipart/form-data" runat="server">
                    <p class="titu_forum">
                        <img src="images/titu_forum.png" alt="Icone" />
                        Conteúdos transversais / Interdisciplinaridade:</p>
                    <p class="mini_txt_forum">Escreva sua mensagem no campo abaixo e clique no botão "Publicar mensagem"..</p>
                    <div class="full">
                        <input type="hidden" id="FTO_ID" runat="server" />
                         <input type="hidden" id="REDIRECT" runat="server" />
                        <textarea name="FME_MENSAGEM" id="FME_MENSAGEM" class="input" rows="35" runat="server"></textarea>
                    </div>
                    <div class="full up_post_btn">
                        <asp:Button ID="pub" runat="server" Text="PUBLICAR MENSAGEM" CssClass="btn_save up_forum" OnClick="pub_Click" />

                        <button class="btn_back up_forum" onclick="window.history.go(-1); return false;">Voltar</button>
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



