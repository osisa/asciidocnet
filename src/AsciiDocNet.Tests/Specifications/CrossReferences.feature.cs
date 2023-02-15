﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:4.0.0.0
//      SpecFlow Generator Version:4.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AsciiDocNet.Tests.Specifications
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "4.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CrossReferencesFeature : object, Xunit.IClassFixture<CrossReferencesFeature.FixtureData>, Xunit.IAsyncLifetime
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CrossReferences.feature"
#line hidden
        
        public CrossReferencesFeature(CrossReferencesFeature.FixtureData fixtureData, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
        }
        
        public static async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunnerForAssembly(null, TechTalk.SpecFlow.xUnit.SpecFlowPlugin.XUnitParallelWorkerTracker.Instance.GetWorkerId());
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en"), "Specifications", "Cross References", "  In order to create links to other sections\r\n  As a writer\r\n  I want to be able " +
                    "to use a cross reference macro", ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        public static async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            string testWorkerId = testRunner.TestWorkerId;
            await testRunner.OnFeatureEndAsync();
            testRunner = null;
            TechTalk.SpecFlow.xUnit.SpecFlowPlugin.XUnitParallelWorkerTracker.Instance.ReleaseWorker(testWorkerId);
        }
        
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
        }
        
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
        {
            await this.TestInitializeAsync();
        }
        
        async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
        {
            await this.TestTearDownAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create a cross reference from an AsciiDoc cell to a section", Skip="Ignored")]
        [Xunit.TraitAttribute("FeatureTitle", "Cross References")]
        [Xunit.TraitAttribute("Description", "Create a cross reference from an AsciiDoc cell to a section")]
        public async System.Threading.Tasks.Task CreateACrossReferenceFromAnAsciiDocCellToASection()
        {
            string[] tagsOfScenario = new string[] {
                    "ignore"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a cross reference from an AsciiDoc cell to a section", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 9
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 10
  await testRunner.GivenAsync("the AsciiDoc source", "|===\r\na|See <<_install>>\r\n|===\r\n\r\n== Install\r\n\r\nInstructions go here.", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 20
  await testRunner.WhenAsync("it is converted to html", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 21
  await testRunner.ThenAsync("the result should match the HTML source", @"table.tableblock.frame-all.grid-all.spread
  colgroup
    col style='width: 100%;'
  tbody
    tr
      td.tableblock.halign-left.valign-top
        div
          .paragraph: p
            'See
            a href='#_install' Install
.sect1
  h2#_install Install
  .sectionbody
    .paragraph: p Instructions go here.", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create a cross reference using the target section title", Skip="Ignored")]
        [Xunit.TraitAttribute("FeatureTitle", "Cross References")]
        [Xunit.TraitAttribute("Description", "Create a cross reference using the target section title")]
        public async System.Threading.Tasks.Task CreateACrossReferenceUsingTheTargetSectionTitle()
        {
            string[] tagsOfScenario = new string[] {
                    "ignore"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a cross reference using the target section title", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 42
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 43
  await testRunner.GivenAsync("the AsciiDoc source", "== Section One\r\n\r\ncontent\r\n\r\n== Section Two\r\n\r\nrefer to <<Section One>>", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 53
  await testRunner.WhenAsync("it is converted to html", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 54
  await testRunner.ThenAsync("the result should match the HTML source", ".sect1\r\n  h2#_section_one Section One\r\n  .sectionbody: .paragraph: p content\r\n.se" +
                        "ct1\r\n  h2#_section_two Section Two\r\n  .sectionbody: .paragraph: p\r\n    \'refer to" +
                        "\r\n    a href=\'#_section_one\' Section One", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create a cross reference using the target reftext", Skip="Ignored")]
        [Xunit.TraitAttribute("FeatureTitle", "Cross References")]
        [Xunit.TraitAttribute("Description", "Create a cross reference using the target reftext")]
        public async System.Threading.Tasks.Task CreateACrossReferenceUsingTheTargetReftext()
        {
            string[] tagsOfScenario = new string[] {
                    "ignore"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a cross reference using the target reftext", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 69
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 70
  await testRunner.GivenAsync("the AsciiDoc source", "[reftext=\"the first section\"]\r\n== Section One\r\n\r\ncontent\r\n\r\n== Section Two\r\n\r\nref" +
                        "er to <<the first section>>", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 81
  await testRunner.WhenAsync("it is converted to html", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 82
  await testRunner.ThenAsync("the result should match the HTML source", ".sect1\r\n  h2#_section_one Section One\r\n  .sectionbody: .paragraph: p content\r\n.se" +
                        "ct1\r\n  h2#_section_two Section Two\r\n  .sectionbody: .paragraph: p\r\n    \'refer to" +
                        "\r\n    a href=\'#_section_one\' the first section", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create a cross reference using the formatted target title", Skip="Ignored")]
        [Xunit.TraitAttribute("FeatureTitle", "Cross References")]
        [Xunit.TraitAttribute("Description", "Create a cross reference using the formatted target title")]
        public async System.Threading.Tasks.Task CreateACrossReferenceUsingTheFormattedTargetTitle()
        {
            string[] tagsOfScenario = new string[] {
                    "ignore"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create a cross reference using the formatted target title", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 96
  this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 97
  await testRunner.GivenAsync("the AsciiDoc source", "== Section *One*\r\n\r\ncontent\r\n\r\n== Section Two\r\n\r\nrefer to <<Section *One*>>", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 107
  await testRunner.WhenAsync("it is converted to html", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 108
  await testRunner.ThenAsync("the result should match the HTML source", @"<div class=""sect1"">
  <h2 id=""_section_strong_one_strong"">
    Section <strong>One</strong>
</h2>
<div class=""sectionbody"">
<div class=""paragraph"">
<p>content</p>
</div>
</div>
</div>
   <div class=""sect1"">
     <h2 id=""_section_two"">Section Two</h2>
<div class=""sectionbody"">
<div class=""paragraph"">
<p>refer to
       <a href=""#_section_strong_one_strong"">
         Section <strong>One</strong>
 </a>
</p>
  </div>
</div>
</div>", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "4.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : object, Xunit.IAsyncLifetime
        {
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.InitializeAsync()
            {
                await CrossReferencesFeature.FeatureSetupAsync();
            }
            
            async System.Threading.Tasks.Task Xunit.IAsyncLifetime.DisposeAsync()
            {
                await CrossReferencesFeature.FeatureTearDownAsync();
            }
        }
    }
}
#pragma warning restore
#endregion
