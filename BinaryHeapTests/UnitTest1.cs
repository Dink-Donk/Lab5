using System;
using Xunit;
using BinaryHeap;

namespace BinaryHeapTests
{
    public class BinaryHeapTests
    {
        [Fact]
        public void ElementWasAdded()
        {
            MaxComparer<int> mc = new MaxComparer<int>();
            BinaryHeap<int> bh = new BinaryHeap<int>(mc);
            var expected = 1;
            bh.Add(expected);
            Assert.Equal(expected, bh.GetRoot());
        }

        [Fact]
        public void ProperMaxElement()
        {
            MaxComparer<int> mc = new MaxComparer<int>();
            BinaryHeap<int> bh = new BinaryHeap<int>(mc);
            var expected = 10;
            for(int i = 0;i<=expected;i++)
                bh.Add(i);
            Assert.Equal(expected, bh.GetRoot());
        }

        [Fact]
        public void ProperMinElement()
        {
            MinComparer<int> mc = new MinComparer<int>();
            BinaryHeap<int> bh = new BinaryHeap<int>(mc);
            var expected = 1;
            for(int i = 10;i>=expected;i--)
                bh.Add(i);
            Assert.Equal(expected, bh.GetRoot());
        }

        [Fact]
        public void ProperMaxElementAfterDeletion()
        {
            MaxComparer<int> mc = new MaxComparer<int>();
            BinaryHeap<int> bh = new BinaryHeap<int>(mc);
            var expected = 10;
            for(int i = 0;i<=expected;i++)
                bh.Add(i);
            bh.RemoveRoot();
            Assert.Equal(expected-1, bh.GetRoot());
        }

        [Fact]
        public void ProperMinElementAfterDeletion()
        {
            MinComparer<int> mc = new MinComparer<int>();
            BinaryHeap<int> bh = new BinaryHeap<int>(mc);
            var expected = 1;
            for(int i = 10;i>=expected;i--)
                bh.Add(i);
            bh.RemoveRoot();
            Assert.Equal(expected+1, bh.GetRoot());
        }

    }
}
