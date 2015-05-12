<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meuperfil.aspx.cs" Inherits="BrincaderiasMusicais.meuperfil" %>

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
    <meta property="og:description" content="M" />
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
                
                <!-- INCLUDE -->
                <brincadeira:headerperfil runat="server" ID="headerperfil" />

                <img src="/images/linha.png" class="linha" />
                
                <brincadeira:menuperfil runat="server" ID="menuperfil" />
                
                <div class="medalhas_perfil">
                    <p class="sub_perfil">Suas recompensas conquistadas</p>
                    <ul class="medalhas">
                        <!--<li class="ativo">-->
                        <li class="ativo">
                            <img src="/images/medalha_ok.png" /><p>Iniciante</p>
                        </li>
                        <li id="liDedicado" runat="server">
                            <img src="/images/medalha1.png" id="imgDedicado" runat="server"/><p>Dedicado</p>
                        </li>
                        <li id="liBlogueiro" runat="server">
                            <img src="/images/medalha2.png" id="imgBlogueiro" runat="server"/><p>Blogueiro</p>
                        </li>
                        <li id="liFotografo" runat="server">
                            <img src="/images/medalha3.png" id="imgFotografo" runat="server"/><p>Fotógrafo</p>
                        </li>
                        <li id="liProdutor" runat="server">
                            <img src="/images/medalha4.png" id="imgProdutor" runat="server"/><p>Produtor</p>
                        </li>
                        <li>
                            <img src="/images/medalha5.png" /><p>Experiente</p>
                        </li>
                    </ul>
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

