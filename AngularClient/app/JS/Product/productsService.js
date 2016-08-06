var app = angular.module('productApp');
app.service('productsService', ['$http','productConstants', function ($http,prodConstants) {
    this.loadProduct = loadProducts;
    
    function loadProducts(onSuccess, onError) {
        

        $http
            .get(prodConstants.url.apiURL + prodConstants.url.products)
            .success(onSuccess)
            .error(onError);
    };
}]);

