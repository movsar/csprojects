using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal abstract class Animal
    {
        public string Name { get; private set; }
        public decimal Age { get; set; } = 0;

        public Animal(string name)
        {
            Name = name;
        }

        public Animal()
        {

        }

        public abstract void Move();

        public void Eat()
        {
            Name = "asd";
            Console.WriteLine("Ням-ням");
        }
        public void Sleep()
        {
            Console.WriteLine("Спатья");
        }
        public virtual void GiveSound()
        {
            Console.WriteLine("AnimalSound");
        }
    }
}
