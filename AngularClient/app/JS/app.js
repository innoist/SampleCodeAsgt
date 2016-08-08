
(function () {

    var app = angular.module("productApp", ['ngRoute', 'angularSpinner', 'oc.lazyLoad']);

    //Interceptors to show busy indicator
    app.factory('myInterceptor', ['$log', '$rootScope', 'usSpinnerService', function ($log, $rootScope, usSpinnerService) {
        
        if ($rootScope.activeCalls == undefined) {
            $rootScope.activeCalls = 0;
        }

        function validate(count) {
            if (count == undefined || count === 0 || count<0) {
                usSpinnerService.stop('spinner-1');
                count = 0;
            } else {
                usSpinnerService.spin('spinner-1');
            }
            $log.debug('Active/deactive spinner:' + count);
        }
        var myInterceptor = {
            request: function (config) {
                
                $rootScope.activeCalls += 1;
                validate($rootScope.activeCalls);
                $log.debug('Making Request :' + $rootScope.activeCalls);
                return config;
            },
            requestError: function (rejection) {
                $rootScope.activeCalls -= 1;
                validate($rootScope.activeCalls);
                $log.debug('Request error :' + $rootScope.activeCalls);
                return rejection;
            },
            response: function (response) {
                $rootScope.activeCalls -= 1;
                validate($rootScope.activeCalls);
                $log.debug('Response received :' + $rootScope.activeCalls);
                return response;
            },
            responseError: function (rejection) {
                $rootScope.activeCalls -= 1;
                validate($rootScope.activeCalls);
                $log.debug('Error Received :' + $rootScope.activeCalls);
                return rejection;
            }
    };

        return myInterceptor;
    }]);



    app.config(['$httpProvider', '$routeProvider', '$logProvider', '$ocLazyLoadProvider', function ($httpProvider, $routeProvider, $logProvider, $ocLazyLoadProvider) {
        $httpProvider.interceptors.push('myInterceptor');
        $logProvider.debugEnabled(true);
        //////// Lazyloading configuration
        $ocLazyLoadProvider.config({
            			modules: [
            				{
            					name: 'ProductModule',
            					files: ['app/JS/Product/productsController.js']
            				},
			                {
			                    name: 'ProductAddModule',
			                    files: ['app/JS/Product/productsCreateController.js']
			                    
			                }
            			],
            asyncLoader: $script
        });

        ////////DEFINING ROUTES
        $routeProvider.
            when('/products', {
                templateUrl: '/app/Views/Products.htm',
                
                controller: 'productsController',
                controllerAs: 'pd',
                resolve: { 
                    loadMyCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
                            return $ocLazyLoad.load('ProductModule');
                    }]
                }
            })
            .when('/CreateProduct', {
                templateUrl: '/app/Views/AddUpdateProduct.html',

                controller: 'productsCreateController',
                controllerAs: 'pd',
                resolve: {
                    loadMyCtrl: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load('ProductAddModule');
                    }]
                }
            })

             .when('/CreateProduct/:id', {
                 templateUrl: '/app/Views/AddUpdateProduct.html',

                 controller: 'productsCreateController',
                 controllerAs: 'pd',
                 resolve: {
                    loadMyCtrl: [
                        '$ocLazyLoad', function($ocLazyLoad) {
                            return $ocLazyLoad.load('ProductAddModule');
                        }
                    ]
                }
            })

            .otherwise({ redirectTo: '/products' });


      

    }]);


})();