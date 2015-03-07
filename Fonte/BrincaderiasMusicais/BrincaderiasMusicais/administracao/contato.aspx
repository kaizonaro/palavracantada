<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contato.aspx.cs" Inherits="BrincaderiasMusicais.administracao.contato" ValidateRequest="false" %>


<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>:: Administração - Contato</title>
    <brincadeira:script runat="server" ID="script" />
    <script src="tinymce/tinymce.min.js"></script>
    <script type="text/javascript">

        tinymce.init({
            selector: "textarea",
            menubar: false
        });

        function visualizar(id) {
            ajax2 = ajaxInit();
            ajax2.open("GET", "contato.aspx?acao=Exibir&FORM_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {

                        var ss = ajax2.responseText.split("|");

                        $('#tit_contato').html("CONTATO RECEBIDO EM: " + ss[0] + " as " + ss[1]);
                        $('#tit_nome').html("<b>Nome: </b> <em>" + ss[2] + "</em>");
                        $('#tit_email').html("<b>E-mail: </b> <em>" + ss[3] + "</em>");
                        $('#tit_message').html("<b>Mensagem: </b> <em>" + ss[4] + "</em>");
                        
                        //Exibir Resultado
                        $('#mask').fadeIn(300);
                        $('#modal').addClass('ativo');
                    }
                }
            }
            ajax2.send(null);
        }

        function fechar_modal() {
            $('#mask').fadeOut(500);
            $('#modal').removeClass('ativo')
        }

        //AJAX
        function ajaxInit() {
            var req;
            try {
                req = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e) {
                try {
                    req = new ActiveXObject("Msxml2.XMLHTTP");
                } catch (ex) {
                    try {
                        req = new XMLHttpRequest();
                    } catch (exc) {
                        alert("Esse browser não tem recursos para uso do Ajax");
                        req = null;
                    }
                }
            }
            return req;
        }

        function popularFormulario(id) {
            ajax4 = ajaxInit();
            ajax4.open("GET", "blog.aspx?acao=editarPost&POS_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {

                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {

                        var resposta = ajax4.responseText.split("<!doctype html>");
                        var ss = resposta[0].split("|");

                        $('#FORM_ID').attr("value", ss[0]);
                        $('#FORM_TITULO').attr("value", ss[1]);
                        tinyMCE.activeEditor.setContent(ss[2]);

                        if (ss[3] == '1') { $('#POS_IMPORTANTE').attr("checked", "checked"); }


                        editar_table2(id);
                    }
                }
            }
            ajax4.send(null);
        }

        function excluirPost(id) {
            var r = confirm("Deseja mesmo desativar este post ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "videos.aspx?acao=excluirVideo&GVI_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
                ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
                ajax2.onreadystatechange = function () {
                    if (ajax2.readyState == 4) {
                        if (ajax2.status == 200) {
                            $('#tr_' + id).hide();
                        }
                    }
                }
                ajax2.send(null);
            } else {
                return false;
            }
        }

        function restorePost(id) {
            var r = confirm("Deseja deseja mesmo ativar este post ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "videos.aspx?acao=ativarVideo&GVI_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
                ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
                ajax2.onreadystatechange = function () {
                    if (ajax2.readyState == 4) {
                        if (ajax2.status == 200) {
                            $('#tr_' + id).hide();
                        }
                    }
                }
                ajax2.send(null);
            } else {
                return false;
            }
        }

        function FiltrarPesquisa(RED_ID, USU_NOME, USU_EMAIL) {
            ajax4 = ajaxInit();
            ajax4.open("GET", "usuarios.aspx?acao=FiltrarPesquisa&RED_ID=" + RED_ID + "&USU_NOME=" + USU_NOME + "&USU_EMAIL=" + USU_EMAIL + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {

                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {

                        $("#tbCentral").html(ajax4.responseText);
                    }
                }

            }

            ajax4.send(null);
        }
    </script>
</head>

<body>
    <!--HEADER-->
    <brincadeira:header runat="server" ID="header" />
    <!--FIM DO HEADER-->

    <!--CONTEUDO GERAL-->
    <section class="all">
        <div class="all_center">
            <section id="conteudo">
                <h2>
                    <img src="images/home.png" alt="inicio"><br>
                    Post Blog</h2>
                <!-- TABELA-->
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget red">
                            <div class="widget-title">
                                <h4>Contato</h4>
                                <div class="btns_acoes">
                                    <div class="filtrar acoes_topo_form">
                                        <img src="images/filtro.png" alt="Filtrar"><p>Filtrar</p>
                                    </div>
                                </div>

                                <div class="widget-body">

                                    <!-- LISTAGEM INICIAL -->
                                    <div class="tabela_ok" id="divLista" runat="server"></div>
                                    <!-- FIM LISTAGEM INICIAL -->

                                    <!-- LISTAGEM EXCLUÍDOS -->
                                    <div class="tabela_excluidos" id="divExcluidos" runat="server"></div>
                                    <!-- FIM LISTAGEM EXCLUÍDOS -->
                                </div>
                            </div>
                        </div>
                    </div>
            </section>
        </div>

        <!--FIM DA TABELA-->
    </section>
    <!--FIM DO CONTEUDO GERAL-->
    <footer class='footer'>
    </footer>
    <section id="mask">
        <article id="modal">
            <div class="Modal">
                <p class="titu" id="tit_contato"></p>
                
                <div class="full" id="tit_nome">
                    
                </div>
                <div class="full" id="tit_email">
                    
                </div>
                <div class="full" id="tit_message">
                    
                </div>
                <nav>
                    <button class="btn" onclick="fechar_modal()">Fechar</button>
                </nav>
            </div>
        </article>
    </section>
</body>
</html>
