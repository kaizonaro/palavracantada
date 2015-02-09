﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="artigos.aspx.cs" Inherits="BrincaderiasMusicais.artigo" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">


    <title>Palavra Cantada - Redes</title>
     <!--FACEBOOK-->
    <meta property="og:title" content="Palavra Cantada - Artigos" /> 
    <meta property="og:image" content="http://projetopalavracantada.net/images/logo-fb.png" />
    <meta property="og:description" content="Página de Artigos" />
    <meta property="og:url" content="http://projetopalavracantada.net/artigos" />
    
    <brincadeira:script runat="server" ID="script" />
   
    
    <script type="text/javascript">
        //ajax
        function GetXMLHttp() {
            if (navigator.appName == "Microsoft Internet Explorer") {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            } else {
                xmlHttp = new XMLHttpRequest();
            }
            return xmlHttp;
        }
        var mod = GetXMLHttp();

        function pagina(pg) {
            /*      mod.open("GET", "ajax/acoes.aspx?pagina=" + pg + "&ACAO=paginacaoArtigos", true);
                  mod.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                  mod.onreadystatechange = function() {  
                      if (mod.readyState == 4) {
                          document.getElementById('divArtigos').innerHTML = mod.responseText;
                      }  
                  };  
                  mod.send(null);  */

            location.href = "artigos.aspx?pagina=" + pg + "";
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
            <div id="sobre" class="interna">
                <div class="titu">
                    Artigos
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <strong>Explore - Artigos</strong>
                </div>
                <div class="oculta">
                    <a href="https://twitter.com/share" class="twitter-share-button" data-lang="pt">Tweetar</a>
                    <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
                </div>
                <!-- ARTIGOS -->
                <div id="divArtigos" runat="server"></div>

                <!-- PAGINAÇÃO -->
                 
                <ul class="social_artigo">
                    <li>
                        <iframe src="//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fprojetopalavracantada.net%2Fartigos&amp;width&amp;layout=button_count&amp;action=like&amp;show_faces=true&amp;share=true&amp;height=21&amp;appId=404437276390840" scrolling="no" frameborder="0" style="border:none; overflow:hidden; height:21px;" allowTransparency="true"></iframe>
                    </li>
                    <li class="tw_blog">
                        <a href="https://twitter.com/share" class="twitter-share-button" data-lang="pt">Tweetar</a>
                            <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
                    </li>
                    <li class="g_blog">
                        <div class="g-plus" data-action="share" data-annotation="bubble" data-href="http://projetopalavracantada.net/artigos"></div>
                    </li>
                </ul>

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

