using System;

using NUnit.Framework;

namespace Codec
{
    [TestFixture]
    public class TestT9Codec
    {
        [Test]
        public void ConvertToT9ShouldReturnEmptyResult()
        {
            Assert.AreEqual(string.Empty, T9Codec.ConvertToT9(null));
            Assert.AreEqual(string.Empty, string.Empty.ConvertToT9());
        }

        [Test]
        public void ConvertToT9ShouldReturnArgumentException()
        {
            Assert.Throws<ArgumentException>(() => "1234567890 hello world".ConvertToT9(),
                @"Invalid income string. Income string should satisfy the pattern: ^[a-z]+(\s+[a-z]+)*$");

            Assert.Throws<ArgumentException>(() => "hello 1234567890 world".ConvertToT9(),
                @"Invalid income string. Income string should satisfy the pattern: ^[a-z]+(\s+[a-z]+)*$");

            Assert.Throws<ArgumentException>(() => "hello world 1234567890".ConvertToT9(),
                @"Invalid income string. Income string should satisfy the pattern: ^[a-z]+(\s+[a-z]+)*$");

            Assert.Throws<ArgumentException>(() => "hello world.".ConvertToT9(),
                @"Invalid income string. Income string should satisfy the pattern: ^[a-z]+(\s+[a-z]+)*$");

            Assert.Throws<ArgumentException>(() => "hello world!".ConvertToT9(),
                @"Invalid income string. Income string should satisfy the pattern: ^[a-z]+(\s+[a-z]+)*$");

            Assert.Throws<ArgumentException>(() => "hello world?".ConvertToT9(),
                @"Invalid income string. Income string should satisfy the pattern: ^[a-z]+(\s+[a-z]+)*$");
        }

        [Test]
        public void ConvertToT9ShouldBeOk()
        {
            Assert.AreEqual("222222303333304", "AbCd eF G".ConvertToT9());
            Assert.AreEqual("4444405055555666", "hI j kLmN".ConvertToT9());
            Assert.AreEqual("66677707777777888088899909999999", "oPq RsTU\tvWx Yz".ConvertToT9());
        }
    }
}
