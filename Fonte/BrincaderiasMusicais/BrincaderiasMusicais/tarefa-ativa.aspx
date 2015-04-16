<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tarefa-ativa.aspx.cs" Inherits="BrincaderiasMusicais.tarefa_ativa" %>

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
            <div id="sobre" class="interna2">
                <div class="titu">
                   Criações Documentadas
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a>  <strong>Criações Documentadas</strong>
                </div>
                <!-- INCLUDE -->
                    <p class="titu_criacoes" id="titu_criacoes" runat="server"></p><br /><br />
                    <span class="tafera_detalhe">Tarefa criada por: <strong id="criador" runat="server"></strong></span>
                    <span class="tafera_detalhe">Publicada Em: <strong id="data" runat="server"></strong></span>
                    <br />                    
                    <br />
                    <p class="titu_criacoes">
                        Descritivo da tarefa:
                    </p>
                    <div class="box_criacoes" id="box_descritivo" runat="server"></div>
                    <br /><br />
                    <p class="titu_criacoes">
                        Vídeo / Referência sobre esta tarefa:
                    </p>
                    <iframe class="video_criacoes" id="video_criacoes" runat="server" src="" frameborder="0" allowfullscreen></iframe>
                    <br /><br />
                    <div class="detalhe_criacoes">
                        <div class="detalhes_autor">
                            <span class="relato_detalhe" id="relato_detalhe" runat="server"><!--<strong>Relatos Enviados</strong>--></span><br />
                            <span class="comentario_detalhe"><strong><< x >> Comentarios</strong></span>
                        </div>
                        <div class="criacoes_btn">
                            <a href="javascript:void(0);" class="btn_comentario">Comente esta tarefa</a>
                            <a href="javascript:void(0);" id="aRelato" runat="server" class="btn_relato">Envie seu relato</a>
                        </div>
                        <br /><br /><br />
                    </div>
                    
                    <img src="/images/linha.png" class="linha" />

                <div class="mascara" id="divRelatos" runat="server">
                    <!-- CARROUSEL -->   
                    <div class="topo_relatos">      
                        <div class="left">
                            <p class="titu_criacoes">
                                Relatos enviados:
                            </p>
                        </div>   
                        <div class="right">
                            <div class="left_relato"><img src="/images/arrow_left2.png"></div>
                            <span class="cont_relato">Visualizando Relato <strong>1</strong> de <b>xx</b></span>
                            <div class="right_relato"><img src="/images/arrow_right2.png"></div>
                        </div> 
                    </div>       
                    <ul class="carrousel relatos_ul" runat="server" id="ulRelatos">
                        
                    </ul>
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
</body>
</html>
