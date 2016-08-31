$(document).ready(function () {
    $("#dfFecha").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
    init();


    function init() {
        cargarArea();
        CargarSexo(); 
    };

    function cargarArea() {
        $.getJSON(
        "/RegistroPersona/obtenerRutaJson",
        {
            nombreControl: "slArea"
        },
        function (data) {

            var slCriterio = $("#slArea");
            slCriterio.empty();

            for (u in data.Area.Area) {
                slCriterio.append("<option value=" + data.Area.Area[u].valor +
                        ">" + data.Area.Area[u].texto + "</option>");
            }
        });
    };

    function CargarSexo() {
        $.getJSON(
               "/RegistroPersona/obtenerRutaJson",
               {
                   nombreControl: "slSexo"
               },
               function (data) {

                   var slCriterio = $("#slSexo");
                   slCriterio.empty();

                   for (u in data.Sexo.Sexo) {
                       slCriterio.append("<option value=" + data.Sexo.Sexo[u].valor +
                               ">" + data.Sexo.Sexo[u].texto + "</option>");
                   }
               });
    };

    $("#btnGuardarTop").click(function (e) {
        
        if ($("#frmRegistroPersona").valid()) {

            var parvNomPer = $("#vNomPer").val();
            var parvApePat = $("#vApePat").val();
            var parvApeMat = $("#vApeMat").val();

            var datojson = JSON.stringify([{
                "vNomPer": parvNomPer,
                "vApePat": parvApePat,
                "vApePat": parvApeMat
            }]);

            $.ajax({
                type: "POST",
                url: requrlRegistroPersonas,
                //headers: headers,
                //data: "{'dato':'" + datojson + "'}",
                data: "{'dato':'" + datojson + "'}",
                //data: "{'page':'" + page + "','rows':'" + rows + "','sidx':'" + sidx + "','sord':'" + sord + "','_search':'" + _search + "','dato':'" + dato + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessRegistrarPersona,
                error: OnErrorRegistrarPersona
            });

            function OnSuccessRegistrarPersona(response) {

                alert(response);
                window.location.href = requrlConsultaPersonas;
            }

            function OnErrorRegistrarPersona(response) {

                window.location.href = requrlError;
            }

        }

    });

    $("#btnGuardarBotton").click(function (e) {

        if ($("#frmRegistroPersona").valid()) {

            var parvNomPer = $("#vNomPer").val();
            var parvApePat = $("#vApePat").val();
            var parvApeMat = $("#vApeMat").val();
            var pariNumTelefonico = $("#iNumTelefonico").val();
            var parvSexo = $("#slSexo").val();
            var parvArea = $("#slArea").val();
            var parsdFecha = $("#dfFecha").val();

            var datojson = JSON.stringify([{
                "vNomPer": parvNomPer,
                "vApePat": parvApePat,
                "vApeMat": parvApeMat,
                "iNumTelefonico": pariNumTelefonico,
                "vSexo": parvSexo,
                "vArea": parvArea,
                "sdFecha": parsdFecha
            }]);

            $.ajax({
                type: "POST",
                url: requrlRegistroPersonas,
                //headers: headers,
                //data: "{'dato':'" + datojson + "'}",
                data: "{'dato':'" + datojson + "'}",
                //data: "{'page':'" + page + "','rows':'" + rows + "','sidx':'" + sidx + "','sord':'" + sord + "','_search':'" + _search + "','dato':'" + dato + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessRegistrarPersona,
                error: OnErrorRegistrarPersona
            });

            function OnSuccessRegistrarPersona(response) {

                alert(response);
                window.location.href = requrlConsultaPersonas;
            }

            function OnErrorRegistrarPersona(response) {

                window.location.href = requrlError;
            }

        }

    });

    $("#btnCancelarTop").click(function (e) {
        window.location.href = requrlConsultaPersonas;
    });

    $("#btnCancelarBotton").click(function (e) {
        window.location.href = requrlConsultaPersonas;
    });    

});