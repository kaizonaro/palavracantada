<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="quem-somos.aspx.cs" Inherits="BrincaderiasMusicais.quem_somos" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

            <!--CONTEUDO INTERNO (QUEM SOMOS)-->
            <div id="sobre" class="interna">
                <div class="titu">
                    Quem Somos
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <strong>Conheça - Quem Somos</strong>
                </div>
                <img src="/images/quem-somos-1.jpg" class="img_destaque" />
                <div class="txt">
                    <p>A  <strong>EDITORA MELHORAMENTOS</strong> se consagrou no mercado editorial com seu catálogo de alta qualidade, autores e ilustradores renomados. Atualmente, oferece mais de mil títulos de literatura infantil e juvenil, formação de professores, gastronomia e desenvolvimento pessoal, além da conceituada linha Michaelis de dicionários. Respeitados autores, como Ziraldo, Mauricio de Sousa, Tatiana Belinky, Angela Lago, Sandra Peres e Paulo Tatit figuram entre os escritores que colaboram para o sucesso editorial dessa grande empresa.</p>
                </div>
                <img src="/images/quem-somos-2.jpg" class="img_destaque" />
                <div class="txt">
                    <p>A  <strong>PALAVRA CANTADA</strong>  existe desde 1994, quando os músicos Sandra Peres e Paulo Tatit propuseram criar novas canções para as crianças. Em todos os seus trabalhos, tornaram-se linhas marcantes a preocupação com a qualidade de letras, arranjos e gravações e o respeito à inteligência e à sensibilidade infantil.</p>
                </div>
            </div>
            <!--FIM DO CONTEUDO INTERNO (QUEM SOMOS)-->

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
