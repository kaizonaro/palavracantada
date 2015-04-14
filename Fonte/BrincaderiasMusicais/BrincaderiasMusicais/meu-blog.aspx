<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="meu-blog.aspx.cs" Inherits="BrincaderiasMusicais.meu_blog" %>

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
    <script type="text/javascript">
        function pagina(pg, us) {
            location.href = "meu-blog.aspx?pagina=" + pg + "&usuario=" + us;
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
            <div id="meuperfil" class="interna">
                <brincadeira:headerperfil runat="server" ID="headerperfil" />

                <img src="/images/linha.png" class="linha" />
                <div id="divArtigos" runat="server">
                    <div class="titu_galeria" runat="server" id="blog_nomeusuario">
                        Blog - << NOME DO USUÁRIO >>
                    </div>

                    <div class="txt blog_txt mini_blog">
                        <a href="/post/post-teste" title="Ver Post">
                            <img width="190px" height="80px" src="/upload/imagens/blog/img_blog.jpg" class="thumb_artigo"></a>
                        <span class="titu_blog"><a href="#" title="Ver Post"><strong>Post Teste</strong></a></span>
                        <span>Em: <strong>22/02/2015</strong>, às <strong>23:53</strong></span>
                        <span>Inner ipsum code get amet, ....</span>

                        <a href="/post/post-teste" class="btn">LEIA MAIS</a>
                        <!--<ul class="social_blog">
                        <li>
                            <iframe src="//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fprojetopalavracantada.net%2Fpost%2Fpost-teste&amp;width&amp;layout=button_count&amp;action=like&amp;show_faces=true&amp;share=true&amp;height=21&amp;appId=404437276390840" scrolling="no" frameborder="0" style="border: none; overflow: hidden; height: 21px;" allowtransparency="true"></iframe>
                        </li>
                        <li class="tw_blog">
                            <iframe id="twitter-widget-1" scrolling="no" frameborder="0" allowtransparency="true" src="http://platform.twitter.com/widgets/tweet_button.b44aac737ba5fb3711801841c2833c12.pt.html#_=1425702804316&amp;count=horizontal&amp;dnt=true&amp;id=twitter-widget-1&amp;lang=pt&amp;original_referer=http%3A%2F%2Flocalhost%3A5131%2Fblog&amp;size=m&amp;url=http%3A%2F%2Fprojetopalavracantada.net%2Fpost%2Fpost-teste" class="twitter-share-button twitter-tweet-button twitter-share-button twitter-count-horizontal" title="Twitter Tweet Button" data-twttr-rendered="true" style="width: 122px; height: 20px;"></iframe>
                            <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
                        </li>
                        <li class="g_blog">
                            <div id="___plus_0" style="text-indent: 0px; margin: 0px; padding: 0px; border-style: none; float: none; line-height: normal; font-size: 1px; vertical-align: baseline; display: inline-block; width: 119px; height: 20px; background: transparent;">
                                <iframe frameborder="0" hspace="0" marginheight="0" marginwidth="0" scrolling="no" style="position: static; top: 0px; width: 119px; margin: 0px; border-style: none; left: 0px; visibility: visible; height: 20px;" tabindex="0" vspace="0" width="100%" id="I1_1425702804236" name="I1_1425702804236" src="https://apis.google.com/u/0/se/0/_/+1/sharebutton?plusShare=true&amp;usegapi=1&amp;action=share&amp;annotation=bubble&amp;hl=pt-BR&amp;origin=http%3A%2F%2Flocalhost%3A5131&amp;url=http%3A%2F%2Flocalhost%3A5131%2Fpost%2Fpost-teste&amp;gsrc=3p&amp;jsh=m%3B%2F_%2Fscs%2Fapps-static%2F_%2Fjs%2Fk%3Doz.gapi.pt_BR.-Rp7PB1ZKIo.O%2Fm%3D__features__%2Fam%3DAQ%2Frt%3Dj%2Fd%3D1%2Ft%3Dzcms%2Frs%3DAGLTcCMnV8u_ZJrbTwAlzVa3FLMPkg1VNQ#_methods=onPlusOne%2C_ready%2C_close%2C_open%2C_resizeMe%2C_renderstart%2Concircled%2Cdrefresh%2Cerefresh%2Conload&amp;id=I1_1425702804236&amp;parent=http%3A%2F%2Flocalhost%3A5131&amp;pfname=&amp;rpctoken=20597497" data-gapiattached="true" title="+Compartilhar"></iframe>
                            </div>
                        </li>
                    </ul>-->
                    </div>

                    <div class="txt blog_txt mini_blog">
                        <a href="/post/post-teste" title="Ver Post">
                            <img width="190px" height="80px" src="/upload/imagens/blog/img_blog.jpg" class="thumb_artigo"></a>
                        <span class="titu_blog"><a href="#" title="Ver Post"><strong>Post Teste</strong></a></span>
                        <span>Em: <strong>22/02/2015</strong>, às <strong>23:53</strong></span>
                        <span>Inner ipsum code get amet, ....</span>

                        <a href="/post/post-teste" class="btn">LEIA MAIS</a>
                        <!--<ul class="social_blog">
                        <li>
                            <iframe src="//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fprojetopalavracantada.net%2Fpost%2Fpost-teste&amp;width&amp;layout=button_count&amp;action=like&amp;show_faces=true&amp;share=true&amp;height=21&amp;appId=404437276390840" scrolling="no" frameborder="0" style="border: none; overflow: hidden; height: 21px;" allowtransparency="true"></iframe>
                        </li>
                        <li class="tw_blog">
                            <iframe id="twitter-widget-1" scrolling="no" frameborder="0" allowtransparency="true" src="http://platform.twitter.com/widgets/tweet_button.b44aac737ba5fb3711801841c2833c12.pt.html#_=1425702804316&amp;count=horizontal&amp;dnt=true&amp;id=twitter-widget-1&amp;lang=pt&amp;original_referer=http%3A%2F%2Flocalhost%3A5131%2Fblog&amp;size=m&amp;url=http%3A%2F%2Fprojetopalavracantada.net%2Fpost%2Fpost-teste" class="twitter-share-button twitter-tweet-button twitter-share-button twitter-count-horizontal" title="Twitter Tweet Button" data-twttr-rendered="true" style="width: 122px; height: 20px;"></iframe>
                            <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
                        </li>
                        <li class="g_blog">
                            <div id="___plus_0" style="text-indent: 0px; margin: 0px; padding: 0px; border-style: none; float: none; line-height: normal; font-size: 1px; vertical-align: baseline; display: inline-block; width: 119px; height: 20px; background: transparent;">
                                <iframe frameborder="0" hspace="0" marginheight="0" marginwidth="0" scrolling="no" style="position: static; top: 0px; width: 119px; margin: 0px; border-style: none; left: 0px; visibility: visible; height: 20px;" tabindex="0" vspace="0" width="100%" id="I1_1425702804236" name="I1_1425702804236" src="https://apis.google.com/u/0/se/0/_/+1/sharebutton?plusShare=true&amp;usegapi=1&amp;action=share&amp;annotation=bubble&amp;hl=pt-BR&amp;origin=http%3A%2F%2Flocalhost%3A5131&amp;url=http%3A%2F%2Flocalhost%3A5131%2Fpost%2Fpost-teste&amp;gsrc=3p&amp;jsh=m%3B%2F_%2Fscs%2Fapps-static%2F_%2Fjs%2Fk%3Doz.gapi.pt_BR.-Rp7PB1ZKIo.O%2Fm%3D__features__%2Fam%3DAQ%2Frt%3Dj%2Fd%3D1%2Ft%3Dzcms%2Frs%3DAGLTcCMnV8u_ZJrbTwAlzVa3FLMPkg1VNQ#_methods=onPlusOne%2C_ready%2C_close%2C_open%2C_resizeMe%2C_renderstart%2Concircled%2Cdrefresh%2Cerefresh%2Conload&amp;id=I1_1425702804236&amp;parent=http%3A%2F%2Flocalhost%3A5131&amp;pfname=&amp;rpctoken=20597497" data-gapiattached="true" title="+Compartilhar"></iframe>
                            </div>
                        </li>
                    </ul>-->
                    </div>

                    <div class="txt blog_txt mini_blog">
                        <a href="/post/post-teste" title="Ver Post">
                            <img width="190px" height="80px" src="/upload/imagens/blog/img_blog.jpg" class="thumb_artigo"></a>
                        <span class="titu_blog"><a href="#" title="Ver Post"><strong>Post Teste</strong></a></span>
                        <span>Em: <strong>22/02/2015</strong>, às <strong>23:53</strong></span>
                        <span>Inner ipsum code get amet, ....</span>

                        <a href="/post/post-teste" class="btn">LEIA MAIS</a>
                        <!--<ul class="social_blog">
                        <li>
                            <iframe src="//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fprojetopalavracantada.net%2Fpost%2Fpost-teste&amp;width&amp;layout=button_count&amp;action=like&amp;show_faces=true&amp;share=true&amp;height=21&amp;appId=404437276390840" scrolling="no" frameborder="0" style="border: none; overflow: hidden; height: 21px;" allowtransparency="true"></iframe>
                        </li>
                        <li class="tw_blog">
                            <iframe id="twitter-widget-1" scrolling="no" frameborder="0" allowtransparency="true" src="http://platform.twitter.com/widgets/tweet_button.b44aac737ba5fb3711801841c2833c12.pt.html#_=1425702804316&amp;count=horizontal&amp;dnt=true&amp;id=twitter-widget-1&amp;lang=pt&amp;original_referer=http%3A%2F%2Flocalhost%3A5131%2Fblog&amp;size=m&amp;url=http%3A%2F%2Fprojetopalavracantada.net%2Fpost%2Fpost-teste" class="twitter-share-button twitter-tweet-button twitter-share-button twitter-count-horizontal" title="Twitter Tweet Button" data-twttr-rendered="true" style="width: 122px; height: 20px;"></iframe>
                            <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
                        </li>
                        <li class="g_blog">
                            <div id="___plus_0" style="text-indent: 0px; margin: 0px; padding: 0px; border-style: none; float: none; line-height: normal; font-size: 1px; vertical-align: baseline; display: inline-block; width: 119px; height: 20px; background: transparent;">
                                <iframe frameborder="0" hspace="0" marginheight="0" marginwidth="0" scrolling="no" style="position: static; top: 0px; width: 119px; margin: 0px; border-style: none; left: 0px; visibility: visible; height: 20px;" tabindex="0" vspace="0" width="100%" id="I1_1425702804236" name="I1_1425702804236" src="https://apis.google.com/u/0/se/0/_/+1/sharebutton?plusShare=true&amp;usegapi=1&amp;action=share&amp;annotation=bubble&amp;hl=pt-BR&amp;origin=http%3A%2F%2Flocalhost%3A5131&amp;url=http%3A%2F%2Flocalhost%3A5131%2Fpost%2Fpost-teste&amp;gsrc=3p&amp;jsh=m%3B%2F_%2Fscs%2Fapps-static%2F_%2Fjs%2Fk%3Doz.gapi.pt_BR.-Rp7PB1ZKIo.O%2Fm%3D__features__%2Fam%3DAQ%2Frt%3Dj%2Fd%3D1%2Ft%3Dzcms%2Frs%3DAGLTcCMnV8u_ZJrbTwAlzVa3FLMPkg1VNQ#_methods=onPlusOne%2C_ready%2C_close%2C_open%2C_resizeMe%2C_renderstart%2Concircled%2Cdrefresh%2Cerefresh%2Conload&amp;id=I1_1425702804236&amp;parent=http%3A%2F%2Flocalhost%3A5131&amp;pfname=&amp;rpctoken=20597497" data-gapiattached="true" title="+Compartilhar"></iframe>
                            </div>
                        </li>
                    </ul>-->
                    </div>

                    <nav class="paginacao">
                        <ul>
                            <li><a href="javascript:void(0);" class="nav_pg" title="Página anterior">
                                <img src="images/nav_left.png">ANTERIORES</a></li>
                            <li><a href="javascript:void(0);" title="Página atual" class="ativo">1</a></li>
                            <li><a href="javascript:void(0);" title="Página 2">2</a></li>
                            <li><a href="javascript:void(0);" title="Página 3">3</a></li>
                            <li><a href="javascript:void(0);" class="nav_pg" title="Próxima Página">PRÓXIMOS
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
