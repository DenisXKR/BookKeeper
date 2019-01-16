/// <reference path="angular-mocks.js" />
/// <reference path="angular.min.js" />
/// <reference path="site/service.js" />
/// <reference path="site/module.js" />
/// <reference path="site/controller.js" />

app.controller("bookKeeperCtrl", function ($scope, bookKeeperService) {

    $scope.selectedCategoryId = null;

    $scope.getAllExpenes = function () {
        var getExpenesData = bookKeeperService.getExpenses();
        getExpenesData.then(function (exp) {
            $scope.expenes = exp.data;
        }, function (err) {
            console.log(err);
        });
        var getCategoryData = bookKeeperService.getCategory();
        getCategoryData.then(function (category) {
            $scope.categories = category.data
        }, function (err) {
            console.log(err);
        })
    }

    $scope.getAllExpeneByCategory = function () {
        var getExpenesData = bookKeeperService.getByCategory();
        getExpenesData.then(function (exp) {
            $scope.expenesCategory = exp.data;
        }, function (err) {
            console.log(err);
        });
    }

    $scope.getAllExpeneByMonth = function () {
        var getExpenesData = bookKeeperService.getByMonth();
        getExpenesData.then(function (exp) {
            $scope.expenesMonth = exp.data;
        }, function (err) {
            console.log(err);
        });
    }

    $scope.editExpense = function (expense) {
        var getExpenesData = bookKeeperService.getExpense(expense.Id);
        getExpenesData.then(function (item) {
            $scope.expense = item.data;
            $scope.id = expense.Id;
            $scope.categoryName = expense.CategoryName;
            $scope.selectedCategoryId = expense.CategoryId
            $scope.date = $.datepicker.formatDate('yy-mm-dd', new Date(expense.Date));
            $scope.amount = expense.Amount;
            $scope.Action = "Update";
            showEditDialog();
        }, function (err) {
            console.log(err);
        });
    }

    $scope.addUpdateExpense = function () {
        var Expense = {
            Id: $scope.id,
            CategoryId: $scope.selectedCategoryId,
            Date: $scope.date,
            Amount: $scope.amount,
        };

        var getAction = $scope.Action;

        if (getAction == "Update") {
            var getExpenesData = bookKeeperService.updateExpense(Expense);
            getExpenesData.then(function () {
                $scope.getAllExpenes();
                $scope.cancel();
            }, function (err) {
                console.log(err);
            });
        }
        else {
            var getExpenesData = bookKeeperService.addExpense(Expense);
            getExpenesData.then(function () {
                $scope.getAllExpenes();
                $scope.cancel();
            }, function (err) {
                console.log(err);
            });
        }
    }

    $scope.addExpense = function () {
        $scope.selectedCategoryId = null;
        $scope.date = "";
        $scope.amount = "";
        $scope.Action = "Add";
        showEditDialog();
    }

    $scope.formatDate = function (date) {
        var dateOut = new Date(date);
        return dateOut;
    };

    $scope.deleteExpenes = function (expense) {
        var getExpenesData = bookKeeperService.deleteExpense(expense.Id);
        getExpenesData.then(function () {
            $scope.getAllExpenes();
        }, function (err) {
            console.log(err);
        });
    }

    function showEditDialog() {
        $('#editDialog').modal();
    }

    $scope.cancel = function () {
        $('#editDialog').modal('hide');
    };

    $scope.getAllExpenes();
});