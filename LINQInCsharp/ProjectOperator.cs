using static LINQInCsharp.Datastore;

namespace LINQInCsharp
{
    public class ProjectOperator
    {
        static IEnumerable<Racer> racersList = Formula1.GetChampions();
        public static void UsingQueryWithSelect()
        {
            var racers = from racer in Formula1.GetChampions() where racer.Wins > 8 select racer;

            var racers1 = Formula1.GetChampions().Where(x => x.Cars.ToString() == "Ferari");

            Console.WriteLine("Names of racers with more than 20 wins\n\n");
            foreach (var item in racers1)
            {
                Console.WriteLine($"{item} has {item.Cars} wins");
            }
        }

        // Using select many  or compound from

        public static void UsingCompoundFrom()
        {
            var cars = from racer in racersList
                       from car in racer.Cars
                       select new
                       {
                           car,
                           racer
                       };

            foreach (var item in cars)
            {
                Console.WriteLine($"Name: {item.racer} Car:{item.car}");
            }

        }

        public static void UsingSelectFrom()
        {
            var cars = racersList.SelectMany(
                racer => racer.Cars,(_racer, car) =>
                new {
                    racerName = _racer.LastName,
                    car ,
                    Year = _racer.Years,
                });
                Console.WriteLine(@"Racer Name                             Car Name");
            foreach (var item in cars)
            {
                Console.WriteLine(@$"Name:{item.racerName}                 Car : {item.car} ");

                foreach (var year in item.Year)
                {
                    Console.WriteLine($" Year: { year}");
                }
            }
           
        }

        public static void UsingWhereMethodSyntax()
        {
            var result = racersList.Where(car => car.Cars.Contains("Ferrari") || car.Cars.Contains("Massarati"));

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void QueryUkRacers()
        {
            var _country = "Uk";
            var result = from racer in racersList
                         from country in racer.Country
                         where country.ToString() == _country
                         select racer;


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        public static void QueryUkRacers2()
        {
            var result = racersList.Where(racer => racer.Country.Contains("UK"));

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

   
        public static void QueryRacers2()
        {
            var result = from racer in racersList
                         from years in racer.Years
                         where years > 1960
                         select racer;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
