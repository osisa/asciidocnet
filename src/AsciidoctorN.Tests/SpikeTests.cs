using System.Linq;
using AsciiDocNet;

using AsciidoctorN.Tests.TestInfrastructure;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using osisa.IO.TestInfrastructure;
using osisa.TestInfrastructure.UnitTestSupport;

using static AsciidoctorN.Tests.TestInfrastructure.TestValues;

namespace AsciidoctorN.Tests
{
    [TestClass]
    //[DeploymentItem("TestDocs", "")]
    public class SpikeTests : UnitTestsBase
    {
        #region Public Methods and Operators

        [TestMethod]
        public void Constructor()
        {
            // Arrange

            // Act
            var result = CreateUnitUnderTest();

            // Assert
            result.Should().NotBeNull();
        }
        
        [TestMethod]
        [DeploymentItem(TestDocs + BasicExample)]
        public void Constructor_FromBasicExample()
        {
            // Arrange

            // Act
            var result = CreateUnitUnderTest(BasicExample);

            // Assert
            result.Should().NotBeNull();
        }

        [TestMethod]
        [DeploymentItem(TestDocs + BasicExample)]
        public void GetTitle_FromBasicExample()
        {
            // Arrange
            var unitUnderTest = CreateUnitUnderTest(BasicExample);

            // Act
            var result = unitUnderTest.Title;

            // Assert
            result.Title.Should().Be("Document Title");
        }

        [TestMethod]
        [DeploymentItem(TestDocs + BasicExample)]
        public void GetAuthors_FromBasicExample()
        {
            // Arrange
            var unitUnderTest = CreateUnitUnderTest(BasicExample);

            // Act
            var result = unitUnderTest.Authors;

            // Assert
            result.Count.Should().Be(1);
            result[0].FullName.Should().Be("Doc Writer");
        }

        [TestMethod]
        [DeploymentItem(TestDocs + BasicExample)]
        public void GetAttributes_FromBasicExample()
        {
            // Arrange
            var unitUnderTest = CreateUnitUnderTest(BasicExample);

            // Act
            var result = unitUnderTest.Attributes;

            // Assert
            result.Count.Should().Be(5);
            result[0].Name.Should().Be(@"docdir");
            result[1].Name.Should().Be(@"reproducible");
            result[2].Name.Should().Be(@"listing-caption");
            result[3].Name.Should().Be(@"source-highlighter");
            result[4].Name.Should().Be(@"toc");
        }
        
        [TestMethod]
        [DeploymentItem(TestDocs + BasicExample)]
        [DataRow(0, " Uncomment next line to add a title page (or set doctype to book)")]
        [DataRow(1, ":title-page:")]
        [DataRow(2, " Uncomment next line to set page size (default is A4)")]
        [DataRow(3, ":pdf-page-size: Letter")]
        //[DataRow(4, "noText")]
        //[DataRow(5, "noText")]
        //[DataRow(6, "noText")]
        //[DataRow(7, "noText")]
        //[DataRow(8, "noText")]
        //[DataRow(9, "noText")]
        [DataRow(10, "require 'prawn'")]
        //[DataRow(11, "noText")]
        //[DataRow(12, "noText")]
        public void GetElement_AsIText_FromBasicExample(int index, string expectedText)
        {
            // Arrange
            var unitUnderTest = CreateUnitUnderTest(BasicExample);

            // Act
            var result = unitUnderTest.ElementAt(index);

            // Assert
            result.Parent.Count.Should().Be(13);
            TestContext.WriteLine("Element 0:{0}", result);

            var textResult = (IText)result;
            textResult.Text.Should().StartWith(expectedText);
        }
        
        [TestMethod]
        [DeploymentItem(TestDocs + BasicExample)]
        //[DataRow(4, "noText")]
        public void GetElement_Index4_AsParagraph_FromBasicExample()
        {
            // Arrange
            var unitUnderTest = CreateUnitUnderTest(BasicExample);

            // Act
            var result = unitUnderTest.ElementAt(4);

            // Assert
            result.Parent.Count.Should().Be(13);
            TestContext.WriteLine("Element 0:{0}", result);

            var paragraphResult = (Paragraph)result;
            TestContext.WriteLine("ParagraphCount:{0}", paragraphResult.Count);
            paragraphResult.Count.Should().Be(5);

            var paragraphIndex = 0;
            foreach (var paragraph in paragraphResult)
            {
                TestContext.WriteLine("Paragraph[{0}]:{1}", paragraphIndex, paragraph);
                paragraphIndex++;
            }
        }

