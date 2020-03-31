using System;

namespace Generics_2
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
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> j = new MyList<int>(5, 1, 2, 3, 4, 5);
            Console.WriteLine("My list after creating:");
            for (int i = 0; i < j.Size; i++)
            {
                Console.WriteLine(j[i]);
            }

            j.Add(6);
            Console.WriteLine("My list after adding new elements:");
            for (int i = 0; i < j.Size; i++)
            {
                Console.WriteLine(j[i]);
            }
            Console.WriteLine("Size of my list after operations=" + j.Size);
            Console.ReadKey();
        }
    }
}
