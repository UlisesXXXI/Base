const App = (function () {

    var application = {};

    //Methods for Popup
    application.Aviso = {
        element: 'e94bfecd-9617-48ae-b845-28d31c754042',
        sufixContainer: '_container',
        sufixBody: '_body',
        sufixTittle: '_tittle',
        sufixButtonOk: '_ok_button',
        sufixCancelButton: '_cancel_button',
        template: `<div id="{{element}}" class="modal fade" role="dialog">
                                 <div class="modal-dialog">
                                       <!-- Modal content-->
                                       <div class="modal-content">
                                          <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                <h4 class="modal-title" id="{{tittle}}">{{title_text}}</h4>
                                           </div>
                                           <div class="modal-body" id="{{body}}">
                                                <p>{{body_text}}</p>
                                           </div>
                                           <div class="modal-footer">
                                               <button type="button" class="btn btn-success" data-dismiss="modal" id="{{okbutton}}">{{ok_text}}}</button>
                                               <button type="button" class="btn btn-default" data-dismiss="modal" id="{{cancelbutton}}">{{cancel_text}}</button>
                                           </div>
                                       </div>

                                     </div>
                                </div>`,

        Open: function (prop) {
            prop = prop || {};
            //Build default properties
            var prop_with_defaults = {
                showBtnOK: prop.showBtnOK || true,
                showBtnCancel: prop.showBtnCancel || false,
                title: prop.title || '...',
                msg: prop.msg || '...',
                okCallback: prop.okCallback,
                cancelCallback: prop.cancelCallback,
                okText: prop.okText || 'Ok',
                cancelText: prop.cancelText || 'Cancel'
            };


            //Build the PopUp template
            var bodyTemplate = this.template.replace('{{element}}', this.element);
            bodyTemplate = bodyTemplate.replace('{{tittle}}', this.element + this.sufixTittle);
            bodyTemplate = bodyTemplate.replace('{{body}}', this.element + this.sufixBody);
            bodyTemplate = bodyTemplate.replace('{{cancelbutton}}', this.element + this.sufixCancelButton);
            bodyTemplate = bodyTemplate.replace('{{okbutton}}', this.element + this.sufixButtonOk);
            bodyTemplate = bodyTemplate.replace('{{ok_text}}', prop_with_defaults.okText);
            bodyTemplate = bodyTemplate.replace('{{cancel_text}}', prop_with_defaults.cancelText);
            bodyTemplate = bodyTemplate.replace('{{title_text}}', prop_with_defaults.title);
            bodyTemplate = bodyTemplate.replace('{{body_text}}', prop_with_defaults.msg);

            //Bild the container if not exists
            var container = document.getElementById(this.element + this.sufixContainer);
            if (!container) {
                container = document.createElement("div");
                container.setAttribute('id', this.element + this.sufixContainer);
                var body = document.getElementsByTagName("body");

                body[0].appendChild(container);

            }




            //Inject the PopUP in the container 
            container.innerHTML = bodyTemplate;


            //configure buttons    
            this.ConfigureButtons(this.element + this.sufixButtonOk, prop_with_defaults.showBtnOK, prop_with_defaults.okCallback, prop_with_defaults.okText);
            this.ConfigureButtons(this.element + this.sufixCancelButton, prop_with_defaults.showBtnCancel, prop_with_defaults.cancelCallback, prop_with_defaults.cancelText);

            //Show Modal
            $("#" + this.element).modal({ show: true, backdrop: 'static' });

            //add event when modal hidden to remove it
            $('#' + this.element).on('hidden.bs.modal', function (e) {
                var el = document.getElementById(App.Aviso.element + App.Aviso.sufixContainer);

                ; el.remove();

            })


        },
        ConfigureButtons(elementID, show, callback, texto) {
            var btn = document.getElementById(elementID);

            if (!show) {
                btn.remove();
            } else {
                btn.innerHTML = texto;
                if (callback || typeof callback === 'function') {
                    btn.addEventListener('click', function () {
                        fn = callback[0];
                        param = callback[1];
                        fn(param);
                    });
                }
            }
        }
    }

    //Methos for Spinner 
    application.Spinner = {
        element: 'c9221cec-e496-4546-a356-55c1a770d477',
        template: `
                                        <div  style="width: 100%;height: 100%; background-color:black;position: absolute; z-index: 9999998; opacity: 0.4; top: 0px; left: 0px" >
                                            <div class="sk-cube-grid" style="top: 30%; position: absolute; left: 50%; z-index: 9999999; opacity: 1.0;" >
                                                <div class="sk-cube sk-cube1" style="background: red"></div>
                                                <div class="sk-cube sk-cube2" style="background: rgb(92, 92, 131)"></div>
                                                <div class="sk-cube sk-cube3" style="background: green"></div>
                                                <div class="sk-cube sk-cube4" style="background:yellowgreen"></div>
                                                <div class="sk-cube sk-cube5" style="background: tomato"></div>
                                                <div class="sk-cube sk-cube6" style="background:wheat"></div>
                                                <div class="sk-cube sk-cube7" style="background:steelblue"></div>
                                                <div class="sk-cube sk-cube8" style="background:floralwhite"></div>
                                                <div class="sk-cube sk-cube9"></div>
                                            </div>
                                        </div>`,
        Start: function () {
            var cont = document.createElement("div");
            cont.id = this.element;
            var bodytemplate = this.template
            cont.innerHTML = bodytemplate;
            var body = document.getElementsByTagName('body');
            body[0].appendChild(  cont);
            $("#" + this.element).fadeIn();

        },
        Stop: function () {
            $("#" + this.element).fadeOut(200, function () {
                this.remove();
            });
        }


    }

    $(document).ajaxStart(function () {
        App.Spinner.Start();
    });

    $(document).ajaxStop(function () {
        App.Spinner.Stop();
    });


    return application;

})();

