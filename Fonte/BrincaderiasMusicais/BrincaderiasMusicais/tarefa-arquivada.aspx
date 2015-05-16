box_descritivo<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tarefa-arquivada.aspx.cs" Inherits="BrincaderiasMusicais.tarefa_arquivada" %>

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

    <script type="text/javascript">
        function GetXMLHttp() {
            if (navigator.appName == "Microsoft Internet Explorer") {
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            } else {
                xmlHttp = new XMLHttpRequest();
            }
            return xmlHttp;
        }
        var mod = GetXMLHttp();

        function teste(id) {
            $("#idREL").attr("value", id);
            $("#mask").fadeIn(200);
            $('.modal_comentario2').fadeIn(400);
            $('.modal_relatos').fadeOut(0);

        }

        function verComentarios(pg, id) {
            mod.open("GET", "/ajax/acoes.aspx?pg=" + pg + "&id=" + id + "&acao=verComentarios", true);
            mod.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            mod.onreadystatechange = function () {
                if (mod.readyState == 4) {
                    if (mod.status == 200) {
                        var resposta = mod.responseText.split("<script>");
                        document.getElementById('comentarioRelatos').innerHTML = resposta[0];
                        $("#mask").fadeIn(200);
                        $('.modal_relatos').fadeIn(400);
                    }
                }
            };
            mod.send(null);
        }

        function verComentarios2(pg, id) {
            mod.open("GET", "/ajax/acoes.aspx?pg=" + pg + "&id=" + id + "&acao=verComentarios2", true);
            mod.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            mod.onreadystatechange = function () {
                if (mod.readyState == 4) {
                    if (mod.status == 200) {
                        var resposta = mod.responseText.split("<script>");
                        document.getElementById('divcomentario1').innerHTML = resposta[0];
                        
                        $("#mask").fadeIn(200);
                        $('.modal_comentario1').fadeIn(400);
                    }
                }
            };
            mod.send(null);
        }

        function fechar_relato() {
            $('.modal_relatos').fadeOut(200);
            $('#mask').fadeOut(400);
        }

        function cancelar_relato() {
            $(".fechar_comentario2").click()
            $("#comentarioRelato").val("")
        }

        function cancelar_tarefa() {
            $(".fechar_comentario").click()
            $("#comentarioTarefa").val("")
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
                   Criações Documentadas
                </div>
                <div id="breadcrumb">
                    <a href="/" title="Home">Home</a>  <strong>Criações Documentadas</strong>
                </div>
                <!-- INCLUDE -->
                    <p class="titu_criacoes" runat="server" id="titu_criacoes"> </p><br /><br />
                    <span class="tafera_detalhe">Proposta criada por: <strong id="criador" runat="server"></strong></span>
                <span class="tafera_detalhe">Prazo para envio de relatos: <strong id="data" runat="server"></strong></span>
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
                            <span class="relato_detalhe" id="relato_detalhe" runat="server"></span><br />
                            <span class="comentario_detalhe"><strong runat="server" id="totalComentarios"></strong></span>
                        </div>
                        <div class="criacoes_btn2">
                            <%--<a href="#" class="btn_comentario3">Comente esta proposta</a>--%>
                            <a href="javascript:void(0);" class="btn_comentario3 abre_comentario">Comente esta proposta</a>
                        </div>
                        <br /><br /><br />
                    </div>
                    
                    <img src="/images/linha.png" class="linha" />

                    <p class="titu_criacoes">
                        Devolutiva da equipe formativa sobre esta tarefa:
                    </p>
                    <div class="box_criacoes" id="divDevolutiva"  runat="server">
                       
                    </div>
                <br /><br />
                   <%-- <span class="tafera_detalhe">Tarefa criada por: <strong><< NOME DO ADMIN >></strong></span>
                    <span class="tafera_detalhe">Publicada Em: <strong>12/03/2015</strong></span>--%>
                <br /><br />
                <p class="titu_criacoes" runat="server" id="titulovideodevolutiva">
                        Vídeo da devolutiva:
                    </p>
                <div class="video_criacoes" runat="server" id="video_criacoesdevolutiva">
                    <iframe class="video_criacoes" id="video_devolutiva" runat="server" src="" frameborder="0" allowfullscreen></iframe>
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
 <!--MODAL COENTARIO-->
    <div id="mask">
        <div class="modal_comentario">
            <div class="fechar_comentario x">
                <img src="/images/x.jpg" />
            </div>
            <p class="titu_criacoes">
                COMENTE A PROPOSTA
            </p>
            <span class="tafera_detalhe">Deixe seu comentário para a proposta:
                <!--<strong><< nome da tarefa - nome da tarefa - nome da tarefa - nome da tarefa - nome ... >> </strong>-->
            </span>
            <form method="post" action="tarefa-arquivada.aspx" id="up_foto2">
                <br />
                <br />
                <input type="hidden" id="acao" name="acao" value="comentarTarefa" />
                <input type="hidden" id="idCDO" runat="server" name="idCDO" value="" />
                <textarea class="box_criacoes input" id="comentarioTarefa" name="comentarioTarefa" rows="10"></textarea><br />
                <br />
                <div class="full enviar_relato">
                    <input type="button" class="btn_back" value="Cancelar" onclick="cancelar_tarefa()" />
                    <input type="submit" name="comentarTarefa" value="ENVIAR COMENTÁRIO" id="comentarTarefa" class="btn_save" />
                </div>
            </form>
        </div>

        <div class="modal_comentario2">
            <div class="fechar_comentario2 x">
                <img src="/images/x.jpg" />
            </div>
            <p class="titu_criacoes">
                COMENTE ESTE RELATO
            </p>
            <span class="tafera_detalhe">Deixe seu comentário para o relato:
                <!--<strong><< nome da tarefa - nome da tarefa - nome da tarefa - nome da tarefa - nome ... >> </strong>-->
            </span>
            <form method="post" action="tarefa-arquivada.aspx" id="up_foto">
                <br />
                <br />
                <input type="hidden" id="acao1" name="acao" value="comentarRelato" />
                <input type="hidden" id="idREL" runat="server" name="idREL" value="" />
                <input type="hidden" id="idCDO1" runat="server" name="idCDO1" value="" />

                <textarea class="box_criacoes input" id="comentarioRelato" name="comentarioRelato" rows="9"></textarea><br />
                <br />
                <div class="full enviar_relato">
                    <input type="button" class="btn_back" value="Cancelar" onclick="cancelar_relato()" />
                    <input type="submit" name="comentarRelato" value="COMENTAR RELATO" id="comentarRelato" class="btn_save">
                </div>
            </form>
        </div>

        <div class="modal_relatos" id="comentarioRelatos" runat="server">
        </div>

        <div class="modal_comentario1" id="divcomentario1">
            <!--<div class="fechar_comentario x">
                <img src="/images/x.jpg" />
            </div>
            <p class="titu_criacoes">
                COMENTÁRIOS DA TAREFA
            </p>-->
        </div>
    </div>
</body>
</html>