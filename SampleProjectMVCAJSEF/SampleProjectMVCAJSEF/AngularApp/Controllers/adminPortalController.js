app.controller('AdminPortalController', function ($scope, $timeout, $window, ClientService) {
    var ctrl = this;
    ctrl.Navigate = function (link) {
        $window.location.href = link;
    }
});