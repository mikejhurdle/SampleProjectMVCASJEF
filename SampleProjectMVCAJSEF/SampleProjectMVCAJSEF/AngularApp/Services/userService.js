app.service('UserService', function ($http) {
    this.getAllUsers = function () {
        return $http({
            url: "/api/v1/user/GetAll",
            method: "GET"
        })
            .then(function (response) {
                return response.data;
            });
    };
    this.SaveUser = function (dto) {
        return $http({
            url: "/api/v1/user/Save",
            method: "POST",
            data:dto
        })
            .then(function (response) {
                return response.data;
            });
    };
    this.GetRoles = function () {
        return $http({
            url: "/api/v1/user/GetRoles",
            method: "GET"
        })
            .then(function (response) {
                return response.data;
            });
    };
    this.GetUsersByClient = function (id) {
        return $http({
            url: "/api/v1/user/GetUsers/"+id,
            method: "GET"
        })
            .then(function (response) {
                return response.data;
            });
    };
});