App.role = {

    CargarDatatable: function (dataTableName) {
        var getUrl = window.location;
        var baseUrl = getUrl.protocol + "//" + getUrl.host + "/" + getUrl.pathname.split('/')[1];
        var url = baseUrl + "role/nuevorole";
        var datatable = $("#" + dataTableName);
        var urlajax = datatable.attr["data-ajax"];
        $("#" + dataTableName).DataTable({
            "ajax": urlajax,
            dataSrc: '',
            select: true,
            columns: [
                { data: 'Name' },
                { data: 'Active' },

                {
                    sortable: false,
                    "render": function (data, type, full, meta) {

                        var urlNuevo = App.CreateUrl('/Roles/NuevoRole/');
                        var buttonID = full.tipogasto;
                        return "<a class= 'btn btn-danger glyphicon glyphicon-remove' role='button' onclick='App.role.eliminarRole(" + full.TipoGastoID + ")'></a>" +
                            "<a class= 'btn btn-success glyphicon glyphicon-edit' role='button' onclick='App.role.nuevoRole(\"" + urlNuevo + "\"," + full.TipoGastoID + ")'></a>";




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
    nuevoRole: function (url, id) {
        if (id == undefined) id = 0;
        var containerPopUp = document.createElement("div");
        containerPopUp.id = "container-Role-popup";
        var bdy = document.getElementsByTagName("body");
        console.log(bdy);
        bdy[0].appendChild(containerPopUp);

        $.ajax({
            url: url,
            type: "POST",
            data: { "id": id },
            success: function (response) {
                containerPopUp.innerHTML = response;

                var mdl = $("#modalRole");
                mdl.on('hidden.bs.modal', App.tipogasto.eliminarModal);

                mdl.modal({ "show": 'true' });

                $(document).ready(function () {

                    $("form input").keypress(function (e) {

                        if (e.keyCode == 13) {
                            e.preventDefault();
                            return false;
                        }

                    });
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }


        });

    },
    eliminarRole: function (id) {
        App.Aviso.Open({
            title: 'Confirmación',
            msg: '¿Estas seguro de eliminar?',
            okText: 'Sí',
            cancelText: 'No',
            showBtnCancel: true,
            okCallback: [function (param) {


                $.ajax({
                    url: App.getBaseUrl() + "/role/Eliminar",
                    type: "POST",
                    data: { "id": param.id },
                    success: function (response) {
                        this.id;
                        var mdl = $("#modalRole");
                        mdl.modal("hide");
                        App.tipogasto.eliminarModal();
                        App.tipogasto.ActualizarTabla("tablaRole");
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        App.Aviso.Open({ msg: "No se pudo eliminar, No existe o hay entidades relacionadas", title: "Error: " + errorThrown });

                    }


                });

            },
            { "id": id }
            ]
        });




    },
    eliminarModal: function () {
        $("#modalRole").remove();
    },
    GuardarCambios: function (nuevo) {

        url = (nuevo) ? "Roles/Insert" : "Roles/Edit";

        $.ajax({
            url: url,
            type: "Post",
            data: $("#formRoles").serialize(),


            success: function (response) {
                var mdl = $("#modalRoles");
                mdl.modal("hide");
                App.tipogasto.eliminarModal();
                App.tipogasto.ActualizarTabla("tablaRole");


            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }
        });
    },
    AjaxEliminarRole: function (id) {
        $.ajax({
            url: 'Roles/Delete',
            type: "Post",
            data: { id: id },
            success: function (response) {

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }
        });
    }


};

$(document).ready(function () {

    App.role.CargarDatatable('tablaRole');


})
