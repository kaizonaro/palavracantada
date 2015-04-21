// JavaScript Document

$(document).ready(function () {
   
  
//GERAL
	//exibe a pg depois que carregada
	//$('body').hide();	
		
	window.onload=function(){		
	   // $('body').fadeIn();
	   // $('#mask').fadeIn(300);
       // $('#modal').fadeIn(400)
	    // twitter();
	    $('#twitter-widget-0').removeAttr('style');
	    if ($('.oculta').size() > 0) {
	        $('.oculta').remove()
	    }
        caroussel()
	}
	
    //BANNER

    //CONTA OS BANERS E CRIA OS BULLETS
	var total = $('#header_banner .banner').length;
	for (var i = 0; i < total; i++) {
	    $('#bullets ul').append(' <li><img src="/images/bullet.png" /></li>')
	}
	$('#header_banner .banner').fadeOut(0)
	$('#header_banner .banner:first').addClass('primeiro');
	$('#header_banner .banner:last').addClass('ultimo');
	$('#header_banner .banner:first').addClass('ativo').fadeIn(0);
	$('#bullets ul li:first').addClass('bullet_ativo');
    //INICIA MUDANÇA AUTOMATICA
	var speed = 7000,
        rotate = setInterval(proximo_banner, speed);

	function proximo_banner() {
	    clearInterval(rotate)
	    if ($('#header_banner .ativo').hasClass('ultimo')) {
	        $('#header_banner .ativo').removeClass('ativo')
	        $('#header_banner .primeiro').addClass('ativo')
	        $('#header_banner .banner:visible').fadeOut(400);
	        $('#header_banner .ativo').fadeIn(400);
	    }else{
	        $('#header_banner .ativo').removeClass('ativo').next('.banner').addClass('ativo');
	        $('#header_banner .banner:visible').fadeOut(400);
	        $('#header_banner .ativo').fadeIn(500);
	    }
	    //var bg = $('#header_banner .ativo .bg').attr('src')	    
	    //$('#banner').css('background-image', 'url(' + bg + ')')
	    //var atual = $('#header_banner .ativo').index();
	    //$('#bullets ul li').removeClass('bullet_ativo');
	   // $('#bullets ul li:eq(' + atual + ')').addClass('bullet_ativo');
	    rotate = setInterval(proximo_banner, speed);
	}


	/*$('#bullets ul li').click(function () {
	    clearInterval(rotate)
	    var bullet = $(this).index();
	    $('#header_banner .ativo').removeClass('ativo')
	    $('#header_banner .banner:eq(' + bullet + ')').addClass('ativo');
	    $('#header_banner .banner:visible').fadeOut(400);
	    $('#header_banner .ativo').delay(405).fadeIn(400);
	    var bg = $('#header_banner .ativo .bg').attr('src')
	    $('#banner').css('background-image', 'url(' + bg + ')')
	    var atual = $('#header_banner .ativo').index();
	    $('#bullets ul li').removeClass('bullet_ativo');
	    $('#bullets ul li:eq(' + atual + ')').addClass('bullet_ativo');
	    rotate = setInterval(proximo_banner, speed);
	});*/

    //Banner interna
	$('.banner_sobre img').fadeOut(0)
	$('.banner_sobre img:first').addClass('primeiro');
	$('.banner_sobre img:last').addClass('ultimo');
	$('.banner_sobre img:first').addClass('ativo').fadeIn(0);
    //INICIA MUDANÇA AUTOMATICA
	var speed = 6000,
        rotate2 = setInterval(proximo_banner2, speed);

	function proximo_banner2() {
	    clearInterval(rotate2)
	    if ($('.banner_sobre .ativo').hasClass('ultimo')) {
	        $('.banner_sobre .ativo').removeClass('ativo')
	        $('.banner_sobre .primeiro').addClass('ativo')
	        $('.banner_sobre img:visible').fadeOut(1600);
	        $('.banner_sobre .ativo').fadeIn(2000);
	    } else {
	        $('.banner_sobre .ativo').removeClass('ativo').next('img').addClass('ativo');
	        $('.banner_sobre img:visible').fadeOut(1600);
	        $('.banner_sobre .ativo').fadeIn(2000);
	    }
	    //var bg = $('#header_banner .ativo .bg').attr('src')	    
	    //$('#banner').css('background-image', 'url(' + bg + ')')
	    //var atual = $('#header_banner .ativo').index();
	    //$('#bullets ul li').removeClass('bullet_ativo');
	    // $('#bullets ul li:eq(' + atual + ')').addClass('bullet_ativo');
	    rotate2 = setInterval(proximo_banner2, speed);
	}


    //NOTIFICAÇÕES
	$('.notificacao li:first').addClass('primeiro');
	$('.notificacao li:last').addClass('ultimo');
	$('.notificacao li:first').addClass('ativo').fadeIn(0);

	$('.notificacoes_logado .right_logado').click(function () {
	    proximo_not();
	})
	$('.notificacoes_logado .left_logado').click(function () {
	    anterior_not();
	})

    //CaRROUSSEL
    //CARROUSSEL MOBILE
	$('.left_video').click(function () {
	        anterior_item(this);
	    
	});
	$('.right_video').click(function () {
	        proximo_item(this);
	    
	});

    //CARROUSSEL RELATO
	$('.left_relato').click(function () {
	    anterior_item2(this);

	});
	$('.right_relato').click(function () {
	    proximo_item2(this);
	});

	if ($('.relatos_ul').size() > 0) {
	    $('.cont_relato b').text($('.relatos_ul li').size())
	}

    //MODAL COMENTARIO TAREFA
	$('.abre_comentario').click(function (e) {
	    e.preventDefault();
	    $("#mask").fadeIn(200);
	    $('.modal_comentario').fadeIn(400);
	});

	$('.fechar_comentario').click(function () {
	    $('.modal_comentario').fadeOut(200);
	    $('#mask').fadeOut(400);
	})

    //MODAL COMENTARIO RELATO TAREFA
	/*$('.abre_comentario2').click(function (e) {
	    e.preventDefault();
	    $("#mask").fadeIn(200);
	    $('.modal_comentario2').fadeIn(400);
//	    $('.modal_relatos').fadeOut(0);
	});*/

	$('.fechar_comentario2').click(function () {
	    $('.modal_comentario2').fadeOut(200);
	    $('#mask').fadeOut(400);
	})

    //modal lista realos
	/*$('.abre_relatos').click(function (e) {
	    e.preventDefault();
	    $("#mask").fadeIn(200);
	    $('.modal_realtos').fadeIn(400);
	})*/

	$('.fechar_relato').click(function () {
	    $('.modal_relatos').fadeOut(200);
	    $('#mask').fadeOut(400);
	})

    //GALERIA HOME(FOTOS)
	$('.fotos_home li:first').addClass('primeiro');
	$('.fotos_home li:last').addClass('ultimo');
	$('.fotos_home li:first').addClass('ativo');
	$('.fotos_home li').click(function (e) {
	    e.preventDefault();
	    $('.fotos_home li').removeClass('ativo')
	    $(this).addClass('ativo');
	    var atual = $('.fotos_home .ativo').index() + 1;
	    var total = $('.fotos_home li').length;
	    var img = $(this).children('a').attr('href')
	    var titu = $(this).children('p').text()
	    $('#fotos .controles .quantos .atual').text(atual);
	    $('#fotos .controles .quantos .total').text(total);
	    $('#fotos p').text(titu);
	    if (atual == 1) {
	        $('#fotos .controles .left_galeria').addClass('disabled');
	    } else {
	        $('#fotos .controles .left_galeria').removeClass('disabled');
	    }
	    if (atual == total) {
	        $('#fotos .controles .right_galeria').addClass('disabled');
	    } else {
	        $('#fotos .controles .right_galeria').removeClass('disabled');
	    }
	    $('#fotos .img_galeria').attr('src', img);
	    $('#mask').fadeIn(200);
	    $('#mask #fotos').fadeIn(400);
	});
	$("#fotos .right_galeria").click(function () {
	    proximo_foto()
	});
	$("#fotos .left_galeria").click(function () {
	    anterior_foto()
	});
	$('.fechar_foto').click(function () {
	    $('#mask').fadeOut(400);
	    $('#mask #fotos').fadeOut(200);
        $('#videos iframe').attr('src','')
	});

    //GALERIA DE FOTOS INTERNA
	$('.galeria_img_interna li:first').addClass('primeiro');
	$('.galeria_img_interna li:last').addClass('ultimo');
	$('.galeria_img_interna li:first').addClass('ativo');
	$('.galeria_img_interna li').click(function (e) {
	    e.preventDefault();
	    $('.galeria_img_interna li').removeClass('ativo')
	    $(this).addClass('ativo');
	    var atual = $('.galeria_img_interna .ativo').index() + 1;
	    var total = $('.galeria_img_interna li').length;
	    var img = $(this).children('a').attr('href')
	    var titu = $(this).children('p').text()
	    $('#fotos .controles .quantos .atual').text(atual);
	    $('#fotos .controles .quantos .total').text(total);
	    $('#fotos p').text(titu);
	    if (atual == 1) {
	        $('#fotos .controles .left_galeria2').addClass('disabled');
	    } else {
	        $('#fotos .controles .left_galeria2').removeClass('disabled');
	    }
	    if (atual == total) {
	        $('#fotos .controles .right_galeria2').addClass('disabled');
	    } else {
	        $('#fotos .controles .right_galeria2').removeClass('disabled');
	    }
	    $('#fotos .img_galeria').attr('src', img);
	    $('#mask').fadeIn(200);
	    $('#mask #fotos').fadeIn(400);
	});
	$("#fotos .right_galeria2").click(function () {
	    proximo_foto2()
	});
	$("#fotos .left_galeria2").click(function () {
	    anterior_foto2()
	});
	$('.fechar_foto').click(function () {
	    $('#mask').fadeOut(400);
	    $('#mask #fotos').fadeOut(200);
	    $('#videos iframe').attr('src', '')
	    $('#mask #videos').fadeOut(200);
	});

    /************************************/

	$('.ops_galeria b:first').click(function () {
	    $('.ops_galeria b').removeClass('ativo');
	    $(this).addClass('ativo');
	    $('.videos_home').fadeOut(0);
	    $('.fotos_home').fadeIn(200)
	})
	$('.ops_galeria b:last').click(function () {
	    $('.ops_galeria b').removeClass('ativo');
	    $(this).addClass('ativo');
	    $('.fotos_home').fadeOut(0);
	    $('.videos_home').fadeIn(200)
	});
    //GALERIA DA HOME (VIDEO)
	$('.videos_home li:first').addClass('primeiro');
	$('.videos_home li:last').addClass('ultimo');
	$('.videos_home li:first').addClass('ativo');
	$('.videos_home li').click(function (e) {
	    e.preventDefault();
	    $('.videos_home li').removeClass('ativo')
	    $(this).addClass('ativo');
	    var atual = $('.videos_home .ativo').index() + 1;
	    var total = $('.videos_home li').length;
	    var video = $(this).children('a').attr('href')
	    var titu = $(this).children('p').text()
        var descricao =$(this).children('span').text()
	    $('#videos .controles .quantos .atual').text(atual);
	    $('#videos .controles .quantos .total').text(total);
	    $('#videos p').text(titu);
	    $('#videos span').text(descricao);
	    if (atual == 1) {
	        $('#videos .controles .left_galeria').addClass('disabled');
	    } else {
	        $('#videos .controles .left_galeria').removeClass('disabled');
	    }
	    if (atual == total) {
	        $('#videos .controles .right_galeria').addClass('disabled');
	    } else {
	        $('#videos .controles .right_galeria').removeClass('disabled');
	    }
	    $('#videos iframe').attr('src', '//www.youtube.com/embed/' + video + '?autoplay=1');
	    $('#mask').fadeIn(200);
	    $('#mask #videos').fadeIn(400);
	});
	$("#videos .right_galeria").click(function () {
	    proximo_video()
	});
	$("#videos .left_galeria").click(function () {
	    anterior_video()
	});

    //GALERIA DA HOME (interna)
	$('.galeria_video_interna li:first').addClass('primeiro');
	$('.galeria_video_interna li:last').addClass('ultimo');
	$('.galeria_video_interna li:first').addClass('ativo');
	$('.galeria_video_interna li').click(function (e) {
	    e.preventDefault();
	    $('.videos_home li').removeClass('ativo')
	    $(this).addClass('ativo');
	    var atual = $('.galeria_video_interna .ativo').index() + 1;
	    var total = $('.galeria_video_interna li').length;
	    var video = $(this).children('a').attr('href')
	    var titu = $(this).children('p').text()
	    $('#videos .controles .quantos .atual').text(atual);
	    $('#videos .controles .quantos .total').text(total);
	    $('#videos p').text(titu);
	    if (atual == 1) {
	        $('#videos .controles .left_galeria2').addClass('disabled');
	    } else {
	        $('#videos .controles .left_galeria2').removeClass('disabled');
	    }
	    if (atual == total) {
	        $('#videos .controles .right_galeria2').addClass('disabled');
	    } else {
	        $('#videos .controles .right_galeria2').removeClass('disabled');
	    }
	    $('#videos iframe').attr('src', '//www.youtube.com/embed/' + video + '?autoplay=1');
	    $('#mask').fadeIn(200);
	    $('#mask #videos').fadeIn(400);
	});
	$("#videos .right_galeria2").click(function () {
	    proximo_video2()
	});
	$("#videos .left_galeria2").click(function () {
	    anterior_video2()
	});
	$('.fechar_foto').click(function () {
	    $('#mask').fadeOut(400);
	    $('#mask #fotos').fadeOut(200);
	    $('#mask #videos').fadeOut(200);
	});

//VALIDAÇÃO DOS FORMS
    //contato
	$('#contato').submit(function () {
	    $('#contato .input').each(function () {
	        if ($(this).val() == "") {
	            $(this).addClass('error')
	        } else {
	            if ($(this).hasClass('email')) {
	                email = $(this).val()
	                var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
	                if (filtro.test(email)) {
	                    $(this).removeClass('error')
	                } else {
	                    $(this).addClass('error')
	                }
	            }
	        }
	    });
	    if ($('#contato .input').hasClass('error')) {
	        return false
	    }
	});

	$('#up_foto').submit(function () {
	    $('#up_foto .input').each(function () {
	        if ($(this).val() == "") {
	            $(this).addClass('error')
	        } else {
	            if ($(this).hasClass('email')) {
	                email = $(this).val()
	                var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
	                if (filtro.test(email)) {
	                    $(this).removeClass('error')
	                } else {
	                    $(this).addClass('error')
	                }
	            }
	        }
	    });
	    if ($('#up_foto .input').hasClass('error')) {
	        return false
	    }
	});

    //EDITAR BIOGRAFIA
	$('#biografia').submit(function () {
	    $('#biografia .input').each(function () {
	        if ($(this).val() == "") {
	            $(this).addClass('error')
	        } else {
	            if ($(this).hasClass('email')) {
	                email = $(this).val()
	                var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
	                if (filtro.test(email)) {
	                    $(this).removeClass('error')
	                } else {
	                    $(this).addClass('error')
	                }
	            }
	        }
	    });
	    if ($('#biografia .input').hasClass('error')) {
	        return false
	    }
	});

	$('#cadastro_form').submit(function () {
		$('#cadastro_form .input').each(function () {
		    if ($(this).val() == "") {
		        $(this).addClass('error')
		    } else {
		        if ($(this).hasClass('email')) {
		            email = $(this).val()
		            var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
		            if (filtro.test(email)) {
		                $(this).removeClass('error')
		            } else {
		                $(this).addClass('error')
		            }
		        }
		    }
		});
		if ($('#cadastro_form .input').hasClass('error')) {
		    return false
		}		
	});

	$('.cadastro_home .btn').click(function () {
	    $('.cadastro_home .input').each(function () {
	        if ($(this).val() == "") {
	            $(this).addClass('error')
	        } else {
	            if ($(this).hasClass('email')) {
	                email = $(this).val()
	                var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
	                if (filtro.test(email)) {
	                    $(this).removeClass('error')
	                } else {
	                    $(this).addClass('error')
	                }
	            }
	        }
	    });
	    if ($('.cadastro_home .right .checkbox:checked').size() < 1) {
	        $('.cadastro_home .right .checkbox').addClass('error');
	    } else {
	        $('.cadastro_home .right .checkbox').removeClass('error');
	    }
	    if ($('.cadastro_home #termo:checked').size() < 1) {
	        $('.cadastro_home #termo').addClass('error');
	    } else {
	        $('.cadastro_home #termo').removeClass('error');
	    }
	    if ($('.cadastro_home .input').hasClass('error')) {
	        return false
	    } else {
	        validarSenha();
	    }
	});

	$('.obg').focusout(function () {
	    if ($(this).val() == "" || $(this).val() == "__/__/____") {
	        $(this).addClass('error')
	    } else {
	        if ($(this).hasClass('email')) {
	            email = $(this).val()
	            var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
	            if (filtro.test(email)) {
	                $(this).removeClass('error')
	            } else {
	                $(this).addClass('error')
	            }
	        } else {
	            $(this).removeClass('error')
	        }
	    }
	});
    //LOGIN
	$('.form_login').submit(function () {
	    $('.form_login .input').each(function () {
	        if ($(this).val() == "") {
	            $(this).addClass('error')
	        } else {
	            if ($(this).hasClass('email')) {
	                email = $(this).val()
	                var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
	                if (filtro.test(email)) {
	                    $(this).removeClass('error')
	                } else {
	                    $(this).addClass('error')
	                }
	            }
	        }
	    });
	    if ($('.form_login .input').hasClass('error')) {
	        return false
	    }
	});

    //FORM SENHA
    //LOGIN
	$('.form_senha').submit(function () {
	    $('.form_senha .input').each(function () {
	        if ($(this).val() == "") {
	            $(this).addClass('error')
	        } else {
	            if ($(this).hasClass('email')) {
	                email = $(this).val()
	                var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
	                if (filtro.test(email)) {
	                    $(this).removeClass('error')
	                } else {
	                    $(this).addClass('error')
	                }
	            }
	        }
	    });
	    if ($('.form_senha .input').hasClass('error')) {
	        return false
	    }
	});

	$('#setup').submit(function () {
	    $('#setup .obg').each(function () {
	        if ($(this).val() == "") {
	            $(this).addClass('error')
	        } else {
	            if ($(this).hasClass('email')) {
	                email = $(this).val()
	                var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
	                if (filtro.test(email)) {
	                    $(this).removeClass('error')
	                } else {
	                    $(this).addClass('error')
	                }
	            }
	        }
	    });
	    if ($('#setup .obg').hasClass('error')) {
	        return false
	    }
	});

	$('.input').focusout(function () {
	    if ($(this).hasClass('senha2')) {
            return false
	    } else { 

	        if ($(this).val() == "" || $(this).val() == "__/__/____") {
	            $(this).addClass('error')
	        } else {
	            if ($(this).hasClass('email')) {
	                email = $(this).val()
	                var filtro = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
	                if (filtro.test(email)) {
	                    $(this).removeClass('error')
	                } else {
	                    $(this).addClass('error')
	                }
	            } else {
	                $(this).removeClass('error')
	            }
	        }
	    }
	});

    //FORM HOME MODAL
	$('.cadastro_home input[type=reset]').click(function () {
	    $('#mask').fadeOut(400);
	    $('#modal').fadeOut(300)
	})

	//celular mask 
	$(function($){
		$('.cel').mask("(99) 9999-9999?9");
	});
    //DATA
	$(function ($) {
	    $('.data').mask("99/99/9999");
	});
	//( digitos 
	$('.cel').unbind('focusout').focusout(function(){
        var valor = $(this).val().replace('_','');
        var len = valor.length;
        if (len >= 14){
            $(this).unmask();
            if( len == 14) $(this).mask("(99) 9999-9999?9");
            else  $(this).mask("(99) 99999-999?9");
        }
    }).trigger('focusout');
	
	$(".sonumero").keypress(function (e) {
        //if the letter is not digit then display error and don't type anything
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            //display error message
            return false;
        }
	});

    //ESQUECI MINHA SENHA
	$('.esqueci_senha').click(function () {
	    $('.form_login').fadeOut(0);
	    $('.form_senha').fadeIn(200);
	})
	$('.esqueci_voltar').click(function () {
	    $('.form_senha').fadeOut(0);
	    $('.form_login').fadeIn(200);
	})
    /*FIM DO DOCUMENT READY*/
});

