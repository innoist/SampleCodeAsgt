
var app = angular.module('productApp');
app.controller('productsController', ['$scope', 'productsService', function ($scope, productsService) {
    
    var vm = this;
    vm.hello = 'Hi';
    productsService.loadProduct(productsLoaded, productsFailed);


    function productsLoaded(data, responseText, response) {
        
    }
    function productsFailed(data, data2) {
        debugger
    }
}]);