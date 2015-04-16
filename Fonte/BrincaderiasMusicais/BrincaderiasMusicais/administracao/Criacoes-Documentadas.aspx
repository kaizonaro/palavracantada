﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Criacoes-Documentadas.aspx.cs" Inherits="BrincaderiasMusicais.administracao.Criacoes_Documentadas" %>

<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>:: Administração - Criações Documentadas</title>
    <brincadeira:script runat="server" ID="script" />
    <script src="tinymce/tinymce.min.js"></script>
    <script type="text/javascript">

        tinymce.init({
            selector: "textarea",
            menubar: false
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
            ajax4.open("GET", "criacoes-documentadas.aspx?acao=editar&CDO_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {

                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {
                        var resposta = ajax4.responseText.split("<!doctype html>");
                        var ss = resposta[0].split("|");
                        //alert(ss[3]);
                        $('#CDO_ID').attr("value", ss[0]);
                        $('#RED_ID option[value="' + parseInt(ss[1]) + '"]').attr('selected', 'selected').change();
                        tinyMCE.activeEditor.setContent(ss[2]);
                        $('#CDO_DATA').attr("value", ss[3]);
                        $('#CDO_STATUS option[value="' + parseInt(ss[4]) + '"]').attr('selected', 'selected').change();

                        editar_table2(id);
                    }
                }
            }
            ajax4.send(null);
        }

        function excluir(id) {
            var r = confirm("Deseja mesmo desativar esta Criação Documentada ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "criacoes-documentadas.aspx?acao=excluir&CDO_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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

        function restaurar(id) {
            var r = confirm("Deseja deseja mesmo ativar esta Criação Documentada ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "criacoes-documentadas.aspx?acao=restaurar&FAQ_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
                    Criações Documentadas</h2>
                <!-- TABELA-->
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget red">
                            <div class="widget-title">
                                <h4>Criações Documentadas</h4>
                                <div class="btns_acoes">

                                    <div class="incluir acoes_topo_form">
                                        <img src="images/mais.png" alt="Incluir"><p>Incluir</p>
                                    </div>

                                    <div class="form_table">

                                        <!-- FORMULÁRIO DE INCLUSÃO -->
                                        <form id="Form1" class="inc_form form" name="incluir" action="criacoes-documentadas.aspx" novalidate="novalidate" accept-charset="default" runat="server">
                                            <input type="hidden" id="acao" name="acao" value="gravar" />
                                            <input type="hidden" id="CDO_ID" name="CDO_ID" value="0" />

                                            <p>Rede</p>
                                            <select name="RED_ID" class="input" id="RED_ID" runat="server">
                                                <option value="NULL">Nenhuma</option>
                                            </select>

                                            <p>Titulo:*</p>
                                            <textarea id="CDO_TAREFA" name="CDO_TAREFA" style="width: 100%"></textarea>

                                            <p>Data:*</p>
                                            <input type="text" maxlength="10" name="CDO_DATA" id="CDO_DATA" class="input data obg" placeholder="Data da Tarefa" />

                                            <p>Status*</p>
                                            <select name="CDO_STATUS" class="input" id="CDO_STATUS" runat="server">
                                                <option value="Ativa">Ativa</option>
                                                <option value="Arquivada">Arquivada</option>
                                            </select>

                                            <p>Descrição:</p>
                                            <textarea id="CDO_DESCRITIVO" name="CDO_DESCRITIVO" style="width: 100%"></textarea>

                                            <p>Video:</p>
                                            <input type="text" maxlength="10" name="CDO_VIDEO" id="CDO_VIDEO" class="input data obg" placeholder="Data da Tarefa" />

                                            <p>Devolutiva:</p>
                                            <input type="text" maxlength="10" name="CDO_DEVOLUTIVA" id="CDO_DEVOLUTIVA" class="input data obg" placeholder="Data da Tarefa" />
                                            
                                            <p>Video da Devolutiva:</p>
                                            <input type="text" maxlength="10" name="CDO_VIDEO_DEVOLUTIVA" id="CDO_VIDEO_DEVOLUTIVA" class="input data obg" placeholder="Data da Tarefa" />


                                            <p class="p_btn">
                                                <input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                                <asp:Button ID="Incluir" CssClass="btn_form" runat="server" Text="Incluir" OnClick="gravar" />
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
</body>
</html>