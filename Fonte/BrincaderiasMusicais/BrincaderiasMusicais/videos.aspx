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
                    Fotos
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
                    nscreva-se nos perfis da Palavra Cantada e do Projeto Brincadeiras Musicais da Palavra Cantada para ficar sabendo primeiro quando novidades forem ao ar. Confira!
                </p>
                <div class="social_video">
                    <div class="left">
                        <img src="images/you1.png" alt="Flickr Brincadeiras musicais" />
                        <p class="desc_social">Clique aqui e inscreva-se no<br /><a href="" title="You Tube" target="_blank">YOUTUBE OFICIAL</a> do Projeto<br /><b>Brincadeiras Musicais</b></p>
                    </div>
                    <div class="right">
                        <img src="images/you2.png" alt="Flickr Brincadeiras musicais" />
                        <p class="desc_social">Clique aqui e inscreva-se no<br /><a href="" title="You Tube" target="_blank">YOUTUBE OFICIAL</a> do Projeto<br /><b>Palavra Cantada</b></p>
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