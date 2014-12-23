// JavaScript Document

$(document).ready(function () {



    //GERAL
    //exibe a pg depois que carregada
    $('body').hide();

    $(window).bind('load', function () {
        $('body').fadeIn();
    })

    //VALIDAÇÃO DOS FORMS
    //contato
    $('#login_adm').submit(function () {
        var login = $('#login_adm .login_adm').val();
        var senha = $('.senha_adm').val();
        if (login != "") {
            var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
            if (filtro.test(login)) {
            }
            else {
                $('#login_adm .login_adm').addClass('error');
                $('#login_adm .login_adm').next('span').html('*e-mail inválido').fadeIn(100);
                valida = false
            }
        }
        else {
            $('#login_adm .login_adm').addClass('error');
            $('#login_adm .login_adm').next('span').html('*Campo Obrigatório').fadeIn(100);
            valida = false
        }
        if (senha == "") {
            $('#login_adm .senha_adm').addClass('error');
            $('#login_adm .senha_adm').next('span').html('*Campo Obrigatório').fadeIn(100);
            valida = false
        } else {
            if (senha.length < 6 || senha.length > 10) {
                $('#login_adm .senha_adm').addClass('error');
                $('#login_adm .senha_adm').next('span').html('*A senha deve ter de 6 a 10 caractéres').fadeIn(100);
                valida = false
            }
        }
        if (valida) { } else { return false }
    });
    $('#login_adm .login_adm').focusout(function () {
        var login = $('#login_adm .login_adm').val();
        if (login != "") {
            var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
            if (filtro.test(login)) {
                $('#login_adm .login_adm').removeClass('error');
                $('#login_adm .login_adm').next('span').html('').fadeOut(100);
                $('#login_adm .login_adm').addClass('ok');
                valida = true
            }
            else {
                $('#login_adm .login_adm').addClass('error');
                $('#login_adm .login_adm').next('span').html('*e-mail inválido').fadeIn(100);
                valida = false
            }
        }
        else {
            $('#login_adm .login_adm').addClass('error');
            $('#login_adm .login_adm').next('span').html('*Campo obrigatório').fadeIn(100);;
            valida = false
        }
    });
    $('.senha_adm').focusout(function (e) {
        var senha = $('.senha_adm').val();
        if (senha == "") {
            $('.senha_adm').addClass('error');
            $('.senha_adm').next('span').html('*Campo Obrigatório').fadeIn(100);;
            return false
        } else {
            if (senha.length < 6 || senha.length > 10) {
                $('.senha_adm').addClass('error');
                $('.senha_adm').next('span').html('*A senha deve ter de 6 a 10 caractéres').fadeIn(100);
                return false
            } else {
                $('.senha_adm').removeClass('error');
                $('.senha_adm').next('span').html('').fadeOut(100);
                $('.senha_adm').addClass('ok');
            }
        }
    });

    //esqueci minha senha

    $('#login_adm .esqueci a').click(function (e) {
        e.preventDefault();
        $('#login_adm').fadeOut(0);
        $('#login_adm').get(0).reset();
        $('#esqueci_senha').fadeIn(100)
    });

    $('#esqueci_senha .esqueci a').click(function (e) {
        e.preventDefault();
        $('#esqueci_senha').fadeOut(0);
        $('#esqueci_senha').get(0).reset();
        $('#login_adm').fadeIn(100)
    });

    $('#esqueci_senha').submit(function () {
        var login = $('#esqueci_senha .login_adm').val();
        var rede = $('.rede_adm').val();
        if (login != "") {
            var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
            if (filtro.test(login)) {
            }
            else {
                $('#esqueci_senha .login_adm').addClass('error');
                $('#esqueci_senha .login_adm').next('span').html('*e-mail inválido').fadeIn(100);
                valida = false
            }
        }
        else {
            $('#esqueci_senha .login_adm').addClass('error');
            $('#esqueci_senha .login_adm').next('span').html('*Campo Obrigatório').fadeIn(100);
            valida = false
        }
        if (rede == "") {
            $('.rede_adm').addClass('error');
            $('.rede_adm').next('span').html('*Campo Obrigatório').fadeIn(100);
            valida = false
        }
        if (valida) { } else { return false }
    });
    $('#esqueci_senha .login_adm').focusout(function () {
        var login = $('#esqueci_senha .login_adm').val();
        if (login != "") {
            var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
            if (filtro.test(login)) {
                $('#esqueci_senha .login_adm').removeClass('error');
                $('#esqueci_senha .login_adm').next('span').html('').fadeOut(100);
                $('#esqueci_senha .login_adm').addClass('ok');
                valida = true
            }
            else {
                $('#esqueci_senha .login_adm').addClass('error');
                $('#esqueci_senha .login_adm').next('span').html('*e-mail inválido').fadeIn(100);
                valida = false
            }
        }
        else {
            $('#esqueci_senha .login_adm').addClass('error');
            $('#esqueci_senha .login_adm').next('span').html('*Campo obrigatório').fadeIn(100);;
            valida = false
        }
    });
    $('.rede_adm').focusout(function (e) {
        var rede = $('.rede_adm').val();
        if (rede == "") {
            $('.rede_adm').addClass('error');
            $('.rede_adm').next('span').html('*Selecione uma rede').fadeIn(100);
            return false
        } else {
            $('.rede_adm').removeClass('error');
            $('.rede_adm').next('span').html('').fadeOut(100);
            $('.rede_adm').addClass('ok');
        }
    });

    //MENU USUARIO
    //ativa menu
    fechar = setTimeout(function () { $('.user_menu').fadeOut(300); }, 3000);
    $('.icon_user img').click(function () {
        clearInterval(fechar);
        $('.user_menu').fadeIn(300);
        fechar = setTimeout(function () { $('.user_menu').fadeOut(300); }, 3000);
    });
    $('.icon_user p').click(function (e) {
        e.preventDefault()
        $('.icon_user img').click();
    })
    //pausa timer do menu se estiver no houver
    $('.user_menu').hover(function () { clearInterval(fechar); }, function () { fechar = setTimeout(function () { $('.user_menu').fadeOut(300); }, 3000); })

    //MENU
    //ALTERA ICONE	
    if ($('#menu ul li').hasClass('ativo')) {
        var bread = $('.ativo a img').attr('src').replace('.png', '3.png');
        $('h2 img').attr('src', bread);
    }
    //$('h2 img').after("<br>"+$('.ativo a p').text());
    //celular mask 
    $(function ($) {
        $('.tel').mask("(99) 9999-9999");
    });

    $(function ($) {
        $('.cel').mask("(99) 9999-9999?9");
    });

    //( digitos 
    $('.cel').unbind('focusout').focusout(function () {
        var valor = $(this).val().replace('_', '');
        var len = valor.length;
        if (len >= 14) {
            $(this).unmask();
            if (len == 14) $(this).mask("(99) 9999-9999?9");
            else $(this).mask("(99) 99999-999?9");
        }
    }).trigger('focusout');

    /*$('.uf').focus(function () {
	    $(this).keypress(function (e) {
	        if ($(this).val().length == 2) {
	            return false
	            e.preventDefault
	        }
	    })
	});
	$(".sonumero").keypress(function (e) {
	    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
	        return false;
	    }
	});*/

    //DADOS PESSOAIS
    $('.form_dados').submit(function () {
        $('.obg').each(function () {
            if ($(this).val() == '') {
                $(this).addClass('error')
                $(this).next('span').html('Campo obrigatório').fadeIn()
            } else {
                if ($(this).hasClass('email')) {
                    login = $(this).val()
                    var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
                    if (filtro.test(login)) {

                    }
                    else {
                        $(this).addClass('error')
                        $(this).next('span').html('Email inválido').fadeIn()
                    }
                }
            }
        });
        if ($('.input').hasClass('error')) {
            return false
        }
    })

    $('.form_dados .obg').focusout(function () {
        if ($(this).hasClass('email')) {
            if ($(this).val() == '') {
                $(this).addClass('error')
                $(this).next('span').html('Campo obrigatório').fadeIn()
            } else {
                if ($(this).hasClass('email')) {
                    login = $(this).val()
                    var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
                    if (filtro.test(login)) {
                        $(this).removeClass('error')
                        $(this).next('span').fadeOut(0)
                    }
                    else {
                        $(this).addClass('error')
                        $(this).next('span').html('Email inválido').fadeIn()
                    }
                }
            }
        }
    })

    //VALIDA REDES 
    //DADOS PESSOAIS
    $('.inc_form').submit(function () {
        $('.obg').each(function () {
            if ($(this).val() == '') {
                $(this).addClass('error')
            } else {
                if ($(this).hasClass('email')) {
                    login = $(this).val()
                    var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
                    if (filtro.test(login)) {
                        $(this).removeClass('error')
                    }
                    else {
                        $(this).addClass('error')
                    }
                } else {
                    $(this).removeClass('error')
                }
            }
        });
        if ($('.input').hasClass('error')) {
            return false
        }
    })

    $('.obg').focusout(function () {
        if ($(this).val() == '') {
            $(this).addClass('error')
        } else {
            if ($(this).hasClass('email')) {
                login = $(this).val()
                var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
                if (filtro.test(login)) {
                    $(this).removeClass('error')
                }
                else {
                    $(this).addClass('error')
                }
            } else {
                $(this).removeClass('error')
            }
        }
    })
    //TABELA	
    //APLICA JQUERY NA TABELA
    if ($('#tabela').size() > 0) {
        $('#tabela').dataTable({
            "dom": '<"top"iflp<"clear">>rt<"bottom"iflp<"clear">>',
            "order": [[0, "desc"]],
            "filter": false
        });
    }
    //abrir form
    $('.incluir').click(function () {
        if ($('.form_table').height() > 0) {
            $('.form_table').removeAttr('style');
            if ($('.fil_form').is(':visible')) {
                $('.form_table form').fadeOut(0);
                setTimeout(function () {
                    $('.form_table form').fadeOut()
                    $('.inc_form').fadeIn()
                    var antigo = $(".form_table").outerHeight(),
					novo = $(".form_table").css('height', 'auto').outerHeight();
                    $('.form_table').height(antigo);
                    $('.form_table').animate({ height: novo }, 500);
                }, 510)
            } else {
                $('.form_table').removeAttr('style');
                $('.form_table form').fadeOut(0);
            }
        } else {
            $('.form_table form').fadeOut()
            $('.inc_form').fadeIn()
            var antigo = $(".form_table").outerHeight(),
			novo = $(".form_table").css('height', 'auto').outerHeight();
            $('.form_table').height(antigo);
            $('.form_table').animate({ height: novo }, 500);
        }
    });
    $('.filtrar').click(function () {
        if ($('.form_table').height() > 0) {
            $('.form_table').removeAttr('style');
            if ($('.inc_form').is(':visible')) {
                $('.form_table form').fadeOut(0);
                setTimeout(function () {
                    $('.form_table form').fadeOut()
                    $('.fil_form').fadeIn()
                    var antigo = $(".form_table").outerHeight(),
					novo = $(".form_table").css('height', 'auto').outerHeight();
                    $('.form_table').height(antigo);
                    $('.form_table').animate({ height: novo }, 500);
                }, 510)
            } else {
                $('.form_table').removeAttr('style');
                $('.form_table form').fadeOut(0);
            }
        } else {
            $('.form_table form').fadeOut()
            $('.fil_form').fadeIn()
            var antigo = $(".form_table").outerHeight(),
			novo = $(".form_table").css('height', 'auto').outerHeight();
            $('.form_table').height(antigo);
            $('.form_table').animate({ height: novo }, 500);
        }
    });

    $('.excluidos').click(function () {
        $('.tabela_ok').fadeOut(10)
        $('.tabela_excluidos').delay(12).fadeIn(100);
        $('.acoes_topo_form').fadeOut(100);
        $('.voltar_topo_form').delay(110).fadeIn(100);
    });
    $('.voltar_topo_form').click(function () {
        $('.tabela_excluidos').fadeOut(10)
        $('.tabela_ok').delay(12).fadeIn(100);
        $('.acoes_topo_form').delay(10).fadeIn(100);
        $('.voltar_topo_form').fadeOut(0);
    })
    //clona paginacao
    clone()

    $('.pgnfake ul li').click(function (e) {
        e.preventDefault();
        var nth = $(this).index() + 1
        if (nth == 5) {
            oSettings.oApi._fnPageChange(oSettings, "next");
            fnCallbackDraw(oSettings);
        }
        $('.table').next('div').addClass('pg');
        $('.pg ul li:nth-child(' + nth + ')').click()
        $('.table').next('div').removeClass('pg')
        clone()
    })

    //ABRI EDIÇÃO
    /*	$('.img_edit').click(function(e) {
            e.preventDefault();
            $('.tr_form').remove()
            $('tr').removeClass('tr_ativo');
            $(this).parent('td').parent('tr').addClass('tr_ativo');	
            var tds=$('.table .tr_ativo td').size();
            var conteudo=$('.alteracao_div').html()
            $('.tr_ativo').after('<tr class="tr_form"><td colspan="'+tds+'" align="center">'+conteudo+'</td></tr>');
                var antigo=$( ".tr_form td form" ).height(),
                novo=$( ".tr_form td form" ).css('height','auto').height();
                $('.tr_form td form').height(antigo);	
                $('.tr_form td form').animate({height:novo},900);
        });*/

    $('.form_alt_senha').submit(function () {
        $('.input').each(function () {
            if ($(this).val() == '') {
                $(this).addClass('error');
                $(this).next('span').html('Digite uma nova senha').fadeIn();
            } else {
                if ($(this).val().length < 6 || $(this).val().length > 12) {
                    $(this).addClass('error');
                    $(this).next('span').html('Digite a senha com no minimo 6 e máximo 12 caractéres').fadeIn();
                } else {
                    $(this).removeClass('error');
                    $(this).next('span').fadeOut(0)
                }
            }
        });
        if ($('.input').hasClass('error')) {
            return false
        } else {
            if ($('.input:first').val() == $('.input:last').val()) {
            } else {
                $('.input:last').addClass('error');
                $('.input:last').next('span').html('As senhas não conferem').fadeIn();
                return false
            }
        }
    })


});

