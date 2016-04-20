var Edit = function () {
    var onSucces = function (id) {
        $(id).toggleClass("Kesz");
    }
    return {
        onSucces: onSucces
    };
}();

var Create = function() {
    var onInit = function() {
        $(document).ready(function() {
            $("#Create-Teendolista").hide();
            $("#Create-Teendo").show();
            $("#Szoveg").focus();
            $("#Szoveg").keypress(function(e) {
                if (e.which == 13) {
                    e.preventDefault();
                    $("#Create input[type='submit']").focus().click();
                    return false;
                }
            });
            $("#SzinkodMegadva").change(function() {
                $("input#SzinKod").toggle();
                $("span#Megadom").toggle();
                $("span#NemAdomMeg").toggle();
            });
            var tipusValtas = function(input) {
                if (input.value == "teendo") {
                    $("#Create-Teendolista").hide();
                    $("#Create-Teendo").show();
                }
                if (input.value == "teendolista") {
                    $("#Create-Teendolista").show();
                    $("#Create-Teendo").hide();
                }
            };
            $("#Radio-Teendo").click(function() { tipusValtas(this) });
            $("#Radio-Teendolista").click(function () { tipusValtas(this) });
        });
    };
    var onSuccess = function () {
        $("input#SzinKod").hide();
        $("span#Megadom").show();
        $("span#NemAdomMeg").hide();
        $("#Create form")[0].reset();
        $("#Szoveg").focus();
    };
    return {
        onInit: onInit,
        onSuccess: onSuccess
    };
}();
