<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="palavra-cantada.aspx.cs" Inherits="BrincaderiasMusicais.palavra_cantada" %>

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
            <div id="sobre" class="interna palavraCantada">
                <div class="titu">
                    Palavra Cantada
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <strong>Conheça - Palavra Cantada</strong>
                </div>
                <img src="/images/sandra-paulo.jpg" class="img_destaque" />
                <div class="txt boxEsquerda">
                    <p><strong>Sandra Peres</strong> é pianista e compositora, formada pela Faculdade de Música do Conservatório Dramático e Musical de São Paulo. Em 1986, em Paris, fez o curso completo de Análise de Composição Cotemporânea no IRCAM. De volta ao Brasil, se dedicou por dois anos ao curso de Musicoterapia na Universidade Marcelo Tupinambá. Em 1994, criou com Paulo Tatit o selo Palavra Cantada.</p>
                </div>
                <div class="txt boxDireita">
                    <p><strong>Paulo Tait</strong> é arquiteto de formação e músico autodidata. Participou como principal arranjador do Grupo Rumo, que foi destaque da vanguarda musical paulistana na década de 1980, e trabalhou como músico e parceiro do compositor Arnaldo Antunes nos anos 1990. Em 1994, criou com Sandra Peres, o selo Palavra Cantada, que vem sendo aclamada pelo público e pela crítica do país como um trabalho diferenciado dentro da nossa cultura musical.</p>
                </div>
                <img src="/images/banner_bottom.jpg" class="interna_bottom" />
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