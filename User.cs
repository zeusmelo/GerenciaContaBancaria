using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaContaBancaria
{
    internal abstract class User
    {
        private string name;
        private uint age;
        private DateTime born;
        private string adr;
        private string doc;

        public string Name { get => name; set => name = value; }
        public uint Age { get => age; set => age = value; }
        public DateTime Born { get => born; set => born = value; }
        public string Adr { get => adr; set => adr = value; }
        public string Doc { get => doc; set => doc = value; }

        public User(string name, uint age, DateTime born, string adr, string doc)
        {
            this.name = name;
            this.age = age;
            this.born = born;
            this.adr = adr;
            this.doc = doc;

        }

        
    }
}
