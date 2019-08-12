app.service('DropdownService', function ($http) {
    this.getAllDropdowns = function () {
        return $http({
            url: "/api/v1/dropdown/GetValues",
            method: "GET"
        })
            .then(function (response) {
                return response.data;
            });
    };

    this.getAllDropdownsByType = function (type) {
        return $http({
            url: "/api/v1/dropdown/GetValuesByType?type=" + type,
            method: "GET"
        })
            .then(function (response) {
                return response.data;
            });
    };

    this.saveDropdownValue = function (model) {
        return $http({
            url: "/api/v1/dropdown/SaveDropdownItem",
            method: "POST",
            data: model
        }).then(function (response) {
            return response;
        });
    };
});