$(document).ready(function(){
    /* OWL Carousel */ 
    $('.blog-slider').owlCarousel({
        items: 3,
        navigation: true,
        navigationText: ["", ""],
        autoPlay: true
    });

    /* Boton ir arriba */
    $('.up').click(function(){
		$('body, html').animate({
			scrollTop: '0px'
		}, 300);
	});
 
    $(window).scroll(function () {
		if( $(this).scrollTop() > 0 ){
            $('.up').slideDown(300);
		} else {
            $('.up').slideUp(300);
        }
	});
});
