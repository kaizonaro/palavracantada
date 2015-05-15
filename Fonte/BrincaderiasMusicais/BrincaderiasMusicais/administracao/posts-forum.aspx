<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="posts-forum.aspx.cs" Inherits="BrincaderiasMusicais.administracao.posts_forum" ValidateRequest="false" %>


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
         
        function excluirPost(id, msg) {
            var r = confirm("Deseja mesmo " + msg + " esta mensagem do forum ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "posts-forum.aspx?acao=excluirPost&FME_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
            var r = confirm("Deseja deseja mesmo ativar esta mensagem do forum ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "posts-forum.aspx?acao=ativarPost&FME_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
                                   <%-- <div class="filtrar acoes_topo_form">
                                        <img src="images/filtro.png" alt="Filtrar"><p>Filtrar</p>
                                    </div>
                                    <div class="incluir acoes_topo_form">
                                        <img src="images/mais.png" alt="Incluir"><p>Incluir</p>
                                    </div>--%>
                                    <div class="excluidos acoes_topo_form">
                                        <img src="images/lixo.png" alt="Filtrar"><p>Ítens excluidos</p>
                                    </div>
                                    <div class="voltar_topo_form acoes_topo_form">
                                        <img src="images/restore.png" alt="Filtrar"><p>Voltar</p>
                                    </div>
                                    <div class="form_table">

                                        <!-- FORMULÁRIO DE INCLUSÃO -->
                                     <%--   <form id="Form1" class="inc_form form" name="incluir" action="blog.aspx" novalidate="novalidate" accept-charset="default" runat="server">
                                            <input type="hidden" id="acao" name="acao" value="gravar" />
                                            <input type="hidden" id="FME_ID" name="FME_ID" value="0" />

                                            <p>Título:*</p>
                                            <input type="text" maxlength="60" name="FME_TITULO" id="FME_TITULO" class="input obg" placeholder="Título do Post" />

                                            <p>Imagem (478px x 332px)*:</p>
                                            <asp:FileUpload ID="FME_IMAGEM" runat="server" class="multi input" />
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
                                            <textarea id="FME_TEXTO" name="FME_TEXTO" style="width: 100%">

                                            </textarea>


                                            <label for="FME_IMPORTANTE">Importante:</label>
                                            <input type="checkbox" id="FME_IMPORTANTE" name="FME_IMPORTANTE" value="1" />

                                            <p class="p_btn">
                                                <input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                                <asp:Button ID="Incluir" CssClass="btn_form" runat="server" Text="Salvar" OnClick="gravar" />
                                            </p>
                                        </form>--%>

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
