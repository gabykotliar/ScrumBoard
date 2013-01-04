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
                this.suggestOn = true;
                var self = this;
                this.Name = ko.observable('');
                this.Vision = ko.observable('');
                this.Code = ko.computed({
                    read: self.getCode,
                    write: self.setManualCode,
                    owner: this
                });
            }
            NewProjectViewModel.prototype.toJSON = function () {
                return JSON.stringify({
                    Code: this.Code(),
                    Name: this.Name(),
                    Vision: this.Vision()
                });
            };
            NewProjectViewModel.prototype.onResourceCreated = function (data, textStatus, jqXHR) {
                window.location.href = this.options.successRedirectUrl.replace("[id]", data.Name);
            };
            NewProjectViewModel.prototype.getCode = function () {
                if(this.suggestOn) {
                    this.code = this.Name().replace(/[[\]{}()*+?.,\\^$|#\s]+/g, '_');
                }
                ; ;
                return this.code;
            };
            NewProjectViewModel.prototype.setManualCode = function (value) {
                this.suggestOn = false;
                this.code = value;
            };
            return NewProjectViewModel;
        })(NewResourceViewModel);
        Project.NewProjectViewModel = NewProjectViewModel;        
        var DashboardViewModel = (function () {
            function DashboardViewModel() {
                this.projectName = '';
                this.projectVision = '';
            }
            DashboardViewModel.prototype.initialize = function () {
                var self = this;
                $.ajax('/api/project/' + Utils.UriHelper.currentFile(), {
                    type: 'GET',
                    accepts: 'JSON',
                    context: this,
                    success: function (project, textStatus, jqXHR) {
                        self.projectName = project.Name;
                        ko.applyBindings(this);
                        document.title = project.Name + ' - Dashboard';
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        new Utils.ErrorHandler().webApiError(jqXHR, textStatus, errorThrown);
                    }
                });
            };
            return DashboardViewModel;
        })();
        Project.DashboardViewModel = DashboardViewModel;        
    })(ViewModels.Project || (ViewModels.Project = {}));
    var Project = ViewModels.Project;

})(ViewModels || (ViewModels = {}));

