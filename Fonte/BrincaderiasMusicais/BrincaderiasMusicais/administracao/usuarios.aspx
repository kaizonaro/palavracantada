<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="BrincaderiasMusicais.administracao.usuarios" %>

<%@ Register Src="~/administracao/inc/script.ascx" TagPrefix="brincadeira" TagName="script" %>
<%@ Register Src="~/administracao/inc/header.ascx" TagPrefix="brincadeira" TagName="header" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>:: Administração - Usuários</title>
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
                        $('#USU_EMAIL').val(ss[3]);
                        $('#USU_SENHA').val(ss[4]);
                        tinyMCE.activeEditor.setContent(ss[5]);
                        $('#thumb').html('<img src=\"../upload/imagens/usuarios/' + ss[6] + '\" width="70" height="70"/>');
                        $('#USU_DH_CADASTRO').html("<p>Cadastrado desde: " + ss[7] + "</p>");
                        $('#USU_QTD_ACESSO').html("<p>Quantidade de Acessos: " + ss[8] + "</p>");
                        $('#USU_DH_ULTIMO_ACESSO').html("<p>Ultimo Acesso: " + ss[9] + "</p>");

                        if (ss[10] == "True") {
                            $('#USU_ATIVO').attr("checked", "checked");
                        }

                        $("#USU_PRESENCIAL option[value='" + ss[11] + "']").attr("selected", "selected");




                        editar_table2(id);
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

        function FiltrarPesquisa(a, b, c) {
            $.ajax({
                type: 'GET',
                url: location.pathname,
                async: true,
                data: "acao=FiltrarPesquisa&USU_NOME=" + a + "&USU_EMAIL=" + b + "&RED_ID=" + c,
                success: function (data) {
                    console.log(data)
                    $("#tabela").html(data);
                    repaginar();
                },
                error: function (xhr, status, error) {
                    var err = eval("(" + xhr.responseText + ")");
                    alert("Erro: " + err.Message);
                },
                beforeSend: function () {
                    console.log("comecou")
                },
                complete: function () {
                    console.log("acabou");
                }
            });
        }

        function ValidarUsuario() {
            ajax2 = ajaxInit();
            ajax2.open("GET", "usuarios.aspx?acao=ValidarUsuario&USU_USUARIO=" + USU_USUARIO.value, true);
            ajax2.setRequestHeader("Content-Type", "charset=iso-8859-1");
            ajax2.onreadystatechange = function () {
                if (ajax2.readyState == 4) {
                    if (ajax2.status == 200) {

                        var ss = ajax2.responseText.split("|");

                        $("#redemensagem").html(ss[0]);

                        if (ss[1] == 0) {
                            $("#Incluir").attr("disabled", true);
                            $("#USU_USUARIO").attr("style", "background-color:#FFAEAE");
                            $("#USU_USUARIO").focus();
                            $("#USU_USUARIO").select();
                        }
                        else {
                            $("#Incluir").removeAttr("disabled");
                            $("#USU_USUARIO").removeAttr("style");
                        }

                    }
                }
            }
            ajax2.send(null);

        }

        function capturar(campo) {
            document.getElementById("USU_USUARIO").value = removeCaracteres(trim(campo.value));
        }

        function trim(e) {
            espacos = /\s/g;
            return e.replace(espacos, "").toLowerCase();
        }

        function removeCaracteres(e) {
            remove = /á|é|í|ó|ã|à|ê|#|!|@|$|%|&|(|)|{|}|&|(|)|ú/g;  // adicione os caracteres indesejáveis
            return e.replace(remove, "");
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
                    Usuários</h2>
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
                                        <form class="inc_form form" name="incluir" action="usuarios.aspx" novalidate="novalidate" accept-charset="default" runat="server">
                                            <input type="hidden" id="acao" name="acao" value="gravarUsuario" />
                                            <input type="hidden" id="USU_ID" name="USU_ID" value="0" />

                                            <div id="USU_DH_CADASTRO"></div>
                                            <div id="USU_QTD_ACESSO"></div>
                                            <div id="USU_DH_ULTIMO_ACESSO"></div>

                                            <p>Selecione uma rede:*</p>
                                            <select id="RED_ID" name="RED_ID" class="input obg" data-validation="required" runat="server">
                                                <option value="">Selecione</option>
                                            </select>

                                            <p>Nome:*</p>
                                            <input type="text" name="USU_NOME" id="USU_NOME" class="input obg" placeholder="Nome Completo">

                                            <p>Usuário:* <span style="font-size: 10px; display: block; font-weight: normal;">Não utilizer acentos e/ou caracteres especiais(ex.: @, #, &...)</span></p>
                                            <input type="text" name="USU_USUARIO" onblur="capturar(this);" id="USU_USUARIO" onchange="ValidarUsuario()" class="input obg" placeholder="Nome de Usuário">
                                            <p id="redemensagem"></p>

                                            <p>E-mail:*</p>
                                            <input type="text" name="USU_EMAIL" id="USU_EMAIL" class="input obg" placeholder="Digite um e-mail válido" />

                                            <p>Senha:*</p>
                                            <input type="password" name="USU_SENHA" id="USU_SENHA" class="input obg senha" placeholder="Escolha uma senha" />

                                            <p>Biografia</p>
                                            <textarea id="USU_BIOGRAFIA" name="USU_BIOGRAFIA"></textarea>

                                            <p>Foto</p>
                                            <asp:FileUpload ID="USU_FOTO" CssClass="input" runat="server" />
                                            <div id="thumb"></div>
                                            <p>Tipo de Curso</p>
                                            <select id="USU_PRESENCIAL" name="USU_PRESENCIAL" class="input obg" data-validation="required" runat="server">
                                                <option value="0">A Distância</option>
                                                <option value="0">Presencial</option>
                                            </select>
                                            <p>Status</p>
                                            <input type="checkbox" value="1" id="USU_ATIVO" name="USU_ATIVO" /><label for="USU_ATIVO">Ativo</label>



                                            <p class="p_btn">
                                                <input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                                <asp:Button ID="Incluir" CssClass="btn_form" runat="server" Text="Salvar" OnClick="Incluir_Click" />
                                            </p>

                                        </form>
                                        <form class="fil_form form" novalidate accept-charset="default">
                                            <p>Rede</p>
                                            <select id="FL_REDE_ID" name="FL_REDE_ID" class="input" runat="server">
                                                <option value="">Selecione</option>
                                            </select>

                                            <p>Nome:</p>
                                            <input type="text" name="FL_NOME" id="FL_NOME" class="input" />

                                            <p>E-Mail:</p>
                                            <input type="text" name="FL_EMAIL" id="FL_EMAIL" class="input" />


                                            <p class="p_btn">
                                                <input type="reset" value="Limpar" class="btn_form" formmethod="get" />
                                                <input type="button" onclick="FiltrarPesquisa(FL_NOME.value, FL_EMAIL.value, FL_REDE_ID.value)" value="Filtrar" class="btn_form" formmethod="get" />
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
