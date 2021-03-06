﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="blog.aspx.cs" Inherits="BrincaderiasMusicais.administracao.blog" ValidateRequest="false" %>


<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>:: Administração - Post Blog</title>
    <brincadeira:script runat="server" ID="script" />
    <script src="tinymce/tinymce.min.js"></script>
    <script type="text/javascript">

        tinymce.init({
            selector: "textarea",
            menubar: false,
            language: "pt_BR",
            height: 500,
            resize: false,
            plugins: [
                    "advlist autolink lists link image charmap print preview anchor",
                    "searchreplace visualblocks code fullscreen",
                    "insertdatetime media table contextmenu paste youtube"
            ],
            toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image| youtube"

        });




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

                        $('#POS_ID').attr("value", ss[0]);
                        $('#POS_TITULO').attr("value", ss[1]);
                        tinyMCE.activeEditor.setContent(ss[2]);
                        $('#PCA_ID option[value="' + parseInt(ss[4]) + '"]').attr('selected', 'selected').change();
                        $('#thumb').html(ss[5])
                        $('#RED_ID option[value="' + parseInt(ss[6]) + '"]').attr('selected', 'selected').change();
                        if (parseInt(ss[3]) == 1) { $('#POS_IMPORTANTE').attr("checked", "checked"); }

                        editar_table2(id);
                    }
                }
            }
            ajax4.send(null);
        }

        function excluirPost(id, msg) {
            var r = confirm("Deseja mesmo " + msg + " este post ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "blog.aspx?acao=excluirPost&POS_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
                ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
                ajax2.onreadystatechange = function () {
                    if (ajax2.readyState == 4) {
                        if (ajax2.status == 200) {
                            if (msg == "desativar") {
                                $('#tr_' + id).hide();
                            } else { $('#xtr_' + id).hide(); }

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
                ajax2.open("GET", "blog.aspx?acao=ativarPost&POS_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
                ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
                ajax2.onreadystatechange = function () {
                    if (ajax2.readyState == 4) {
                        if (ajax2.status == 200) {
                            $('#x[tr_' + id).hide();
                        }
                    }
                }
                ajax2.send(null);
            } else {
                return false;
            }
        }

        function FiltrarPesquisa(RED_ID, POS_TITULO) {
            ajax4 = ajaxInit();
            ajax4.open("GET", "blog.aspx?acao=FiltrarPesquisa&RED_ID=" + RED_ID + "&POS_TITULO=" + POS_TITULO + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {

                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {

                        $("#divLista").html(ajax4.responseText);
                        editar_table2(id);
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
                                <h4>Post Blog</h4>
                                <div class="btns_acoes">
                                    <div class="filtrar acoes_topo_form">
                                        <img src="images/filtro.png" alt="Filtrar"><p>Filtrar</p>
                                    </div>
                                    <div class="incluir acoes_topo_form">
                                        <img src="images/mais.png" alt="Incluir"><p>Incluir</p>
                                    </div>
                                    <div class="excluidos acoes_topo_form">
                                        <img src="images/lixo.png" alt="Filtrar"><p>Ítens excluidos</p>
                                    </div>
                                    <div class="voltar_topo_form acoes_topo_form">
                                        <img src="images/restore.png" alt="Filtrar"><p>Voltar</p>
                                    </div>
                                    <div class="form_table">

                                        <!-- FORMULÁRIO DE INCLUSÃO -->
                                        <form id="Form1" class="inc_form form" name="incluir" action="blog.aspx" novalidate="novalidate" accept-charset="default" runat="server">
                                            <input type="hidden" id="acao" name="acao" value="gravar" />
                                            <input type="hidden" id="POS_ID" name="POS_ID" value="0" />

                                            <p>Título:*</p>
                                            <input type="text" maxlength="60" name="POS_TITULO" id="POS_TITULO" class="input obg" placeholder="Título do Post" />

                                            <p>Imagem (478px x 332px)*:</p>
                                            <asp:FileUpload ID="POS_IMAGEM" runat="server" class="multi input" />
                                            <div id="thumb"></div>

                                            <p>Categoria*</p>
                                            <select name="PCA_ID" runat="server" id="PCA_ID" data-validation="required" class="input obg">
                                                <option value="">Selecione a categoria</option>
                                            </select>

                                            <p>Rede</p>
                                            <select name="RED_ID" class="input" id="RED_ID" runat="server">
                                                <option value="NULL">Todas as redes</option>
                                            </select>

                                            <p>Post:*</p>
                                            <textarea id="POS_TEXTO" name="POS_TEXTO" style="width: 100%">

                                            </textarea>


                                            <label for="POS_IMPORTANTE">Importante:</label>
                                            <input type="checkbox" id="POS_IMPORTANTE" name="POS_IMPORTANTE" value="1" />

                                            <p class="p_btn">
                                                <input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                                <asp:Button ID="Incluir" CssClass="btn_form" runat="server" Text="Salvar" OnClick="gravar" />
                                            </p>
                                        </form>

                                        <form class="fil_form form" novalidate accept-charset="default">
                                            <p>Rede</p>
                                            <select id="FL_REDE_ID" name="FL_REDE_ID" class="input" runat="server">
                                                <option value="NULL">Selecione</option>
                                            </select>


                                            <p>Título</p>
                                            <input type="text" name="FL_POS_TITULO" id="FL_POS_TITULO" class="input" />


                                            <p class="p_btn">
                                                <input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                                <input type="button" onclick="FiltrarPesquisa(FL_REDE_ID.value, FL_POS_TITULO.value)" value="Filtrar" class="btn_form" formmethod="get" />
                                            </p>
                                        </form>
                                    </div>
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

    <!--MASK-->
    <section id="masknew" class="all">
        <div class="modal_blog" id="detahes" runat="server">
        </div>
        <button type="button" class="btn_fecha_blog" onclick="$('#masknew').fadeOut()">Fechar</button>
    </section>
    <!--FIM DO MASK-->

    <!--CSS dps add la no arquivo style ou onde quiser kkk-->
    <style>
        #masknew {
            position: fixed;
            width: 100%;
            height: 100%;
            left: 0;
            top: 0;
            overflow-y: scroll;
            background: rgba(0,0,0,0.5);
            z-index: 9999;
            display:none
        }

        .modal_blog {
            width: 90%;
            margin: 30px auto;
            max-width: 600px;
            height: 500px;
            position: relative;
            background: #fff;
            overflow-Y: scroll;
        }

        .btn_fecha_blog {
            color: #fff;
            padding: 8px 20px;
            margin: 20px auto;
            backgroud: #305051;
            border-radius: 5px;
            cursor: pointer;
        }
    </style>
    <script>
        function VerDetalhes(id) {
            $.ajax({
                type: 'GET',
                url: location.pathname,
                async: true,
                data: "acao=VerDetalhes&POS_ID=" + id,
                success: function (data) {
                    console.log(data)
                    $('#detahes').html(data)
                    $('#masknew').fadeIn()
                },
                error: function (xhr, status, error) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert("Erro: " + err.Message);
                },
                beforeSend: function () {
                    console.log("comecou")
                },
                complete: function () {
                    console.log("acabou")
                }
            });
        }
    </script>
</body>
</html>
