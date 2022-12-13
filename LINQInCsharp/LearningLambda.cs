namespace LINQInCsharp
{
    internal static class LearningLambda
    {
       static List<int> list = new List<int>();

        public static void PrintEven()
        {
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            List<int> evenNumbers = list.FindAll((i) =>
            {
                Console.WriteLine("value of i is currently: {0}", i);
                bool isEven = ((i % 2) == 0);
                return isEven;
            });
            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();

        }
    }
}