        [TestMethod]
        [DeploymentItem(TestDocs + BasicExample)]
        //[DataRow(5, "noText")]
        //[DataRow(6, "noText")]
        //[DataRow(7, "noText")]
        //[DataRow(8, "noText")]
        //[DataRow(9, "noText")]
        //[DataRow(11, "noText")]
        //[DataRow(12, "noText")]
        public void GetElement_Index5_AsSectionTitle_FromBasicExample()
        {
            // Arrange
            var unitUnderTest = CreateUnitUnderTest(BasicExample);

            // Act
            var result = unitUnderTest.ElementAt(5);

            // Assert
            result.Parent.Count.Should().Be(13);
            TestContext.WriteLine("Element[5] :{0}", result);

            var sectionTitle = (SectionTitle)result;
            sectionTitle.Count.Should().Be(1);
            sectionTitle[0].Should().BeOfType<TextLiteral>().Subject.Text.Should().Be("Introduction");
        }


        [TestMethod]
        [DeploymentItem(TestDocs + BasicExample)]
        //[DataRow(5, "noText")]
        //[DataRow(6, "noText")]
        //[DataRow(7, "noText")]
        //[DataRow(8, "noText")]
        //[DataRow(9, "noText")]
        //[DataRow(11, "noText")]
        //[DataRow(12, "noText")]
        public void GetElement_Index6_AsParagraph_FromBasicExample()
        {
            // Arrange
            var index = 6;
            var unitUnderTest = CreateUnitUnderTest(BasicExample);

            // Act
            var result = unitUnderTest.ElementAt(index);

            // Assert
            result.Parent.Count.Should().Be(13);
            TestContext.WriteLine("Element[{0}] :{1}", index, result);

            var paragraph = (Paragraph)result;
            paragraph.Count.Should().Be(3);
            paragraph[0].Should().BeOfType<TextLiteral>().Subject.Text.Should().Be("A paragraph followed by an unordered list");
            paragraph[1].Should().BeOfType<AttributeReference>().Subject.Text.Should().Be("empty");
            paragraph[2].Should().BeOfType<TextLiteral>().Subject.Text.Should().Be("footnote:[AsciiDoc supports unordered, ordered, and description lists.] with square bullets.footnote:[You may choose from square, disc, and circle for the bullet style.]");
        }

        [TestMethod]
        [DeploymentItem(TestDocs + BasicExample)]
        //[DataRow(5, "noText")]
        //[DataRow(6, "noText")]
        //[DataRow(7, "noText")]
        //[DataRow(8, "noText")]
        //[DataRow(9, "noText")]
        //[DataRow(11, "noText")]
        //[DataRow(12, "noText")]
        public void GetElement_Index7_AsUnorderedList_FromBasicExample()
        {
            // Arrange
            var index = 7;
            var unitUnderTest = CreateUnitUnderTest(BasicExample);

            // Act
            var result = unitUnderTest.ElementAt(index);

            // Assert
            result.Parent.Count.Should().Be(13);
            TestContext.WriteLine("Element[{0}] :{1}", index, result);

            var unorderedList = (UnorderedList)result;
            unorderedList.Items.Count.Should().Be(3);

            unorderedList.Items[0].Should().BeOfType<UnorderedListItem>();
            unorderedList.Items[0].Count.Should().Be(1);
            unorderedList.Items[0][0].Should().BeOfType<Paragraph>().Subject.Count.Should().Be(1);
            unorderedList.Items[0][0].Should().BeOfType<Paragraph>().Subject[0].Should().BeOfType<TextLiteral>().Subject.Text.Should().Be("item 1");

            unorderedList.Items[1].Should().BeOfType<UnorderedListItem>();
            unorderedList.Items[1].Count.Should().Be(1);
            unorderedList.Items[1][0].Should().BeOfType<Paragraph>().Subject.Count.Should().Be(1);
            unorderedList.Items[1][0].Should().BeOfType<Paragraph>().Subject[0].Should().BeOfType<TextLiteral>().Subject.Text.Should().Be("item 2");

            unorderedList.Items[2].Should().BeOfType<UnorderedListItem>();
            unorderedList.Items[2].Count.Should().Be(1);
            unorderedList.Items[2][0].Should().BeOfType<Paragraph>().Subject.Count.Should().Be(1);
            unorderedList.Items[2][0].Should().BeOfType<Paragraph>().Subject[0].Should().BeOfType<TextLiteral>().Subject.Text.Should().Be("item 3");

        }


