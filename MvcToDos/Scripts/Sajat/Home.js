var Home = function () {
    var onCreateSuccess = function () {
        $(".Create form")[0].reset();
        $("#Szoveg").focus();
    }
    var onEditSucces = function (id) {
        $(id).toggleClass("Kesz");
    }
    return {
        onCreateSuccess: onCreateSuccess,
        onEditSucces: onEditSucces
    };
}();


