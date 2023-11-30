using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Lion : Animal
    {
        public void Roar()
        {
            Console.WriteLine("1ааакъ");
        }
        public Lion(string name) : base(name)
        {

        }
        public override void GiveSound()
        {
            Console.WriteLine("LionSound");
        }
    }
}
