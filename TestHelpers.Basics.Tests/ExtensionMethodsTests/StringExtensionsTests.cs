using System;
using TestHelpers.Basics;
using Xunit;

namespace ExtensionMethodsTests.StringExtensionsTests
{
    public class ReplaceGuids
    {
        [Fact]
        public void GivenAStringThatContainsAGuidWithDashes_ThenTheGuidIsReplaced()
        {
            var guidWithDashes = "ac0da77e-49d9-41bf-8429-41fd6d86c489";
            var textWithGuid = $"This text contains a guid ({guidWithDashes}) with dashes";

            var result = textWithGuid.ReplaceGuids("ReplacementValue");

            Assert.Equal("This text contains a guid (ReplacementValue) with dashes", result);
        }

        [Fact]
        public void GivenAStringThatDoesNotContainAnyGuids_ThenTheStringIsUnchanged()
        {
            const string textWithoutGuid = "This text contains no guids";

            var result = textWithoutGuid.ReplaceGuids("ReplacementValue");

            Assert.Equal(textWithoutGuid, result);
        }

        [Theory]
        [InlineData("CF40E04E-E957-4591-9D61-2FC265D5A046")]
        [InlineData("{CF40E04E-E957-4591-9D61-2FC265D5A046}")]
        [InlineData("(CF40E04E-E957-4591-9D61-2FC265D5A046)")]
        [InlineData("f0106e2b-b7aa-42e6-80d0-8c15713d03fb")]
        [InlineData("{f0106e2b-b7aa-42e6-80d0-8c15713d03fb}")]
        [InlineData("(f0106e2b-b7aa-42e6-80d0-8c15713d03fb)")]
        public void GivenAStringThatContainsAGuidWithDashes_ThenGuidIsReplaced(string stringWithGuid)
        {
            var result = stringWithGuid.ReplaceGuids("ReplacementValue");

            Assert.True(result.Contains("ReplacementValue"));
        }

        [Theory]
        [InlineData("CF40E04EE95745919D612FC265D5A046")]
        [InlineData("f0106e2bb7aa42e680d08c15713d03fb")]
        public void GivenAStringThatContainsAGuidWithoutDashes_ThenStringIsUnchanged(string stringWithGuid)
        {
            var result = stringWithGuid.ReplaceGuids("ReplacementValue");

            Assert.Equal(stringWithGuid, result);
        }
    }

    public class ReplaceJsonFormatedDateTime
    {
        [Fact]
        public void GivenAStringThatContainsARegularDateTime_ThenTheStringIsUnchanged()
        {
            const string textWithDateTime = "The time is 2017-03-04 17:41:27";

            var result = textWithDateTime.ReplaceJsonFormatedDateTime("now!");

            Assert.Equal(textWithDateTime, result);
        }

        [Fact]
        public void GivenAStringThatContainsAQuotedDateTime_ThenTheDateTimeValueIsReplaced()
        {
            var textWithDateTime = "The time is \"2017-03-04 17:41:27\"";

            var result = textWithDateTime.ReplaceJsonFormatedDateTime("now!");

            Assert.Equal("The time is now!", result);
        }
    }

    public class ReplaceExactMatch
    {
        [Fact]
        public void GivenAStringThatContainsOneInstanceOfTheValueYouWantToReplace_ThenTheValueIsReplaced()
        {
            const string text = "Always say no!";

            var result = text.ReplaceExactMatch("no", "yes");

            Assert.Equal("Always say yes!", result);
        }

        [Fact]
        public void GivenAStringThatContainsOneInstanceOfTheValueYouWantToReplaceButItHasDifferentCasing_ThenTheStringIsUnchanged()
        {
            const string text = "Always say No!";

            var result = text.ReplaceExactMatch("no", "yes");

            Assert.Equal(text, result);
        }

        [Fact]
        public void GivenAStringThatContainsThreeInstancesOfTheValueYouWantToReplace_ThenAllValuesAreReplaced()
        {
            const string text = "Some text that keeps repeating the same text over and over and over again";

            var result = text.ReplaceExactMatch("over", "under");

            Assert.Equal("Some text that keeps repeating the same text under and under and under again", result);
        }

        [Fact]
        public void GivenAStringThatDoesNotContainTheValueYouWantToReplace_ThenTheStringIsUnchanged()
        {
            const string text = "A simple string without the value to replace";

            var result = text.ReplaceExactMatch("NotFound", "New Value");

            Assert.Equal(text, result);
        }
    }
}