var ViewModels;
(function (ViewModels) {
    (function (Project) {
        var NewProjectViewModel = (function () {
            function NewProjectViewModel(options) {
                this.options = options;
                this.Name = ko.observable('');
                this.Vision = ko.observable('');
                this.form = $('form');
            }
            NewProjectViewModel.prototype.create = function () {
                if(!this.form.valid()) {
                    return false;
                }
                var self = this;
                $.ajax(this.options.apiPostUrl, {
                    type: 'POST',
                    contentType: "application/json;charset=utf-8",
                    data: this.toJSON(),
                    accepts: 'JSON',
                    context: this
                }).success(function (result) {
                    self.successfulPost(result);
                }).error(function (jqXHR, textStatus, errorThrown) {
                    new Utils.ErrorHandler().webApiError(jqXHR, textStatus, errorThrown);
                });
                return false;
            };
            NewProjectViewModel.prototype.toJSON = function () {
                return JSON.stringify({
                    Name: this.Name(),
                    Vision: this.Vision()
                });
            };
            NewProjectViewModel.prototype.successfulPost = function (result) {
                window.location.href = this.options.successRedirectUrl + result.Name;
            };
            return NewProjectViewModel;
        })();
        Project.NewProjectViewModel = NewProjectViewModel;        
    })(ViewModels.Project || (ViewModels.Project = {}));
    var Project = ViewModels.Project;

})(ViewModels || (ViewModels = {}));

