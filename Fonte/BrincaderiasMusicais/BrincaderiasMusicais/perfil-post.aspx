<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perfil-post.aspx.cs" Inherits="BrincaderiasMusicais.peril_post" %>

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
             <div id="sobre2" class="interna">
                 <img class="mini_perfil" src="/images/thumb_perfil.jpg" alt="Foto do Perfil do Fulano" />
                <div class="titu">
                    BLOG
                </div>
                 <div class="titu2">
                    << nome do usuário >>
                </div>

                 <div class="oculta"><a href="https://twitter.com/share" class="twitter-share-button" data-lang="pt">Tweetar</a>
                            <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script></div>
                <img id="img1" src="/images/sobre.jpg" class="img_destaque" runat="server" style="height: 200px" />
                <span id="logPost">Publicado por <strong><i>Fernando Santos</i></strong> em <strong><i>22/02/2015</i></strong> na categoria: <strong><i>Vídeo</i></strong><br><br></span>
                <div id="txtPost" class="txt textoPost"><p class="tit_post">Post Teste</p><p>Inner ipsum code get amet, getElementById adipiscing split. Mauris finibus, felis id command dapibus, nisl ex #000000 nisl, id euismod mauris magna vel purus. send luctus augue euismod sapien rhoncus, et mattis lectus malesuada. Donuts fermentum turpis a getElementById accumsan. Aliquam send orci nibh. In code sem, pulvinar ultrices venenatis id, ultrices eu release. Ut tempor metus urna. Return get amet imperdiet turpis. Integer command ac ipsum send tempor. Aenean AJAX mollis null, volutpat euismod eros. _POSTs vitae ante set _POST luctus viverra condimentum id _POST. Cras vehicula congue ante, fakepath viverra quam rutrum set. Return non finibus ipsum, send ultrices lectus. Donuts tempus convallis purus ut ornare. Nam vel split sem.</p>
<p>nullm set aliquam est. display:none efficitur Inner vitae augue imperdiet scelerisque. Vivamus fermentum arcu pulvinar fermentum laoreet. Phasellus id ante _POST. Praesent at blandit null, at ornare nisl. Quisque cursus non mi vitae facilisis. Maecenas command sem _POST, send tincidunt felis cursus set. Return at fakepath enim, malesuada consequat justo. Mauris blandit egestas Inner, get amet interdum eros ullamcorper set. Fusce mollis, risus id rutrum efficitur, magna risus rhoncus release, id #000000 lacus magna AJAX sapien. null facilisi.</p></div>
                <a href="#" class="btn">ver mais posts</a>
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

