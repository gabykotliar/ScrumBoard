/// <reference path="jquery.d.ts" />
/// <reference path="Utils.ts" />

interface ValidatableForm extends JQuery
{
    valid();
}

module ViewModels.Project 
{
    interface NewViewModelConfigurationOptions { apiPostUrl: string; successRedirectUrl: string; }
     
    export class NewViewModel 
    { 
        form: ValidatableForm;
        submit: JQuery;                

        constructor (public options: NewViewModelConfigurationOptions) {             

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
