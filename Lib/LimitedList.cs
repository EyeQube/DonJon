using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class LimitedList<T> : IEnumerable<T>
    {

        private List<T> list = new List<T>();
        public int Capacity { get; set; }

        public LimitedList(int capacity)
        {
            Capacity = capacity;
        }

        public bool Add(T item)
        {
            if (list.Count >= Capacity) return false;
            list.Add(item);
            return true;
        }


        public void Remove(T item)
        {
            list.Remove(item);

        }

        public IEnumerator<T> GetEnumerator()
        {
            //return list.GetEnumerator();

            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }


    }

}
