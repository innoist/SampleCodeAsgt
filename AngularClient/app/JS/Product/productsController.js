
var app = angular.module('productApp');
app.controller('productsController', ['$scope', 'productsService', '$rootScope', '$location', function ($scope, productsService, $rootScope, $location) {
    
    var vm = this;
    vm.products = [];

    $rootScope.loadProduct = $rootScope.loadProduct == undefined ? true : false;

        productsService.loadProduct(productsLoaded);
    
    function productsLoaded(data, responseText, response) {
        vm.products = data;

    
        vm.viewProduct = function(productId) {
            $location.url('CreateProduct/' + productId);
        }}
    


}]);