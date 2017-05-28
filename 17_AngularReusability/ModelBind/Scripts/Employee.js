//function EmployeeViewModel($scope, $http) {
//    $scope.EmpObj = {
//        "EmployeeCode": "",
//        "EmployeeName": "",
//        "EmployeeSalary": "",
//        "EmployeeSalaryColor": ""
//    };
//    $scope.Employees = {};

//    $scope.getColor = function (Salary) {
//        if (Salary == 0) {
//            return "";
//        }
//        else if (Salary > 10000) {
//            return "Blue";
//        }
//        else {
//            return "Red";
//        }

//    }
//    $scope.$watch("EmpObj.EmployeeSalary", function () {
//        $scope.EmpObj.EmployeeSalaryColor = $scope.getColor($scope.EmpObj.EmployeeSalary);
//    });
//    $scope.Add = function () {
//        $http({ method: "POST", data: $scope.EmpObj, url: "Submit" }).success(function (data, status, headers, config) {
//            $scope.Employees = data;
//            $scope.EmpObj = {
//                "EmployeeCode": "",
//                "EmployeeName": "",
//                "EmployeeSalary": "",
//                "EmployeeSalaryColor": ""
//            };
//        });


//    }
//    $scope.Load = function () {
//        $http({ method: "GET", url: "GetEmployees" }).
//        success(function (data, status, headers, config) {
//            $scope.Employees = data;
//            //alert("Load");
//            //alert($scope.Employees.length);
//            for (var x = 0; x < $scope.Employees.length; x++) {

//                var emp = $scope.Employees[x];
//                emp.EmployeeSalaryColor = $scope.getColor(emp.EmployeeSalary);
//            }


//        });
//    }
    
//    $scope.LoadByName = function () {
//        $http({ method: "GET", data: $scope.EmpObj, url: "GetEmployeesByName" }).
//        success(function (data, status, headers, config) {
//            $scope.Employees = data;
//            //alert("LoadByName");
//            //alert($scope.Employees.length);

//            for (var x = 0; x < $scope.Employees.length; x++) {

//                var emp = $scope.Employees[x];
//                emp.EmployeeSalaryColor = $scope.getColor(emp.EmployeeSalary);
//            }


//        });
//    }


//    $scope.Load();


//    $scope.$watch("$scope.Employees", function () {

//        for (var x = 0; x < $scope.Employees.length; x++) {

//            var emp = $scope.Employees[x];
//            emp.EmployeeSalaryColor = $scope.getColor($scope.EmpObj.EmployeeSalary);
//        }
//    });



//}