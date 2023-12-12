using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakesAdvanced.Models
{
    internal class Store
    {
        public string Name { get; }
        public Kitchen _kitchen;
        public Storage _storage;
    }
}
