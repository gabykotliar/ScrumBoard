describe("When creating projects", function() {

    beforeEach(function () {

    });

    it("create should be called", function () {
        
        setFixtures('<input id="submit" data-bind="click: create" type="button" value="Create" />');
        
        var viewModel = new ViewModels.Project.NewProjectViewModel({
        });

        spyOn(viewModel, 'create');

        viewModel.initialize();

        $("#submit").click();

        expect(viewModel.create).toHaveBeenCalled();
    });
});