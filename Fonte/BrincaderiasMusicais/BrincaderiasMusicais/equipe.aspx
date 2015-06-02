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

    <script type="text/javascript">
        //ajax
        function GetXMLHttp() {
            if (navigator.appName == "Microsoft Internet Explorer") {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            } else {
                xmlHttp = new XMLHttpRequest();
            }
            return xmlHttp;
        }
        var mod = GetXMLHttp();

        function MudarIntegrante(id) {
            //validar se há integrante selecionado
            if (id != 0) {
                mod.open("GET", "equipe.aspx?id=" + id + "&ACAO=mudarIntegrante", true);
                mod.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                mod.onreadystatechange = function () {
                    if (mod.readyState == 4) {
                        if (mod.status == 200) {
                            var ss = mod.responseText.split("|");
                            //alert(id);
                            $('#divNome').html(ss[0]);
                            $('#divDescricao').html(ss[1]);
                            $('#imgIntegrante').attr("src", "/upload/imagens/equipe/" + ss[2]);
                            //$("#slPlayList option[value='" + ss[1] + "']").attr("selected", "selected");
                        }
                    }
                };
                mod.send(null);
            }
        }
    </script>
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
                        <img src="/images/img_equipe.png" alt="Integrante da Equipe" id="imgIntegrante" /></div>
                </div>
                <div class="txt boxEsquerda">
                    <p>Conheça melhor cada um dos integrantes da equipe do Projeto Brincadeiras Musicais da Palavra Cantada.</p>
                    <p>Selecione no menu abaixo o integrante que deseja exibir e então clique no botão “ok” para visualizar a foto e a biografia do integrante.</p>
                    <div class="select_equipe txt">
                        <form action="javascript:void(0)" onsubmit="MudarIntegrante($('#slIntegrante').val())">
                            <select name="equipe" runat="server" id="slIntegrante">
                                <option value="0" selected="selected">Escolha um membro</option>
                            </select>
                            <input type="submit" class="input btn" value="OK" />
                        </form>
                    </div>
                </div>
                <div class="titu" id="divNome">
                    
                </div>
                <div class="txt" id="divDescricao">
                    
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
