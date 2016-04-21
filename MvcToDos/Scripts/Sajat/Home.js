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

var CreateLista = function () {
    var ujraszamozas = function() {
        var lista = $("div#TeendolistaElemek ul li");
        for (var i = 1; i < lista.length; i++) {
            var $Id = $(lista[i]).find("input.Id");
            var nameId = $Id.attr("name");
            if (nameId != undefined) {
                nameId = nameId.toString().replace(/\[.\]/, "[" + (i - 1) + "]");
                $Id.removeAttr("name");
                $Id.attr("name", nameId);
            }

            var $Szoveg = $(lista[i]).find("input.Szoveg");
            var nameSzoveg = $Szoveg.attr("name");
            if (nameSzoveg != undefined) {
                nameSzoveg = nameSzoveg.toString().replace(/\[.\]/, "[" + (i - 1) + "]");
                $Szoveg.removeAttr("name");
                $Szoveg.attr("name", nameSzoveg);
            }
        }
    }
    var ellenorzes = function() {
        var lista = $("div#TeendolistaElemek ul li");
        lista.find("div.Hiba").hide();
        for (var i = 1; i < lista.length; i++) {
            var $Szoveg = $(lista[i]).find("input.Szoveg");
            if ($Szoveg.val() == "") {
                var $Hiba = $(lista[i]).find("div.Hiba");
                $Hiba.text("A listaelem értéke nem lehet üres!");
                $Hiba.show();
                return false;
            }
        }
        return true;
    }
    var elemTorlese = function (id) {
        $("div#TeendolistaElemek ul li#elem" + id).remove();
        ujraszamozas();
    };
    var ujElem = function () {
        if (ellenorzes()) {
            var $ujElem = $("li.UresListaElem").clone();
            $ujElem.removeClass("UresListaElem");

            var lista = $("div#TeendolistaElemek ul li");
            var id = 0;
            for (var i = 1; i < lista.length; i++) {
                var ujId = $(lista[i]).find("input.Id").val();
                if (ujId > id) {
                    id = ujId;
                }
            }
            id++;
            $ujElem.attr("id", "elem" + id);
            $ujElem.find("input.Id").val(id);
            $ujElem.find("input.Id").attr("name", "TeendoListaElemek[" + (id - 1) + "].Id");
            $ujElem.find("input.Szoveg").attr("name", "TeendoListaElemek[" + (id - 1) + "].Szoveg");
            $ujElem.find("button.Torles").click(function(e) {
                e.preventDefault();
                elemTorlese(id);
            });
            $("div#TeendolistaElemek ul").append($ujElem);
            $ujElem.show();
            $ujElem.find("input[type='text']").focus();
            $ujElem.find("input[type='text']").keypress(function (e) {
                if (e.which == 13) {
                    e.preventDefault();
                    ujElem();
                    return false;
                }
            });
            ujraszamozas();
        }
    };

    var onInit = function() {
            $("div#TeendolistaElemek button#ujElem").click(function(e) {
                e.preventDefault();
                ujElem();
            });
        $("div.Types label").click(function() {
            if ($("div#TeendolistaElemek input[name='TeendoListaElemek[0].Id']").length == 0) {
                ujElem();
                $("div#TeendolistaElemek input[name='TeendoListaElemek[0].Szoveg']").focus();
            }
        });
    };

    var onSuccess = function() {
        var lista = $("div#TeendolistaElemek ul li");
        for (var i = 1; i < lista.length; i++) {
            $(lista[i]).remove();
        }
        ujElem();

    };

    var onBegin = function() {
        return ellenorzes();
    };

    return {
        onInit: onInit,
        onBegin: onBegin,
        onSuccess: onSuccess
            };
}();
