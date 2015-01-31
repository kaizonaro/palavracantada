<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fotos.aspx.cs" Inherits="BrincaderiasMusicais.fotos1" %>

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
                    Fotos
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <strong>Explore - Fotos</strong>
                </div>
                <div class="select_fotos txt">
                    <p>Selecione abaixo a galeria que gostaria de visualizar e clique ok</p>
                    <select>
                        <option value="" selected>galeria de formadores Brincadeiras Musicais da Palavra Cantada</option>
                    </select>
                    <input type="submit" class="input btn" value="OK" />
                </div>
                <object width="468" height="297">
                    <param name="flashvars" value="offsite=true&lang=en-us&page_show_url=%2Fphotos%2Fbrincamusicais%2Fsets%2F72157648231396034%2Fshow%2F&page_show_back_url=%2Fphotos%2Fbrincamusicais%2Fsets%2F72157648231396034%2F&set_id=72157648231396034&jump_to="></param>
                    <param name="movie" value="https://www.flickr.com/apps/slideshow/show.swf?v=1811922554"></param>
                    <param name="allowFullScreen" value="true"></param>
                    <embed type="application/x-shockwave-flash" src="https://www.flickr.com/apps/slideshow/show.swf?v=1811922554" allowfullscreen="true" flashvars="offsite=true&lang=en-us&page_show_url=%2Fphotos%2Fbrincamusicais%2Fsets%2F72157648231396034%2Fshow%2F&page_show_back_url=%2Fphotos%2Fbrincamusicais%2Fsets%2F72157648231396034%2F&set_id=72157648231396034&jump_to=" width="468" height="297"></embed>
                </object>
                <p class="txt">
                    Siga os perfis do Projeto Brincadeiras Musicais da Palavra Cantada no <b>Flickr</b> e no <b>Instagram</b> e não perca nenhuma novidade do projeto. Confira os links!
                </p>
                <div class="social_fotos">
                    <div class="left">
                        <img src="images/flickr_fotos.png" alt="Flickr Brincadeiras musicais" />
                        <p class="desc_social">Projeto Brincadeiras Musicais<br /> da Palavra Cantada<br /> <a href="https://www.flickr.com/photos/brincamusicais" title="Flickr" target="_blank">FLICKR OFICIAL</a></p>
                    </div>
                    <div class="right">
                        <img src="images/insta_fotos.png" alt="Flickr Brincadeiras musicais" />
                        <p class="desc_social">Projeto Brincadeiras Musicais<br /> da Palavra Cantada<br /> <a href="http://localhost:5131/images/insta.png" title="INSTAGRAM" target="_blank">INSTAGRAM OFICIAL</a></p>
                    </div>
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

