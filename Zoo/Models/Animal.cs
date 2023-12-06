namespace Zoo.Models
{
    internal abstract class Animal
    {
        #region Properties, Fields and Constructors
        public string Name { get; private set; }
        public decimal Age { get; set; } = 0;
        public abstract void Move();
        public Animal(string name)
        {
            Name = name;
        }
        #endregion
        public void Eat()
        {
            Console.WriteLine("Ням-ням");
        }
        public void Sleep()
        {
            Console.WriteLine("Спатья");
        }
        public virtual void MakeSound()
        {
            Console.WriteLine("Гав бав");
        }
    }
}
