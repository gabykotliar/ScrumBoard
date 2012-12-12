/// <reference path="jquery.d.ts" />
/// <reference path="URI.d.ts" />

module Utils 
{ 
    export class ErrorHandler 
    { 
        webApiError(jqXHR: JQueryXHR, textStatus: string, errorThrow: string): any
        { 
            var msg = '[' + jqXHR.status + '] ' + jqXHR.statusText + '\n';

            try {

                msg += new ApiErrorResponse(jqXHR.responseText).toString();

            } catch (e) { }

            alert(msg);
        }
    }

    class ApiErrorResponse
    {
        Message:  string;
        ModelState: any;

        constructor (responseText: string) { 
            var err = <ApiErrorResponse>JSON.parse(responseText);

            this.Message = err.Message;
            this.ModelState = err.ModelState;
        }

        public toString() { 

            var str = this.Message;

            str += '\n\nErrors:' + this.jsonModelStateToString();

            return str;
        }

        private jsonModelStateToString()
        { 
            if (!this.ModelState) return '';
            
            var msg = '';

            for (var prop in this.ModelState)
            { 
                msg += '\n    ' + prop + ':';
                        
                for (var i = 0, len = this.ModelState[prop].length; i < len; i++)
                { 
                    msg += '\n        - ' + this.ModelState[prop][i];
                }                        
            }

            return msg;
        }
    }

    export class UriHelper { 

        private static _current: any;

        private static current() { 
            if (!this._current)
                this._current = new URI(window.location.href);

            return this._current;
        }

        static currentFile() { 
            return this.current().filename();
        }
    }
}