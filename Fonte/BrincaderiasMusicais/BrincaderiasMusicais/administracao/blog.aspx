<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="blog.aspx.cs" Inherits="BrincaderiasMusicais.administracao.blog" %>


<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>:: Administração - Post Blog</title>
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
            ajax4.open("GET", "blog.aspx?acao=editarPost&POS_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {

                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {

                        var resposta = ajax4.responseText.split("<!doctype html>");
                        var ss = resposta[0].split("|");

                        $('#POS_ID').attr("value", ss[0]);
                        $('#POS_TITULO').attr("value", ss[1]);
                        $('#POS_TEXTO').html(ss[2]);
                         if (ss[3] == '1'){$('#POS_IMPORTANTE').attr("checked","checked");}
                             

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
                                            <input type="text" name="POS_TITULO" id="POS_TITULO" class="input" placeholder="Título do Post" />

                                            <p>Imagem:*</p>
                                            <asp:FileUpload ID="POS_IMAGEM" runat="server" class="multi" />

                                            <p>Post:*</p>
                                            <textarea id="POS_TEXTO" name="POS_TEXTO" rows="10" class="input" placeholder="Texto do Post"></textarea>

                                            <p>Importante:</p>
                                            <input type="checkbox" id="POS_IMPORTANTE" name="POS_IMPORTANTE" value="1" />

                                            <p class="p_btn">
                                                <input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                                <asp:Button ID="Incluir" CssClass="btn_form" runat="server" Text="Incluir" OnClick="gravar" />
                                            </p>
                                        </form>

                                        <!-- <form class="fil_form form" novalidate accept-charset="default">
                                        <p>Rede</p>
                                        <select id="FL_REDE_ID" name="FL_REDE_ID" class="input" runat="server" onchange="FiltrarPesquisa(FL_REDE_ID.value, FL_NOME.value, FL_EMAIL.value)">
                                            <option value="">Selecione</option>
                                        </select>

                                    	<p>Nome:</p>
                                		<input type="text" name="FL_NOME" id="FL_NOME" class="input"  onchange="FiltrarPesquisa(FL_REDE_ID.value, FL_NOME.value, FL_EMAIL.value)" />

                                        <p>E-Mail:</p>
                                		<input type="text" name="FL_EMAIL" id="FL_EMAIL" class="input" onchange="FiltrarPesquisa(FL_REDE_ID.value, FL_NOME.value, FL_EMAIL.value)" />
                                        

                                        <p class="p_btn">
                                    		<input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                            <input type="button" onclick="FiltrarPesquisa(FL_REDE_ID.value, FL_NOME.value, FL_EMAIL.value)" value="Filtrar" class="btn_form" formmethod="get" />
                               			</p>
                                    </form>-->
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
