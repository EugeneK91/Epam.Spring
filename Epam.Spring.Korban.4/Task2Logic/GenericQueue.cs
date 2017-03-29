using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Task2Logic
{
    public class GenericQueue<T> : IEnumerable<T>
    {

        #region Property

        public int Count { get { return _size; } }

        #endregion

        #region Fields

        private T[] _array;
        private int _head ;
        private int _tail ;
        private int _size ;
        private int _growFactor;

        #endregion

        #region Constructors

        public GenericQueue() : this(5, 2){}

        public GenericQueue(int capacity) : this(capacity, 2){} 

        public GenericQueue(int capacity, int growFactor)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("capacity");
            if (!(growFactor >= 1 && growFactor <= 10))
                throw new ArgumentOutOfRangeException("growFactor");

            _array = new T[capacity];
            _head = 0;
            _tail = 0;
            _size = 0;
            _growFactor = growFactor;

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Make deep copy and return array
        /// </summary>
        /// <returns></returns>
        public Array ToArray()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, _array);
                stream.Position = 0;

                return (T[])formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// Add element to end a queue
        /// </summary>
        /// <param name="element"></param>
        public void Enqueue(T element)
        {
            if (_size == _array.Length)
            {
                var newcapacity = _array.Length * _growFactor;
                if (newcapacity < _array.Length)
                {
                    newcapacity = _array.Length;
                }
                SetCapacity(newcapacity);
            }

            _array[_tail] = element;
            _tail = (_tail + 1) % _array.Length;
            _size++;

        }

        /// <summary>
        /// remove  element from head of queue and return this value
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("EmptyQueue");

            var removed = _array[_head];
            _array[_head] = default(T);
            _head = (_head + 1) % _array.Length;
            _size--;
            return removed;
        }

        /// <summary>
        /// Read value from head of queue
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("EmptyQueue");

            return _array[_head];
        }

        /// <summary>
        /// Enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; _size != i; i++)
            {
                yield return _array[(_head + i) % _array.Length];
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Set capacity of queue
        /// </summary>
        /// <param name="newcapacity"></param>
        private void SetCapacity(int newcapacity)
        {
            var newarray = new T[newcapacity];
            if (_size > 0)
            {
                if (_head < _tail)
                {
                    Array.Copy(_array, _head, newarray, 0, _size);
                }
                else
                {
                    Array.Copy(_array, _head, newarray, 0, _array.Length - _head);
                    Array.Copy(_array, 0, newarray, _array.Length - _head, _tail);
                }
            }

            _array = newarray;
            _head = 0;
            _tail = (_size == newcapacity) ? 0 : _size;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



        #endregion
    }
}
