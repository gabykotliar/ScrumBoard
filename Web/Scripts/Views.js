var Views;
(function (Views) {
    (function (Project) {
        var New = (function () {
            function New(options) {
                this.options = options;
                this.form = $('form');
                this.submit = this.form.find('#submit');
                var self = this;
                this.submit.bind('click', null, function (e) {
                    return self.post(e);
                });
            }
            New.prototype.post = function (event) {
                var self = this;
                var data = this.form.serialize();
                $.ajax(this.options.apiPostUrl, {
                    type: 'POST',
                    data: data,
                    accepts: 'JSON',
                    context: this
                }).success(function (result) {
                    self.successfulPost(result);
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    alert(textStatus);
                });
                return false;
            };
            New.prototype.successfulPost = function (result) {
                window.location.href = this.options.successRedirectUrl + result.Name;
            };
            return New;
        })();
        Project.New = New;        
    })(Views.Project || (Views.Project = {}));
    var Project = Views.Project;

})(Views || (Views = {}));

