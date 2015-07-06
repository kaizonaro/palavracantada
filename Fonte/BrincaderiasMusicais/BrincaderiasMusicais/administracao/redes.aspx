<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="redes.aspx.cs" Inherits="BrincaderiasMusicais.administracao.redes" %>


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
            ajax4.open("GET", "redes.aspx?acao=editarRede&RED_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {


                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {

                        var resposta = ajax4.responseText.split("<!DOCTYPE html>");

                        var ss = resposta[0].split("|");


                        $('#RED_ID').attr("value", ss[0]);

                        $('#RED_TITULO').attr("value", ss[1]);
                        $('#RED_CIDADE').attr("value", ss[2]);
                        $('#RED_UF').attr("value", ss[3]);
                        $('#USU_MASSA_PRESENCIAL').attr("value", ss[4]);
                        $('#USU_MASSA_PRESENCIAL').attr("disabled", true);
                        $('#USU_MASSA_DISTANCIA').attr("value", ss[5]);
                        $('#USU_MASSA_DISTANCIA').attr("disabled", true);
                        editar_table(id);
                    }
                }
            }
            ajax4.send(null);
        }

        function renable() {
            $('#USU_MASSA_PRESENCIAL').attr("disabled", false);
            $('#USU_MASSA_PRESENCIAL').attr("value", "");
            $('#USU_MASSA_DISTANCIA').attr("disabled", false);
            $('#USU_MASSA_DISTANCIA').attr("value", "");
        }

        function excluirRede(id) {
            var r = confirm("Deseja mesmo desativar esta rede?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "redes.aspx?acao=excluirRede&RED_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
            ajax2.open("GET", "redes.aspx?acao=ValidarRede&RED_TITULO=" + RED_TITULO.value, true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {

                        var resposta = ajax2.responseText.split("<!DOCTYPE html>");
                        var ss = resposta[0].split("|");

                        $("#redemensagem").html(ss[0]);

                        if (ss[1] == 0) {
                            $("#bt_cadastrar").attr("disabled", true);
                            $("#RED_TITULO").attr("style", "background-color:#FFAEAE");
                            $("#RED_TITULO").focus();
                            $("#RED_TITULO").select();
                        }
                        else {
                            $("#bt_cadastrar").removeAttr("disabled");
                            $("#RED_TITULO").removeAttr("style");
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
                ajax2.open("GET", "redes.aspx?acao=restoreRede&RED_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
                                <h4>Redes</h4>
                                <div class="btns_acoes">
                                    <!--<div class="filtrar acoes_topo_form">
                                	<img src="images/filtro.png" alt="Filtrar"><p>Filtrar</p>
                                </div>-->
                                    <div class="incluir acoes_topo_form" onclick="renable()">
                                        <img src="images/mais.png" alt="Incluir"><p>Incluir</p>
                                    </div>
                                    <div class="excluidos acoes_topo_form">
                                        <img src="images/lixo.png" alt="Filtrar"><p>Ítens excluidos</p>
                                    </div>
                                    <div class="voltar_topo_form acoes_topo_form">
                                        <img src="images/restore.png" alt="Filtrar"><p>Voltar</p>
                                    </div>
                                    <div class="form_table">
                                        <form class="inc_form form" method="post" name="incluir" action="redes.aspx" enctype="multipart/form-data" onsubmit="return validardinamico()">
                                            <input type="hidden" value="GravarRede" id="acao" name="acao" />

                                            <input type="hidden" value="0" id="RED_ID" name="RED_ID" />
                                            <p>Nome da Rede*</p>
                                            <input type="text" name="RED_TITULO" class="input obg" onchange="ValidarRede()" id="RED_TITULO" />
                                            <input type="hidden" value="" id="valido" class="obg" name="valido" />
                                            <p id="redemensagem"></p>
                                            <p>Cidade*</p>
                                            <input type="text" name="RED_CIDADE" class="input obg" id="RED_CIDADE" />
                                            <p>UF*</p>
                                            <input type="text" name="RED_UF" class="input uf obg" id="RED_UF" onkeypress="return uf(this.value, event)" onkeyup="maiuscula(this)" />
                                            <p>Nome do Diretor</p>
                                            <input type="text" name="RED_NOME_DIRETOR" class="input obg" id="RED_NOME_DIRETOR" />

                                            <p>Assinatura do Diretor (700x250)</p>
                                            <input type="file" id="RED_ASSINATURA" name="RED_ASSINATURA" class="input"  />

                                            <p>Brasão do Municipio (350x250)</p>
                                            <input type="file" id="RED_BRASAO" name="RED_BRASAO" class="input"  />



                                            <p>Configuração da Rede (Usuários e Quantidade de Horas)</p>
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td></td>
                                                    <td>Presenciais</td>
                                                    <td>A Distancia</td>
                                                </tr>
                                                <tr>
                                                    <td>Quantidade de Usuários</td>
                                                    <td>
                                                        <input type="number" class="input sonumero" id="USU_MASSA_PRESENCIAL" name="USU_MASSA_PRESENCIAL" onkeypress="return sonumero(event)" /></td>
                                                    <td>
                                                        <input type="number" class="input sonumero" id="USU_MASSA_DISTANCIA" name="USU_MASSA_DISTANCIA" onkeypress="return sonumero(event)" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Quantidade de Horas</td>
                                                    <td>
                                                        <input type="number" class="input sonumero" id="RED_HORAS_PRESENCIAIS" name="RED_HORAS_PRESENCIAIS" onkeypress="return sonumero(event)" /></td>
                                                    <td>
                                                        <input type="number" class="input sonumero" id="RED_HORAS_DISTANCIA" name="RED_HORAS_DISTANCIA" onkeypress="return sonumero(event)" onchange="calcular()" /></td>
                                                </tr>

                                            </table>

                                            <p>Peso dos Itens (Para usuários a distância)</p>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td></td>
                                                    <td>Blog</td>
                                                    <td>Galeria</td>
                                                    <td>Videos Pessoais</td>
                                                    <td>Fotos Pessoais</td>
                                                    <td>Criações Documentadas</td>
                                                    <td>Forum</td>
                                                </tr>
                                                <tr id="pesos">
                                                    <td>Peso em Horas</td>
                                                    <td>
                                                        <input type="number" class="input sonumero" name="PES_BLOG" id="PES_BLOG" onkeypress="return sonumero(event)" /></td>
                                                    <td>
                                                        <input type="number" class="input sonumero" name="PES_GALERIA" id="PES_GALERIA" onkeypress="return sonumero(event)" /></td>
                                                    <td>
                                                        <input type="number" class="input sonumero" name="PES_VIDEOS" id="PES_VIDEOS" onkeypress="return sonumero(event)" /></td>
                                                    <td>
                                                        <input type="number" class="input sonumero" name="PES_FOTOS" id="PES_FOTOS" onkeypress="return sonumero(event)" /></td>
                                                    <td>
                                                        <input type="number" class="input sonumero" name="PES_CRIACOES" id="PES_CRIACOES" onkeypress="return sonumero(event)" /></td>
                                                    <td>
                                                        <input type="number" class="input sonumero" name="PES_FORUM" id="PES_FORUM" onkeypress="return sonumero(event)" /></td>
                                                </tr>
                                                <tr id="limites" style="display: none">
                                                    <td>Limite em Horas</td>
                                                    <td>
                                                        <input type="number" class="input sonumero" name="LIM_BLOG" id="LIM_BLOG" onkeypress="return sonumero(event)" /></td>
                                                    <td>
                                                        <input type="number" class="input sonumero" name="LIM_GALERIA" id="LIM_GALERIA" onkeypress="return sonumero(event)" /></td>
                                                    <td>
                                                        <input type="number" class="input sonumero" name="LIM_VIDEOS" id="LIM_VIDEOS" onkeypress="return sonumero(event)" /></td>
                                                    <td>
                                                        <input type="number" class="input sonumero" name="LIM_FOTOS" id="LIM_FOTOS" onkeypress="return sonumero(event)" /></td>
                                                    <td>
                                                        <input type="number" class="input sonumero" name="LIM_CRIACOES" id="LIM_CRIACOES" onkeypress="return sonumero(event)" /></td>
                                                    <td>
                                                        <input type="number" class="input sonumero" name="LIM_FORUM" id="LIM_FORUM" onkeypress="return sonumero(event)" /></td>
                                                </tr>
                                            </table>
                                            <p>
                                                <input type="reset" value="Limpar" class="btn_form" formmethod="get" />

                                                <input type="submit" id="bt_cadastrar" class="btn_form" value="Salvar" />

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
    <script>
        function calcular() {
            var totalhoras = $("#RED_HORAS_DISTANCIA").val();

            $("#LIM_CRIACOES").val(Math.round((totalhoras * 50) / 100))
            $("#LIM_FORUM").val(Math.round((totalhoras * 20) / 100))
            $("#LIM_FOTOS").val(Math.round((totalhoras * 2.5) / 100))
            $("#LIM_VIDEOS").val(Math.round((totalhoras * 2.5) / 100))
            $("#LIM_GALERIA").val(Math.round((totalhoras * 5) / 100))
            $("#LIM_BLOG").val(Math.round((totalhoras * 20) / 100))

            $("#PES_CRIACOES").val(Math.ceil(($("#LIM_CRIACOES").val() * 10) / 100))
            $("#PES_FORUM").val(Math.ceil(($("#LIM_FORUM").val() * 10) / 100))
            $("#PES_FOTOS").val(Math.ceil(($("#LIM_FOTOS").val() * 10) / 100))
            $("#PES_VIDEOS").val(Math.ceil(($("#LIM_VIDEOS").val() * 10) / 100))
            $("#PES_GALERIA").val(Math.ceil(($("#LIM_GALERIA").val() * 10) / 100))
            $("#PES_BLOG").val(Math.ceil(($("#LIM_BLOG").val() * 10) / 100))

        }


    </script>

</body>
</html>
