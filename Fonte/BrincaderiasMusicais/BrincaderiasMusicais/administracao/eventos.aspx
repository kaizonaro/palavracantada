<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eventos.aspx.cs" Inherits="BrincaderiasMusicais.administracao.eventos" %>


<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>:: Administração - Eventos</title>
    <brincadeira:script runat="server" ID="script" />
    <script src="tinymce/tinymce.min.js"></script>
    <script type="text/javascript">

        function mascaraData(campoData) {
            var data = campoData.value;
            if (data.length == 2) {
                data = data + '/';
                document.forms[0].data.value = data;
                return true;
            }
            if (data.length == 5) {
                data = data + '/';
                document.forms[0].data.value = data;
                return true;
            }
        }

        tinymce.init({
            height: 500,
            resize: false,
            language: "pt_BR",
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
            ajax4.open("GET", "eventos.aspx?acao=editar&EVE_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {

                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {

                        var resposta = ajax4.responseText.split("<!doctype html>");
                        var ss = resposta[0].split("|");

                        $('#EVE_ID').attr("value", ss[0]);
                        $('#RED_ID option[value="' + parseInt(ss[1]) + '"]').attr('selected', 'selected').change();
                        $('#EVE_TITULO').attr("value", ss[2]);
                        tinyMCE.activeEditor.setContent(ss[3]);
                        $('#EVE_DIA').attr("placeholder", ss[4]);
                        $('#EVE_HORA').attr("placeholder", ss[5]);

                        editar_table2(id);
                        
                    }
                }
            }
            ajax4.send(null);
        }

        function excluir(id) {
            var r = confirm("Deseja mesmo desativar este Evento ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "eventos.aspx?acao=excluir&EVE_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
            var r = confirm("Deseja deseja mesmo ativar esta FAQ ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "faq.aspx?acao=restaurar&FAQ_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
                    EVENTOS</h2>
                <!-- TABELA-->
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget red">
                            <div class="widget-title">
                                <h4>EVENTOS</h4>
                                <div class="btns_acoes">

                                    <div class="incluir acoes_topo_form">
                                	    <img src="images/mais.png" alt="Incluir"><p>Incluir</p>
                                    </div>  
                                    
                                    <div class="form_table">

                                        <!-- FORMULÁRIO DE INCLUSÃO -->
                                        <form id="Form1" class="inc_form form" name="incluir" action="eventos.aspx" novalidate="novalidate" accept-charset="default" runat="server">
                                            <input type="hidden" id="acao" name="acao" value="gravar" />
                                            <input type="hidden" id="EVE_ID" name="EVE_ID" value="0" />

                                            <p>Rede</p>
                                            <select name="RED_ID" class="input" id="RED_ID" runat="server">
                                                <option value="NULL">Todas as Redes</option>
                                            </select>

                                            <p>Título do Evento:*</p>
                                            <input type="text" maxlength="64" name="EVE_TITULO" id="EVE_TITULO" class="input obg" placeholder="Digite o título do evento" />

                                            <p>Descrição:*</p>
                                            <textarea id="EVE_DESCRICAO" name="EVE_DESCRICAO" style="width: 100%"></textarea>

                                            <p>Dia:*</p>
                                            <input type="text" maxlength="10" name="EVE_DIA" id="EVE_DIA" class="input data obg" placeholder="Dia do Evento" />
                                            
                                            <p>Hora:*</p>
                                            <input type="text" maxlength="32" name="EVE_HORA" id="EVE_HORA" class="input hora obg" placeholder="Digite a hora de início do evento" />

                                            <p class="p_btn">
                                                <input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                                <asp:Button ID="Incluir" CssClass="btn_form" runat="server" Text="Salvar" OnClick="gravar" />
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