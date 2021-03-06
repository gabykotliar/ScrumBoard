﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.17929
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ScrumBoard.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class VelocityFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Velocity.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Velocity", "In order to measure the productivity of the team\r\nI want to be able to measure th" +
                    "e Velocity of the team\r\nThat is defined as the sum of the commited effort for th" +
                    "e completed stories in a sprint", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Velocity")))
            {
                ScrumBoard.Specs.VelocityFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("An empty sprint has a velocity of 0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Velocity")]
        public virtual void AnEmptySprintHasAVelocityOf0()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("An empty sprint has a velocity of 0", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Effort",
                        "IsDone"});
#line 7
 testRunner.Given("A sprint with the following stories", ((string)(null)), table1, "Given ");
#line 9
 testRunner.Then("the Velocity should be 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("An sprint with all stories undone has a velocity of 0")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Velocity")]
        public virtual void AnSprintWithAllStoriesUndoneHasAVelocityOf0()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("An sprint with all stories undone has a velocity of 0", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Effort",
                        "IsDone"});
            table2.AddRow(new string[] {
                        "1",
                        "false"});
            table2.AddRow(new string[] {
                        "2",
                        "false"});
            table2.AddRow(new string[] {
                        "5",
                        "false"});
#line 12
 testRunner.Given("A sprint with the following stories", ((string)(null)), table2, "Given ");
#line 17
 testRunner.Then("the Velocity should be 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("An sprint with done and undone stories")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Velocity")]
        public virtual void AnSprintWithDoneAndUndoneStories()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("An sprint with done and undone stories", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Effort",
                        "IsDone"});
            table3.AddRow(new string[] {
                        "1",
                        "false"});
            table3.AddRow(new string[] {
                        "2",
                        "true"});
            table3.AddRow(new string[] {
                        "5",
                        "true"});
            table3.AddRow(new string[] {
                        "4",
                        "false"});
            table3.AddRow(new string[] {
                        "0.5",
                        "true"});
#line 20
 testRunner.Given("A sprint with the following stories", ((string)(null)), table3, "Given ");
#line 27
 testRunner.Then("the Velocity should be 7.5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("An sprint with all stories done")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Velocity")]
        public virtual void AnSprintWithAllStoriesDone()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("An sprint with all stories done", ((string[])(null)));
#line 29
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Effort",
                        "IsDone"});
            table4.AddRow(new string[] {
                        "1",
                        "true"});
            table4.AddRow(new string[] {
                        "2",
                        "true"});
            table4.AddRow(new string[] {
                        "5",
                        "true"});
            table4.AddRow(new string[] {
                        "4",
                        "true"});
            table4.AddRow(new string[] {
                        "0.5",
                        "true"});
#line 30
 testRunner.Given("A sprint with the following stories", ((string)(null)), table4, "Given ");
#line 37
 testRunner.Then("the Velocity should be 12.5", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
