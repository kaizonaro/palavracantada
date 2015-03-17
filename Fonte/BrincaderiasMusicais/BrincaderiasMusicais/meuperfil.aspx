<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meuperfil.aspx.cs" Inherits="BrincaderiasMusicais.meuperfil" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>
<%@ Register Src="~/inc/headerperfil.ascx" TagPrefix="brincadeira" TagName="headerperfil" %>
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
                <div class="menu_perfil">
                    <p class="sub_perfil">Ajustes de seu perfil</p>
                    <span class="primeiro"><a href="editar-foto.aspx">Editar foto de perfil</a></span>
                    <span class="segundo"><a href="editar-biografia">Editar mini-biografia</a></span>
                    <span class="terceiro"><a href="javascript:void(0)">configurações</a></span>

                    <p class="sub_perfil">Ajustes de seu perfil</p>
                    <span class="quarto"><a href="enviar-post">Adicionar Post</a></span>
                    <span class="quinto"><a href="enviar-foto">Adicionar Foto</a></span>
                    <span class="sexto"><a href="enviar-video">Adicionar Video</a></span>
                </div>
                <div class="medalhas_perfil">
                    <p class="sub_perfil">Suas recompensas conquistadas</p>
                    <ul class="medalhas">
                        <!--<li class="ativo">-->
                        <li>
                            <img src="/images/medalha_ok.png" /><p>Iniciante</p>
                        </li>
                        <li>
                            <img src="/images/medalha.png" /><p>dedicado</p>
                        </li>
                        <li>
                            <img src="/images/medalha.png" /><p>blogueiro</p>
                        </li>
                        <li>
                            <img src="/images/medalha.png" /><p>fotografo</p>
                        </li>
                        <li>
                            <img src="/images/medalha.png" /><p>produtor</p>
                        </li>
                        <li>
                            <img src="/images/medalha.png" /><p>experiente</p>
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