function twitter() {
    $('#twitter-widget-0').removeAttr('style');
}
//NOTICIAS LOGADO HOME
function proximo_not() {
    if ($('.notificacao .ativo').hasClass('ultimo')) {
        $('.notificacao li').removeClass('ativo')
        $('.notificacao .primeiro').addClass('ativo')
        $('.notificacao li:visible').fadeOut(0);
        $('.notificacao .ativo').delay(00).fadeIn(100);
    } else {
        $('.notificacao .ativo').removeClass('ativo').next('li').addClass('ativo');
        $('.notificacao li:visible').fadeOut(0);
        $('.notificacao .ativo').delay(00).fadeIn(100);
    }
}

function anterior_not() {
    if ($('.notificacao .ativo').hasClass('primeiro')) {
        $('.notificacao .ativo').removeClass('ativo')
        $('.notificacao .ultimo').addClass('ativo')
        $('.notificacao li:visible').fadeOut(0);
        $('.notificacao .ativo').delay(00).fadeIn(100);
    } else {
        $('.notificacao .ativo').removeClass('ativo').prev('li').addClass('ativo');
        $('.notificacao li:visible').fadeOut(0);
        $('.notificacao .ativo').delay(00).fadeIn(100);
    }
}
//GALERIA DE FOTOS HOME
function proximo_foto() {
    if ($('.fotos_home .ativo').hasClass('ultimo')) {

    } else {
        $('.fotos_home .ativo').removeClass('ativo').next('li').addClass('ativo');
        var atual = $('.fotos_home .ativo').index() + 1;
        var total = $('.fotos_home li').length;
        var img = $('.fotos_home .ativo').children('a').attr('href');
        var titu = $('.fotos_home .ativo').children('p').text()
        $('#fotos .controles .quantos .atual').text(atual);
        $('#fotos .controles .quantos .total').text(total);
        if (atual == 1) {
            $('#fotos .controles .left_galeria').addClass('disabled');
        } else {
            $('#fotos .controles .left_galeria').removeClass('disabled');
        }
        if (atual == total) {
            $('#fotos .controles .right_galeria').addClass('disabled');
        } else {
            $('#fotos .controles .right_galeria').removeClass('disabled');
        }
        $('#fotos .img_galeria').attr('src', '' + img);
        $('#fotos p').text(titu);
    }
}

