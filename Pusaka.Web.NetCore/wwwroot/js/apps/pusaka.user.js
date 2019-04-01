Current = {};
var l;
var options = {};
var attachment = {};

Dropzone.autoDiscover = false;

$(document).ready(function () {
    Users.Init();
    Users.Table();
    Users.BindTable();
});

var Users = {
    Init: function () {
        $('#divTransaction').hide();

        $('.datepicker').datepicker({
            format: 'dd/mm/yyyy',
            orientation: 'bottom'
        }).on('changeDate', function (ev) {
            if ($(this).val() !== "") {
                var date = ev.date.getMonth() + 1 + "/" + ev.date.getDate() + "/" + ev.date.getFullYear();
                $(this).attr('data-val', date);
            }
        });

        $("#formTransaction").validate({
            rules: {
                inputFullName: "required",
                inputInitialName: "required",
                inputUserName: "required",
                inputPassword: {
                    required: function (element) {
                        return $("#inputPassword").val() !== "";
                    },
                    minlength: 5
                },
                inputEmailAddress: {
                    required: true,
                    email: true
                },
                inputConfirmPassword: {
                    required: function (element) {
                        return $("#inputPassword").val() !== "";
                    },
                    equalTo: "#inputPassword"
                }
            },
            errorPlacement: function (error, element) {
                error.appendTo(element.parent());
            }
        });

        options.placeholder = 'Search Role';
        bs.select2.roles('#inputRole', options);

        $('#buttonSubmit').unbind().click(function () {
            l = Ladda.create(this);

            if ($("#formTransaction").validate().form()) {
                l.start();
                Form.Submit();
            }
        });

        $('#buttonCancel').unbind().click(function () {
            $('#divSummary').show('slow');
            $('#divTransaction').hide('slow');
            bs.utility.clearForm('formTransaction');
        });

        $('#buttonAdd').unbind().click(function () {
            $('#addModal').modal('show');
            $("#formTransaction").validate().resetForm();
            Form.Init.Create();
        });

        $('#inputUploadPhoto').dropzone({
            url: bs.configuration.webApiUrl + "/api/v1/shared/upload/photo",
            autoProcessQueue: true,
            paramName: "file",
            clickable: true,
            maxFilesize: 5, //in mb
            addRemoveLinks: true,
            maxFiles: 1,
            acceptedFiles: '.png,.jpg',
            dictDefaultMessage: "Upload your photo here",
            renameFile: 'photouser',
            thumbnailWidth: 240,
            thumbnailHeight: 400,
            uploadMultiple: false,
            init: function () {
                this.on("sending", function (file, xhr, formData) {

                });
                this.on("success", function (file, responseText) {
                    attachment = file;
                });
                this.on("addedfile", function (file) {
                    if (this.files.length > 1) {
                        this.removeFile(this.files[0]);
                    }
                });
                this.on("reset", function () {
                    attachment = {};
                });
            }
        });
    },
    Table: function () {
        $('#tableSummary').DataTable({
            "oLanguage": {
                "sEmptyTable": "No data available"
            },
            "columnDefs": [
                { orderable: false, targets: 0 }
            ],
            "order": [[2, "asc"]],
            "bLengthChange": false,
            "bFilter": true,
            "data": [],
            "scrollX": true,
            "columns": [
                {
                    data: null, render: function (data, type, row) {
                        return '<div class="d-flex"><button type="button" class="btn btn-sm u-btn-indigo" id="btnEdit"><i class="fas fa-pencil-alt"></i></button>' +
                            '<button type="button" class="btn btn-sm u-btn-lightred ml-1" id="btnDelete"><i class="fas fa-trash-alt"></i></button></div>';
                    },
                    width: "70px"
                },
                { data: "userId", visible: false },
                { data: "userName" },
                { data: "fullName" },
                { data: "emailAddress" },
                { data: "roleName" },
                { data: "statusName" }
            ]
        });

        $('#tableSummary tbody').on('click', 'button#btnEdit', function () {
            var data = $('#tableSummary').DataTable().row($(this).parents('tr')).data();
            Current.Selected = data;

            $('#divSummary').hide('slow');
            $('#divTransaction').show('slow');

            Form.Init.Edit();
        });

        $('#tableSummary tbody').on('click', 'button#btnDelete', function () {
            var data = $('#tableSummary').DataTable().row($(this).parents('tr')).data();
            Current.Selected = data;

            options.labelOK = 'Yes';
            options.labelCancel = 'No';
            bs.MessageBox.confirm(
                'Are you sure want to delete this' + (Current.Selected ? Current.Selected.userName : 'this') + ' ?',
                'Delete Confirmation',
                Form.Delete,
                options
            );
        });

        $(window).resize(function () {
            $("#tableSummary").DataTable().columns.adjust().draw();
        });
    },
    BindTable: function () {
        var getFunc = Data.Get();

        $.when(getFunc).then(function (result) {
            var table = $('#tableSummary').DataTable();
            table.clear().rows.add(result).draw();
        });
    }
};

