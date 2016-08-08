var app = angular.module('ProductAddModule', ['oc.lazyLoad']);
app.controller('productsCreateController', [
    '$scope', 'productsService', '$location', '$rootScope', '$routeParams', function($scope, productsService, $location, $rootScope, $routeParams) {

    var vm = this;
    vm.SaveProduct = SaveProduct;//SAVE PRODUCT FUNCTION
    vm.CancelProduct = CancelProduct; //CANCEL PRODUCT FUNCTION
    vm.Product = {};
    vm.integerval = /^\d*$/; //REG EXPRESSION FOR NUMBER FIELD

    function SaveProduct() {
        productsService.saveProduct(vm.Product, Saved, Saved);

    }

    //Data Saved Successfully
    function Saved() {
        $rootScope.loadProduct = true;
        $location.url('products');

    }
    ////Product Detail loaded and set to fields
    function ProductDetail(data) {

        if (data) {
            vm.Product.Id = data.Id;
            vm.Product.ProductName = data.ProductName;
            vm.Product.StockCount = data.StockCount;
            vm.Product.Description = data.Description;
        }
    }
        //Cancel takes you back to the page. Ideally it should not load in this case
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