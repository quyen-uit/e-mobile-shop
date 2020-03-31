// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(
    function () {


        //var owl = $("#owl-demo");

        //owl.owlCarousel({
        //    dots: false,
        //    singleItem: true,
        //    items: 1,
        //    URLhashListener: true,
        //    startPosition: 'URLHash'
           
        //});


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
                    nav: true,
                    navText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>', '<i class="fa fa-angle-right" aria-hidden="true"></i>']

                }
            }
        });


        var owl2 = $("#owl-demo2");
        owl2.owlCarousel({
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
                    nav: true,
                    navText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>', '<i class="fa fa-angle-right" aria-hidden="true"></i>']
                   
                }
            }
        });

    });