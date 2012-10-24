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

            // if (!this.form.valid()) return false;

            var data = this.form.serialize();

            $.ajax(this.options.apiPostUrl,
            //$.ajax('/project/new',
            {
                type: 'POST',
                data: data,                
                accepts: 'JSON',
                context: this
            })
            .success(function (result) {
                self.successfulPost(result);
            })
            .fail(function (jqXHR, textStatus, errorThrown) {
                alert(textStatus);
            });

            return false; //cancel default event
        }

        successfulPost(result: any): void 
        { 
            window.location.href = this.options.successRedirectUrl + result.Name;            
        }
    }
}