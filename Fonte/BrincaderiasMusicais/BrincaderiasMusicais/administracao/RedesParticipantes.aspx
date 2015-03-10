<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RedesParticipantes.aspx.cs" Inherits="BrincaderiasMusicais.administracao.redes_participantes" %>


<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <title>:: Administração - Redes</title>
    <brincadeira:script runat="server" ID="script" />

    <script type="text/javascript">

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
            ajax4.open("GET", "redesparticipantes.aspx?acao=editarRede&REP_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {


                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {

                        var resposta = ajax4.responseText.split("<!DOCTYPE html>");

                        var ss = resposta[0].split("|");


                        $('#REP_ID').attr("value", ss[0]);

                        $('#REP_TITULO').attr("value", ss[1]);
                        $('#REP_CIDADE').attr("value", ss[2]);
                        $('#REP_UF').attr("value", ss[3]);
                      
                        editar_table(id);
                    }
                }
            }
            ajax4.send(null);
        }



        function excluirRede(id) {
            var r = confirm("Deseja mesmo desativar esta rede?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "redesparticipantes.aspx?acao=excluirRede&REP_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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

        function ValidarRede() {


            ajax2 = ajaxInit();
            ajax2.open("GET", "redesparticipantes.aspx?acao=ValidarRede&REP_TITULO=" + REP_TITULO.value, true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {

                        var resposta = ajax2.responseText.split("<!DOCTYPE html>");
                        var ss = resposta[0].split("|");

                        $("#redemensagem").html(ss[0]);

                        if (ss[1] == 0) {
                            $("#bt_cadastrar").attr("disabled", true);
                            $("#REP_TITULO").attr("style", "background-color:#FFAEAE");
                            $("#REP_TITULO").focus();
                            $("#REP_TITULO").select();
                        }
                        else {
                            $("#bt_cadastrar").removeAttr("disabled");
                            $("#REP_TITULO").removeAttr("style");
                        }


                    }
                }
            }
            ajax2.send(null);

        }

        function restoreRede(id) {
            var r = confirm("Deseja deseja mesmo ativar esta rede?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "redesparticipantes.aspx?acao=restoreRede&REP_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
                    Redes</h2>
                <!-- TABELA-->
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget red">
                            <div class="widget-title">
                                <h4>Redes Participantes</h4>
                                <div class="btns_acoes">
                                    <!--<div class="filtrar acoes_topo_form">
                                	<img src="images/filtro.png" alt="Filtrar"><p>Filtrar</p>
                                </div>-->
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
                                        <form class="inc_form form" name="incluir" action="redesparticipantes.aspx">
                                            <input type="hidden" value="gravarRede" id="acao" name="acao" />

                                            <input type="hidden" value="0" id="REP_ID" name="REP_ID" />
                                            <p>Nome da Rede*</p>
                                            <input type="text" name="REP_TITULO" class="input obg" onchange="ValidarRede()" id="REP_TITULO" />
                                            <input type="hidden" value="" id="valido" class="obg" name="valido" />
                                            <p id="redemensagem"></p>
                                            <p>Cidade*</p>
                                            <input type="text" name="REP_CIDADE" class="input obg" id="REP_CIDADE" />
                                            <p>UF*</p>
                                            <input type="text" name="REP_UF" maxlength="2" class="input uf obg" id="REP_UF" onkeypress="return uf(this.value, event)" onkeyup="maiuscula(this)" />

                                            <input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                            <input type="submit" value="Incluir" class="btn_form" formmethod="get" onclick="validardinamico()" id="bt_cadastrar" />
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
