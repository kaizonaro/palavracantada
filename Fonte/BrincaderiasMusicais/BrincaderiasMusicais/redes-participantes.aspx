<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="redes-participantes.aspx.cs" Inherits="BrincaderiasMusicais.redes_participantes" %>

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

            <!--CONTEUDO INTERNO (REDES PARTICIPANTES)-->
            <div id="sobre" class="interna redesParticipantes">
                <div class="titu">
                    Redes Participantes
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <strong>Conheça - Redes Participantes</strong>
                </div>
                <img src="/images/redes-participantes-1.jpg" class="img_destaque" />
                <div class="txt boxEsquerda">
                    <ul>
                        <li>Aparecida de Goiânia – GO</li>
                        <li>Americana – SP</li>
                        <li>Bauru – SP</li>
                        <li>Belford Roxo – RJ</li>
                        <li>Cachoeira Paulista – SP</li>
                        <li>Cajamar – SP</li>
                        <li>Campinas – SP</li>
                        <li>Cotia – SP</li>
                        <li>Cubatão – SP</li>
                        <li>Embu das Artes – SP</li>
                        <li>Ferraz de Vasconcelos – SP</li>
                        <li>Indaiatuba – SP</li>
                        <li>Itirapina – S</li>
                        <li>Jundiaí – SP</li>
                        <li>Goiânia – GO</li>
                    </ul>
                </div>
                <div class="txt boxDireita">
                    <ul>
                        <li>Louveira – SP</li>
                        <li>Mauá – SP</li>
                        <li>Mogi Mirim – SP</li>
                        <li>Nepomuceno – MG</li>
                        <li>Niterói – RJ</li>
                        <li>Praia Grande – SP</li>
                        <li>Santana de Parnaíba – SP</li>
                        <li>Salvador – BA</li>
                        <li>São Gonçalo – RJ</li>
                        <li>Sorocaba – SP</li>
                        <li>Sumaré – SP</li>
                        <li>Taboão da Serra – SP</li>
                        <li>Taquaritinga – SP</li>
                        <li>Taubaté – SP</li>
                        <li>Vargem Grande Pta. – SP</li>
                    </ul>
                </div>
                
            </div>
            <!--FIM DO CONTEUDO INTERNO (REDES PARTICIPANTES)-->

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
