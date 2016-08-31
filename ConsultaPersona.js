$(document).ready(function () {
    var selectedRows = {};

    init();

    function init() {
        cargarGrilla();
        CargarSexo();
    }
    

    function cargarGrilla() {

        $("#grdPersona").jqGrid({
            url: requrlListarPersonas,
            datatype: 'json',
            //async: false,
            mtype: 'POST',
            postData: {
                dato: function () {

                    var parvNomPer = $("#vNomPer").val();

                    var datojson = JSON.stringify([{
                        "vNomPer": parvNomPer
                    }]);
                    return datojson;
                }
            },
            jsonReader: {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: true
            },
            colNames: [
                'Código',
                'Nombre',
                'ApPaterno',
                'ApMaterno',
                'NumTelefonico',
                'Sexo',
                'Area',
                'Fecha'
            ],
            colModel: [
                { key: true, name: 'iCodPer', index: 'iCodPer', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'vNomPer', index: 'vNomPer', hidden: false, align: "center", width: 150, sortable: false },
                { name: 'vApePat', index: 'vApePat', hidden: false, align: "center", width: 150, sortable: false },
                { name: 'vApeMat', index: 'vApeMat', hidden: false, align: "center", width: 150, sortable: false },
                { name: 'iNumTelefonico', index: 'iNumTelefonico', hidden: false, align: "center", width: 150, sortable: false },
                { name: 'vSexo', index: 'vSexo', hidden: false, align: "center", width: 150, sortable: false },
                { name: 'vArea', index: 'vArea', hidden: false, align: "center", width: 150, sortable: false },
                { name: 'sdFecha', index: 'sdFecha', hidden: false, align: "center", width: 150, sortable: false }
            ],
            rowNum: 10, rowList: [10, 15, 20, 25], pager: '#pagePersona', sortname: 'iCodPer', viewrecords: true, sortorder: "asc",
            height: 285,
            autowidth: true,
            shrinkToFit: false,
            caption: "Resultados - Lista de Personas",
            rownumbers: true,
            reloadAfterEdit: false,
            reloadAfterSubmit: false,
            autoencode: false,
            loadonce: true,
            multiselect: true, onSelectRow: function (rowId, status, e) {
                if (status === false) {
                    delete selectedRows[rowId];
                } else {
                    selectedRows[rowId] = status;
                }
            },
            onSelectAll: function (rowIds, status) {
                if (status === true) {
                    for (var i = 0; i < rowIds.length; i++) {
                        selectedRows[rowIds[i]] = true;
                    }
                } else {
                }

            },
            loadError: function (xhr, st, err) {
                window.location.href = requrlError;
            }
        }).navGrid('#pageSolicitud', { refresh: false, search: false, add: false, edit: false, del: false });
    }

    function CargarSexo() {
        $.getJSON(
               "/Home/obtenerRutaJson",
               {
                   nombreControl: "vSexo"
               },
               function (data) {

                   var slCriterio = $("#vSexo");
                   slCriterio.empty();

                   for (u in data.Sexo.Sexo) {
                       slCriterio.append("<option value=" + data.Sexo.Sexo[u].valor +
                               ">" + data.Sexo.Sexo[u].texto + "</option>");
                   }
               });
    };

    $('#btnBuscar').click(function () {

        $("#grdPersona").trigger("reloadGrid", { fromServer: true, page:1,page:2});
        
        ///***************************************************************************/
        //var page = $("#grdPersonas").getGridParam("page");
        //var rows = $("#grdPersonas").getGridParam("rowNum");
        //var sidx = $("#grdPersonas").getGridParam("sortname");
        //var sord = $("#grdPersonas").getGridParam("sortorder");
        //var _search = true; //BANDERA PARA DETERMINAR SI SE ESTA LANZANDO DESDE LA BUSQUEDA Y PARA QUE NO SE EJECUTE DOS VECES
        ///***************************************************************************/

        //var parvNomPer = $("#vNomPer").val();

        //var datojson = JSON.stringify([{
        //    "vNomPer": parvNomPer
        //}]);

        //$.ajax({
        //    type: "POST",
        //    url: requrlListarPersonas,
        //    //headers: headers,
        //    //data: "{'dato':'" + datojson + "'}",
        //    data: "{'page':'" + page + "','rows':'" + rows + "','sidx':'" + sidx + "','sord':'" + sord + "','_search':'" + _search + "','token':'" + token + "','dato':'" + dato + "'}",
        //    //data: "{'page':'" + page + "','rows':'" + rows + "','sidx':'" + sidx + "','sord':'" + sord + "','_search':'" + _search + "','dato':'" + dato + "'}",
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    success: OnSuccessListarPersonas
        //    //complete: OnSuccessListarPersonas //DE ESTA FORMA SE LLENA LA GRILLA DESDE UN AJAX
        //});

        //function OnSuccessListarPersonas(response) {

        //    $("#grdPersona").trigger("reloadGrid", { fromServer: true, page: 1 });
        //    //$("#grdPersona").jqGrid("clearGridData", true).trigger("reloadGrid");
        //}
        
    });

    $('#btnNuevo').click(function () {
        window.location.href = requrlRegistroPersona;
    });
    

});