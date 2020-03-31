using System;
using System.Linq;

namespace Generics_7
{
    class ArrayList
    {
        public object[] MyArray;
        public int Size { get; private set; }
        //public int Capasity { get; set; }

        public ArrayList()
        {
            MyArray = new object[] { };
            Size = 0;
        }

        public object this[int i]
        {
            get { return MyArray[i]; }
            set { MyArray[i] = value; }
        }
        public ArrayList(object[] obj)
        {
            MyArray = obj;
            Size = obj.Count();
        }

        public void Add(object obj)
        {
            Array.Resize<object>(ref MyArray, ++Size);
            MyArray[Size - 1] = obj;
        }
        public void Clear()
        {
            MyArray = new object[] { };
            Size = 0;
        }

        public void Reverse()
        {
            int size = Size;
            object[] array = new object[Size];
            object[] temp = MyArray;
            int index = Size - 1;
            int i = 0;
            /*for(int i=0;i<Size;i++)
            {
                MyArray[--index] = temp[i];
            }*/
            while (index >= 0)
            {
                array[index--] = temp[i++];
            }
            //MyArray[0]=temp[]
            MyArray = array;

        }

        public object[] CopyTo(int from)
        {
            int temp = from;
            if (temp > 0 && temp < Size)
            {
                int newSize = Size - from;
                object[] To = new object[newSize];
                for (int i = 0; i < newSize; i++)
                {
                    To[i] = MyArray[temp];
                    temp++;
                }
                return To;
            }
            else return null;
        }
        public void AddRange(object[] range)
        {
            int temp = this.Size;
            int index = 0;
            int tempt = Size + range.Count();
            Array.Resize<object>(ref MyArray, tempt);
            this.Size += range.Count();
            for (int i = temp; i < Size; i++)
            {
                MyArray[i] = range[index++];
            }
        }
        public void Remove(int rem)
        {
            int index = rem;
            for (int i = index; i < MyArray.Count() - 1; i++)
            {
                MyArray[i] = MyArray[i + 1];
            }
            Array.Resize<object>(ref MyArray, --Size);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList myarr = new ArrayList(new object[] { "new interface", 12, 17, 'a' });
            Console.WriteLine("ArrayList after creating and filling:");
            for (int i = 0; i < myarr.Size; i++)
            {
                Console.WriteLine(myarr[i]);
            }
            myarr.Clear();
            myarr.AddRange(new object[] { 'b', 13, 42, "Kotlin" });
            Console.WriteLine("ArrayList after clearing and adding range:");
            for (int i = 0; i < myarr.Size; i++)
            {
                Console.WriteLine(myarr[i]);
            }
            myarr.Remove(1);
            Console.WriteLine("After removing element with index 1:");
            for (int i = 0; i < myarr.Size; i++)
            {
                Console.WriteLine(myarr[i]);
            }
            myarr.Reverse();
            Console.WriteLine("After revercing:");
            for (int i = 0; i < myarr.Size; i++)
            {
                Console.WriteLine(myarr[i]);
            }

            object[] arr = new object[] { };
            arr = myarr.CopyTo(1);
            Console.WriteLine("Copying ArrayList into array of objects from 1 index:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadKey();
        }
    }
}
