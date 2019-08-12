app.controller('ManageUsersController', function ($scope, UserService, $timeout, $mdBottomSheet, $mdToast,$window, $mdDialog) {
    var ctrl = this;
    (ctrl.RefreshUsers = function () {
        UserService.getAllUsers().then(function (data) {
            ctrl.UserList = data;
        });
    })();
    ctrl.Navigate = function (link) {
        $window.location.href = link;
    }
    ctrl.EditUser = function (user) {
        if (user) {
            ctrl.SelectedUser = user;
        } else {
            ctrl.SelectedUser = {Id:null, FirstName:null,LastName:null,Email:null,Phone:null,Role:null,Active:true}
        }
        
        $mdDialog.show({
            templateUrl: '/AngularApp/Templates/EditUserTemplate.html',
            controller: EditUserController,
            clickOutsideToClose:true
        }).then(function (result) {
            if (result) {
                ctrl.RefreshUsers();
                $mdToast.show(
                    $mdToast.simple()
                        .textContent(result)
                        .position('top right')
                        .hideDelay(1500)
                );
                
            }
        }).catch(function (error) {
            $mdToast.show(
                $mdToast.simple()
                    .textContent(error)
                    .position('top right')
                    .hideDelay(1500)
            );
        });
    }
    function EditUserController($scope, $mdDialog,UserService) {
        $scope.user = ctrl.SelectedUser;
        UserService.GetRoles().then(function (data) {
            $scope.Roles = data;
        });
        $scope.save = function () {
            UserService.SaveUser($scope.user).then(function (data) {
                $mdDialog.hide('Successfully updated user!');
            });
        }
        $scope.cancel = function () {
            $mdDialog.hide();
        }
    }
});