$(function () {
    let form = document.querySelector('form');

    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });

    $(".form-group-button").click(function () {
        //var buttonActionType = document.getElementsByTagName("button")[0].id;
        var buttonActionType = document.getElementsByClassName("form-group-button")[0].id;

        var firstName = $("#fname").val();
        var lastName = $("#lname").val();
        var address = $("#address1").val();
        var address2 = $("#address2").val();
        var phoneNum = $("#phone").val();
        var emailAddress = $("#emailAddress").val();
        var employeeID = $("#empId").val();

        var authObj = {
            FirstName: firstName,
            LastName: lastName,
            Address: address,
            Address2: address2,
            HomePhone: phoneNum,
            EmailAddress: emailAddress,
            EmployeeID: employeeID
        };

        var myUrl;

        if (buttonActionType == "update") {
            myUrl = "/EditEmployee/UpdateEmp";
        }
        else if (buttonActionType == "create") {
            myUrl = "/EditEmployee/InsertEmp";
        }

        $.ajax({
            type: "POST",
            url: myUrl,
            data: authObj,
            dataType: "json",
            success: function (response) {
                if (response.result) {
                    toastr.success("Update Succeed.");
                    window.location = response.url;
                }
                else {
                    toastr.error('Unable to Update user');
                    return false;
                }
            },
            failure: function (response) {
                toastr.error('Unable to make request!!');
            },
            error: function (response) {
                toastr.error('Something happen, Please contact Administrator!!');

            }
        });
    });
});