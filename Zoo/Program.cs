namespace Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal Lion = new Lion("lion");
            Lion.Age = 4;
            Lion.GiveSound();

            //Elephant Elephant = new Elephant("elephant");
            //Elephant.Age = 6;
            
        }
    }
}
