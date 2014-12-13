<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="BrincaderiasMusicais.administracao.usuarios" %>

<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>:: Administração - Usuários</title>
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
            ajax4.open("GET", "ajax/acoes.aspx?acao=populaUsuario&USU_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
            ajax4.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax4.onreadystatechange = function () {
               

                if (ajax4.readyState == 4) {
                    if (ajax4.status == 200) {
                        
                        var ss = ajax4.responseText.split("|");

                        $('#USU_ID').attr("value", ss[0]);
                        $("#RED_ID option[value='" + ss[1] + "']").attr("selected", "selected");
                        $('#USU_NOME').attr("value", ss[2]);
                        $('#USU_EMAIL').attr("value", ss[3]);
                        $('#USU_SENHA').attr("value", ss[4]);

                        $('#USU_SENHA').attr("readonly", "");
                        
                        editar_table(id);
                    }
                }
            }
            ajax4.send(null);
        }

        function excluirUsuario(id) {
            var r = confirm("Deseja mesmo desativar este usuário ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "usuarios.aspx?acao=excluirUsuario&USU_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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

        function restoreUsuario(id) {
            var r = confirm("Deseja deseja mesmo ativar este usuário ?");
            if (r == true) {
                ajax2 = ajaxInit();
                ajax2.open("GET", "usuarios.aspx?acao=AtivarUsuario&USU_ID=" + id + "&Rand=" + Math.ceil(Math.random() * 100000), true);
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
    <brincadeira:header runat="server" id="header" />
    <!--FIM DO HEADER-->
    
    <!--CONTEUDO GERAL-->
    <section class="all">
    	<div class="all_center">
        	<section id="conteudo">
            	<h2><img src="images/home.png" alt="inicio"><br>Usuários</h2>
                 <!-- TABELA-->
                <div class="row-fluid">
                    <div class="span12">
                    <div class="widget red">
                        <div class="widget-title">
                            <h4>Usuários</h4>
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
                                	<form class="inc_form form" name="incluir" action="usuarios.aspx" novalidate="novalidate" accept-charset="default">
                                        <input type="hidden" id="acao" name="acao" value="gravarUsuario" />
                                        <input type="hidden" id="USU_ID" name="USU_ID" value="0" />

                                    	<p>Selecione uma rede:*</p>
                                        <select id="RED_ID" name="RED_ID" class="input obg" data-validation="required" runat="server">
                                            <option value="">Selecione</option>
                                        </select>
                                        
                                        <p>Nome:*</p>
                                		<input type="text" name="USU_NOME" id="USU_NOME" class="input error" placeholder="Nome Completo">
                                        
                                        <p>E-mail:*</p>
                                        <input type="text" name="USU_EMAIL" id="USU_EMAIL" class="input"  placeholder="Digite um e-mail válido"/>
                                        
                                        <p>Senha:*</p>
                                        <input type="password" name="USU_SENHA" id="USU_SENHA" class="input"  placeholder="Escolha uma senha"/>
                                        
                                        
                                        </label><p class="p_btn">
                                    		<input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                            <input type="submit" value="incluir" class="btn_form" formmethod="get" />
                               			</p>
                                    </form>
                                    <form class="fil_form form" novalidate accept-charset="default">
                                    	<p>campo:*</p>
                                		<input type="text" class="input" data-validation="required" />
                                        <p>campo:*</p>
                                        <input type="text" class="input" data-validation="required" />
                                        <p class="p_btn">
                                    		<input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                            <input type="submit" value="Filtrar" class="btn_form" formmethod="get" />
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
                                 <!--<table class="table table-striped table-bordered" id="sample_2">
                                    <thead>
                                    <tr>
                                        <th style="width:8px;">ID</th>
                                        <th>Nome</th>
                                        <th>Email</th>
                                        <th>Telefone</th>
                                        <th>ultima compra</th>
                                        <th>Ações</th>
                                    </tr>
                                    </thead>
                                    <tbody>
                                    <tr class="">
                                        <td>1</td>
                                        <td><a href="#" title="Cliente">Cleyber Nunes</a></td>
                                        <td><a href="mailto:soa bal@yahoo.com">soa bal@yahoo.com</a></td>
                                        <td>(11) 3781-9806</td>
                                        <td>07/10/2014</td>
                                        <td><a href="#" class="img_del"><img src="images/restore.png"></a></td>
                                    </tr>
                                    </tbody>
                                </table>-->
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
