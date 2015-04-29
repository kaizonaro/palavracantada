<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enviar-relato.aspx.cs" Inherits="BrincaderiasMusicais.enviar_relato" %>

<%@ Register Src="~/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>
<%@ Register Src="~/inc/footer.ascx" TagPrefix="brincadeira" TagName="footer" %>
<%@ Register Src="~/inc/menu.ascx" TagPrefix="brincadeira" TagName="menu" %>
<%@ Register Src="~/inc/blog.ascx" TagPrefix="brincadeira" TagName="blog" %>
<%@ Register Src="~/inc/login.ascx" TagPrefix="brincadeira" TagName="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">


    <title>Palavra Cantada - Criações Documentadas</title>
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
                    <a href="/" title="Home">Home</a> >> <a href="/Criacoes-Documentadas" title="Home">Criações Documentadas</a> >> <strong>Enviar Relato</strong>
                </div>
                <!-- INCLUDE -->
                <p class="titu_criacoes" id="titu_criacoes" runat="server"></p><br /><br />
                <span class="tafera_detalhe">Tarefa criada por: <strong id="criador" runat="server"></strong></span>
                    <span class="tafera_detalhe">Publicada Em: <strong id="data" runat="server"></strong></span>
                <br />
                <br />
                <p class="titu_criacoes">
                    Enviar relato:
                </p>
                <form method="post" action="enviar-relato.aspx" id="up_foto" runat="server">
                    <input type="hidden" id="CDO_ID" value="" runat="server" />
                    <input type="hidden" id="acao" value="Gravar" />
                    <textarea name="CDR_RELATO" id="CDR_RELATO" class="box_criacoes" placeholder="Escreva o seu relato sobre esta tarefa neste espaço" rows="12"></textarea>
                    <p class="txt">
                        <strong>Gostaria de anexar um vídeo ao seu relato? Digite o link (YouTube) do vídeo abaixo:</strong><br />
                        Exemplo: https://www.youtube.com/watch?v=e5ADrw5YpHU
                    </p>
                    <input type="text" class="input" placeholder="" id="CDR_VIDEO" name="CDR_VIDEO"/>
                    <div class="full enviar_relato">
                        <button class="btn_back" onclick="window.history.go(-1); return false;">Cancelar</button>
                        <!--<input type="submit" name="PublicarFoto" value="Enviar Relato" id="PublicarFoto" class="btn_save">-->
                        <asp:Button ID="Button1" class="btn_save" runat="server" Text="Enviar Relato" OnClick="gravar" />
                    </div>
                </form>
                <br />
                <br />

                <img src="/images/linha.png" class="linha" />


                <!--<div class="detalhe_criacoes">
                    <div class="detalhes_autor">
                        <span class="comentario_detalhe">Tarefa criada por: <strong><< nome do admin >></strong></span><br />
                        <span class="comentario_detalhe">Publicada em: <strong><< dia / mês / ano >></strong></span>
                    </div>
                    <br />
                    <br />
                    <br />
                </div>-->

                <p class="titu_criacoes">
                    Descritivo da tarefa:
                </p>
               <div class="box_criacoes" id="box_descritivo" runat="server"></div>
                <br />
                <br />
                <p class="titu_criacoes">
                    Vídeo / Referência sobre esta tarefa:
                </p>
                <iframe class="video_criacoes" id="video_criacoes" runat="server" src="" frameborder="0" allowfullscreen></iframe>
                <br />
                <br />
                <div class="detalhes_autor">
                    <span class="relato_detalhe" id="relato_detalhe" runat="server"></span><br />
                    <span class="comentario_detalhe"><strong runat="server" id="totalComentarios"><!--<< x >> Comentarios--></strong></span>
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
