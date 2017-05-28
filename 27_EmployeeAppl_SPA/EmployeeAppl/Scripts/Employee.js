function EmployeeViewModel($scope, $http) {
    $scope.EmpObj = {
        "EmployeeCode": "",
        "EmployeeName": "",
        "EmployeeSalary": "",
        "EmployeeSalaryColor": ""
    };
    $scope.Employees = {};
    $scope.Errors = {};
    $scope.getColor = function (Salary) {
        if (Salary == 0) {
            return "";
        }
        else if (Salary > 10000) {
            return "Blue";
        }
        else {
            return "Red";
        }

    }
    $scope.$watch("EmpObj.EmployeeSalary", function () {
        $scope.EmpObj.EmployeeSalaryColor = $scope.getColor($scope.EmpObj.EmployeeSalary);
    });
    $scope.AddNew= function () {
        alert("send");
        $http({ method: "POST", data: $scope.EmpObj, url: "http://localhost:8048/Api/Employee" }).
            success(function (data, status, headers, config) {
            if (data.IsValid)
            {
                $scope.Employees = data.Data;
                $scope.EmpObj = {
                    "EmployeeCode": "",
                    "EmployeeName": "",
                    "EmployeeSalary": "",
                    "EmployeeSalaryColor": ""
                };
                for (var x = 0; x < $scope.Employees.length; x++) {

                    var emp = $scope.Employees[x];
                    emp.EmployeeSalaryColor = $scope.getColor(emp.EmployeeSalary);
                }
            }
            else
            {
                alert("hi");
                $scope.Errors = data.Data.ErrorList;
            }
        });

        debugger;
    }


    $scope.Add = function () {

        $http({ method: "POST", data: $scope.EmpObj, url: "http://localhost:8048/Api/Employee" }).
            success(function (data, status, headers, config) {
                //debugger;
                if (data.IsValid)
                {
                    $scope.Employees = data.Data;
                    //debugger;
                    $scope.EmpObj = {
                        "EmployeeCode": "",
                        "EmployeeName": "",
                        "EmployeeSalary": "",
                        "EmployeeSalaryColor": ""
                    };
                    for (var x = 0; x < $scope.Employees.length; x++) {

                        var emp = $scope.Employees[x];
                        emp.EmployeeSalaryColor = $scope.getColor(emp.EmployeeSalary);
                    }
                }
                else
                {
                    $scope.Errors = data.Data.ErrorList;
                }
            });
    }
        $scope.Load = function () {

       $http({ method: "GET", url: "http://localhost:8048/Api/Employee" }).
        success(function (data, status, headers, config) {
            $scope.Employees = data;

            for (var x = 0; x < $scope.Employees.length; x++) {

                var emp = $scope.Employees[x];
                emp.EmployeeSalaryColor = $scope.getColor(emp.EmployeeSalary);
            }


        });
    }
    $scope.Update = function () {
        $http({ method: "PUT", data: $scope.EmpObj, url: "http://localhost:8048/Api/Employee" }).success(function (data, status, headers, config) {
            $scope.Employees = data;
            $scope.EmpObj = {
                "EmployeeCode": "",
                "EmployeeName": "",
                "EmployeeSalary": "",
                "EmployeeSalaryColor": ""
            };

            for (var x = 0; x < $scope.Employees.length; x++) {

                var emp = $scope.Employees[x];
                emp.EmployeeSalaryColor = $scope.getColor(emp.EmployeeSalary);
            }
        });
    }

    $scope.Delete = function () {
        $http.defaults.headers["delete"] = {
            'Content-Type': 'application/json;charset=utf-8'
        };
        $http({ method: "DELETE", data: $scope.EmpObj, url: "http://localhost:8048/Api/Employee" }).success(function (data, status, headers, config) {
            $scope.Employees = data;
            $scope.EmpObj = {
                "EmployeeCode": "",
                "EmployeeName": "",
                "EmployeeSalary": "",
                "EmployeeSalaryColor": ""
            };
            for (var x = 0; x < $scope.Employees.length; x++) {

                var emp = $scope.Employees[x];
                emp.EmployeeSalaryColor = $scope.getColor(emp.EmployeeSalary);
            }
        });
    }

    $scope.LoadByCode = function (EmployeeCode) {
        alert("LoadByCode");
        $http({
            method: "GET",
            url: "http://localhost:8048/Api/Employee?EmployeeCode=" + EmployeeCode
        }).
      success(function (data, status, headers, config) {
          //$scope.Employees = data;
          alert("LoadByCode1");
          debugger;
          $scope.EmpObj = {
              "EmployeeCode": data[0].EmployeeCode,
              "EmployeeName": data[0].EmployeeName,
              "EmployeeSalary": data[0].EmployeeSalary,
              "EmployeeSalaryColor": data[0].EmployeeSalaryColor
          };
        });
    }
    $scope.Load();

    $scope.$watch("$scope.Employees", function () {

        for (var x = 0; x < $scope.Employees.length; x++) {

            var emp = $scope.Employees[x];
            emp.EmployeeSalaryColor = $scope.getColor($scope.EmpObj.EmployeeSalary);
        }
    });



}