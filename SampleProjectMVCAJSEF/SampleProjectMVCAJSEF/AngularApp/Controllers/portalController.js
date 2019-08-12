app.controller('PortalController', function ($scope, $timeout, $window) {
    var ctrl = this;
    ctrl.Navigate = function (link) {
        $window.location.href = link;
    }
});