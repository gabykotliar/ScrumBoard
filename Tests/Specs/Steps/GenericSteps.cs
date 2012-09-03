using System;
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

        private static void ThenIShouldBeAbleToAssignAnAsType<T>(string propertyName)
        {
            var entity = ScenarioContext.Current["entity"];

            var validator = new PropertyValidator<T>(propertyName, entity);

            validator.CheckExistance();
            validator.CheckStandardSetAndGetBehaviour();
        }

        [Then(@"I should be able to assign a '(.*)' as a number with no decimal places")]
        public void ThenIShouldBeAbleToAssignAnAsInteger(string propertyName)
        {
            ThenIShouldBeAbleToAssignAnAsType<int>(propertyName);
        }

        [Then(@"I should be able to assign a '(.*)' as a number with decimal places")]
        public void ThenIShouldBeAbleToAssignAnAsDouble(string propertyName)
        {
            ThenIShouldBeAbleToAssignAnAsType<double>(propertyName);
        }

        [Then(@"I should be able to assign a '(.*)' as a date")]
        public void ThenIShouldBeAbleToAssignAnAsDate(string propertyName)
        {
            ThenIShouldBeAbleToAssignAnAsType<DateTime>(propertyName);
        }

        [Then(@"I should be able to assign a '(.*)' as a text")]
        public void ThenIShouldBeAbleToAssignAnAsString(string propertyName)
        {
            ThenIShouldBeAbleToAssignAnAsType<string>(propertyName);
        }
    }
}
