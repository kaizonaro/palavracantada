<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fotos.aspx.cs" Inherits="BrincaderiasMusicais.fotos" %>


<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>:: Administração - Fotos</title>
    <brincadeira:script runat="server" id="script" />

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
            ajax4.open("GET", "ajax/acoes.aspx?acao=populaFotos&GFO_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {

                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {

                        var ss = ajax4.responseText.split("|");
                        
                        $('#GFO_ID').attr("value", ss[0]);
                        $("#RED_ID option[value='" + parseInt(ss[1]) + "']").attr("selected", "selected");
                        $('#GFO_LEGENDA').attr("value", ss[2]);
                       
                        editar_table2(id);
                    }
                }
            }
            ajax4.send(null);
        }

        function excluirFoto(id) {
            var r = confirm("Deseja mesmo desativar esta Foto ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "fotos.aspx?acao=excluirFoto&GFO_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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

        function restaurarFoto(id) {
            var r = confirm("Deseja deseja mesmo ativar esta foto ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "fotos.aspx?acao=restaurarFoto&GFO_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
    <brincadeira:header runat="server" id="header" />
    <!--FIM DO HEADER-->
    
    <!--CONTEUDO GERAL-->
    <section class="all">
    	<div class="all_center">
        	<section id="conteudo">
            	<h2><img src="images/home.png" alt="inicio"><br>Fotos</h2>
                 <!-- TABELA-->
                <div class="row-fluid">
                    <div class="span12">
                    <div class="widget red">
                        <div class="widget-title">
                            <h4>Fotos</h4>
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
                                	<form  class="inc_form form" name="incluir" action="fotos.aspx" novalidate="novalidate" accept-charset="default" runat="server">
                                        <input type="hidden" id="acao" name="acao" value="gravar" />
                                        <input type="hidden" id="GFO_ID" name="GFO_ID" value="0" />

                                    	
                                        <p>Foto:*</p>
                                		<asp:FileUpload runat="server" ID="GFO_IMAGEM" CssClass="input obg" />
                                        
                                        <p>Legenda:*</p>
                                        <input type="text" name="GFO_LEGENDA" id="GFO_LEGENDA" class="input"  placeholder="Lengenda da foto"/>
                                        
                                        <p>Selecione uma rede:</p>
                                        <select id="RED_ID" name="RED_ID" class="input obg" runat="server">
                                            <option value="NULL">Selecione</option>
                                        </select>

                                        <p class="p_btn">
                                    		<input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                            <asp:Button ID="Incluir" Cssclass="btn_form"  runat="server" Text="Incluir" OnClick="gravar" />
                               			</p>
                                    </form>

                                    <form class="fil_form form" novalidate accept-charset="default">
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