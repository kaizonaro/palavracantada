<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="blog-regional.aspx.cs" Inherits="BrincaderiasMusicais.blog_regional" %>

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
    <meta property="og:title" content="Palavra Cantada - Blog" />
    <meta property="og:image" content="http://projetopalavracantada.net/images/logo-fb.png" />
    <meta property="og:description" content="Página de Blog" />

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
            <div id="sobre" class="interna">
                <div class="titu">
                    Blog Regional -  Nome da Região 
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <strong><a href="
                        3">Blog-Regional</a></strong></span>
                </div>
                <div id="msg" class="txt" runat="server"></div>
                <div class="oculta">
                    <a href="https://twitter.com/share" class="twitter-share-button" data-lang="pt">Tweetar</a>
                    <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
                </div>
                <!-- ARTIGOS -->
                <div id="divArtigos">
                    <!-- PAGINAÇÃO -->
                    <!--<nav class="paginacao">
                        <ul>
                            <li><a href="javascript:void(0);" class="nav_pg" title="Página anterior">
                                <img src="images/nav_left.png">ANTERIORES</a></li>
                            <li><a href="javascript:void(0);" title="Página atual" class="ativo">1</a></li>
                            <li><a href="javascript:void(0);" onclick="pagina('2')" title="Página 2">2</a></li>
                            <li><a href="javascript:void(0);" onclick="pagina('3')" title="Página 3">3</a></li>
                            <li><a href="javascript:void(0);" onclick="pagina('2')" class="nav_pg" title="Próxima Página">PRÓXIMOS
                                <img src="images/nav_right.png "></a></li>
                        </ul>
                    </nav>-->
                    <div class="txt blog_txt"><a href="/post/post-logado-3" title="Ver Post">
                        <img width="190px" height="132px" src="/upload/imagens/blog/thumb-120320150002260.jpg" class="thumb_artigo"></a>   <span class="titu_blog"><a href="/post/post-logado-3" title="Ver Post"><strong>Post logado 3</strong></a></span>   <span>Publicado por: <strong>Fernando Santos </strong></span><span>Em: <strong>12/03/2015</strong>, às <strong>00:02</strong></span>   <span>na categoria: <strong>Diversos</strong></span>
                        <div class="txt">
                            <p>Post logado 3, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1</p>
                            
                             <p> <a href="/post/post-logado-3" class="btn">LEIA MAIS</a></p>
                        </div>
                    </div>
                    <div class="txt blog_txt"><a href="/post/post-logado-2" title="Ver Post">
                        <img width="190px" height="132px" src="/upload/imagens/blog/thumb-120320150001420.jpg" class="thumb_artigo"></a>   <span class="titu_blog"><a href="/post/post-logado-2" title="Ver Post"><strong>Post logado 2</strong></a></span>   <span>Publicado por: <strong>Fernando Santos </strong></span><span>Em: <strong>12/03/2015</strong>, às <strong>00:01</strong></span>   <span>na categoria: <strong>Diversos</strong></span>
                        <div class="txt">
                            <p></p>
                            <p>Post logado 2, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1</p>
                            <p><a href="/post/post-logado-2" class="btn">LEIA MAIS</a></p>
                        </div>
                        
                    </div>
                    <div class="txt blog_txt"><a href="/post/post-logado-1" title="Ver Post">
                        <img width="190px" height="132px" src="/upload/imagens/blog/thumb-110320152309280.jpg" class="thumb_artigo"></a>   <span class="titu_blog"><a href="/post/post-logado-1" title="Ver Post"><strong>Post logado 1</strong></a></span>   <span>Publicado por: <strong>Fernando Santos </strong></span><span>Em: <strong>11/03/2015</strong>, às <strong>23:09</strong></span>   <span>na categoria: <strong>Diversos</strong></span>
                        <div class="txt">
                            <p></p>
                            <p>Post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1, post logado 1</p>
                            <p><a href="/post/post-logado-1" class="btn">LEIA MAIS</a></p>
                        </div>
                        
                    </div>
                    <nav class="paginacao">
                        <ul>
                            <li><a href="javascript:void(0);" class="nav_pg" title="Página anterior">
                                <img src="images/nav_left.png">ANTERIORES</a></li>
                            <li><a href="javascript:void(0);" title="Página atual" class="ativo">1</a></li>
                            <li><a href="javascript:void(0);" onclick="pagina('2')" title="Página 2">2</a></li>
                            <li><a href="javascript:void(0);" onclick="pagina('2')" class="nav_pg" title="Próxima Página">PRÓXIMOS
                                <img src="images/nav_right.png "></a></li>
                        </ul>
                    </nav>
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
