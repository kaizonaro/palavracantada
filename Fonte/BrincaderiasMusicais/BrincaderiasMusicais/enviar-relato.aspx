﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enviar-relato.aspx.cs" Inherits="BrincaderiasMusicais.enviar_relato" %>

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
                <p class="titu_criacoes">
                    << Título da Tarefa - Título da Tarefa - Título da
                </p>
                <br />
                <br />
                <span class="tafera_detalhe">Tarefa criada por: <strong><< NOME DO ADMIN >></strong></span>
                <span class="tafera_detalhe">Publicada Em: <strong>12/03/2015</strong></span>
                <br />
                <br />
                <p class="titu_criacoes">
                    Enviar relato:
                </p>
                <form method="post" action="enviar-foto.aspx" id="up_foto" enctype="multipart/form-data">
                    <textarea name="relato" class="box_criacoes" placeholder="Escreva o seu relato sobre esta tarefa neste espaço" rows="12"></textarea>
                    <p class="txt">
                        <strong>Gostaria de anexar um vídeo ao seu relato? Digite o link (YouTube) do vídeo abaixo:</strong><br />
                        Exemplo: https://www.youtube.com/watch?v=e5ADrw5YpHU
                    </p>
                    <input type="text" class="input" placeholder="" id="FOT_LEGENDA" name="FOT_LEGENDA">
                    <div class="full enviar_relato">
                        <button class="btn_back" onclick="window.history.go(-1); return false;">Cancelar</button>
                        <input type="submit" name="PublicarFoto" value="Enviar Relato" id="PublicarFoto" class="btn_save">
                    </div>
                </form>
                <br />
                <br />

                <img src="/images/linha.png" class="linha" />


                <div class="detalhe_criacoes">
                    <div class="detalhes_autor">
                        <span class="comentario_detalhe">Tarefa criada por: <strong><< nome do admin >></strong></span><br />
                        <span class="comentario_detalhe">Publicada em: <strong><< dia / mês / ano >></strong></span>
                    </div>
                    <br />
                    <br />
                    <br />
                </div>

                <p class="titu_criacoes">
                    Descritivo da tarefa:
                </p>
                <div class="box_criacoes">
                    Mussum ipsum cacilds, vidis litro abertis. Consetis adipiscings elitis. Pra lá , depois divoltis porris, paradis. Paisis, filhis, espiritis santis. Mé faiz elementum girarzis, nisi eros vermeio, in elementis mé pra quem é amistosis quis leo. Manduma pindureta quium dia nois paga. Sapien in monti palavris qui num significa nadis i pareci latim. Interessantiss quisso pudia ce receita de bolis, mais bolis eu num gostis.

Suco de cevadiss, é um leite divinis, qui tem lupuliz, matis, aguis e fermentis. Interagi no mé, cursus quis, vehicula ac nisi. Aenean vel dui dui. Nullam leo erat, aliquet quis tempus a, posuere ut mi. Ut scelerisque neque et turpis posuere pulvinar pellentesque nibh ullamcorper. Pharetra in mattis molestie, volutpat elementum justo. Aenean ut ante turpis. Pellentesque laoreet mé vel lectus scelerisque interdum cursus velit auctor. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam ac mauris lectus, non scelerisque augue. Aenean justo massa.

Casamentiss faiz malandris se pirulitá, Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum. Lorem ipsum dolor sit amet, consectetuer Ispecialista im mé intende tudis nuam golada, vinho, uiski, carirí, rum da jamaikis, só num pode ser mijis. Adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.

Cevadis im ampola pa arma uma pindureta. Nam varius eleifend orci, sed viverra nisl condimentum ut. Donec eget justis enim. Atirei o pau no gatis. Viva Forevis aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Copo furadis é disculpa de babadis, arcu quam euismod magna, bibendum egestas augue arcu ut est. Delegadis gente finis. In sit amet mattis porris, paradis. Paisis, filhis, espiritis santis. Mé faiz elementum girarzis. Pellentesque viverra accumsan ipsum elementum gravidis.


                </div>
                <br />
                <br />
                <p class="titu_criacoes">
                    Vídeo / Referência sobre esta tarefa:
                </p>
                <iframe class="video_criacoes" src="https://www.youtube.com/embed/x8VNNyobJRo" frameborder="0" allowfullscreen></iframe>
                <br />
                <br />
                <div class="detalhes_autor">
                    <span class="relato_detalhe"><strong>&lt;&lt; x &gt;&gt; Relatos Enviados</strong></span><br>
                    <span class="comentario_detalhe"><strong>&lt;&lt; x &gt;&gt; Comentarios</strong></span>
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