using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    /// <summary>
    /// Ogólny mechanizm interpretacji Liczb Rzymskich
    /// </summary>
    class RomanNumberInterpreter
    {
        protected RomanNumberInterpreter(int value)
        {

        }

        /// <summary>
        /// Kluczowa metoda interpretera
        /// </summary>
        /// <param name="romanNumeber"></param>
        /// <param name="value"></param>
        protected virtual void Interpret(ref string romanNumeber, ref int value)
        {

        }



    }

    class UnityInterpreter : RomanNumberInterpreter
    {
        protected UnityInterpreter(int value) : base(value)
        {
        }
    }

    class DecimalInterpreter : RomanNumberInterpreter
    {
        protected DecimalInterpreter(int value) : base(value)
        {
        }
    }

    class HundredInterpreter : RomanNumberInterpreter
    {
        protected HundredInterpreter(int value) : base(value)
        {
        }
    }

    class ThousendInterpreter : RomanNumberInterpreter
    {
        protected ThousendInterpreter(int value) : base(value)
        {
        }
    }
}


