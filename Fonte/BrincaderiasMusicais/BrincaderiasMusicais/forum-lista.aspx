<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forum-lista.aspx.cs" Inherits="BrincaderiasMusicais.forum_lista" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>
<%@ Register Src="~/inc/headerperfil.ascx" TagPrefix="brincadeira" TagName="headerperfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">


    <title>Palavra Cantada - Fórum</title>
    <!--FACEBOOK-->
    <meta property="og:title" content="Projeto Brincadeiras Musicais da Palavra Cantada - Fórum" />
    <meta property="og:image" content="http://projetopalavracantada.net/images/logo-fb.png" />
    <meta property="og:description" content="Página de Artigos" />
    <meta property="og:url" content="http://projetopalavracantada.net/forum" />

    <brincadeira:script runat="server" ID="script" />

     <script type="text/javascript">
         function pagina() {
             location.href = "/forum";
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

            <!--CONTEUDO INTERNO (ARTIGOS)-->
            <div id="sobre" class="interna2">
                <div class="titu">
                    Fórum
                </div>
                <div id="breadcrumb" runat="server">
                </div>
                <p class="titu_forum">
                    <img src="/images/titu_forum.png" alt="Icone" />
                    <span id="spanTitulo" runat="server"></span>
                </p>
                <p class="mini_txt_forum">Escreva sua mensagem no campo abaixo e clique no botão "Publicar mensagem".</p>
                <div id="up_foto" class="full up_post_btn">
                    <button class="btn_back up_forum" onclick="pagina(); return false;">Voltar</button>
                    <form id="frmPostar" name="frmPostar" action="/postar-forum" method="post">
                        <input type="hidden" id="FTO_ID" runat="server" />
                        <input type="hidden" id="REDIRECT" runat="server" />
                        <input type="submit" name="pub" value="PUBLICAR MENSAGEM" id="pub" class="btn_save up_forum">
                    </form>
                    <hr class="div_forum" />
                </div>
                <div id="divLista" runat="server">
                    <!-- <div class="txt blog_txt txt_forum">
                    <div class="txt">
                        <p class="destque_forum">Mensagem enviada por: <a href='#' title='João da Silva'>João da Silva</a></p>
                        <p class="destque_forum">Enviada em: <b>10/03/2015</b></p>
                        <br />
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla pellentesque urna ac sem maximus pulvinar. Proin id hendrerit nunc. Cras vel vehicula erat. Praesent vel aliquam felis. Etiam vitae arcu at turpis volutpat feugiat eu id tortor. In tristique tempor dui, a dictum ex venenatis nec. Nulla facilisi. Phasellus sodales euismod ligula, vel pretium libero scelerisque in. Fusce consequat magna a diam consectetur, et fermentum risus laoreet.</p>
                    </div>
                </div>

                <div class="txt blog_txt txt_forum">
                    <div class="txt">
                        <p class="destque_forum">Mensagem enviada por: <a href='#' title='João da Silva'>João da Silva</a></p>
                        <p class="destque_forum">Enviada em: <b>10/03/2015</b></p>
                        <br />
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla pellentesque urna ac sem maximus pulvinar. Proin id hendrerit nunc. Cras vel vehicula erat. Praesent vel aliquam felis. Etiam vitae arcu at turpis volutpat feugiat eu id tortor. In tristique tempor dui, a dictum ex venenatis nec. Nulla facilisi. Phasellus sodales euismod ligula, vel pretium libero scelerisque in. Fusce consequat magna a diam consectetur, et fermentum risus laoreet.</p>
                    </div>
                </div>

                <div class="txt blog_txt txt_forum">
                    <div class="txt">
                        <p class="destque_forum">Mensagem enviada por: <a href='#' title='João da Silva'>João da Silva</a></p>
                        <p class="destque_forum">Enviada em: <b>10/03/2015</b></p>
                        <br />
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla pellentesque urna ac sem maximus pulvinar. Proin id hendrerit nunc. Cras vel vehicula erat. Praesent vel aliquam felis. Etiam vitae arcu at turpis volutpat feugiat eu id tortor. In tristique tempor dui, a dictum ex venenatis nec. Nulla facilisi. Phasellus sodales euismod ligula, vel pretium libero scelerisque in. Fusce consequat magna a diam consectetur, et fermentum risus laoreet.</p>
                    </div>
                </div>
                <nav class="paginacao">
                    <ul>
                        <li><a href="javascript:void(0);" class="nav_pg" title="Página anterior">
                            <img src="/images/nav_left.png">ANTERIORES</a></li>
                        <li><a href="javascript:void(0);" title="Página atual" class="ativo">1</a></li>
                        <li><a href="javascript:void(0);" onclick="pagina('2')" title="Página 2">2</a></li>
                        <li><a href="javascript:void(0);" onclick="pagina('2')" class="nav_pg" title="Próxima Página">PRÓXIMOS
                            <img src="/images/nav_right.png "></a></li>
                    </ul>
                </nav>-->
                </div>
            </div>
            <!--FIM DO CONTEUDO INTERNO (ARTIGOS)-->

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
