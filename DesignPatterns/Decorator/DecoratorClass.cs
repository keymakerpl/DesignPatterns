using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    #region Komponenty które chcemy dekorować(rozszerzyć)


    /// <summary>
    /// Abstrakcja Komponentu
    /// </summary>
    public abstract class Drinc
    {
        public abstract decimal Price();

        public void Capacity()
        {
            Console.WriteLine("\nObjętość: 330ml");
        }
    }

    /// <summary>
    /// Konkretny komponent A
    /// </summary>
    public class Tea : Drinc
    {
        public override decimal Price()
        {
            return 5M;
        }

        public override string ToString()
        {
            return "Tea";
        }
    }

    /// <summary>
    /// Konkretny komponent B
    /// </summary>
    public class Caffe : Drinc
    {
        public override decimal Price()
        {
            return 10M;
        }

        public override string ToString()
        {
            return "Caffe";
        }
    }

    #endregion

    #region Dekorator, nim dekorujemy komponenty

    /// <summary>
    /// Dekorator
    /// </summary>
    public abstract class DrincWithAdd : Drinc
    {
        /// <summary>
        /// Dekorator agreguje klasę abstrakcyjną po której dzidziczą komponenty konkretne które chcemy udekorować
        /// </summary>
        protected Drinc drinc;

        public DrincWithAdd(Drinc drinc)
        {
            this.drinc = drinc;
        }
    }

    #endregion

    #region Konkretne komponenty z użyciem dekoratora

    public class DrincWithCinamone : DrincWithAdd
    {
        public DrincWithCinamone(Drinc drinc) : base(drinc)
        {
        }

        public override decimal Price()
        {
            return drinc.Price() + 0.5M;
        }

        public override string ToString()
        {
            return drinc.ToString() + " with cinamone";
        }
    }

    public class DrincWithSugar : DrincWithAdd
    {
        private bool brownSugar;
        public DrincWithSugar(Drinc drinc, bool brownSugar = false) : base(drinc)
        {
            this.brownSugar = brownSugar;
        }

        public override decimal Price()
        {
            return drinc.Price() + (brownSugar ? 0.3M : 0.2M);
        }

        public override string ToString()
        {
            return drinc.ToString() + String.Format(" with {0} sugar", brownSugar ? "brown" : "white");
        }
    }

    public class DrincWithCitrus : DrincWithAdd
    {
        private int qnt;
        public DrincWithCitrus(Drinc drinc, int qnt = 1) : base(drinc)
        {
            this.qnt = qnt;
        }

        public override decimal Price()
        {
            return drinc.Price() + (qnt * 0.1M);
        }

        public override string ToString()
        {
            return drinc.ToString() + String.Format(" with {0} slice of citrus", qnt);
        }
    }

    #endregion
}