function anterior_foto() {
    if ($('.fotos_home .ativo').hasClass('primeiro')) {

    } else {
        $('.fotos_home .ativo').removeClass('ativo').prev('li').addClass('ativo');
        var atual = $('.fotos_home .ativo').index() + 1;
        var total = $('.fotos_home li').length;
        var img = $('.fotos_home .ativo').children('a').attr('href');
        var titu = $('.fotos_home .ativo').children('p').text()
        $('#fotos .controles .quantos .atual').text(atual);
        $('#fotos .controles .quantos .total').text(total);
        if (atual == 1) {
            $('#fotos .controles .left_galeria').addClass('disabled');
        } else {
            $('#fotos .controles .left_galeria').removeClass('disabled');
        }
        if (atual == total) {
            $('#fotos .controles .right_galeria').addClass('disabled');
        } else {
            $('#fotos .controles .right_galeria').removeClass('disabled');
        }
        $('#fotos .img_galeria').attr('src', '' + img);
        $('#fotos p').text(titu);
    }
}

//GALLERIA VIDEOS HOME
function proximo_video() {
    if ($('.videos_home .ativo').hasClass('ultimo')) {

    } else {
        $('.videos_home .ativo').removeClass('ativo').next('li').addClass('ativo');
        var atual = $('.videos_home .ativo').index() + 1;
        var total = $('.videos_home li').length;
        var video = $('.videos_home .ativo').children('a').attr('href')
        var titu = $('.videos_home .ativo').children('p').text()
        $('#videos .controles .quantos .atual').text(atual);
        $('#videos .controles .quantos .total').text(total);
        $('#videos p').text(titu);
        if (atual == 1) {
            $('#videos .controles .left_galeria').addClass('disabled');
        } else {
            $('#videos .controles .left_galeria').removeClass('disabled');
        }
        if (atual == total) {
            $('#videos .controles .right_galeria').addClass('disabled');
        } else {
            $('#videos .controles .right_galeria').removeClass('disabled');
        }
        $('#videos iframe').attr('src', '//www.youtube.com/embed/' + video + '?autoplay=1');
        $('#videos p').text(titu);
    }
}

