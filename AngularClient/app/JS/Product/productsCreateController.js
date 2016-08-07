var app = angular.module('productApp');
app.controller('productsCreateController', [
    '$scope', 'productsService', '$location', '$rootScope', function ($scope, productsService, $location, $rootScope) {

        var vm = this;
        vm.SaveProduct = SaveProduct;
        vm.Product = {};
        function SaveProduct() {
            productsService.saveProduct(vm.Product, Saved, Saved);

        }

        function Saved(data) {
            $rootScope.loadProduct = true;
            $location.url('products');
            
        }
        function CancelProduct() {
            $rootScope.loadProduct = false;
            $location.url('products');
        }
        

        
        

    }
]);