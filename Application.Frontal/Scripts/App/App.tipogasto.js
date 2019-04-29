

App.tipogasto = {

    CargarDatatable: function (dataTableName) {
        var datatable = $("#" + dataTableName);
        var urlajax = datatable.attr["data-ajax"];
        $("#" + dataTableName).DataTable({
            "ajax": urlajax,
            dataSrc: '',
            select: true,
            buttons: [
                'colvis',
                'excel',
                'print'
            ],
            columns: [
                { data: 'TipoGastoID' },
                { data:'Descripcion'}
            ]
        });
        $('#tablatiposdegasto tbody').on('click', 'tr', function () {
            var data = $('#tablatiposdegasto').DataTable().row(this).data();
            App.tipogasto.nuevoTipo(data.TipoGastoID);
        });

    },

    ActualizarTabla: function (dataTableName) {
        $("#" + dataTableName).DataTable().ajax.reload();
       
    },

    nuevoTipo: function(id){
        if (id == undefined) id = 0;
        var containerPopUp = document.createElement("div");
        containerPopUp.id = "container-tipogasto-popup";
        var bdy = document.getElementsByTagName("body");
        console.log(bdy);
        bdy[0].appendChild(containerPopUp);
        
        $.ajax({
            url: "/TipoGasto/NuevoTipo",
            type: "POST",
            data: { "id": id },
            success: function (response) {
                containerPopUp.innerHTML = response;

                var mdl = $("#modaltipogasto");
                mdl.on('hidden.bs.modal', App.tipogasto.eliminarModal);
                
                mdl.modal({ "show": 'true' })
                
    
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }       
            

        });

    },
    eliminarModal: function () {
        $("#modaltipogasto").remove();
    },
    GuardarCambios: function (nuevo) {

        url = (nuevo) ? "TipoGasto/Insert" : "TipoGasto/Edit";

        $.ajax({
            url: url,
            type: "Post",
            data: $("#formtipogasto").serialize(),
            
            
            success: function (response) {
                var mdl = $("#modaltipogasto");
                mdl.modal("hide");
                App.tipogasto.eliminarModal();
                App.tipogasto.ActualizarTabla("tablatiposdegasto");
                
                
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
