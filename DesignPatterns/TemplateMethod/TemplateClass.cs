using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{

    /// <summary>
    /// Wzorzec Metoda szablonowa, definiuje szablon z którego tworzone są nowe obiekty.
    /// </summary>
    public class TemplateClass
    {

        public abstract class Pizza
        {
            public Pizza()
            {
                Prepare();
            }

            private void Prepare()
            {
                PrepareCake();
                AddSauce();
                AddAdds();
                AddSpieces();
                Bake();
            }

            private void AddTomatoSauce()
            {
                Console.WriteLine("Dodaj sos pomidorowy");
            }

            protected virtual void AddSauce()
            {
                AddTomatoSauce();
            }

            private void Bake()
            {
                Console.WriteLine("Upiecz. Czas: " + GetBakeTime());
            }

            protected virtual string GetBakeTime()
            {
                return "15 min";
            }            

            protected abstract void PrepareCake();
            protected abstract void AddAdds();
            protected abstract void AddSpieces();


        }

        /// <summary>
        /// Klasy konkretne
        /// </summary>
        public class Margheritha : Pizza
        {
            protected override void AddAdds()
            {
                Console.WriteLine("Dodano mozarelle");
            }

            protected override void AddSauce()
            {
                base.AddSauce();
            }

            protected override void AddSpieces()
            {
                Console.WriteLine("Dodano bazylię, oregano");
            }

            protected override void PrepareCake()
            {
                Console.WriteLine("Cienkie ciasto");
            }
        }

        public class Soprano : Pizza
        {
            protected override void AddAdds()
            {
                Console.WriteLine("Oliwki, kapary");
            }

            protected override void AddSauce()
            {
                base.AddSauce();
            }

            protected override void AddSpieces()
            {
                Console.WriteLine("Bazylia, pieprz");
            }

            protected override void PrepareCake()
            {
                Console.WriteLine("Grube ciasto");
            }

            protected override string GetBakeTime()
            {
                return "20 min";
            }
        }

    }
}
