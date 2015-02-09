<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="post.aspx.cs" Inherits="BrincaderiasMusicais.post" %>

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
                    BLOG
                </div>

                <div id="breadcrumb" runat="server"></div>
                 <div class="oculta"><a href="https://twitter.com/share" class="twitter-share-button" data-lang="pt">Tweetar</a>
                            <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script></div>
                <img id="imgPost" src="/images/sobre.jpg" class="img_destaque" runat="server" style="height: 200px" />
                <span id="logPost" runat="server"></span>
                <div class="txt textoPost" runat="server" id="txtPost"></div><br /><br />
                <ul class="social_blog">
                    <li>
                        <iframe src="//www.facebook.com/plugins/like.php?href=https%3A%2F%2Fwww.facebook.com%2Fbrincamusicais%3Ffref%3Dts&amp;width&amp;layout=button_count&amp;action=like&amp;show_faces=false&amp;share=true&amp;height=21&amp;appId=335341063329023" scrolling="no" frameborder="0" style="border: none; overflow: hidden; height: 21px;" allowtransparency="true"></iframe>
                    </li>
                    <li class="tw_blog2">
                        <a href="https://twitter.com/share" class="twitter-share-button" data-lang="pt">Tweetar</a>
                        <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
                    </li>
                    <li class="g_blog">
                        <div class="g-plus" data-action="share" data-annotation="bubble" data-href="Url do post pra compartilhar"></div>
                        <!--altere o link (data-href) para o link do post-->
                    </li>
                </ul>
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
