var app = angular.module('myApp', [])
app.controller('registrationForm', function ($scope) {
    $scope.master = {
        Name: "Dhanush", Email: "Dhanuhsc@smartsoft.in", Address: "Hyderabad",
        Mobile: "7032829714", Pincode: "500050"
    };
    $scope.reset = function () {
        $scope.user = angular.copy($scope.master);
    };
    $scope.reset();
    app.controller('registrationForm', function ($scope, $http) {
        $scope.Submit = function () {
            var submitform =
            {
                method: "POST",
                url: "../api/Home/Registration",
                params: {
                    Name: $scope.user.Name,
                    Email: $scope.user.Email,
                    Password: $scope.user.Password,
                    City: $scope.user.City,
                    country: $scope.user.country,
                    Mobile: $scope.user.Mobile
                }
            };
            $http(submitform)
            {
               alert("Registration Succesfully");
                $scope.GetReport();
            }
        }
        $scope.GetReport = function () {
            $http({
                method: 'POST',
                url: "../api/Home/RegistrationReport",
                params: {
                    Action: 'Report', Id: 0
                }
            }).then(function successCallback(response) {
                debugger
                $scope.Response = response.data.Table;
               
            }, function errorCallback(response) {
                
            });
        }
        $scope.GetReport();
    });

})