<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="galeria-geral.aspx.cs" Inherits="BrincaderiasMusicais.galeria_geral" %>

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
                    <p class="titu_agenda">Galeria Colaborativa de Fotos</p>
                    <p class="sub_galeria_geral">Fotografias enviadas pelos membros da rede de ensino de <strong id="nomerede1" runat="server"></strong>
(use as setas para navegar nas fotos e clique na foto para ampliá-la).</p>
                    <div class="galeria_geral">

                        <div class="mascara">
                            <!-- FOTOS -->
                            <ul id="ulFotos" class="fotos_home carrousel" rel="0" runat="server">
                              
                               
                                
                                
                            </ul>
                            <div class="left_video">
                                <img src="/images/arrow_left2.png">
                            </div>
                            <div class="right_video">
                                <img src="/images/arrow_right2.png">
                            </div>
                        </div>

                    </div>

                    <div class="upload_geral">
                        <p>Participe da Galeria Colaborativa de Fotos!</p>
                        <a href="enviar-foto.aspx"><img src="images/foto_icon.png" alt="Icone Camera"/> Clique para enviar a sua foto</a>
                    </div>
                    <img src="/images/linha.png" class="linha" />
                    <p class="titu_agenda">Galeria Colaborativa de Fotos</p>
                    <p class="sub_galeria_geral">Vídeos enviados pelos membros da rede de ensino de  <strong id="nomerede2" runat="server"></strong>
(use as setas para navegar nos vídeos e clique na imagem para assistir o vídeo).</p>
                    <div class="galeria_geral">
                        <div class="mascara">
                            <!-- VIDEOS -->
                            <ul id="ulVideos" class="videos_home carrousel" rel="0" style="display:block;" runat="server">
                                 
                               
                            </ul>
                            <div class="left_video">
                                <img src="/images/arrow_left2.png">
                            </div>
                            <div class="right_video">
                                <img src="/images/arrow_right2.png">
                            </div>
                        </div>
                    </div>
                <div class="upload_geral">
                        <p>Participe da Galeria Colaborativa de Fotos!</p>
                        <a href="enviar-video.aspx"><img src="images/icone_video.png" alt="Icone Camera"/> Clique para enviar a sua foto</a>
                    </div>
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

     <!-- LIGHT VIEW MODAL E AFINS-->
    <div id="mask" runat="server">
        <article id="fotos">
            <img src="/images/galeri0202a.jpg" class="img_galeria" />
            <p>:: LEGANDA DA FOTO 001 ::</p>
            <div class="controles">
                <div class="left_galeria">
                    <img src="/images/arrow_left2.png" />
                </div>
                <div class="quantos"><b class="atual">1</b>/<b class="total">4</b></div>
                <div class="right_galeria">
                    <img src="/images/arrow_right2.png" />
                </div>
                <div class="fechar_galeria fechar_foto">FECHAR</div>
            </div>
        </article>

        <article id="videos">
            <iframe width="640" height="360" src="//www.youtube.com/embed/CaTXgmHyMSk" frameborder="0" allowfullscreen></iframe>
            <p>:: titulo Do video 001 ::</p>
            <div class="controles">
                <div class="left_galeria">
                    <img src="/images/arrow_left2.png" />
                </div>
                <div class="quantos"><b class="atual">1</b>/<b class="total">4</b></div>
                <div class="right_galeria">
                    <img src="/images/arrow_right2.png" />
                </div>
                <div class="fechar_galeria fechar_foto">FECHAR</div>
            </div>
        </article>
    </div>
    <!-- FIM DO LIGHT VIEW MODAL E AFINS-->
</body>
</html>