function anterior_video() {
    if ($('.videos_home .ativo').hasClass('primeiro')) {

    } else {
        $('.videos_home .ativo').removeClass('ativo').prev('li').addClass('ativo');
        var atual = $('.videos_home .ativo').index() + 1;
        var total = $('.videos_home li').length;
        var video = $('.videos_home .ativo').children('a').attr('href')
        var titu = $('.videos_home .ativo').children('p').text()
        $('#videos .controles .quantos .atual').text(atual);
        $('#videos .controles .quantos .total').text(total);
        $('#videos p').text(titu);
        if (atual == 1) {
            $('#videos .controles .left_galeria').addClass('disabled');
        } else {
            $('#videos .controles .left_galeria').removeClass('disabled');
        }
        if (atual == total) {
            $('#videos .controles .right_galeria').addClass('disabled');
        } else {
            $('#videos .controles .right_galeria').removeClass('disabled');
        }
        $('#videos iframe').attr('src', '//www.youtube.com/embed/' + video + '?autoplay=1');
        $('#videos p').text(titu);
    }
}

function proximo_video2() {
    if ($('.galeria_video_interna .ativo').hasClass('ultimo')) {

    } else {
        $('.galeria_video_interna .ativo').removeClass('ativo').next('li').addClass('ativo');
        var atual = $('.galeria_video_interna .ativo').index() + 1;
        var total = $('.galeria_video_interna li').length;
        var video = $('.galeria_video_interna .ativo').children('a').attr('href')
        var titu = $('.galeria_video_interna .ativo').children('p').text()
        $('#videos .controles .quantos .atual').text(atual);
        $('#videos .controles .quantos .total').text(total);
        $('#videos p').text(titu);
        if (atual == 1) {
            $('#videos .controles .left_galeria2').addClass('disabled');
        } else {
            $('#videos .controles .left_galeria2').removeClass('disabled');
        }
        if (atual == total) {
            $('#videos .controles .right_galeria2').addClass('disabled');
        } else {
            $('#videos .controles .right_galeria2').removeClass('disabled');
        }
        $('#videos iframe').attr('src', '//www.youtube.com/embed/' + video + '?autoplay=1');
        $('#videos p').text(titu);
    }
}

