<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forum.aspx.cs" Inherits="BrincaderiasMusicais.forum" %>

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
                    <a href="/" title="Home">Home</a>  &gt;&gt; <strong>Fórum</strong>
                </div>

                <p class="titu_forum">
                    Tópicos do fórum:
                </p><br />

                <p class="titu_forum2">
                    <img src="images/titu_forum.png" alt="Icone" />
                   <a href="#" title="encontros com Brincantes">encontros com Brincantes:</a>
                </p>

                <p class="titu_forum2">
                    <img src="images/titu_forum.png" alt="Icone" />
                   <a href="#" title="encontros com Brincantes">encontros com Brincantes:</a>
                </p>

                <p class="titu_forum2">
                    <img src="images/titu_forum.png" alt="Icone" />
                   <a href="#" title="encontros com Brincantes">encontros com Brincantes:</a>
                </p>

                <p class="titu_forum2">
                    <img src="images/titu_forum.png" alt="Icone" />
                   <a href="#" title="encontros com Brincantes">encontros com Brincantes:</a>
                </p>

                <p class="titu_forum2">
                    <img src="images/titu_forum.png" alt="Icone" />
                   <a href="#" title="encontros com Brincantes">encontros com Brincantes:</a>
                </p>

                <img src="/images/linha.png" class="linha_forum">
                <p class="titu_forum">
                    Mensagens recentes publicadas no fórum:
                    <hr class="div_forum2" />
                </p>
                <div class="txt blog_txt txt_forum">
                    <div class="txt">
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla pellentesque urna ac sem maximus pulvinar.  volutpat feugiat eu id tortor(...)</p>
                        <p class="destque_forum">Mensagem enviada por: <a href='#' title='João da Silva'>João da Silva</a></p>
                        <p class="destque_forum">Enviada em: <b>10/03/2015</b></p><br /><br />
                    </div>
                </div>

                <div class="txt blog_txt txt_forum">
                    <div class="txt">
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla pellentesque urna ac sem maximus pulvinar.  volutpat feugiat eu id tortor(...)</p>
                        <p class="destque_forum">Mensagem enviada por: <a href='#' title='João da Silva'>João da Silva</a></p>
                        <p class="destque_forum">Enviada em: <b>10/03/2015</b></p><br /><br />
                    </div>
                </div>
                
                <div class="txt blog_txt txt_forum">
                    <div class="txt">
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla pellentesque urna ac sem maximus pulvinar.  volutpat feugiat eu id tortor(...)</p>
                        <p class="destque_forum">Mensagem enviada por: <a href='#' title='João da Silva'>João da Silva</a></p>
                        <p class="destque_forum">Enviada em: <b>10/03/2015</b></p><br /><br />
                    </div>
                </div>
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
