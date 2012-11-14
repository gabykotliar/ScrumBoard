var ViewModels;
(function (ViewModels) {
    (function (Project) {
        var NewViewModel = (function () {
            function NewViewModel(options) {
                this.options = options;
                this.form = $('form');
                this.submit = this.form.find('#submit');
                var self = this;
                this.submit.bind('click', null, function (e) {
                    return self.post(e);
                });
            }
            NewViewModel.prototype.post = function (event) {
                var self = this;
                if(!this.form.valid()) {
                    return false;
                }
                var data = this.form.serialize();
                $.ajax(this.options.apiPostUrl, {
                    type: 'POST',
                    data: data,
                    accepts: 'JSON',
                    context: this
                }).success(function (result) {
                    self.successfulPost(result);
                }).error(function (jqXHR, textStatus, errorThrown) {
                    new Utils.ErrorHandler().webApiError(jqXHR, textStatus, errorThrown);
                });
                return false;
            };
            NewViewModel.prototype.successfulPost = function (result) {
                window.location.href = this.options.successRedirectUrl + result.Name;
            };
            return NewViewModel;
        })();
        Project.NewViewModel = NewViewModel;        
    })(ViewModels.Project || (ViewModels.Project = {}));
    var Project = ViewModels.Project;

})(ViewModels || (ViewModels = {}));

