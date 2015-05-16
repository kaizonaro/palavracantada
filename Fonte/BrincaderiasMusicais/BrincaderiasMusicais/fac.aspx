<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fac.aspx.cs" Inherits="BrincaderiasMusicais.fac" %>

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

        function MudarFAQ(id) {
            //validar se há pergunta selecionado
            if (id != 0) {
                mod.open("GET", "fac.aspx?id=" + id + "&ACAO=mudarFAQ", true);
                mod.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                mod.onreadystatechange = function () {
                    if (mod.readyState == 4) {
                        if (mod.status == 200) {
                            var ss = mod.responseText.split("|");
                            $('#pPergunta').html(ss[0]);
                            $('#pResposta').html(ss[1]);
                            $('.recebe_faq').addClass('resposta_do_faq')
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

            <!--CONTEUDO INTERNO (QUEM SOMOS)-->
            <div id="sobre" class="interna faq">
                <div id="titu" class="titu">FAQ</div>
                <div id="breadcrumb"><a href='/' title='Home'>Home</a> >> <strong>FAQ</strong></div>

                <div class="box_prof">
                    Olá! Eu sou o Professor Beleléu.<br />
                    <br />
                    A Palavra Cantada me convidou<br />
                    para responder nesta página<br />
                    as  perguntas mais frequentes<br />
                    sobre o Brincadeiras Musicais.
                </div>

                <div class="full">
                    <div class="prof">
                        <img src="/images/prof.png" />
                    </div>
                    <div class="select_faq">
                        <p class="txt"><strong>Selecione na caixa de opções abaixo a resposta que deseja visualizar e clique no botão de ok para visualizar a respota.</strong> </p>
                        
                        <form action="javascript:void(0)" onsubmit="MudarFAQ($('#pergunta').val())">
                            <select name="pergunta" id="pergunta" runat="server">
                                <option value="0" selected="selected">Selecione uma das perguntas abaixo:</option>
                            </select>
                            <input type="submit" class="btn" value="ok" />
                        </form>
                        <p class="txt desc_faq">Caso você não encontre a resposta para a sua questão, entre em contato com a equipe Brincadeiras Musicais através do link <a href="/contato" title="contato">contato</a></</p>

                    </div>
                    <div class="full recebe_faq">
                        <p class="titu_verde" id="pPergunta" runat="server">
                            
                        </p>
                        <p class="txt" id="pResposta" runat="server"></p>
                    </div>
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

