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

