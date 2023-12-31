﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace game.tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ВекторN_МерногоВеторногоПространстваFeature : object, Xunit.IClassFixture<ВекторN_МерногоВеторногоПространстваFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Vector.feature"
#line hidden
        
        public ВекторN_МерногоВеторногоПространстваFeature(ВекторN_МерногоВеторногоПространстваFeature.FixtureData fixtureData, game_tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("ru-RU"), "Features", "Вектор n-мерного веторного пространства", "Для описания атрибутов объекта - положение в пространстве, мгновенная скоровть \r\n" +
                    "используются объекты класса Vector.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Два веткора можно сложить")]
        [Xunit.TraitAttribute("FeatureTitle", "Вектор n-мерного веторного пространства")]
        [Xunit.TraitAttribute("Description", "Два веткора можно сложить")]
        [Xunit.TraitAttribute("Category", "позитивный")]
        public virtual void ДваВеткораМожноСложить()
        {
            string[] tagsOfScenario = new string[] {
                    "позитивный"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Два веткора можно сложить", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
 testRunner.Given("двухмерный вектор a с координатами (2, 3)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
#line hidden
#line 8
 testRunner.And("двухмерный вектор b с координатами (2, -1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line hidden
#line 9
 testRunner.When("складываем веторы a и b", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Когда ");
#line hidden
#line 10
 testRunner.Then("получаем вектор с координатами (4, 2).", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Два вектора разной размерности складывать нельзя")]
        [Xunit.TraitAttribute("FeatureTitle", "Вектор n-мерного веторного пространства")]
        [Xunit.TraitAttribute("Description", "Два вектора разной размерности складывать нельзя")]
        [Xunit.TraitAttribute("Category", "негативный")]
        public virtual void ДваВектораРазнойРазмерностиСкладыватьНельзя()
        {
            string[] tagsOfScenario = new string[] {
                    "негативный"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Два вектора разной размерности складывать нельзя", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 13
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 14
    testRunner.Given("двухмерный вектор a с координатами (2, 3)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
#line hidden
#line 15
 testRunner.And("трехмерный вектор b с координатами (2, -1, 0)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line hidden
#line 16
 testRunner.When("складываем веторы a и b", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Когда ");
#line hidden
#line 17
 testRunner.Then("выбрасывается исключение", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ВекторN_МерногоВеторногоПространстваFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ВекторN_МерногоВеторногоПространстваFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
