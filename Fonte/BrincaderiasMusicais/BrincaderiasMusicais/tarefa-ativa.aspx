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
                <p class="titu_criacoes" id="titu_criacoes" runat="server"></p>
                <br />
                <br />
                <span class="tafera_detalhe">Tarefa criada por: <strong id="criador" runat="server"></strong></span>
                <span class="tafera_detalhe">Publicada Em: <strong id="data" runat="server"></strong></span>
                <br />
                <br />
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
                <div class="detalhe_criacoes">
                    <div class="detalhes_autor">
                        <span class="relato_detalhe" id="relato_detalhe" runat="server">
                            <!--<strong>Relatos Enviados</strong>-->
                        </span>
                        <br />
                        <span class="comentario_detalhe"><strong><< x >> Comentarios</strong></span>
                    </div>
                    <div class="criacoes_btn">
                        <a href="javascript:void(0);" class="btn_comentario abre_comentario">Comente esta tarefa</a>
                        <a href="javascript:void(0);" id="aRelato" runat="server" class="btn_relato">Envie seu relato</a>
                    </div>
                    <br />
                    <br />
                    <br />
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
                            <div class="left_relato">
                                <img src="/images/arrow_left2.png">
                            </div>
                            <span class="cont_relato">Visualizando Relato <strong>1</strong> de <b>xx</b></span>
                            <div class="right_relato">
                                <img src="/images/arrow_right2.png">
                            </div>
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

    <!--MODAL COENTARIO-->
    <div id="mask">
        <div class="modal_comentario">
            <div class="fechar_comentario x">
                <img src="/images/x.jpg" />
            </div>
            <p class="titu_criacoes">
                COMENTE A TAREFA
            </p>
            <span class="tafera_detalhe">Deixe seu comentário para a tarefa <strong><< nome da tarefa - nome da tarefa - nome da tarefa - nome da tarefa - nome ... >> </strong></span>
            <form method="post" action="enviar-relato.aspx" id="up_foto"><br /><br />
                <textarea class="box_criacoes input" rows="10"></textarea><br /><br />
                <div class="full enviar_relato">
                    <button class="btn_back">Cancelar</button>
                    <input type="submit" name="PublicarFoto" value="Enviar Relato" id="PublicarFoto" class="btn_save">
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
            <span class="tafera_detalhe">Deixe seu comentário para o relato <strong><< nome da tarefa - nome da tarefa - nome da tarefa - nome da tarefa - nome ... >> </strong></span>
            <form method="post" action="enviar-relato.aspx" id="up_foto"><br /><br />
                <textarea class="box_criacoes input" rows="10"></textarea><br /><br />
                <div class="full enviar_relato">
                    <button class="btn_back">Cancelar</button>
                    <input type="submit" name="PublicarFoto" value="Enviar Relato" id="PublicarFoto" class="btn_save">
                </div>
            </form>
        </div>

        <div class="modal_relatos">
            <div class="fechar_relato x">
                <img src="/images/x.jpg" />
            </div>
            <p class="titu_criacoes">
                <img src="/images/icon_comente.png" alt="Icone de comentários" /> COMENTÁRIOS DA TAREFA
            </p>
            <span class="tafera_detalhe">Visualizando comentários da tarefa <strong><< nome da tarefa - nome da tarefa - nome da tarefa - nome da tarefa - nome da tarefa - nome da tarefa - nome da tarefa... >> </strong></span>
            <hr />
            <div class="box_lista_relato">
                <img class="mini_perfil" src="/images/thumb_perfil.jpg" alt="Foto do Perfil do Fulano" />
                <p class="txt">
                    Dolor quisque faucibus ligula nec urna hendrerit, at dignissim mauris tristique. Etiam ipsum dolor, feugiat non lacinia ut, lacinia in nisi. Vivamus dictum risus nulla, sit amet sodales ligula sagittis ac. Fusce ac consectetur enim, ac dignissim nunc.
                </p>
                <span class="tafera_detalhe">Comentário  enviado por:  <strong><< nome do usuário >> </strong></span>
            </div>

            <div class="box_lista_relato">
                <img class="mini_perfil" src="/images/thumb_perfil.jpg" alt="Foto do Perfil do Fulano" />
                <p class="txt">
                    Dolor quisque faucibus ligula nec urna hendrerit, at dignissim mauris tristique. Etiam ipsum dolor, feugiat non lacinia ut, lacinia in nisi. Vivamus dictum risus nulla, sit amet sodales ligula sagittis ac. Fusce ac consectetur enim, ac dignissim nunc.
                </p>
                <span class="tafera_detalhe">Comentário  enviado por:  <strong><< nome do usuário >> </strong></span>
            </div>

            <div class="box_lista_relato">
                <img class="mini_perfil" src="/images/thumb_perfil.jpg" alt="Foto do Perfil do Fulano" />
                <p class="txt">
                    Dolor quisque faucibus ligula nec urna hendrerit, at dignissim mauris tristique. Etiam ipsum dolor, feugiat non lacinia ut, lacinia in nisi. Vivamus dictum risus nulla, sit amet sodales ligula sagittis ac. Fusce ac consectetur enim, ac dignissim nunc.
                </p>
                <span class="tafera_detalhe">Comentário  enviado por:  <strong><< nome do usuário >> </strong></span>
            </div>

            <div class="box_lista_relato">
                <img class="mini_perfil" src="/images/thumb_perfil.jpg" alt="Foto do Perfil do Fulano" />
                <p class="txt">
                    Dolor quisque faucibus ligula nec urna hendrerit, at dignissim mauris tristique. Etiam ipsum dolor, feugiat non lacinia ut, lacinia in nisi. Vivamus dictum risus nulla, sit amet sodales ligula sagittis ac. Fusce ac consectetur enim, ac dignissim nunc.
                </p>
                <span class="tafera_detalhe">Comentário  enviado por:  <strong><< nome do usuário >> </strong></span>
            </div>
            <div class="box_lista_relato">
                <img class="mini_perfil" src="/images/thumb_perfil.jpg" alt="Foto do Perfil do Fulano" />
                <p class="txt">
                    Dolor quisque faucibus ligula nec urna hendrerit, at dignissim mauris tristique. Etiam ipsum dolor, feugiat non lacinia ut, lacinia in nisi. Vivamus dictum risus nulla, sit amet sodales ligula sagittis ac. Fusce ac consectetur enim, ac dignissim nunc.
                </p>
                <span class="tafera_detalhe">Comentário  enviado por:  <strong><< nome do usuário >> </strong></span>
            </div>

            <nav class="paginacao">   <ul>   <li><a href="javascript:void(0);" class="nav_pg" title="Página anterior"><img src="images/nav_left.png">ANTERIORES</a></li>   <li><a href="javascript:void(0);" title="Página atual" class="ativo">1</a></li>   <li><a href="javascript:void(0);" onclick="pagina('2')" title="Página 2">2</a></li>   <li><a href="javascript:void(0);" onclick="pagina('3')" title="Página 3">3</a></li>   <li><a href="javascript:void(0);" onclick="pagina('2')" class="nav_pg" title="Próxima Página">PRÓXIMOS <img src="images/nav_right.png "></a></li>   </ul>  </nav>

        </div>
    </div>
</body>
</html>
