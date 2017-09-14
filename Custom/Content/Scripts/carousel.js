$(document).ready(function () {

    $('.car-wrapper').slick({
        dots: true,
        infinite: true,
        speed: 900,
        fade: true,
        cssEase: 'linear'
    });

    var imageCount = $('#imageCount').val();

    for (var i = 0; i < imageCount; i++) {
        var imageDiv = $('#car-image-' + i);
        var imageUrl = $('#image-url-' + i).val();

        imageDiv.css('background-image', 'url("' + imageUrl + '")');
        
    }
});