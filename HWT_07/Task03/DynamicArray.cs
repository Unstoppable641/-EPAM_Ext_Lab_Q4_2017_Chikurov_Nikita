namespace Task03
{
    using System;
    using System.Collections.Generic;

    public class DynamicArray<T> where T : new()
    {
        private const int DefaultCapacity = 8;
        private const int Reserve = 2; 

        private T[] arr;

        public int Length { get; private set; }

        public int Capacity => this.arr.Length;

        public T this[int index]
        {
            get
            {
                if (index > this.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                return this.arr[index];
            }

            set
            {
                if (index > this.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                this.arr[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.Length == this.arr.Length - 1)
            {
                this.ExpandCapacity(this.arr.Length);
            }

            this.arr[this.Length] = element;
            this.Length++;
        }

        public void AddRange(T[] rangeArray)
        {
            if (rangeArray.Length + (this.Length + 1) > this.arr.Length)
            {
                this.ExpandCapacity(rangeArray.Length + this.Length);
            }

            foreach (var element in rangeArray)
            {
                this.arr[this.Length] = element;
                this.Length++;
            }
        }

        public void Remove(T element)
        {
            var tempArr = new T[this.arr.Length];
            var j = 0;
            foreach (var t in this.arr)
            {
                if (!t.Equals(element))
                {
                    tempArr[j] = t;
                    j++;
                }
                else
                {
                    this.Length--;
                }
            }

            this.arr = tempArr;
        }

        public bool Insert(T element, int position)
        {
            if (position > this.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(element));
            }

            if (this.Length == this.arr.Length - 1)
            {
                this.ExpandCapacity(this.arr.Length);
            }

            var i = this.Length;
            while (i != position - 1)
            {
                this.arr[i + 1] = this.arr[i];
                i--;
            }

            this.arr[position] = element;
            this.Length++;
            return true;
        }

        private void SetDefault(int leftBound, int rightBound)
        {
            for (var i = leftBound; i < rightBound; i++)
            {
                this.arr[i] = default(T);
            }
        }

        private void ExpandCapacity(int capacity) 
        {
            var tempArr = new T[capacity * Reserve];
            for (var i = 0; i < this.arr.Length; i++)
            {
                tempArr[i] = this.arr[i];
            }

            this.arr = tempArr;
        }

        public DynamicArray()
        {
            this.arr = new T[DefaultCapacity];
            this.SetDefault(0, this.arr.Length);
            this.Length = 0;
        }

        public DynamicArray(int length)
        {
            this.arr = new T[length];
            this.Length = 0;
        }

        public DynamicArray(IReadOnlyList<T> initialArray)
        {
            this.arr = new T[initialArray.Count];
            for (var i = 0; i < initialArray.Count; i++)
            {
                this.arr[i] = initialArray[i];
            }

            this.Length = initialArray.Count - 1;
        }
    }
}
