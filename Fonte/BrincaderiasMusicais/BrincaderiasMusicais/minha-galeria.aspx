<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="minha-galeria.aspx.cs" Inherits="BrincaderiasMusicais.minha_galeria" %>

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


    <title>Palavra Cantada - Redes</title>
    <!--FACEBOOK-->
    <meta property="og:title" content="Projeto Brincadeiras Musicais da Palavra Cantada - Artigos" />
    <meta property="og:image" content="http://projetopalavracantada.net/images/logo-fb.png" />
    <meta property="og:description" content="Página de Artigos" />
    <meta property="og:url" content="http://projetopalavracantada.net/artigos" />

    <brincadeira:script runat="server" ID="script" />
    
    <script type="text/javascript">
        function pagina(pg) {
            location.href = "minha-galeria.aspx?pagina=" + pg + "";
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
            <div id="meuperfil" class="interna">
                
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a> >> <a href="/meu-perfil/" title="Home">Meu Perfil</a> >> <strong>Minhas Fotos</strong>
                </div>
                <br /><br />
                <brincadeira:headerperfil runat="server" ID="headerperfil" />
                
                <img src="/images/linha.png" class="linha" />
                
                <div id="divArtigos" runat="server">

                   <!-- <div class="titu_galeria">
                        GALERIA DE FOTOS - << NOME DO USUÁRIO >>
                    </div>
                    
                    <ul class="galeria_img_interna">
                        <li><a href="/upload/imagens/galeria/ampliada/galeria.jpg">
                            <img src="/upload/imagens/galeria/blog-pb.jpg" alt=" Foto 01 - aberta"></a>
                            <p>titulo numero 01</p>
                        </li>
                        <li><a href="/upload/imagens/galeria/ampliada/galeria2.jpg">
                            <img src="/upload/imagens/galeria/blog-pb.jpg" alt=" Foto 01 - aberta"></a>
                            <p>titulo numero 01</p>
                        </li>
                        <li><a href="/upload/imagens/galeria/ampliada/galeria.jpg">
                            <img src="/upload/imagens/galeria/blog-pb.jpg" alt=" Foto 01 - aberta"></a>
                            <p>titulo numero 01</p>
                        </li>
                        <li><a href="/upload/imagens/galeria/ampliada/galeria2.jpg">
                            <img src="/upload/imagens/galeria/blog-pb.jpg" alt=" Foto 01 - aberta"></a>
                            <p>titulo numero 01</p>
                        </li>
                        <li><a href="/upload/imagens/galeria/ampliada/galeria.jpg">
                            <img src="/upload/imagens/galeria/blog-pb.jpg" alt=" Foto 01 - aberta"></a>
                            <p>titulo numero 01</p>
                        </li>
                        <li><a href="/upload/imagens/galeria/ampliada/galeria2.jpg">
                            <img src="/upload/imagens/galeria/blog-pb.jpg" alt=" Foto 01 - aberta"></a>
                            <p>titulo numero 01</p>
                        </li>
                        <li><a href="/upload/imagens/galeria/ampliada/galeria.jpg">
                            <img src="/upload/imagens/galeria/blog-pb.jpg" alt=" Foto 01 - aberta"></a>
                            <p>titulo numero 01</p>
                        </li>
                        <li><a href="/upload/imagens/galeria/ampliada/galeria2.jpg">
                            <img src="/upload/imagens/galeria/blog-pb.jpg" alt=" Foto 01 - aberta"></a>
                            <p>titulo numero 01</p>
                        </li>
                        <li><a href="/upload/imagens/galeria/ampliada/galeria.jpg">
                            <img src="/upload/imagens/galeria/blog-pb.jpg" alt=" Foto 01 - aberta"></a>
                            <p>titulo numero 01</p>
                        </li>
                    </ul>-->

                   <!-- <nav class="paginacao">
                        <ul>
                            <li><a href="javascript:void(0);" class="nav_pg" title="Página anterior">
                                <img src="images/nav_left.png">ANTERIORES</a></li>
                            <li><a href="javascript:void(0);" title="Página atual" class="ativo">1</a></li>
                            <li><a href="javascript:void(0);" title="Página 2">2</a></li>
                            <li><a href="javascript:void(0);" title="Página 3">3</a></li>
                            <li><a href="javascript:void(0);" class="nav_pg" title="Próxima Página">PRÓXIMOS
                                <img src="images/nav_right.png "></a></li>
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

    <!-- LIGHT VIEW MODAL E AFINS-->
    <div id="mask" runat="server">
        <article id="fotos">
            <img src="/images/galeri0202a.jpg" class="img_galeria" />
            <p>:: LEGANDA DA FOTO 001 ::</p>
            <div class="controles">
                <div class="left_galeria2">
                    <img src="/images/arrow_left2.png" />
                </div>
                <div class="quantos"><b class="atual">1</b>/<b class="total">4</b></div>
                <div class="right_galeria2">
                    <img src="/images/arrow_right2.png" />
                </div>
                <div class="fechar_galeria fechar_foto">FECHAR</div>
            </div>
        </article>
    </div>
    <!-- FIM DO LIGHT VIEW MODAL E AFINS-->
</body>
</html>
