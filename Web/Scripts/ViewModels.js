var __extends = this.__extends || function (d, b) {
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
}
var ViewModels;
(function (ViewModels) {
    (function (Project) {
        var NewResourceViewModel = (function () {
            function NewResourceViewModel(options) {
                this.options = options;
                this.form = $('form');
            }
            NewResourceViewModel.prototype.initialize = function () {
                ko.applyBindings(this);
            };
            NewResourceViewModel.prototype.create = function () {
                if(!this.form.valid()) {
                    return false;
                }
                $.ajax(this.options.apiPostUrl, {
                    type: 'POST',
                    contentType: "application/json;charset=utf-8",
                    data: this.toJSON(),
                    accepts: 'JSON',
                    context: this,
                    success: this.onResourceCreated,
                    error: this.onError
                });
                return false;
            };
            NewResourceViewModel.prototype.toJSON = function () {
                return '{}';
            };
            NewResourceViewModel.prototype.onResourceCreated = function (data, textStatus, jqXHR) {
                alert(jqXHR.statusText);
            };
            NewResourceViewModel.prototype.onError = function (jqXHR, textStatus, errorThrown) {
                new Utils.ErrorHandler().webApiError(jqXHR, textStatus, errorThrown);
            };
            return NewResourceViewModel;
        })();        
        var NewProjectViewModel = (function (_super) {
            __extends(NewProjectViewModel, _super);
            function NewProjectViewModel(options) {
                        _super.call(this, options);
                this.options = options;
                this.Name = ko.observable('');
                this.Vision = ko.observable('');
            }
            NewProjectViewModel.prototype.toJSON = function () {
                return JSON.stringify({
                    Name: this.Name(),
                    Vision: this.Vision()
                });
            };
            NewProjectViewModel.prototype.onResourceCreated = function (data, textStatus, jqXHR) {
                window.location.href = this.options.successRedirectUrl + data.Name;
            };
            return NewProjectViewModel;
        })(NewResourceViewModel);
        Project.NewProjectViewModel = NewProjectViewModel;        
    })(ViewModels.Project || (ViewModels.Project = {}));
    var Project = ViewModels.Project;

})(ViewModels || (ViewModels = {}));

