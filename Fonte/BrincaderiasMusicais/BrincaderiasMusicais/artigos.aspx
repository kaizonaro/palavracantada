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
                
                <div class="txt artigo_txt">
                    <img src="images/imagem-artigo.jpg" class="thumb_artigo">
                    <span><strong> Título do Artigo</strong></span>
                    <span>Autor: <strong>Loren Ipsun Esting</strong></span>
                    <span>Data da publicação: <strong>10/12/2014</strong></span>
                    <img src="images/btn_download.png" class="download_artigo">
                    <div class="txt">   
                        <p>Texto resumido com a descrição do artigo lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse porta neque eget lacus pretium, a imperdiet mauris ullamcorper. Etiam convallis enim a massa dapibus, non posuere massa facilisis.</p>
                    </div>
                </div>

                 <div class="txt artigo_txt">
                    <img src="images/imagem-artigo.jpg" class="thumb_artigo">
                    <span><strong> Título do Artigo</strong></span>
                    <span>Autor: <strong>Loren Ipsun Esting</strong></span>
                    <span>Data da publicação: <strong>10/12/2014</strong></span>
                    <img src="images/btn_download.png" class="download_artigo">
                    <div class="txt">   
                        <p>Texto resumido com a descrição do artigo lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse porta neque eget lacus pretium, a imperdiet mauris ullamcorper. Etiam convallis enim a massa dapibus, non posuere massa facilisis.</p>
                    </div>
                </div>

                 <div class="txt artigo_txt">
                    <img src="images/imagem-artigo.jpg" class="thumb_artigo">
                    <span class="titu_artigo"><strong> Título do Artigo</strong></span>
                    <span>Autor: <strong>Loren Ipsun Esting</strong></span>
                    <span>Data da publicação: <strong>10/12/2014</strong></span>
                    <img src="images/btn_download.png" class="download_artigo">
                    <div class="txt">   
                        <p>Texto resumido com a descrição do artigo lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse porta neque eget lacus pretium, a imperdiet mauris ullamcorper. Etiam convallis enim a massa dapibus, non posuere massa facilisis.</p>
                    </div>
                </div>

                <nav class="paginacao">
                    <ul>
                        <li><a href="#" class="nav_pg" title="Página anterior"><img src="images/nav_left.png" />ANTERIORES</a></li>
                        <li><a href="#" title="Página 01" class="ativo">01</a></li>
                        <li><a href="#" title="Página 02">02</a></li>
                        <li><a href="#" title="Página 03">03</a></li>
                        <li><a href="#" class="nav_pg" title="Próxima Página">PRÓXIMOS <img src="images/nav_right.png "/></a></li>
                    </ul>                    
                </nav>

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
