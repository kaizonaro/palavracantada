<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="equipe.aspx.cs" Inherits="BrincaderiasMusicais.equipe" %>

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
                    Equipe
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <strong>Conheça - Equipe</strong>
                </div>
                <div class="txt boxDireita">
                    <div class="box_equipe">
                        <img src="/images/img_equipe.png" alt="Integrante da Equipe" /></div>
                </div>
                <div class="txt boxEsquerda">
                    <p>Conheça melhor cada um dos integrantes da equipe do Projeto Brincadeiras Musicais da Palavra Cantada.</p>
                    <p>Selecione no menu abaixo o integrante que deseja exibir e então clique no botão “ok” para visualizar a foto e a biografia do integrante.</p>
                    <div class="select_equipe txt">
                        <form action="javascript:void(0);">
                            <select name="equipe">
                                <option value="" selected>Escolha um menbro</option>
                                <option value="">Escolha um menbro</option>
                                <option value="">Escolha um menbro</option>
                                <option value="">Escolha um menbro</option>
                            </select>
                            <input type="submit" class="input btn" value="OK" />
                        </form>
                    </div>
                </div>
                 <div class="titu">
                    Nome do Individuo
                </div>
                <div class="txt">
                    Educadora musical, musicista e pesquisadora. Professora fundadora da EMIA - Escola Municipal de Iniciação Artística (São Paulo, SP), instituição na qual também exerceu o cargo de Assistente Artístico e foi coordenadora da área de música. Bacharel em Composição pela Escola de Comunicações e Artes da USP. Mestre e doutoranda pela Faculdade de Educação da Unicamp, integrante do Laborarte – Laboratório de Estudos sobre Arte, Corpo e Educação -, pesquisa as relações entre música, educação, estética e subjetividade. Tem apresentado palestras e trabalhos e prestado assessoria na área de educação musical em instituições públicas e privadas, cursos de extensão, seminários e congressos. Instrumentista, dedica-se ao clarinete e à flauta doce. Nesse instrumento especializou-se no Conservatório Real de Haia, Holanda. Apresentou-se como solista junto a formações como Orquestra Sinfônica Municipal de São Paulo e Sinfonia Cultura. Participa do grupo de música antiga Carmina, do quarteto de flautas doces Fontegara, como também do Núcleo E, voltado à performance e pesquisa entre linguagens artísticas.
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
