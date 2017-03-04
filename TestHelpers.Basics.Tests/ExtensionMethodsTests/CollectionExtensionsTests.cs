using System.Collections.Generic;
using System.Linq;
using TestHelpers.Basics;
using Xunit;


namespace ExtensionMethodsTests.CollectionExtensionsTests
{
    public class AddIfNotNull
    {
        [Fact]
        public void GivenAListThatIsNullAndAValidItem_ThenNothingHappensAndTheListIsStillNull()
        {
            List<string> list = null;

            list.AddIfNotNull("Valid item");

            Assert.Null(list);
        }

        [Fact]
        public void GivenAListAndAnItemThatIsNull_ThenNothingHappensAndTheListIsStillNull()
        {
            List<string> list = null;

            list.AddIfNotNull(null);

            Assert.Null(list);
        }

        [Fact]
        public void GivenAListAndAValidItem_ThenTheItemIsAdded()
        {
            var list = new List<string>();

            list.AddIfNotNull("Valid item");

            Assert.Equal(1, list.Count);
            Assert.Equal("Valid item", list[0]);
        }

        [Fact]
        public void GivenAListAndAnInvalidItem_ThenTheItemIsNotAdded()
        {
            var list = new List<string>();

            list.AddIfNotNull(null);

            Assert.Equal(0, list.Count);
        }
    }

    public class ForEach
    {
        [Fact]
        public void GivenAListThatIsNull_ThenNothingHappens()
        {
            List<int> list = null;
            int sum = 0;

            list.ForAll(x => sum += x);

            Assert.Equal(0, sum);
        }

        [Fact]
        public void GivenAnArrayThatIsNull_ThenNothingHappens()
        {
            int[] array = null;
            int sum = 0;

            array.ForAll(x => sum += x);

            Assert.Equal(0, sum);
        }

        [Fact]
        public void GivenAListWithTwoNumbers_ThenTheNumbersAreAddedToTheSum()
        {
            var list = new List<int> { 5, 5 };
            int sum = 0;

            list.ForAll(x => sum += x);

            Assert.Equal(10, sum);
        }

        [Fact]
        public void GivenAnArrayWithTwoNumbers_ThenTheNumbersAreAddedToTheSum()
        {
            var array = new [] {5, 5};
            int sum = 0;

            array.ForAll(x => sum += x);

            Assert.Equal(10, sum);
        }
    }

    public class AsReadOnlyList
    {
        [Fact]
        public void GivenAStringValue_ThenItIsWrappedInAReadOnlyListWithOneItem()
        {
            var value = "String value";

            var result = value.AsReadOnlyList();

            Assert.Equal(1, result.Count);
            Assert.Equal(value, result[0]);
        }
    }

    public class AsReadOnlyCollection
    {
        [Fact]
        public void GivenAStringValue_ThenItIsWrappedInAReadOnlyCollectionWithOneItem()
        {
            var value = "String value";

            var result = value.AsReadOnlyCollection();

            Assert.Equal(1, result.Count);
            Assert.Equal(value, result.First());
        }
    }
}