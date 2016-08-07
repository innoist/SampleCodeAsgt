var app = angular.module('productApp');
app.controller('productsCreateController', [
    '$scope', 'productsService', '$location', '$rootScope', '$routeParams', function($scope, productsService, $location, $rootScope, $routeParams) {

    var vm = this;
    vm.SaveProduct = SaveProduct;
    vm.CancelProduct = CancelProduct;
    vm.Product = {};
    vm.integerval = /^\d*$/;

    function SaveProduct() {
        productsService.saveProduct(vm.Product, Saved, Saved);

    }

    

    function Saved(data) {
        $rootScope.loadProduct = true;
        $location.url('products');

    }

    function ProductDetail(data) {

        if (data) {
            vm.Product.Id = data.Id;
            vm.Product.ProductName = data.ProductName;
            vm.Product.StockCount = data.StockCount;
            vm.Product.Description = data.Description;
        }
    }

    function CancelProduct() {

        $rootScope.loadProduct = false;
        $location.url('products');
    }


    if ($routeParams.id) {
        //Means edit case
        productsService.loadProductById($routeParams.id, ProductDetail);

    }

        
        

    }
]);