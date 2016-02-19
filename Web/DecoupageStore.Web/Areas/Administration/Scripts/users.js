(function () {
    $(document).ready(function () {
        $("#page0").click();
    })

    function OnAjaxGetUsersSuccess(data) {
        console.log("Success: " + data);
    }

    function OnAjaxGetUsersFailure(request, error) {
        console.log("Error: " + error);
    }
})