function anterior_video2() {
    if ($('.galeria_video_interna .ativo').hasClass('primeiro')) {

    } else {
        $('.galeria_video_interna .ativo').removeClass('ativo').prev('li').addClass('ativo');
        var atual = $('.galeria_video_interna .ativo').index() + 1;
        var total = $('.galeria_video_interna li').length;
        var video = $('.galeria_video_interna .ativo').children('a').attr('href')
        var titu = $('.galeria_video_interna .ativo').children('p').text()
        $('#videos .controles .quantos .atual').text(atual);
        $('#videos .controles .quantos .total').text(total);
        $('#videos p').text(titu);
        if (atual == 1) {
            $('#videos .controles .left_galeria2').addClass('disabled');
        } else {
            $('#videos .controles .left_galeria2').removeClass('disabled');
        }
        if (atual == total) {
            $('#videos .controles .right_galeria2').addClass('disabled');
        } else {
            $('#videos .controles .right_galeria2').removeClass('disabled');
        }
        $('#videos iframe').attr('src', '//www.youtube.com/embed/' + video + '?autoplay=1');
        $('#videos p').text(titu);
    }
}

//Forçar o download do arquivo
function download(arquivo) {
    location.href = "ajax/download.aspx?arquivo=" + arquivo + "";
}

//GALERIA DE FOTOS
function proximo_foto2() {
    if ($('.galeria_img_interna .ativo').hasClass('ultimo')) {
        
    } else {
        $('.galeria_img_interna .ativo').removeClass('ativo').next('li').addClass('ativo');
        var atual = $('.galeria_img_interna .ativo').index() + 1;
        var total = $('.galeria_img_interna li').length;
        var img = $('.galeria_img_interna .ativo').children('a').attr('href');
        var titu = $('.galeria_img_interna .ativo').children('p').text()
        $('#fotos .controles .quantos .atual').text(atual);
        $('#fotos .controles .quantos .total').text(total);
        if (atual == 1) {
            $('#fotos .controles .left_galeria2').addClass('disabled');
        } else {
            $('#fotos .controles .left_galeria2').removeClass('disabled');
        }
        if (atual == total) {
            $('#fotos .controles .right_galeria2').addClass('disabled');
        } else {
            $('#fotos .controles .right_galeria2').removeClass('disabled');
        }
        $('#fotos .img_galeria').attr('src', '' + img);
        $('#fotos p').text(titu);
    }
}

