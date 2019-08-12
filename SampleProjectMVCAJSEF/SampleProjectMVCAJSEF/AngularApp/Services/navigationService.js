app.service('NavigationService', function ($http) {
    this.GetNavTiles = function () {
        return $http({
            url: "/api/v1/navigation/GetNavTiles",
            method: "GET"
        })
            .then(function (response) {
                return response.data;
            });
    };
    this.GetAdminTiles = function () {
        return $http({
            url: "/api/v1/navigation/GetAdminTiles",
            method: "GET"
        })
            .then(function (response) {
                return response.data;
            });
    };
});