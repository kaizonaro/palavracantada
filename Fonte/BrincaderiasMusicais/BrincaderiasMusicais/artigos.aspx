<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="artigos.aspx.cs" Inherits="BrincaderiasMusicais.artigo" %>

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

    <brincadeira:script runat="server" ID="script" />
    <script type="text/javascript">

        //  $('html, body').animate({
        //     scrollTop: $("#sobre").offset().top
        // }, 2000);

        //$("#breadcrumb").hide();


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
                        <iframe src="//www.facebook.com/plugins/like.php?href=https%3A%2F%2Fwww.facebook.com%2Fbrincamusicais%3Ffref%3Dts&amp;width&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;share=true&amp;height=21&amp;appId=335341063329023" scrolling="no" frameborder="0" style="border: none; overflow: hidden; height: 21px;" allowtransparency="true"></iframe>
                        
                    </li>
                    <li class="tw_blog">
                        <a href="https://twitter.com/share" class="twitter-share-button" data-lang="pt">Tweetar</a>
                            <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
                    </li>
                    <li class="g_blog">
                        <div class="g-plus" data-action="share" data-annotation="bubble" data-href="/post/colocarurl"></div>
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
    <script>
        setTimeout(function () {
            $('html, body').animate({
                scrollTop: $("#sobre").offset().top
            }, 500);
        }, 3000);

    </script>
</body>
</html>
