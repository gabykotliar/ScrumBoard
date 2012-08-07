using ScrumBoard.Specs.Helpers;
using TechTalk.SpecFlow;

namespace ScrumBoard.Specs.Steps
{
    [Binding]
    public class GenericSteps
    {
        public static void StoreEntityForCurrentScenario(object entity)
        {
            ScenarioContext.Current.Add("entity", entity);
        }

        [Then(@"It should have a unique key")]
        public void ItShouldHaveAUniqueKey()
        {
            var entity = ScenarioContext.Current["entity"];

            var validator = new PropertyValidator<int>("Id", entity);

            validator.CheckExistance();
            validator.CheckIfVirtual();
            validator.CheckStandardSetAndGetBehaviour();
        }
    }
}
