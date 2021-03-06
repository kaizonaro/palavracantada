﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="banners.aspx.cs" Inherits="BrincaderiasMusicais.administracao.banners" %>

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
            ajax4.open("GET", "banners.aspx?acao=editarBanner&BAN_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {


                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {

                        var resposta = ajax4.responseText.split("<!DOCTYPE html>");
 
                        var ss = resposta[0].split("|");


                       $("#RED_ID option[value='" + ss[0] + "']").attr("selected", "selected");

                        $('#BAN_ID').attr("value", ss[1]);
                        $('#BAN_LEGENDA').attr("value", ss[2]);
                        $('#BAN_LINK').attr("value", ss[3]);
                        $("#PAG_ID option[value='" + parseInt(ss[4]) + "']").attr("selected", "selected");

                        editar_table2(id);
                    }
                }
            }
            ajax4.send(null);
        }

        function excluirBanner(id, msg) {
            var r = confirm("Deseja mesmo "+msg+" este Banner?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "banners.aspx?acao=excluirBanner&BAN_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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

        function restoreBanner(id) {
            var r = confirm("Deseja deseja mesmo ativar este Banner?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "banners.aspx?acao=restoreBanner&BAN_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
                    Banners</h2>
                <!-- TABELA-->
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget red">
                            <div class="widget-title">
                                <h4>Banners</h4>
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
                                        <form class="inc_form form" name="incluir" enctype="multipart/form-data" action="banners.aspx" runat="server">
                                            <input type="hidden" value="gravarBanner" id="acao" name="acao" />
                                            <input type="hidden" value="0" id="BAN_ID" name="BAN_ID" />
                                            <p>Imagem do Banner</p>
                                            <asp:FileUpload runat="server" ID="BAN_IMAGEM" name="BAN_IMAGEM" class="input" />
                                            <p>Legenda</p>
                                            <input type="text" name="BAN_LEGENDA" class="input obg" id="BAN_LEGENDA" />
                                            <p>Rede</p>
                                            <select name="RED_ID" class="input" id="RED_ID" runat="server">
                                                <option value="NULL">Nenhuma</option>
                                            </select>
                                             <p>Pagina</p>
                                            <select name="PAG_ID" class="input obg" id="PAG_ID" runat="server">
                                                <option value="NULL">Selecione</option>
                                            </select>
                                            <p>Link</p>
                                            <input type="text" name="BAN_LINK" class="input" id="BAN_LINK" />
                                            <p>
                                                <input type="button" value="Limpar" class="btn_form"  formmethod="get" onclick="limpaform(this)" />
                                                <asp:Button ID="Incluir" Cssclass="btn_form"  runat="server" Text="Salvar" OnClick="gravarBanner" />
                                                 
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

