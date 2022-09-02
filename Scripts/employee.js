var app = angular.module('myApp', []);
app.controller('EmpolyeeCtrl', function ($scope) {
    $scope.Name = "HarishP";
    $scope.Email = "harishpesari09@gmail.com";
    $scope.Address = "Hyderabad";
    $scope.EmpDetails = function () {
        return $scope.Name + "" + $scope.Email + "" + $scope.Address;
    }
}
);

app.controller('rptEmpolyeeCtrl', function ($scope) {
    $scope.rptEmpolyee =
    [
        { Name: 'HarishP', City: 'Beemavaram' },
        { Name: 'Grapsy', City: 'Hyderabad' },
        { Name: 'Sneha', City: 'Hyderabad' },
        { Name: 'Rvali', City: 'Buswapoor' },
        { Name: 'Aditya', City: 'Andra' },
        { Name: 'Komal', City: 'Warangal' },
        { Name: 'Nirmal', City: 'Kakinada' },
        { Name: 'Abhilash', City: 'Kondapoor' },
        { Name: 'Nagarjuna', City: 'Nalgondaa' }
    ];
});

$scope.EditData = function (RegistrationId) {
    debugger
    var req = {
        method: 'GET',
        url: "../api/Home/GetRegistrations",
        params: {
            RegistrationId: RegistrationId,
            Action: 'Report'
        }
    };
    $http(req)
       .success(function (Response) {
           $user.StudentName = Response[0]["Studentname"]
           //$scope.College = Response[0]["College"]
           //$scope.Email = Response[0]["Email"]
           //$scope.MobileNo = Response[0]["MobileNo"]
           //$scope.Village = Response[0]["Village"]
           //$scope.City = Response[0]["City"]
           //$scope.Country = Response[0]["Country"]
           //$scope.Password = Response[0]["Password"];
       })
       .error(function (Message) {
           alertify.alert(Message.Message);
       });
};

app.controller('Registrationform', function ($scope, $http) {


    $scope.Submit = function () {
        debugger
        var submitform =
        {
            method: "POST",
            url: "../api/Home/GetRegistrations",
            params: {
                //Name: $scope.user.Name,
                //Email: $scope.user.Email,
                //Password: $scope.user.Password,
                //City: $scope.user.City,
                //country: $scope.user.country,
                //Mobile: $scope.user.Mobile
                RegistrationId: "1",
                Action: 'Report'
            }
        };
        $http(req)
           .success(function (Response) {
               $user.StudentName = Response[0]["Name"]
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    
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
            // this callback will be called asynchronously
            // when the response is available
        }, function errorCallback(response) {
            // called asynchronously if an error occurs
            // or server returns response with an error status.
        });

    }
    $scope.GetReport();
});
