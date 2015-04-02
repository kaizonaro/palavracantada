<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="post-regional.aspx.cs" Inherits="BrincaderiasMusicais.post_regional" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <!--FACEBOOK-->
    <meta property="og:title" content="Projeto Brincadeiras Musicais da Palavra Cantada - Vídeos" runat="server" id="metaTitle" />
    <meta property="og:image" content="" runat="server" id="metaImage" />
    <meta property="og:description" content="" runat="server" id="metaDescription" />
    <meta property="og:url" content="" runat="server" id="metaURL" />


    </span>

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

            <!--CONTEUDO INTERNO (SOBRE)-->
            <div id="sobre" class="interna">
                <div class="titu">
                    BLOG Regional -  Nome da Região 
                </div>

                <div id="breadcrumb"><a href="/" title="Home">Home</a> &gt;&gt; <strong>Blog</strong> &gt;&gt; Post logado 3 </div>

                <img src="/upload/imagens/blog/big-120320150002260.jpg" id="imgPost" class="img_destaque" style="height: 332px; width: 478px;">
                <span id="logPost">Publicado por <strong><i>AparecidoFernando Santos</i></strong> em <strong><i>12/03/2015</i></strong> na categoria: <strong><i>Diversos</i></strong><br>
                    <br>
                </span>
                <div id="txtPost" class="txt textoPost">
                    <p class="tit_post">Post logado 3</p>
                    <p>Post logado 3, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1</p>
                </div>
                <br>
                <br>
            </div>
            <!--FIM DO CONTEUDO INTERNO (SOBRE)-->

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

