App.gasto = App.gasto || {};

App.gasto.CargarTabla = function(dataTableName){


        var datatable = $("#" + dataTableName);
        var urlajax = datatable.attr["data-ajax"];
        $("#" + dataTableName).DataTable({
        	"ajax": urlajax,
        	dataSrc: '',
        	select: true,
        	columns: [
                { data: 'Descripcion' },
                { data: 'Fecha' },
				{ data: 'Importe' },
				{data:'TipoGasto.Descripcion'},

                {
                	sortable: false,
                	"render": function (data, type, full, meta) {
                		var buttonID = full.tipogasto;
                		return "<a class= 'btn btn-danger glyphicon glyphicon-remove' role='button' onclick='App.tipogasto.eliminarTipo(" + full.TipoGastoID + ")'></a>" +
                            "<a class= 'btn btn-success glyphicon glyphicon-edit' role='button' onclick='App.tipogasto.nuevoTipo(" + full.TipoGastoID + ")'></a>";




                	}
                },
        	]
        });
        

};

$(document).ready(function () {
	App.gasto.CargarTabla('tablagastos')

});