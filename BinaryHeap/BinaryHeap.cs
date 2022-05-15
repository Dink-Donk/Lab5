using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private IComparer<T> _comparer;
        private List<T> Heap;

        public int HeapSize
        {
            get
            {
                return this.Heap.Count();
            }
        }

        public BinaryHeap(IComparer<T> comparer)
        {
            Heap = new List<T>();
            _comparer = comparer;
        }

        public void Add(T value)
        {
            Heap.Add(value);
            int i = HeapSize - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && _comparer.Compare(Heap[parent], Heap[i]) < 0)
            {
                T temp = Heap[i];
                Heap[i] = Heap[parent];
                Heap[parent] = temp;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        private void Heapify(int index)
        {
            var left = 2 * index + 1;
            var right = 2 * index + 2;
            var largest = index;
            if (left < HeapSize && _comparer.Compare(Heap[left], Heap[index]) > 0)
            { largest = left; }
            if (right < HeapSize && _comparer.Compare(Heap[right], Heap[largest]) > 0)
            { largest = right; }

            if (largest == index) return;
            var temp = Heap[largest];
            Heap[largest] = Heap[index];
            Heap[index] = temp;
            Heapify(largest);
        }

        public T RemoveRoot()
        {
            T result = Heap[0];
            Heap[0] = Heap[HeapSize - 1];
            Heap.RemoveAt(HeapSize - 1);
            Heapify(0);
            return result;
        }

        public T GetRoot()
        {
            return Heap[0];
        }

    }

    public class MinComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return y.CompareTo(x);
        }
    }

    public class MaxComparer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }
}
