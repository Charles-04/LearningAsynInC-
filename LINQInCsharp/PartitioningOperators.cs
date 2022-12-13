using static LINQInCsharp.Datastore;
using static LINQInCsharp.Datastore.Formula1;

namespace LINQInCsharp
{

    internal static class PartitioningOperators
    {

        //Take, TakeWhile, TakeLast
        public static void UsingTake()
        {
            var results = GetChampions().SkipWhile((x) => (x.Country.Contains("i")) || (x.Country.Contains("I")));

            foreach (var racer in results)
            {
                Console.WriteLine($" Country : {racer.Country} FirstName: {racer.FirstName}");
            }
        }
    }
    internal static class PartitioningOperatorsWithRangeAndIndex
    {
        static Index index = 1;
        static Range range = 1..4;


    }
    internal static class AggregatorOperators
    {
        public static void UsingAggregators()
        {
            var query = GetChampions().Count();

            var queryTwo = GetChampions()
                .Take(3)
                .Sum((x) => (x.Wins));

        }

        public static void UsingAggregates()
        {
            var queryFour = GetChampions().MaxBy((racer) => (racer.Wins));

            Console.WriteLine(queryFour);

        }
    }

    internal static class SequenceEquals
    {
        static List<int> numberList = new() { 1, 2, 3, 4 };
        static List<int> numberListTwo = new() { 1, 2, 3, 4 };

        public static void AreEqual()
        {
            var isOneEqual = numberList.SequenceEqual(numberListTwo);

            Console.WriteLine($"is it Equal {isOneEqual}");
        }
    }
    class LINQBasedFieldsAreClunky
    {
        private static string[] currentVideoGames =
        {
            "Morrowind", "Uncharted 2",
        "Fallout 3", "Daxter", "System Shock 2"
        };

        // Can't use implicit typing here! Must know type of subset!

        public void Something()
        {
            var subset =
            from g in currentVideoGames
            where g.Contains(" ")
            orderby g
            select g;

             void PrintGames()
            {
                foreach (var item in subset)
                {
                    Console.WriteLine(item);
                }
            }
        } 
      
    }

}
