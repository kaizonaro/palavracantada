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
                    <a href="/" title="Home">Home</a>  <strong>Agenda</strong>
                </div>
                <!-- INCLUDE -->
                <form runat="server">
                    <p class="titu_agenda">Próximos eventos de sua região:</p>
                    <div id="topeventos" runat="server">
                      
                    </div>
                    <br />
                    <br />
                    <img src="/images/linha.png" class="linha" />
                    <p class="titu_calendario">AGENDA COMPLETA -  MARÇO 2015 :</p> <!-- acho que poderia ser removida esta linha -->
                    <p class="txt sub_calendario txt_menor"><strong>Clique em uma data para visualizar mais detalhes sobre o evento.</strong></p>
                    <br />
                    <br />

                    <asp:Calendar ID="calendario" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" OnSelectionChanged="calendario_SelectionChanged" Width="100%" OnDayRender="calendario_DayRender" SelectionMode="None">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                    <br />
                    <br />
                    <p class="txt sub_calendario txt_menor"><strong>Detalhes sobre o evento selecionado:</strong></p>
                    <div class="box_info_data">
                        <p><strong><span id="detalhe_tituloevento" runat="server"></span></strong></p>
                        <p>Data:<strong>  <span id="detalhe_dataevento" runat="server"></span></strong></p>
                        <p id="detalhe_descricaoevento" runat="server"></p>
                    </div>
                </form>
            </div>
            <!--FIM DO CONTEUDO INTERNO (ARTIGOS)-->

            <!--BOX LOGIN-->
            <brincadeira:login runat="server" ID="login" />

            <!--BLOG-->
            <brincadeira:blog runat="server" ID="blog" />

        </div>
    </section>
    <!--RODAPÉ-->
    <brincadeira:footer runat="server" ID="footer" />
    <!--FIM DO RODAPÉ-->
</body>
</html>

