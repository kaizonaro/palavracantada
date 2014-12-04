// JavaScript Document

$(document).ready(function () {
//TOPO
    $(document).scroll(function(){
        scroll_topo();
    })		  
//GERAL
	//exibe a pg depois que carregada
	$('body').hide();	
		
	window.onload=function(){		
		$('body').fadeIn();
	}
	
//MENU
	
	//ancora
	$(function() {
	  $('a[href*=#]:not([href=#])').click(function() {
		if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
		  var target = $(this.hash);
		  target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
		  if (target.length) {
			$('html,body').animate({
			  scrollTop: target.offset().top
			}, 1000);
			$('.fechar_menu').click();
			return false;
		  }
		}
	  });
	});
	
	$('div.btn').click(function(){
	var target2 = $('#final');
			$('html,body').animate({
			  scrollTop: target2.offset().top
			}, 1000)
	})	
    //BANNER

    //CONTA OS BANERS E CRIA OS BULLETS
	var total = $('#banner .banner').length;
	for (var i = 0; i < total; i++) {
	    $('#bullets ul').append(' <li><img src="images/bullet.png" /></li>')
	}
	$('#banner .banner').fadeOut(0)
	$('#banner .banner:first').addClass('primeiro');
	$('#banner .banner:last').addClass('ultimo');
	$('#banner .banner:first').addClass('ativo').fadeIn(0);
	$('#bullets ul li:first').addClass('bullet_ativo');
    //INICIA MUDANÇA AUTOMATICA
	var speed = 7000,
        rotate = setInterval(proximo_banner, speed);

	function proximo_banner() {
	    clearInterval(rotate)
	    if ($('#banner .ativo').hasClass('ultimo')) {
	        $('#banner .ativo').removeClass('ativo')
	        $('#banner .primeiro').addClass('ativo')
	        $('#banner .banner:visible').fadeOut(400);
	        $('#banner .ativo').delay(405).fadeIn(500);
	    }else{
	        $('#banner .ativo').removeClass('ativo').next('.banner').addClass('ativo');
	        $('#banner .banner:visible').fadeOut(400);
	        $('#banner .ativo').delay(405).fadeIn(500);
	    }
	    //var bg = $('#banner .ativo .bg').attr('src')	    
	    //$('#banner').css('background-image', 'url(' + bg + ')')
	    //var atual = $('#banner .ativo').index();
	    //$('#bullets ul li').removeClass('bullet_ativo');
	   // $('#bullets ul li:eq(' + atual + ')').addClass('bullet_ativo');
	    rotate = setInterval(proximo_banner, speed);
	}

	/*$('#bullets ul li').click(function () {
	    clearInterval(rotate)
	    var bullet = $(this).index();
	    $('#banner .ativo').removeClass('ativo')
	    $('#banner .banner:eq(' + bullet + ')').addClass('ativo');
	    $('#banner .banner:visible').fadeOut(400);
	    $('#banner .ativo').delay(405).fadeIn(400);
	    var bg = $('#banner .ativo .bg').attr('src')
	    $('#banner').css('background-image', 'url(' + bg + ')')
	    var atual = $('#banner .ativo').index();
	    $('#bullets ul li').removeClass('bullet_ativo');
	    $('#bullets ul li:eq(' + atual + ')').addClass('bullet_ativo');
	    rotate = setInterval(proximo_banner, speed);
	});*/

    //VIDEOS HOME
	$('.box_video .video')
	$('.box_video .video').fadeOut(0)
	$('.box_video .video:first').addClass('primeiro');
	$('.box_video .video:last').addClass('ultimo');
	$('.box_video .video:first').addClass('ativo').fadeIn(0);

	$('.box_video .arrow_right img').click(function () {
	    proximo_video();
	});

	$('.box_video .arrow_left img').click(function () {
	    anterior_video();
	})

	function proximo_video() {
	    if ($('.box_video .ativo').hasClass('ultimo')) {
	        $('.box_video .ativo').removeClass('ativo')
	        $('.box_video .primeiro').addClass('ativo')
	        $('.box_video .video:visible').fadeOut(0);
	        $('.box_video .ativo').delay(02).fadeIn(400);
	    } else {
	        $('.box_video .ativo').removeClass('ativo').next('.video').addClass('ativo');
	        $('.box_video .video:visible').fadeOut(0);
	        $('.box_video .ativo').delay(05).fadeIn(400);
	    }
	}

	function anterior_video() {
	    if ($('.box_video .ativo').hasClass('primeiro')) {
	        $('.box_video .ativo').removeClass('ativo')
	        $('.box_video .ultimo').addClass('ativo')
	        $('.box_video .video:visible').fadeOut(0);
	        $('.box_video .ativo').delay(02).fadeIn(400);
	    } else {
	        $('.box_video .ativo').removeClass('ativo').prev('.video').addClass('ativo');
	        $('.box_video .video:visible').fadeOut(0);
	        $('.box_video .ativo').delay(05).fadeIn(400);
	    }
	}

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

function scroll_topo() {
    var height = $('header').outerHeight();
    var scroll = $(document).scrollTop();
    if (scroll > height) {
        $('header').addClass('header_scroll')
    } else {
        $('header').removeClass('header_scroll')
    }
}