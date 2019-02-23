using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decorator;

namespace Facade
{
    /// <summary>
    /// Fasada, wzorzec który można nazwać potocznie Menu, w tym przypadku buduje klientów korzystających z Decoratora
    /// </summary>
    public static class FacadeClass
    {
        public static Drinc CaffeWithCinamoneAndSugar()
        {
            Drinc caffe = new Caffe();

            caffe = new DrincWithCinamone(caffe);
            caffe = new DrincWithSugar(caffe);

            return caffe;
        }

        public static Drinc TeaWithCitrus(int numberOfSlices = 1)
        {
            Drinc tea = new Tea();

            tea = new DrincWithCitrus(tea, 2);

            return tea;
        }
    }
}
