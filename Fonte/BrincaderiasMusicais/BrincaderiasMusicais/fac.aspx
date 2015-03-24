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
                        <select name="pergunta">
                            <option selected>Lorem ipsum dorem magna signat lorem est ipsum?</option>
                            <option>Lorem ipsum dorem magna signat lorem est ipsum?</option>
                            <option>Lorem ipsum dorem magna signat lorem est ipsum?</option>
                            <option>Lorem ipsum dorem magna signat lorem est ipsum?</option>
                            <option>Lorem ipsum dorem magna signat lorem est ipsum?</option>
                        </select>
                        <input type="submit" class="btn" value="ok" />
                        <p class="txt desc_faq">Caso você não encontre a resposta para a sua questão, entre em contato com a equipe Brincadeiras Musicais através do link <a href="/contato" title="contato">contato</a></</p>
                    </div>
                    <div class="full">
                        <p class="titu_verde">
                            Lorem ipsum dorem magna signat lorem est ipsum?
                        </p>
                        <p class="txt">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed imperdiet diam tortor, nec varius arcu blandit vel. Vestibulum accumsan ut augue et aliquam. Curabitur in nibh ut orci gravida euismod.Nam nec nisi et magna interdum posuere vel at metus. Fusce egestas vehicula risus ac lacinia. Integer est leo, viverra sed dictum id, ultricies non nibh. Duis tempus erat eget gravida vestibulum. Duis tempor a quam ullamcorper tristique.Nullam sollicitudin, elit tempor dapibus euismod, sem velit accumsan est, sed eleifend nisi nibh non turpis. Vivamus nisi velit, vulputate in scelerisque nec, egestas a eros. Nam nec magna sit amet lorem pharetra sodales. Pellentesque porta, felis non fringilla mattis, purus nunc dapibus quam, id vulputate eros erat eu nisl. Vivamus blandit, elit quis finibus feugiat, ante orci porttitor turpisLorem ipsum dorem est signat lorem ipsum signat nam nec nisi et magna interdum posuere vel at metus. Fusce egestas vehicula risus ac lacinia. Integer est leo, viverra sed dictum id, ultricies.</p>
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

