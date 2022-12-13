using static LINQInCsharp.Datastore.Formula1;

namespace LINQInCsharp
{
    internal class UsingSortingOperators
    {
        public static void SortingByQuery()
        {
            var results = from racer in GetChampions()
                          orderby racer.Country, racer.FirstName
                          select racer;

            var descendingRacers = from racer in GetChampions()
                                   orderby racer?.Country , racer?.FirstName 
                                   select racer;
            foreach (var racer in descendingRacers)
            {
                Console.WriteLine($" Country : {racer.Country} FirstName: {racer.FirstName}");
            }

        }
        public static void SortingByMethod()
        {
            var descendingRacers = GetChampions()
                .OrderByDescending(racer => racer.FirstName)
                .ThenByDescending(racer => racer.Country);

            foreach (var racer in descendingRacers)
            {
                Console.WriteLine($" Country : {racer.Country} FirstName: {racer.FirstName}");
            }
        }
    }
}
