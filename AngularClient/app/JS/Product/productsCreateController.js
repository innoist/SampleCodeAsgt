var app = angular.module('productApp');
app.controller('productsCreateController', [
    '$scope', 'productsService', '$location', function ($scope, productsService, $location) {

        var vm = this;
        vm.SaveProduct = SaveProduct;
        vm.Product = {};
        function SaveProduct() {
            productsService.saveProduct(vm.Product, Saved)

        }

        function Saved(data, responseText, response) {
            
        }
        

        
        

    }
]);