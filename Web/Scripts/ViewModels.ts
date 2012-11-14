/// <reference path="jquery.d.ts" />
/// <reference path="knockout-2.2.d.ts" />
/// <reference path="Utils.ts" />

interface ValidatableForm extends JQuery
{
    valid();
}

module ViewModels.Project 
{
    interface NewViewModelConfigurationOptions { apiPostUrl: string; successRedirectUrl: string; }
     
    export class NewProjectViewModel {

        Name = ko.observable('');
        Vision = ko.observable('');

        private form: ValidatableForm;

        constructor (public options: NewViewModelConfigurationOptions) {

            this.form = <ValidatableForm>$('form');
        }

        create(): bool {

            if (!this.form.valid()) return false;

            var self = this;

            $.ajax(this.options.apiPostUrl,
            {
                type: 'POST',
                contentType: "application/json;charset=utf-8",
                data: this.toJSON(),
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

        toJSON(): string {

            return JSON.stringify({
                Name: this.Name(),
                Vision: this.Vision()
            });
        }

        successfulPost(result: any): void {
            window.location.href = this.options.successRedirectUrl + result.Name;
        }        
    }
}
