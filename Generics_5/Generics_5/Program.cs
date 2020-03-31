using System;

namespace Generics_5
{
    class CarCollection<T, U>
    {
        public Tuple<T, U>[] cars { get; set; }
        public int Size { get; private set; }


        public CarCollection()
        {
            cars = new Tuple<T, U>[] { };
            Size = 0;
        }

        public CarCollection(int size, params Tuple<T, U>[] tuple)
        {
            cars = tuple;
            Size = size;
        }

        public Tuple<T, U> this[int i]
        {
            get { return cars[i]; }
            set { cars[i] = value; }
        }

        public void Add(T carName, U year)
        {
            if (carName.GetType() == typeof(string) && year.GetType() == typeof(int))
            {
                Tuple<T, U>[] temp = new Tuple<T, U>[++Size];
                for (int i = 0; i < Size - 1; i++)
                {
                    temp[i] = cars[i];
                }
                temp[Size - 1] = new Tuple<T, U>(carName, year);
                cars = temp;
            }



        }

        public void DeleteAll()
        {
            Tuple<T, U>[] temp = new Tuple<T, U>[0];
            Size = 0;
            cars = temp;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            CarCollection<string, int> car = new CarCollection<string, int>(2, new Tuple<string, int>("heh", 1998), new Tuple<string, int>("mazda", 2000));
            car.Add("BMV", 2017);
            Console.WriteLine("Before deleting:");
            for (int i = 0; i < car.Size; i++)
            {
                Console.WriteLine(car[i].Item1 + " " + car[i].Item2);
            }
            car.DeleteAll();
            car.Add("Honda", 2014);
            Console.WriteLine("After deleting and adding new element:");
            for (int i = 0; i < car.Size; i++)
            {
                Console.WriteLine(car[i].Item1 + " " + car[i].Item2);
            }
            Console.ReadKey();
        }
    }
}