var Form = {
    Init: {
        Create: function () {

            Current.IsNew = true;

            bs.utility.clearForm('formTransaction');
            Dropzone.forElement("#inputUploadPhoto").removeAllFiles(true);
            $('#inputRole').val(null).trigger('change');
            $('#inputStatus').prop('checked', true);
        },
        Edit: function () {

            Current.IsNew = false;

            Dropzone.forElement("#inputUploadPhoto").removeAllFiles(true);

            Dropzone.forElement("#inputUploadPhoto").emit("addedfile", Current.Selected.PhotoPath);
            Dropzone.forElement("#inputUploadPhoto").emit("thumbnail", Current.Selected.PhotoPath, '/BillingSystem/img/photo');
            Dropzone.forElement("#inputUploadPhoto").emit("complete", Current.Selected.PhotoPath);

            $('#inputId').val(Current.Selected.userId);
            $('#inputUserName').val(Current.Selected.userName);
            $('#inputInitialName').val(Current.Selected.initialName);
            $('#inputFullName').val(Current.Selected.fullName);
            $('#inputBirthDate').val(Current.Selected.birthDate === null ? '' : moment(Current.Selected.birthDate).format('DD/MM/YYYY'));
            $('#inputBirthDate').attr('data-val', Current.Selected.birthDate === null ? '' : moment(Current.Selected.birthDate).format('MM/DD/YYYY'));
            $('#inputDomainEmail').val(Current.Selected.domainEmail);
            $('#inputEmailAddress').val(Current.Selected.emailAddress);
            $('#inputPassword').val(Current.Selected.password);
            $('#inputConfirmPassword').val(Current.Selected.password);
            Current.Selected.status === 1 ? $('#inputStatus').prop('checked', true) : $('#inputStatus').prop('checked', false);

            $('#inputRole').select2("trigger", "select", {
                data: { id: Current.Selected.roleCode, text: Current.Selected.roleName }
            });
        }
    },
    Submit: function () {
        if (Current.IsNew) {
            Data.Post();
        } else {
            Data.Put();
        }
    },
    Delete: function () {
        Data.Delete();
    }
};

var Data = {
    Get: function () {
        var params = {
            "name": ""
        };

        var dfd = new $.Deferred();

        $.ajax({
            url: bs.configuration.webApiUrl + '/api/v1/administration/users',
            data: JSON.stringify(params),
            type: 'POST',
            suppressProgressBar: true,
            suppressErrorMessageBox: true
        }).done(function (data, textStatus, jqXHR) {
            dfd.resolve(data);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            window.console && console.log(textStatus + '|' + errorThrown + '|' + textStatus + '|' + errorThrown);
            dfd.reject('Error when getting making ajax calls: ' + textStatus + '|' + errorThrown);
        });

        return dfd.promise();
    },
    Post: function () {
        var params = Data.PostParams();

        bs.utility.webAjax('/api/v1/administration/user/create', 'POST', params, Transaction);

        $('#tableSummary').DataTable().columns.adjust().draw();
    },
    Put: function () {
        var params = Data.PostParams();

        bs.utility.webAjax('/api/v1/administration/user/update', 'POST', params, Transaction);

        $('#tableSummary').DataTable().columns.adjust().draw();
    },
    Delete: function () {
        $.ajax({
            url: bs.configuration.webApiUrl + '/api/v1/administration/user/' + Current.Selected.userId,
            type: 'DELETE',
            suppressProgressBar: true,
            suppressErrorMessageBox: true
        }).done(function (data, textStatus, jqXHR) {
            Settings.BindTable();
        }).fail(function (jqXHR, textStatus, errorThrown) {
            window.console && console.log(textStatus + '|' + errorThrown + '|' + textStatus + '|' + errorThrown);
        });
    },
    PostParams: function () {
        var substr = $('#inputEmailAddress').val().lastIndexOf('@');
        var domainName = $('#inputEmailAddress').val().substring(substr + 1);

        var data = {
            UserId: $('#inputId').val(),
            UserName: $('#inputUserName').val(),
            InitialName: $('#inputInitialName').val(),
            FullName: $('#inputFullName').val(),
            BirthDate: $('#inputBirthDate').attr('data-val') || "",
            DomainEmail: domainName,
            EmailAddress: $('#inputEmailAddress').val(),
            Password: $('#inputPassword').val(),
            Status: $('#inputStatus').prop('checked') === true ? 1 : 0,
            RoleCode: $('#inputRole').val(),
            PhotoPath: attachment.upload.filename || ''
        };

        return data;
    }
};

var Transaction = {
    done: function (data, textStatus, jqXHR) {
        if (Current.Selected)
            Current.Selected = null;

        bs.utility.setFormDisabled('formTransaction', false);
        Users.BindTable();
        l.stop();

        $('#divSummary').show('slow');
        $('#divTransaction').hide('slow');
    },
    fail: function (jqXHR, textStatus, errorThrown) {
        bs.utility.setFormDisabled('formTransaction', false);
        l.stop();
    },
    beforeSend: function (xhr) {
        bs.utility.setFormDisabled('formTransaction', true);
        l.start();
    }
};