

App.tipogasto = {

    CargarDatatable: function (dataTableName) {
        var datatable = $("#" + dataTableName);
        var urlajax = datatable.attr["data-ajax"];
        $("#" + dataTableName).dataTable({
            "ajax": urlajax,
            dataSrc:'',
            columns: [
                { data: 'TipoGastoID' },
                { data:'Descripcion'}
            ]
        });
    },

    ActualizarTabla: function (dataTableName) {

        $("#" + dataTableName).ajax.reload();
    },

    nuevoTipo: function(){

        var containerPopUp = document.createElement("div");
        containerPopUp.id = "container-tipogasto-popup";
        var bdy = document.getElementsByTagName("body");
        console.log(bdy);
        bdy[0].appendChild(containerPopUp);
        
        $.ajax({
            url: "/TipoGasto/NuevoTipo",
            type: "POST",
            success: function (response) {
                containerPopUp.innerHTML = response;

                var mdl = $("#modaltipogasto");
                mdl.modal({ "show":'true'})
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }       
            

        });

    }

};

$(document).ready(function () {

    App.tipogasto.CargarDatatable('tablatiposdegasto');
    

})
