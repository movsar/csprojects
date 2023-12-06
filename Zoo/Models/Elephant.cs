using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Models
{
    internal class Elephant : Animal
    {
        public Elephant(string name) : base(name) { }

        public override void Move()
        {
            Console.WriteLine("Elephant moves");
        }
    }
}
