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
                
                <div style="border-width: 1px; border-color: rgb(102, 0, 51); border-style: none none dotted;" class="txt">
                    <img src="images/imagem-artigo.jpg" style="float: left; margin-right: 20px;">
                    <span style="float: left; font-size: 17px; font-weight: bold;">Título do Artigo</span>
                    <span style="float: left; font-size: 16px;">Autor: <strong>Loren Ipsun Esting</strong></span>
                    <span style="float: left; font-size: 16px;">Data da publicação: <strong>10/12/2014</strong></span>
                    <img style="float: left; margin-top: 10px;" src="images/btn_download.png">
                    <div class="txt">   
                        <p>Texto resumido com a descrição do artigo lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse porta neque eget lacus pretium, a imperdiet mauris ullamcorper. Etiam convallis enim a massa dapibus, non posuere massa facilisis.</p>
                    </div>
                </div>

                <div style="border-width: 1px; border-color: rgb(102, 0, 51); border-style: none none dotted;" class="txt">
                    <img src="images/imagem-artigo.jpg" style="float: left; margin-right: 20px;">
                    <span style="float: left; font-size: 17px; font-weight: bold;">Título do Artigo</span>
                    <span style="float: left; font-size: 16px;">Autor: <strong>Loren Ipsun Esting</strong></span>
                    <span style="float: left; font-size: 16px;">Data da publicação: <strong>10/12/2014</strong></span>
                    <img style="float: left; margin-top: 10px;" src="images/btn_download.png">
                    <div class="txt">   
                        <p>Texto resumido com a descrição do artigo lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse porta neque eget lacus pretium, a imperdiet mauris ullamcorper. Etiam convallis enim a massa dapibus, non posuere massa facilisis.</p>
                    </div>
                </div>

                <div style="border-width: 1px; border-color: rgb(102, 0, 51); border-style: none none dotted;" class="txt">
                    <img src="images/imagem-artigo.jpg" style="float: left; margin-right: 20px;">
                    <span style="float: left; font-size: 17px; font-weight: bold;">Título do Artigo</span>
                    <span style="float: left; font-size: 16px;">Autor: <strong>Loren Ipsun Esting</strong></span>
                    <span style="float: left; font-size: 16px;">Data da publicação: <strong>10/12/2014</strong></span>
                    <img style="float: left; margin-top: 10px;" src="images/btn_download.png">
                    <div class="txt">   
                        <p>Texto resumido com a descrição do artigo lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse porta neque eget lacus pretium, a imperdiet mauris ullamcorper. Etiam convallis enim a massa dapibus, non posuere massa facilisis.</p>
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
