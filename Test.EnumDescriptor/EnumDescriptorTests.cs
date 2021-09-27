using System;
using System.ComponentModel;
using EnumDesriptor;
using Xunit;

namespace Test.EnumDescriptor
{
    public class EnumDescriptorTests
    {
        private const string ExpectedDescription = "Some description";

        private enum StubEnum
        {
            NotDescripted,
            [Description(ExpectedDescription)] Descripted,
            [Description] BlankDescription
        }

        [Fact]
        public void GetDescription_OnDescriptedItem_ReturnsDescription()
        {
            var actualDescription = StubEnum.Descripted.GetDescription();
            Assert.Equal(ExpectedDescription, actualDescription);
        }

        [Fact]
        public void GetDescription_OnNotDescriptedItem_ReturnsItemToString()
        {
            var actualDescription = StubEnum.NotDescripted.GetDescription();
            Assert.Equal("NotDescripted", actualDescription);
        }

        [Fact]
        public void GetDescription_OnBlankDescriptedItem_ReturnsStringEmpty()
        {
            var actualDescription = StubEnum.BlankDescription.GetDescription();
            Assert.Equal(string.Empty, actualDescription);
        }
    }
}
