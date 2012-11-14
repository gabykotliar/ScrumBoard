/// <reference path="jquery.d.ts" />

interface ValidatableForm extends JQuery
{
    valid();
}

module Views.Project 
{
    interface NewConfigurationOptions { apiPostUrl: string; successRedirectUrl: string; }
     
    export class New 
    { 
        form: ValidatableForm;
        submit: JQuery;                

        constructor (public options: NewConfigurationOptions) {             

            this.form = <ValidatableForm>$('form');
            this.submit = this.form.find('#submit');

            var self = this;

            this.submit.bind('click', null, function (e) {
                return self.post(e);
            });
        }

        post(event:JQueryEventObject): bool { 

            var self = this;

            if (!this.form.valid()) return false;

            var data = this.form.serialize();

            $.ajax(this.options.apiPostUrl,
            {
                type: 'POST',
                data: data,                
                accepts: 'JSON',
                context: this
            })
            .success(function (result) {
                self.successfulPost(result);
            })
            .error(function (jqXHR, textStatus, errorThrown) {
                new Utils.ErrorHandler().webApiError(jqXHR, textStatus, errorThrown);
            });            

            return false; //cancel default event
        }

        successfulPost(result: any): void 
        { 
            window.location.href = this.options.successRedirectUrl + result.Name;            
        }
    }
}

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
}