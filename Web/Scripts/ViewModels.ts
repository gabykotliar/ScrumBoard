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

        Code: KnockoutComputed;
        Name: KnockoutObservableString;
        Vision: KnockoutObservableString;
        
        private suggestOn = true;
        private code: string;

        constructor (public options: NewProjectViewModelConfigurationOptions) {
            super(options);

            var self = this;

            this.Name = ko.observable('');
            this.Vision = ko.observable('');
            this.Code = ko.computed({ read: self.getCode, 
                                      write: self.setManualCode, 
                                      owner: this });
        }

        toJSON(): string {

            return JSON.stringify({
                Code: this.Code(),
                Name: this.Name(),
                Vision: this.Vision()
            });
        }

        onResourceCreated(data: any, textStatus: string, jqXHR: JQueryXHR) { 
            window.location.href = this.options.successRedirectUrl.replace("[id]", data.Code);
        }

        getCode(): string { 

            if (this.suggestOn) { 
                this.code = this.Name().replace(/[[\]{}()*+?.,\\^$|#\s]+/g, '_');
            };

            return this.code;
        }

        setManualCode(value: any) { 

            this.suggestOn = false;

            this.code = value;
        }
    }

    export class DashboardViewModel { 

        projectName = '';
        projectVision = '';

        initialize() { 

            var self = this;

            $.ajax('/api/project/' + Utils.UriHelper.currentFile(),
            {
                type: 'GET',                
                accepts: 'JSON',
                context: this,
                success: function (project, textStatus, jqXHR) {                                       

                    self.projectName = project.Name;

                    ko.applyBindings(this);

                    document.title = project.Name + ' - Dashboard';
                },
                error: function (jqXHR, textStatus, errorThrown) { 
                    new Utils.ErrorHandler().webApiError(jqXHR, textStatus, errorThrown);
                }
            });
        }
    }
}
