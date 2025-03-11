namespace Test
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Action a = null;
            for (int i = 0; i < 10; i++)
                a += () => 
                { Console.WriteLine(i); };   
        }
    }
}