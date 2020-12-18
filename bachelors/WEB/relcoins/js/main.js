$( document ).ready(function() {

    $('[data-popup-open]').click(function () {
        $('.popup').fadeIn(300);
        $('.popup .flex-container').animate({ bottom: $(window).height() / 2 - 275 + "px" }, 300);
    });
    $('[data-popup-close]').click(function () {
        history.pushState('', document.title, window.location.pathname);
        $('.popup').fadeOut(300);
        $('.popup .flex-container').animate({ bottom: "0%" }, 300);
    });

    $('#seeAll').on('click', function (event) {
        event.preventDefault();
        $('.slider').slick('unslick');
        $('.slider').css('align-items', 'flex-start');
        $('.slider').css('flex-wrap', 'wrap');
        $('.slide').css('width', 'calc(33% - 60px)');
        $(this).hide();
        //        $('#seeSlider').show();
    });
//    $('#seeSlider').on('click', function(event) {
//        event.preventDefault();
//        $('.slider').slick();
//        $('.slider').css('align-items', 'center');
//        $('.slider').css('flex-wrap', 'unset');
//        $('.slide').css('width', 'unset');
//        $(this).hide();
//        $('#seeAll').show();
//    });
    
    if ($(window).width() <= '768') {
        $('.slider').slick({
            autoplay: true,
            autoplaySpeed: 3000,
            slidesToShow: 1,
            slidesToScroll: 1,
            arrows: true,
            prevArrow: '<img src="img/icons/arrow.png" class="arrow arrow-prev" alt="PREV">',
            nextArrow: '<img src="img/icons/arrow.png" class="arrow" alt="NEXT">',
            dots: false
        });
      }
      if ($(window).width() <= '1023') {
        $('.slider').slick({
            autoplay: true,
            autoplaySpeed: 3000,
            slidesToShow: 2,
            slidesToScroll: 1,
            arrows: true,
            prevArrow: '<img src="img/icons/arrow.png" class="arrow arrow-prev" alt="PREV">',
            nextArrow: '<img src="img/icons/arrow.png" class="arrow" alt="NEXT">',
            dots: false
        });
      }
      if ($(window).width() >= '1024') {
        $('.slider').slick({
            autoplay: true,
            autoplaySpeed: 3000,
            slidesToShow: 3,
            slidesToScroll: 1,
            arrows: true,
            prevArrow: '<img src="img/icons/arrow.png" class="arrow arrow-prev" alt="PREV">',
            nextArrow: '<img src="img/icons/arrow.png" class="arrow" alt="NEXT">',
            dots: false
        });
      }
    

    function come(elem) {
        var docViewTop = $(window).scrollTop(),
        docViewBottom = docViewTop + $(window).height(),
        elemTop = $(elem).offset().top,
        elemBottom = elemTop + $(elem).height() - $(elem).height() / 2;

        return ((elemBottom <= docViewBottom) && (elemTop >= docViewTop));
    }

    $(window).scroll(function() {
        if(come('section.where')) {
            $('section.where .flex-container').css('animation-name', 'sunUp2');
            $('section.where .flex-container').addClass('sun-img');
        }
        if(come('footer')) {
            $('footer').css('animation-name', 'sunUp3');
            $('footer').addClass('sun-img');
        }
    });

});