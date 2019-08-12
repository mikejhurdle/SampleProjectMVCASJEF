app.controller('ManageDropdownController', function ($scope, DropdownService, $timeout, $window) {
    var ctrl = this;
    ctrl.Navigate = function (link) {
        $window.location.href = link;
    }
    ctrl.DropdownTypes = [];
    ctrl.selectedDD = null;
    ctrl.RefreshDropDowns = function () {
        DropdownService.getAllDropdowns().then(function (data) {
            ctrl.DropdownTypes = data;
        });
    };
    ctrl.RefreshDropDowns();
    ctrl.selectItem = function () {
        var count = 0;
        var selecteditem = { "Name": "", "Active": true };
        angular.forEach(ctrl.selectedDD.Values, function (item) {
            if (item.Checked) {
                count += 1;
                if (count === 1) {
                    selecteditem.Name = item.Name;
                    selecteditem.Id = item.Id;
                    selecteditem.TypeId = item.TypeId;
                }
                else {
                    selecteditem = { "Name": "", "Active": true };
                }
            }
        });
        ctrl.selectedItem = selecteditem;
    };
    ctrl.countChecked = function () {
        var count = 0;
        if (ctrl.selectedDD) {
            angular.forEach(ctrl.selectedDD.Values, function (item) {
                if (item.Checked) {
                    count += 1;
                }
            });
        }
        return count;
    };
    ctrl.saveDropdownValue = function () {
        var isNew = false;

        if (!ctrl.selectedItem | !ctrl.selectedItem.TypeId) {
            ctrl.selectedItem.TypeId = ctrl.selectedDD.Id;
            ctrl.selectedItem.Active = true;
            isNew = true;
        }
        DropdownService.saveDropdownValue(ctrl.selectedItem).then(function (data) {
            ctrl.selectedItem.Id = data;
            DropdownService.getAllDropdowns();
            if (isNew) {
                ctrl.selectedDD.Values.push(ctrl.selectedItem);
            } else {

            }
            ctrl.selectedItem = null;
        });
    };
    ctrl.removeDropdownItems = function () {
        angular.forEach(ctrl.selectedDD.Values, function (item, idx) {
            if (item.Checked) {
                item.Active = false;
                item.Checked = false;
                DropdownService.saveDropdownValue(item).then(function (data) {

                });
            }
        });
    };
});