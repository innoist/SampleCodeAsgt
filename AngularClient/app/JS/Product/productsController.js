
    var app = angular.module('ProductModule', ['oc.lazyLoad']);
    app.controller('productsController', [
        '$scope', 'productsService', '$rootScope', '$location', '$ocLazyLoad', function($scope, productsService, $rootScope, $location, $ocLazyLoad) {

            var vm = this;
            vm.products = [];

            $rootScope.loadProduct = $rootScope.loadProduct == undefined ? true : false;

            productsService.loadProduct(productsLoaded);

            function productsLoaded(data, responseText, response) {
                vm.products = data;


                vm.viewProduct = function(productId) {
                    $location.url('CreateProduct/' + productId);
                }
            }


        }
    ])
