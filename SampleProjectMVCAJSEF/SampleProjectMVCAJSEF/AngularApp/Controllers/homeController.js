app.controller('HomeController', function ($scope, NavigationService, $timeout, $window) {
    var ctrl = this;
    (ctrl.RefreshUsers = function () {
        NavigationService.GetNavTiles().then(function (data) {
            ctrl.Tiles = data;
        });
    })();
    ctrl.Navigate = function (link) {
        $window.location.href = link;
    }

});