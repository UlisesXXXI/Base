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
                {
                    data: 'Fecha',
                    "render": function (data, type, row) {
                        if (type === "sort" || type === "type") {
                            return data;
                        }
                        return  moment(data).format("DD/MM/YYYY");
                    }
                },
                {
                    data: 'Importe',
                    render: function (data, type, row) {

                        return data.toLocaleString();
                    }
                        },
				{data:'TipoGasto.Descripcion'},

                {
                	sortable: false,
                	"render": function (data, type, full, meta) {
                        var buttonID = full.tipogasto;
                        var url = App.CreateUrl('/Gasto/Detail/' + full.Id);
                		return "<a class= 'btn btn-danger glyphicon glyphicon-remove' role='button' onclick='App.gasto.eliminarGasto(" + full.TipoGastoID + ")'></a>" +
                            "<a class= 'btn btn-success glyphicon glyphicon-edit' role='button' onclick=\"App.Redireccionar('"+url+"')\"></a>";




                	}
                },
        	]
        });
        

};
App.gasto.ActualizarTabla = function (dataTableName) {
    $("#" + dataTableName).DataTable().ajax.reload();
}
App.gasto.eliminarGasto = function (id) {
    App.Aviso.Open({
        title: 'Confirmación',
        msg: '¿Estas seguro de eliminar?',
        okText: 'Sí',
        cancelText: 'No',
        showBtnCancel: true,
        okCallback: [function (param) {


            $.ajax({
                url: App.getBaseUrl() + "/Gasto/Eliminar",
                type: "POST",
                data: { "id": param.id },
                success: function (response) {
                    
                    App.Aviso.Close();
                    App.gasto.ActualizarTabla("tablagastos");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("Status: " + textStatus); alert("Error: " + errorThrown);
                }


            });

        },
        { "id": id }
        ]
    });




},

$(document).ready(function () {
    App.gasto.CargarTabla('tablagastos');

});