function anterior_foto2() {
    if ($('.galeria_img_interna .ativo').hasClass('primeiro')) {

    } else {
        $('.galeria_img_interna .ativo').removeClass('ativo').prev('li').addClass('ativo');
        var atual = $('.galeria_img_interna .ativo').index() + 1;
        var total = $('.galeria_img_interna li').length;
        var img = $('.galeria_img_interna .ativo').children('a').attr('href');
        var titu = $('.galeria_img_interna .ativo').children('p').text()
        $('#fotos .controles .quantos .atual').text(atual);
        $('#fotos .controles .quantos .total').text(total);
        if (atual == 1) {
            $('#fotos .controles .left_galeria2').addClass('disabled');
        } else {
            $('#fotos .controles .left_galeria2').removeClass('disabled');
        }
        if (atual == total) {
            $('#fotos .controles .right_galeria2').addClass('disabled');
        } else {
            $('#fotos .controles .right_galeria2').removeClass('disabled');
        }
        $('#fotos .img_galeria').attr('src', '' + img);
        $('#fotos p').text(titu);
    }
}
//CARROUSSEL MOBILE
function caroussel() {
    $('.carrousel').each(function (e) {
        var lis = $(this).children('li').size();
        var largura = 100 / lis;
        if ($(this).hasClass('relatos_ul')) {
            $(this).children('li').outerWidth('490px')
        } else {
            $(this).children('li').outerWidth('196px')
        }
        $(this).width(lis + '00%');
        $(this).attr('rel', 0);
        $(this).children('li:first').addClass('primeiro');
        $(this).children('li:last').addClass('ultimo');
        $(this).children('li:first').addClass('ativo');
    });
}

