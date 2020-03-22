// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(
    function () {
        var owl1 = $("#owl-demo1");
        owl1.owlCarousel({
            responsive: {
                0: {
                    items: 2,
                    dots: false
                },
                600: {
                    items: 4,
                    dots: false
                },
                1000: {
                    items: 5,
                    dots: true,
                }
            }
        });

        var owl = $("#owl-demo");

        owl.owlCarousel({
            dots: false,
            pagination: false,
            items: 5, //10 items above 1000px browser width
            itemsDesktop: [1000, 5], //5 items between 1000px and 901px
            itemsDesktopSmall: [900, 3], // betweem 900px and 601px
            itemsTablet: [600, 2], //2 items between 600 and 0
            itemsMobile: false // itemsMobile disabled - inherit from itemsTablet option
        });
    });