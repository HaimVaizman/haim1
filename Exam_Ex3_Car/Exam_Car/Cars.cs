using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Car
{
    class Cars : Car
    {
        List<Car> GetCars = new List<Car>();

        public Car this[int index]
        {
            get
            {
                return (Car)GetCars[index];
            }
            set
            {
                GetCars.Insert(index, value);
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (var item in GetCars)
            {
                //str += item.ToString() + "\n"; // if heritance toString for car class...

                str += $"manufacturer: {item.Manufacturer},\tmodel: {item.Model},\tprice: {item.Price}\n";

            }
            return str;

        }

        public void AddCar(Car car)
        {
            GetCars.Add(car);
        }

        public void CarPrice7()
        {
            var models = from x in GetCars
                         where x.Price > Math.Pow(x.Manufacturer.Length, 7)
                         select x.Model;

            foreach (var item in models)
            {
                Console.WriteLine(item);
            }
        }

        public void Name3()
        {
            var manufacturer = from y in GetCars
                               where y.Manufacturer.Length > 3
                               select y.Manufacturer;

            foreach (var item2 in manufacturer)
            {
                Console.WriteLine(item2 + ":  " + (item2.Length - 4));
            }
        }
    }
}