function proximo_item(id) {
    id.classList.add("esse");
    $('.esse').removeClass('esse').parent('div').children('ul').addClass('esse');
    var atual = $('.esse .ativo');
    var margin = $('.esse li').outerWidth();
    if ($('.esse .ativo').hasClass('primeiro')) {
        $('.esse').parent('div').children('.left_video').fadeIn(200)
    }
    if ($('.esse .ativo').hasClass('ultimo')) {
        //alert('Por favor Para melhor funcionamento do site não altere elementos manualmente')
        return false
    } else {
        if (atual.next('li').hasClass('ultimo')) {
            $('.esse').parent('div').children('.right_video').fadeOut(200)
        }
        //CASO AS SETAS ESTEJAM NO MESMO NIVEL (DENTRO DA UL) O -1 CONPENSA ELES NO INDEX, CASO CONTRARIO USAR +1 (obs: setas no ul nao valida na w3c)
        var conta = atual.index() + 1;
        total = conta * margin;
        $('.esse').animate({ marginLeft: -220*conta }, 300);
        $('.esse .ativo').removeClass('ativo').next('li').addClass('ativo');
        if ($('.esse .ativo').hasClass('ultimo')) {
            $('.esse').parent('div').children('.right_video').fadeOut(200)
        }
        $('.esse').removeClass('esse')
    }
}

