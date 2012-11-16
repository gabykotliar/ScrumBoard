/// <reference path="jquery.d.ts" />
/// <reference path="knockout-2.2.d.ts" />
/// <reference path="Utils.ts" />

interface ValidatableForm extends JQuery
{
    valid();
}

module ViewModels.Project 
{
    interface NewViewModelConfigurationOptions { apiPostUrl: string; }

    class NewResourceViewModel { 

        form: ValidatableForm;

        constructor (public options: NewViewModelConfigurationOptions) {
            this.form = <ValidatableForm>$('form');
        }

        initialize() { 
            ko.applyBindings(this);
        }

        create(): bool {

            if (!this.form.valid()) return false;

            $.ajax(this.options.apiPostUrl,
            {
                type: 'POST',
                contentType: "application/json;charset=utf-8",
                data: this.toJSON(),
                accepts: 'JSON',
                context: this,
                success: this.onResourceCreated,
                error: this.onError
            });

            return false; //cancel default event
        }

        toJSON(): string {
            return '{}';
        }

        onResourceCreated(data: any, textStatus: string, jqXHR: JQueryXHR) { 
            alert(jqXHR.statusText);
        }

        onError(jqXHR: JQueryXHR, textStatus: string, errorThrown: string): any { 
            new Utils.ErrorHandler().webApiError(jqXHR, textStatus, errorThrown);
        }
    }
    
    interface NewProjectViewModelConfigurationOptions 
        extends NewViewModelConfigurationOptions 
    { 
        successRedirectUrl: string; 
    }
     
    export class NewProjectViewModel 
        extends NewResourceViewModel {

        Name = ko.observable('');
        Vision = ko.observable('');

        constructor (public options: NewProjectViewModelConfigurationOptions) {
            super(options);
        }

        toJSON(): string {

            return JSON.stringify({
                Name: this.Name(),
                Vision: this.Vision()
            });
        }

        onResourceCreated(data: any, textStatus: string, jqXHR: JQueryXHR) { 
            window.location.href = this.options.successRedirectUrl + data.Name;
        }
    }
}
