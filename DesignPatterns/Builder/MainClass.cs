using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Cat
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value;}
        }

        private int _age;
        public int Age
        {
            get { return _age;  }
            set { _age = value; }
        }
    }


    public class MainClass
    {
    }
}
