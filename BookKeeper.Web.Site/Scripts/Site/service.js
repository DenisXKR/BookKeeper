app.service("bookKeeperService", function ($http) {

    var expensesUrl = "api/expenses";
    var categoryUrl = "api/category";

    this.getExpenses = function () {
        return $http.get(expensesUrl);
    };

    this.getExpense = function (expenseId) {
        var response = $http({
            method: "get",
            url: expensesUrl,
            params: {
                id: JSON.stringify(expenseId)
            }
        });
        return response;
    }

    this.updateExpense = function (expense) {
        var response = $http({
            method: "put",
            url: expensesUrl,
            data: JSON.stringify(expense),
            dataType: "json"
        });
        return response;
    }

    this.addExpense = function (expense) {
        var response = $http({
            method: "post",
            url: expensesUrl,
            data: JSON.stringify(expense),
            dataType: "json"
        });
        return response;
    }

    this.deleteExpense = function (expenseId) {
        var response = $http({
            method: "delete",
            url: expensesUrl,
            params: {
                id: JSON.stringify(expenseId)
            }
        });
        return response;
    }

    this.getByCategory = function () {
        return $http.get(expensesUrl + '/getexpensebycategory');
    };

    this.getByMonth = function () {
        return $http.get(expensesUrl + '/getexpensebymonth');
    };

    this.getCategory = function () {
        return $http.get(categoryUrl);
    };
});