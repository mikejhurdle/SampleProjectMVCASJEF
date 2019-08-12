app.controller('AdminController', function ($scope, NavigationService, $timeout, $window) {
    var ctrl = this;
    (ctrl.GetAdminTiles = function () {
        NavigationService.GetAdminTiles().then(function (data) {
            ctrl.Tiles = data;
        });
    })();
    ctrl.Navigate = function (link) {
        $window.location.href = link;
    }

});