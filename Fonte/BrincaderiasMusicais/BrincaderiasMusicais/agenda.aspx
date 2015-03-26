<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agenda.aspx.cs" Inherits="BrincaderiasMusicais.agenda" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>

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
                    Agenda
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <strong>Agenda</strong>
                </div>
                <!-- INCLUDE -->
                <p class="titu_agenda">Próximos eventos de sua região:</p>
                <div class="box_eventos">
                    <p class="data_agendada"><a href="#">10/03/2015</a></p>
                    <p class="txt txt_menor">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ornare orci massa, ut esting porttitor dui condimentum id. Phasellus vitae efficitr eros lorem ipsum (máximo 195 caracteres).</p>
                </div>
                <div class="box_eventos">
                    <p class="data_agendada"><a href="#">10/03/2015</a></p>
                    <p class="txt txt_menor">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ornare orci massa, ut esting porttitor dui condimentum id. Phasellus vitae efficitr eros lorem ipsum (máximo 195 caracteres).</p>
                </div>
                <div class="box_eventos">
                    <p class="data_agendada"><a href="#">10/03/2015</a></p>
                    <p class="txt txt_menor">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ornare orci massa, ut esting porttitor dui condimentum id. Phasellus vitae efficitr eros lorem ipsum (máximo 195 caracteres).</p>
                </div>
                <br /><br /><img src="/images/linha.png" class="linha" />
                <p class="titu_calendario">AGENDA COMPLETA - << MARÇO 2015 >>:</p>
                <p class="txt sub_calendario txt_menor"><strong>Clique em uma data para visualizar mais detalhes sobre o evento.</strong></p><br /><br />
                <img src="/images/calendario.png" width="100%" /><br /><br />
                <p class="txt sub_calendario txt_menor"><strong>Detalhes sobre o evento selecionado:</strong></p>
                <div class="box_info_data">
                    <p><strong><< Título do evento selecionado >></strong></p>
                    <p>Data:<strong> << data do evento >></strong></p>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ornare orci massa, ut esting porttitor dui condimentum id. Phasellus vitae efficitr eros lorem ipsum (máximo 195 caracteres).</p>
                </div>

            </div>
            <!--FIM DO CONTEUDO INTERNO (ARTIGOS)-->

            <!--RODAPÉ-->
            <brincadeira:footer runat="server" ID="footer" />
            <!--FIM DO RODAPÉ-->
</body>
</html>

