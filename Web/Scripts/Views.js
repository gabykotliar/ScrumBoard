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
            New.prototype.successfulPost = function (result) {
                window.location.href = this.options.successRedirectUrl + result.Name;
            };
            return New;
        })();
        Project.New = New;        
    })(Views.Project || (Views.Project = {}));
    var Project = Views.Project;

})(Views || (Views = {}));

var Utils;
(function (Utils) {
    var ErrorHandler = (function () {
        function ErrorHandler() { }
        ErrorHandler.prototype.webApiError = function (jqXHR, textStatus, errorThrow) {
            var msg = '[' + jqXHR.status + '] ' + jqXHR.statusText + '\n';
            try  {
                msg += new ApiErrorResponse(jqXHR.responseText).toString();
            } catch (e) {
            }
            alert(msg);
        };
        return ErrorHandler;
    })();
    Utils.ErrorHandler = ErrorHandler;    
    var ApiErrorResponse = (function () {
        function ApiErrorResponse(responseText) {
            var err = JSON.parse(responseText);
            this.Message = err.Message;
            this.ModelState = err.ModelState;
        }
        ApiErrorResponse.prototype.toString = function () {
            var str = this.Message;
            str += '\n\nErrors:' + this.jsonModelStateToString();
            return str;
        };
        ApiErrorResponse.prototype.jsonModelStateToString = function () {
            if(!this.ModelState) {
                return '';
            }
            var msg = '';
            for(var prop in this.ModelState) {
                msg += '\n    ' + prop + ':';
                for(var i = 0, len = this.ModelState[prop].length; i < len; i++) {
                    msg += '\n        - ' + this.ModelState[prop][i];
                }
            }
            return msg;
        };
        return ApiErrorResponse;
    })();    
})(Utils || (Utils = {}));

