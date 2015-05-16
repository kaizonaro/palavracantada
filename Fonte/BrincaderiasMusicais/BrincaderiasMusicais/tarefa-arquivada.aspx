<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tarefa-arquivada.aspx.cs" Inherits="BrincaderiasMusicais.tarefa_arquivada" %>

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
    <meta property="og:title" content="Projeto Brincadeiras Musicais da Palavra Cantada - Tarefa" />
    <meta property="og:image" content="http://projetopalavracantada.net/images/logo-fb.png" />
    <meta property="og:description" content="Página de Artigos" />
    <meta property="og:url" content="http://projetopalavracantada.net/Criacoes-Documentadas" />

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
                    <p class="titu_criacoes" runat="server" id="titu_criacoes"> </p><br /><br />
                    <span class="tafera_detalhe">Tarefa criada por: <strong id="criador" runat="server"></strong></span>
                    <span class="tafera_detalhe">Entregue em: <strong id="data" runat="server">12/03/2015</strong></span>
                    <br />                    
                    <br />
                    <p class="titu_criacoes">
                        Descritivo da tarefa:
                    </p>
                    <div class="box_criacoes" id="box_descritivo" runat="server">
                         
                    </div>
                    <br /><br />
                    <p class="titu_criacoes" runat="server" id="titulovideo">
                        Vídeo / Referência sobre esta tarefa:
                    </p>
                    <iframe runat="server" id="video_criacoes" class="video_criacoes" src="https://www.youtube.com/embed/x8VNNyobJRo" frameborder="0" allowfullscreen></iframe>
                    <br /><br />
                    <div class="detalhe_criacoes">
                        <div class="detalhes_autor">
                            <span class="relato_detalhe"><strong><< x >> Relatos Enviados</strong></span><br />
                            <span class="comentario_detalhe"><strong><< x >> Comentarios</strong></span>
                        </div>
                        <div class="criacoes_btn2">
                            <a href="#" class="btn_comentario3">Comente esta tarefa</a>
                        </div>
                        <br /><br /><br />
                    </div>
                    
                    <img src="/images/linha.png" class="linha" />

                    <p class="titu_criacoes">
                        Devolutiva da equipe formativa sobre esta tarefa:
                    </p>
                    <div class="box_criacoes">
                       

                    </div>
                <br /><br />
                    <span class="tafera_detalhe">Tarefa criada por: <strong><< NOME DO ADMIN >></strong></span>
                    <span class="tafera_detalhe">Publicada Em: <strong>12/03/2015</strong></span>
                <br /><br />
                <p class="titu_criacoes">
                        Vídeo da devolutiva:
                    </p>
                <div class="video_criacoes">

                </div>
                <br /><br />
                <img src="/images/linha.png" class="linha" />

                <div class="mascara">
                    <!-- CARROUSEL -->   
                    <div class="topo_relatos" id="divRelatos" runat="server">      
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
                    <ul class="carrousel relatos_ul" id="ulRelatos" runat="server">
                      
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