function anterior_item(id) {
    id.classList.add("esse");
    $('.esse').removeClass('esse').parent('div').children('ul').addClass('esse');
    //$('.esse').removeClass('esse').next('ul').addClass('esse');
    var atual = $('.esse .ativo');
    var margin = $('.esse li').outerWidth();
    if ($('.esse .ativo').hasClass('ultimo')) {
        $('.esse').parent('div').children('.right_video').fadeIn(200)
    }
    if ($('.esse .ativo').hasClass('primeiro')) {
        //alert('Por favor Para melhor funcionamento do site não altere elementos manualmente')
        return false
    } else {
        $('.esse .ativo').removeClass('ativo').prev('li').addClass('ativo');
        var atual2 = $('.esse .ativo');
        //CASO AS SETAS ESTEJAM NO MESMO NIVEL (DENTRO DA UL) O -2 CONPENSA ELES NO INDEX, CASO CONTRARIO USAR 0(obs: setas no ul nao valida na w3c)
        var conta = atual2.index();
        total = conta * margin;
        $('.esse').animate({ marginLeft: -220 * conta }, 300);
        if ($('.esse .ativo').hasClass('primeiro')) {
            $('.esse').parent('div').children('.left_video').fadeOut(200)
        }
        $('.esse').removeClass('esse')
    }
}

function proximo_item2(id) {
    //id.classList.add("esse");
    $('.carrousel').addClass('esse');
    $('.esse').removeClass('esse').parent('div').children('ul').addClass('esse');
    var atual = $('.esse .ativo');
    var margin = $('.esse li').outerWidth();
    if ($('.esse .ativo').hasClass('primeiro')) {
        $('.esse').parent('div').children('.left_relato').fadeIn(200)
    }
    if ($('.esse .ativo').hasClass('ultimo')) {
        //alert('Por favor Para melhor funcionamento do site não altere elementos manualmente')
        return false
    } else {
        if (atual.next('li').hasClass('ultimo')) {
            $('.esse').parent('div').children('.right_relato').fadeOut(200)
        }
        //CASO AS SETAS ESTEJAM NO MESMO NIVEL (DENTRO DA UL) O -1 CONPENSA ELES NO INDEX, CASO CONTRARIO USAR +1 (obs: setas no ul nao valida na w3c)
        var conta = atual.index() + 1;
        total = conta * margin;
        $('.esse').animate({ marginLeft: total*-1 }, 300);
        $('.esse .ativo').removeClass('ativo').next('li').addClass('ativo');
        if ($('.esse .ativo').hasClass('ultimo')) {
            $('.esse').parent('div').children('.right_relato').fadeOut(200)
        }
        $('.esse').removeClass('esse')
        lis=$('.relatos_ul li').size()
        $('.cont_relato strong').text(conta+1)
        $('.cont_relato b').text(lis)
    }
}

function anterior_item2(id) {
    //id.classList.add("esse");
    $('.carrousel').addClass('esse');
    $('.esse').removeClass('esse').parent('div').children('ul').addClass('esse');
    //$('.esse').removeClass('esse').next('ul').addClass('esse');
    var atual = $('.esse .ativo');
    var margin = $('.esse li').outerWidth();
    if ($('.esse .ativo').hasClass('ultimo')) {
        $('.esse').parent('div').children('.right_relato').fadeIn(200)
    }
    if ($('.esse .ativo').hasClass('primeiro')) {
        //alert('Por favor Para melhor funcionamento do site não altere elementos manualmente')
        return false
    } else {
        $('.esse .ativo').removeClass('ativo').prev('li').addClass('ativo');
        var atual2 = $('.esse .ativo');
        //CASO AS SETAS ESTEJAM NO MESMO NIVEL (DENTRO DA UL) O -2 CONPENSA ELES NO INDEX, CASO CONTRARIO USAR 0(obs: setas no ul nao valida na w3c)
        var conta = atual2.index();
        total = conta * margin;
        $('.esse').animate({ marginLeft: total*-1 }, 300);
        if ($('.esse .ativo').hasClass('primeiro')) {
            $('.esse').parent('div').children('.left_relato').fadeOut(200)
        }
        $('.esse').removeClass('esse')
        lis = $('.relatos_ul li').size()
        $('.cont_relato strong').text(conta+1)
        $('.cont_relato b').text(lis)
    }
}
