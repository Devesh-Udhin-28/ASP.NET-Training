$(function () {
    let form = document.querySelector('form');

    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });

    $("#btnRegister").click(function () {
        toastr.info('Page Under construction!!');
    });

    $("#sign-in").click(function () {
        var emailAddress = $("#emailAddress").val();
        var password = $("#passwd").val();

        var authObj = { EmailAddress: emailAddress, Password: password };
        $.ajax({
            type: "POST",
            url: "/Login/Authenticate",
            data: authObj,
            dataType: "json",
            success: function (response) {
                if (response.result) {
                    toastr.success("Authentication Succeed. Redirecting to relevent page.....");
                    window.location = response.url;
                }
                else {
                    toastr.error('Unable to Authenticate user');
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