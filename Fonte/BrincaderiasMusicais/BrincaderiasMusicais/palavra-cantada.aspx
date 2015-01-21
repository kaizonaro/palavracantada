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
                    <p><strong>Sandra Peres</strong> aenean rutrum odio et eros eleifend tempor. Cras a tempus sem, mollis pulvinar leo. Vivamus magna tellus, molestie sit amet tincidunt id, consectetur lacinia nisi. Donec vitae laoreet sem, ut hendrerit lacus. Nulla tortor sem, mattis sed quam id, feugiat pulvinar sem. Ut euismod posuere pulvinar. Nulla cursus lectus neque, eget tempor mi pulvinar at. Pellentesque a mi quam. Quisque ut odio nec eros pulvinar iaculis rutrum nec eros. Phasellus vehicula lobortis dolor sed sollicitudin. Aliquam id vehicula tellus. Lorem utrum odio et eros eleifend tempor. Cras a tempus sem, mollis pulvinar leo. Vivamus magna tellus, molestie sit amet tincidunt id, consectetur lacinia nisi. utrum odio et eros eleifend tempor. Cras a tempus sem, mollis pulvinar leo. Vivamus magna tellus, molestie sit amet tincidunt id, consectetur lacinia nisi.</p>
                </div>
                <div class="txt boxDireita">
                    <p><strong>Paulo Tait</strong> maecenas enim tellus, sodales a mattis sed, gravida vitae libero. Maecenas sollicitudin mollis sapien, sed eleifend dui. Integer iaculis nibh eget dolor gravida, et molestie nisl scelerisque. Maecenas in scelerisque felis. Fusce nec ultrices ipsum, in facilisis elit. Ut dapibus, quam eu vestibulum venenatis, odio nisi venenatis nisl, ut lorem ipsum doren est signat magnaconsectetur nisl ligula non lorem. Mauris pharetra neque risus, vitae gravida urna dapibus lorem ipsum lorem est signat non at. In hac habitasse platea dictumst. Maecenas enim tellus, sodales a mattis sed, gravida vitae libero. Maecenas sollicitudin mollis sapien, sed eleifend dui. Integer iaculis nibh eget dolor gravida, et molestie nisl scelerisque. Maecenas in scelerisque felis. Fusce nec ultrices ipsum, in facilisis elit. Ut dapibus.</p>
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