

App.tipogasto = {

    CargarDatatable: function (dataTableName) {
        var getUrl = window.location;
        var baseUrl = getUrl.protocol + "//" + getUrl.host + "/" + getUrl.pathname.split('/')[1];
        var url = baseUrl + "TipoGasto/NuevoTipo";
        var datatable = $("#" + dataTableName);
        var urlajax = datatable.attr["data-ajax"];
        $("#" + dataTableName).DataTable({
            "ajax": urlajax,
            dataSrc: '',
            select: true,
            columns: [
                { data: 'TipoGastoID' },
                { data: 'Descripcion' },
               
                {
                    sortable: false,
                    "render": function (data, type, full, meta) {
                        var buttonID = full.tipogasto;
                        return "<a class= 'btn btn-danger glyphicon glyphicon-remove' role='button' onclick='App.tipogasto.eliminarTipo(" + full.TipoGastoID + ")'></a>" +
                            "<a class= 'btn btn-success glyphicon glyphicon-edit' role='button' onclick='App.tipogasto.nuevoTipo('"+url + "',"+ full.TipoGastoID + ")'></a>";
                                


                            
                    }
                },
            ]
        });
        //$('#tablatiposdegasto tbody').on('click', 'tr', function () {
        //    var data = $('#tablatiposdegasto').DataTable().row(this).data();
        //    App.tipogasto.nuevoTipo(data.TipoGastoID);
        //});

    },

    ActualizarTabla: function (dataTableName) {
        $("#" + dataTableName).DataTable().ajax.reload();
       
    },
    nuevoTipo: function(url,id){
        if (id == undefined) id = 0;
        var containerPopUp = document.createElement("div");
        containerPopUp.id = "container-tipogasto-popup";
        var bdy = document.getElementsByTagName("body");
        console.log(bdy);
        bdy[0].appendChild(containerPopUp);
        
        $.ajax({
            url: url,
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
    eliminarTipo: function (id) {
        App.Aviso.Open({
            title: 'Confirmación',
            msg: '¿Estas seguro de eliminar?',
            okText: 'Sí',
            cancelText: 'No',
            showBtnCancel: true,
            okCallback: [function (param)
            {
                                       

                                        $.ajax({
                                            url: App.getBaseUrl() +  "/TipoGasto/Eliminar",
                                            type: "POST",
                                            data: { "id": param.id },
                                            success: function (response) {
                                                this.id;
                                                var mdl = $("#modaltipogasto");
                                                mdl.modal("hide");
                                                App.tipogasto.eliminarModal();
                                                App.tipogasto.ActualizarTabla("tablatiposdegasto");
                                            },
                                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                                App.Aviso.Open({ msg:"No se pudo eliminar, No existe o hay entidades relacionadas", title: "Error: " + errorThrown });
                                                
                                            }


                                        });

                                     },
                {"id":id}
                            ]
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
      },

    AjaxEliminarTipoGasto :function (id) {
        $.ajax({
            url: 'TipoGasto/Insert',
            type: "Post",
            data: {id:id},
            success: function (response) {
               
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