        [TestMethod]
        [DeploymentItem(TestDocs + BasicExample)]
        //[DataRow(5, "noText")]
        //[DataRow(6, "noText")]
        //[DataRow(7, "noText")]
        //[DataRow(8, "noText")]
        //[DataRow(9, "noText")]
        //[DataRow(11, "noText")]
        //[DataRow(12, "noText")]
        public void GetElement_Index8_AsUnorderedList_FromBasicExample()
        {
            // Arrange
            var index = 8;
            var unitUnderTest = CreateUnitUnderTest(BasicExample);

            // Act
            var result = unitUnderTest.ElementAt(index);

            // Assert
            result.Parent.Count.Should().Be(13);
            TestContext.WriteLine("Element[{0}] :{1}", index, result);

            var sectionTitle = (SectionTitle)result;
            sectionTitle.Count.Should().Be(1);
            var textLiteral=(TextLiteral)sectionTitle[0];
            textLiteral.Text.Should().Be("Main");
        }

        [TestMethod]
        public void GetElement_Index9_AsParagraph_FromBasicExample()
        {
            // Arrange
            var index = 9;
            var unitUnderTest = CreateUnitUnderTest(BasicExample);

            // Act
            var result = unitUnderTest.ElementAt(index);

            // Assert
            result.Parent.Count.Should().Be(13);
            TestContext.WriteLine("Element[{0}] :{1}", index, result);

            var paragraph = (Paragraph)result;
            paragraph.Count.Should().Be(3);
            var textLiteral = (TextLiteral)paragraph[0];

            paragraph[0].Should().BeOfType<TextLiteral>().Subject.Text.Should().Be("Here's how you say ");

            var quotationMark = (QuotationMark)paragraph[1];
            quotationMark.Count.Should().Be(1);
            quotationMark[0].Should().BeOfType<TextLiteral>().Subject.Text.Should().Be("Hello, World!");
        }


        [TestMethod]
        [DeploymentItem(TestDocs + TestValues.Example)]
        public void GetAuthors()
        {
            // Arrange
            var unitUnderTest = CreateUnitUnderTest();

            // Act
            var result = unitUnderTest.Authors;

            // Assert
            result.Count.Should().Be(0);
        }
        
        [TestMethod]
        [DeploymentItem(TestDocs + TestValues.Example)]
        public void GetDocType()
        {
            // Arrange
            var unitUnderTest = CreateUnitUnderTest();

            // Act
            var result = unitUnderTest.DocType;

            // Assert
            result.Should().Be(DocType.Article);
        }
        
        [TestMethod]
        public void GetTitle()
        {
            // Arrange
            var unitUnderTest= CreateUnitUnderTest();

            // Act
            var result = unitUnderTest.Title;

            // Assert
            result.Should().BeNull();
        }
        

        [TestMethod]
        [DeploymentItem(@"TestDocs\Documentation1.adoc")]
        public void GetTable()
        {
            // Arrange
            var unitUnderTest = CreateUnitUnderTest(Documentation1);

            // Act
            var result = unitUnderTest.Title;

            // Assert
            result.Title.Should().Be("x");
            //result.Title.Should().Be("Dokumentation Staudt AG");
        }

        [TestMethod]
        public void IsMatch()
        {
            // Arrange
            var text = ",===";
            
            // Act
            var result = PatternMatcher.Table.IsMatch(text);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void CreatePowerPoint()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        [DeploymentItem(TestDocs + TestValues.Example)]
        public void ExampleEnsure()
        {
            // Arrange
            var testFileOperator = TestContext.GetTestFileOperator();

            // Act
            var result = testFileOperator.GetFileInfo(TestValues.Example);

            // Assert
            TestContext.WriteLine("File: {0}", result.PhysicalPath);
            result.Exists.Should().BeTrue();
        }

        [TestMethod]
        [DeploymentItem(TestDocs + TestValues.Example)]
        public void ParseExample()
        {
            // Arrange
            var o = TestContext.GetTestFileOperator();

            //var testOperator=Test
            //var xx=Document.Load().

            // Act

            // Assert
        }

        #endregion

        #region Methods

        private Document CreateUnitUnderTest(string subPath = TestValues.Example)
        {
            var testFileOperator = TestContext.GetTestFileOperator();
            var file = testFileOperator.GetFileInfo(subPath);

            file.Exists.Should().BeTrue();

            return Document.Load(file.PhysicalPath!);
        }

        #endregion
    }
}