function clone() {
    //clona paginacao
    $('.table').prev('.row-fluid').html($('.table').next('.row-fluid').html());
    $('.table').prev('div').addClass('pgnfake');
    $('.pgnfake ul li').click(function (e) {
        e.preventDefault();
        var nth = $(this).index() + 1
        $('.table').next('div').addClass('pg');
        $('.pg ul li:nth-child(' + nth + ')').click()
        $('.table').next('div').removeClass('pg')
        //clone()
    })
}
function editar_table(id) {
    $('.img_ok').removeClass('img_ok')
    $('.tr_form').remove()
    $('tr').removeClass('tr_ativo');
    $('#tr_' + id + '').addClass('tr_ativo');
    $('.img_ok').parent('td').remove();
    var tds = $('.table .tr_ativo td').size();
    var conteudo = $('.inc_form').html().replace(/incluir/g, 'alterar');
    $('.tr_ativo').after('<tr class="tr_form"><td colspan="' + tds + '" align="center"><form class="form alt_form">' + conteudo + '</form></td></tr>');
    var antigo = $(".tr_form td form").height(),
    novo = $(".tr_form td form").css('height', 'auto').height();
    $('.tr_form td form').height(antigo);
    $('.tr_form td form').animate({ height: novo }, 900);
    //valida novo form
    $('.alt_form').submit(function () {
        $('.obg').each(function () {
            if ($(this).val() == '') {
                $(this).addClass('error')
            } else {
                if ($(this).hasClass('email')) {
                    login = $(this).val()
                    var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
                    if (filtro.test(login)) {
                        $(this).removeClass('error')
                    }
                    else {
                        $(this).addClass('error')
                    }
                } else {
                    $(this).removeClass('error')
                }
            }
        });
        if ($('.input').hasClass('error')) {
            return false
        }
    })

    //VALIDA NMO BLUR
    $('.obg').focusout(function () {
        if ($(this).val() == '') {
            $(this).addClass('error')
        } else {
            if ($(this).hasClass('email')) {
                login = $(this).val()
                var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
                if (filtro.test(login)) {
                    $(this).removeClass('error')
                }
                else {
                    $(this).addClass('error')
                }
            } else {
                $(this).removeClass('error')
            }
        }
    })

}
function uf(val) {
    if (val.length > 1) {
        event.stopPropagation()
        return false
    }
}
function maiuscula(z) {
    v = z.value.toUpperCase();
    z.value = v;
}
function sonumero(e) {
    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        return false;
    }
}
function validardinamico() {
}

