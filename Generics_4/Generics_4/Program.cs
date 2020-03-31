using System;

namespace Generics_4
{
    class MyList<T>
    {
        public T[] MyArray;
        public int Size { get; private set; }

        public MyList()
        {
            Size = 0;
            MyArray = new T[] { };

        }
        public MyList(int size, params T[] list)
        {
            Size = size;
            MyArray = list;
        }
        public T this[int i]
        {
            get { return MyArray[i]; }
            set
            {
                if (i <= Size)
                    MyArray[i] = value;
            }
        }

        public void Add(T newElement)
        {
            Size++;
            T[] newMyArray = new T[Size];
            for (int i = 0; i < Size - 1; i++)
            {
                newMyArray[i] = MyArray[i];
            }
            newMyArray[Size - 1] = newElement;
            MyArray = newMyArray;
        }
    }
    static class MyListExtension
    {
        public static T[] GetArray<T>(this MyList<T> list)
        {
            return list.MyArray;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myList = new MyList<int>(5, 5, 4, 3, 2, 1);

            var arr = myList.GetArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Элемент {i + 1} = {arr[i]};");
            }

            Console.ReadLine();
        }
    }
}
