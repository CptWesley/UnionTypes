using Xunit;
using static AssertNet.Assertions;

namespace UnionTypes.Tests
{
    /// <summary>
    /// Test class for union types.
    /// </summary>
    public class UnionTests
    {
        /// <summary>
        /// Checks that we can retrieve the value from a union type if it's the first value.
        /// </summary>
        [Fact]
        public void UnionOfTwoMatchFirst()
        {
            Union<int, string> union = new Union<int, string>(42);
            AssertThat(union.Type).IsEqualTo(typeof(int));
            AssertThat(union.Match(out string _)).IsFalse();
            AssertThat(union.Match(out int num)).IsTrue();
            AssertThat(num).IsEqualTo(42);
        }

        /// <summary>
        /// Checks that we can retrieve the value from a union type if it's the second value.
        /// </summary>
        [Fact]
        public void UnionOfTwoMatchSecond()
        {
            Union<int, string> union = new Union<int, string>("hello");
            AssertThat(union.Type).IsEqualTo(typeof(string));
            AssertThat(union.Match(out int _)).IsFalse();
            AssertThat(union.Match(out string str)).IsTrue();
            AssertThat(str).IsEqualTo("hello");
        }

        /// <summary>
        /// Checks that we can retrieve the value from a union type if it's the first value.
        /// </summary>
        [Fact]
        public void UnionOfTwoGetValueFirst()
        {
            Union<int, string> union = new Union<int, string>(1337);
            AssertThat(union.GetValue()).IsEqualTo(1337);
        }

        /// <summary>
        /// Checks that we can retrieve the value from a union type if it's the second value.
        /// </summary>
        [Fact]
        public void UnionOfTwoGetValueSecond()
        {
            Union<int, string> union = new Union<int, string>("world");
            AssertThat(union.GetValue()).IsEqualTo("world");
        }

        /// <summary>
        /// Checks that we can set the value correctly.
        /// </summary>
        [Fact]
        public void UnionOfTwoSetValue()
        {
            Union<int, string> union = new Union<int, string>("a");
            AssertThat(union.Type).IsEqualTo(typeof(string));
            AssertThat(union.GetValue()).IsEqualTo("a");
            union.SetValue(123);
            AssertThat(union.Type).IsEqualTo(typeof(int));
            AssertThat(union.GetValue()).IsEqualTo(123);
        }

        /// <summary>
        /// Checks that we can set the value correctly at high stages and that we set all other fields to default values.
        /// </summary>
        [Fact]
        public void UnionOfEightSetValue()
        {
            var union = new Union<int, int, int, int, int, int, double, string>("b");
            AssertThat(union.Type).IsEqualTo(typeof(string));
            AssertThat(union.GetValue()).IsEqualTo("b");
            union.SetValue(1.0);
            AssertThat(union.Type).IsEqualTo(typeof(double));
            AssertThat(union.GetValue()).IsEqualTo(1.0);
        }
    }
}