function editar_table2(id) {
    $('.img_ok').removeClass('img_ok')
    $('.tr_form').remove()
    $('tr').removeClass('tr_ativo');
    $('#tr_' + id + '').addClass('tr_ativo');
    $('.img_ok').parent('td').remove();
    var tds = $('.table .tr_ativo td').size();
    var conteudo = $('.inc_form').html().replace(/incluir/g, 'alterar');
    $('.tr_ativo').after('<tr class="tr_form"><td colspan="' + tds + '" align="center"><form class="form" runat="server" name="alterar" enctype="multipart/form-data" method="post">' + conteudo + '</form></td></tr>');
    var antigo = $(".tr_form td form").height(),
    novo = $(".tr_form td form").css('height', 'auto').height();
    $('.tr_form td form').height(antigo);
    $('.tr_form td form').animate({ height: novo }, 900);
}

function editar_table3(id) {
    $('.img_ok').removeClass('img_ok')
    $('.tr_form').remove()
    $('tr').removeClass('tr_ativo');
    $('#tr_' + id + '').addClass('tr_ativo');
    $('.img_ok').parent('td').remove();

    //  $('#GFO_IMAGEM').attr("runat", "server");

    var tds = $('.table .tr_ativo td').size();
    var conteudo = $('.inc_form').html().replace(/incluir/g, 'alterar');
    //$('.tr_ativo').after('<tr class="tr_form"><td colspan="' + tds + '" align="center"><form class="form" runat="server" action="fotos.aspx" name="alterar" enctype="multipart/form-data" method="post">' + conteudo + '</form></td></tr>');
    $('.tr_ativo').after('<tr class="tr_form"><td colspan="' + tds + '" align="center"><form class="form" runat="server" name="alterar" enctype="multipart/form-data" method="post">' + conteudo + '</form></td></tr>');
    var antigo = $(".tr_form td form").height(),
    novo = $(".tr_form td form").css('height', 'auto').height();
    $('.tr_form td form').height(antigo);
    $('.tr_form td form').animate({ height: novo }, 900);
}

//<form class="inc_form form" name="incluir" action="fotos.aspx" novalidate="novalidate" accept-charset="default" runat="server">>>>>>>> .r107
