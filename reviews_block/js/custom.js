$(document).ready(function() {
	$(".owl-carousel").owlCarousel({
		loop:true,
		items: 1,
		margin:130,
		autoplay:true,
	    autoplayTimeout:1500,
	    autoplayHoverPause:true,
		stagePadding: 130,
		dots: false,
		nav: true,
		navText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>','<i class="fa fa-angle-right" aria-hidden="true"></i>'],
		navContainer: '#customNav',
		responsive: {
	    // > 0
	    0 : {
	      dots: false,
	      margin:30,
	      stagePadding: 30,
	    },
	    // > 768
	    768 : {
	    	margin:130,
	    	stagePadding: 130,
        dots: true,
	    }
		}
	});
});