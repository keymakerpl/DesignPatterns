using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Wzorzec pyłka, tworzymy obiekt przez fabrykę gdy jest on potrzebny
/// </summary>

namespace Flyweight
{
    /// <summary>
    /// Ciężka klasa, zawiera właściwość kolor - powiedzmy, że jest ciężka.
    /// </summary>
    public class SignColor
    {
        protected ConsoleColor color;

        public SignColor()
        {

        }
    }

    /// <summary>
    /// Klasa abstrakcyjna znaku, lekka klasa, zawiera tylko znak
    /// </summary>
    public abstract class Sign
    {
        protected char ch;

        public Sign(char ch)
        {
            this.ch = ch;
        }

        public void Display(ConsoleColor color)
        {
            ConsoleColor orginalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(ch);
            Console.ForegroundColor = orginalColor;
        }
    }

    #region Konkretne komponenty, znaki A, B, C...

    class SignA : Sign
    {
        public SignA() : base('A')
        {
        }
    }

    class SignB : Sign
    {
        public SignB() : base('B')
        {
        }
    }

    class SignC : Sign
    {
        public SignC() : base('C')
        {
        }
    }

    class SignD : Sign
    {
        public SignD() : base('D')
        {
        }
    }

    #endregion

    #region Fabryka Znaków

    /// <summary>
    /// Fabryka znaków, tworzy nowy konkretny Obiekt w momencie kiedy jest wymagany
    /// </summary>
    public class SignFactory
    {

        private Dictionary<char, Sign> signs = new Dictionary<char, Sign>();

        public Sign GetSign(char ch)
        {
            Sign sign = null;
            if (signs.Keys.Contains(ch)) sign = signs[ch];
            else
            {
                switch (ch)
                {
                    case 'A':
                        sign = new SignA();
                        break;
                    case 'B':
                        sign = new SignB();
                        break;
                    case 'C':
                        sign = new SignC();
                        break;
                    case 'D':
                        sign = new SignD();
                        break;
                }
            }

            if (!signs.Keys.Contains(ch)) signs.Add(ch, sign);
            return sign;
        }

    }

    #endregion

}
