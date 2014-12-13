// JavaScript Document

$(document).ready(function () {
  
//GERAL
	//exibe a pg depois que carregada
	//$('body').hide();	
		
	window.onload=function(){		
	    $('body').fadeIn();
	    twitter();
	}
	
    //BANNER

    //CONTA OS BANERS E CRIA OS BULLETS
	var total = $('#header_banner .banner').length;
	for (var i = 0; i < total; i++) {
	    $('#bullets ul').append(' <li><img src="images/bullet.png" /></li>')
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

//VALIDAÇÃO DOS FORMS
	//contato
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

	$('.input').focusout(function () {
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
});

function twitter() {
    $('#twitter-widget-0').removeAttr('style');
}
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
