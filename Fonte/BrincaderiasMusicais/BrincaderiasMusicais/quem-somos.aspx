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

            <!--CONTEUDO INTERNO (SOBRE)-->
            <div id="sobre" class="interna">
                <div class="titu">
                    Quem Somos
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <strong>Conheça - Quem Somos</strong>
                </div>
                <img src="/images/sobre.jpg" class="img_destaque" />
                <div class="txt">
                    <p>Aenean rutrum odio et eros eleifend tempor. Cras a tempus sem, mollis pulvinar leo. Vivamus magna tellus, molestie sit amet tincidunt id, consectetur lacinia nisi. Donec vitae laoreet sem, ut hendrerit lacus. Nulla tortor sem, mattis sed quam id, feugiat pulvinar sem. Ut euismod posuere pulvinar. Nulla cursus lectus neque, eget tempor mi pulvinar at. Pellentesque a mi quam. Quisque ut odio nec eros pulvinar iaculis rutrum nec eros. Phasellus vehicula lobortis dolor sed sollicitudin. Aliquam id vehicula tellus. Suspendisse ac orci nunc. Etiam ac quam augue.</p>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam feugiat sed mi quis rutrum. Nulla ultrices condimentum mi ac sagittis. Etiam aliquam id velit in commodo. Nullam facilisis malesuada molestie. Praesent eleifend vulputate libero, a cursus justo blandit a. Nunc scelerisque lorem eget quam eleifend fringilla. Pellentesque pharetra vel dolor sed pretium. Maecenas vulputate, urna vel convallis semper, tellus odio tempus sem, sit amet mollis enim lectus et orci. Sed sit amet leo ut est euismod aliquam. Ut sit amet ligula id ipsum sagittis convallis quis sed erat.</p>
                    <p>Maecenas enim tellus, sodales a mattis sed, gravida vitae libero. Maecenas sollicitudin mollis sapien, sed eleifend dui. Integer iaculis nibh eget dolor gravida, et molestie nisl scelerisque. Maecenas in scelerisque felis. Fusce nec ultrices ipsum, in facilisis elit. Ut dapibus, quam eu vestibulum venenatis, odio nisi venenatis nisl, ut consectetur nisl ligula non lorem. Mauris pharetra neque risus, vitae gravida urna dapibus at. In hac habitasse platea dictumst.</p>
                </div>
            </div>
            <!--FIM DO CONTEUDO INTERNO (SOBRE)-->

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
