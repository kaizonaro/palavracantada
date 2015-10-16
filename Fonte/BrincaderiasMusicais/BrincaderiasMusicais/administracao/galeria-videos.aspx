<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="galeria-videos.aspx.cs" Inherits="BrincaderiasMusicais.administracao.Galeria_Videos" %>


<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>:: Administração - Galeria Colaborativa Fotos</title>
    <brincadeira:script runat="server" ID="script" />
    <script src="tinymce/tinymce.min.js"></script>
    <script type="text/javascript">

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


        function Aprovar(id) {
            var r = confirm("Deseja mesmo aprovar este Video ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "galeria-videos.aspx?acao=Aprovar&COV_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
                ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
                ajax2.onreadystatechange = function () {
                    if (ajax2.readyState == 4) {
                        if (ajax2.status == 200) {
                            alert("Vídeo aprovada com sucesso!");
                            $('#tr_' + id).hide();
                        }
                    }
                }
                ajax2.send(null);
            } else {
                return false;
            }
        }

        function Reprovar(id) {
            var r = confirm("Deseja mesmo reprovar este Video ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "galeria-videos.aspx?acao=Reprovar&COV_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
                    Galeria Colaborativa Colaborativa Videos</h2>
                <!-- TABELA-->
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget red">
                            <div class="widget-title">
                                <h4>Galeria Colaborativa Videos</h4>
                                <div class="btns_acoes">
                                    <!--<div class="incluir acoes_topo_form">
                                        <img src="images/mais.png" alt="Incluir"><p>Incluir</p>
                                    </div>-->
                                    <div class=" acoes_topo_form">
                                       <select id="STATUS" name="STATUS" class="input" runat="server" onchange="location = 'galeria-videos.aspx?STATUS='+$(this).val()">
                                              <option value="" selected> Filtrar por Status </option>
                                            <option value="Aguardando Aprovação">Aguardando Aprovação</option>
                                            <option value="Aprovado">Aprovado</option>
                                            <option value="Reprovado">Reprovado</option>
                                        </select>

                                    </div>
                                    <!-- <div class="voltar_topo_form acoes_topo_form">
                                        <img src="images/restore.png" alt="Filtrar"><p>Voltar</p>
                                    </div>-->
                                    <div class="form_table">

                                        <!-- FORMULÁRIO DE INCLUSÃO -->
                                        <form id="Form1" class="inc_form form" name="incluir" action="equipe.aspx" novalidate="novalidate" accept-charset="default" runat="server">
                                            <input type="hidden" id="acao" name="acao" value="gravar" />
                                            <input type="hidden" id="EQU_ID" name="EQU_ID" value="0" />

                                            <p>Nome:*</p>
                                            <input type="text" name="EQU_NOME" id="EQU_NOME" class="input obg" placeholder="Nome do Integrante" />

                                            <p>Imagem:</p>
                                            <asp:FileUpload ID="EQU_FOTO" runat="server" class="input" />

                                            <p>Descrição:*</p>
                                            <textarea id="EQU_DESCRICAO" name="EQU_DESCRICAO" style="width: 100%">

                                            </textarea>


                                            <p class="p_btn">
                                                <input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                                <asp:Button ID="Incluir" CssClass="btn_form" runat="server" Text="Salvar" OnClick="gravar" />
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
