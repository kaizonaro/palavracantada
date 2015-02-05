<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="videos.aspx.cs" Inherits="BrincaderiasMusicais.videos" %>


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

            <!--CONTEUDO INTERNO (ARTIGOS)-->
            <div id="sobre" class="interna">
                <div class="titu">
                    Vídeos
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <strong>Explore - Vídeos</strong>
                </div>
                <div class="select_fotos txt">
                    <p>Selecione abaixo a galeria que gostaria de visualizar e clique ok</p>
                    <select>
                        <option value="" selected>galeria de formadores Brincadeiras Musicais da Palavra Cantada</option>
                    </select>
                    <input type="submit" class="input btn" value="OK" />
                </div>
               <iframe width="480" height="269" src="https://www.youtube.com/embed/fFo1i8EIS74?list=PLJP_tVi1LVdid5bUMWHJ8wSjz8mBmx0IF" frameborder="0" allowfullscreen></iframe>
                <p class="txt">
                    Inscreva-se nos perfis da Palavra Cantada e do Projeto Brincadeiras Musicais da Palavra Cantada para ficar sabendo primeiro quando novidades forem ao ar. Confira!
                </p>
                <div class="social_video">
                    <div class="left">
                        <a href="https://www.youtube.com/channel/UCaDajiE_wPYRwshUw9RsQPA" title="You Tube" target="_blank"><img src="images/you1.png" alt="Flickr Brincadeiras musicais" /></a>
                        <p class="desc_social">Clique aqui e inscreva-se no<br /><a href="https://www.youtube.com/channel/UCaDajiE_wPYRwshUw9RsQPA" title="You Tube" target="_blank">YOUTUBE OFICIAL</a> do Projeto<br /><b>Brincadeiras Musicais</b></p>
                    </div>
                    <div class="right">
                        <a href="https://www.youtube.com/user/palavracantadatube" title="You Tube" target="_blank"><img src="images/you2.png" alt="Flickr Brincadeiras musicais" /></a>
                        <p class="desc_social">Clique aqui e inscreva-se no<br /><a href="https://www.youtube.com/user/palavracantadatube" title="You Tube" target="_blank">YOUTUBE OFICIAL</a> do Projeto<br /><b>Palavra Cantada</b></p>
                    </div>
                </div>
                <ul class="social_foto">
                    <li>
                        <iframe src="//www.facebook.com/plugins/like.php?href=http%3A%2F%2Fprojetopalavracantada.net%2Fvideos&amp;width&amp;layout=button_count&amp;action=like&amp;show_faces=true&amp;share=true&amp;height=21&amp;appId=404437276390840" scrolling="no" frameborder="0" style="border:none; overflow:hidden; height:21px;" allowTransparency="true"></iframe>
                    </li>
                    <li class="tw_blog2">
                        <a href="https://twitter.com/share" class="twitter-share-button" data-lang="pt">Tweetar</a>
                        <script>!function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } }(document, 'script', 'twitter-wjs');</script>
                    </li>
                    <li class="g_blog">
                        <div class="g-plus" data-action="share" data-annotation="bubble" data-href="http://projetopalavracantada.net/videos"></div>
                        <!--altere o link (data-href) para o link do post-->
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