<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="BrincaderiasMusicais.usuarios" %>

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
    <meta property="og:title" content="Palavra Cantada - Usuários" /> 
    <meta property="og:image" content="http://projetopalavracantada.net/images/logo-fb.png" />
    <meta property="og:description" content="Página de Usuários" />

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
           /* mod.open("GET", "ajax/acoes.aspx?pagina=" + pg + "&ACAO=paginacaoBlog", true);
            mod.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            mod.onreadystatechange = function () {
                if (mod.readyState == 4) {
                    document.getElementById('divArtigos').innerHTML = mod.responseText;
                }
            };
            mod.send(null);*/
            location.href = "blog.aspx?pagina=" + pg + "";
             
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
            <div id="sobre" class="interna2">
                <div class="titu">
                    Usuários - <% Response.Write(Session["nomeInstituicao"]); %>
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <strong><a href="Usuários.aspx">Usuários</a></strong> >> <span id="bread" runat="server"></span>
                </div>
                <div id="msg" class="txt" runat="server" ></div>
                <div class="oculta"><a href="https://twitter.com/share" class="twitter-share-button" data-lang="pt">Tweetar</a>
                            <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script></div>
                <!-- ARTIGOS -->
                <div id="divArtigos" runat="server">
                   
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
