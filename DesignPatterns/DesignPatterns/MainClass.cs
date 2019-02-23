using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodFactory;
using Singleton;
using Adapter;
using Decorator;
using Facade;
using Bridge;
using Proxy;
using Flyweight;

namespace DesignPatterns
{
    class MainClass
    {
        static void Main(string[] args)
        {
            //RunMethodFactory();
            //RunSingleton();
            //RunAdapter();
            //RunDecorator();
            //RunFacade();
            //RunBridge();
            //RunProxy();
            RunFlyweight();

            Console.ReadLine();
        }

        private static void RunFlyweight()
        {
            string doc = "ABCDDDABBC";
            char[] docSigns = doc.ToCharArray();

            ConsoleColor[] colors = new ConsoleColor[docSigns.Length];

            for (int i = 0; i < docSigns.LongLength; ++i) colors[i] = ConsoleColor.White;
            colors[3] = ConsoleColor.DarkRed;
            colors[4] = ConsoleColor.Blue;
            colors[6] = ConsoleColor.DarkYellow;

            SignFactory signFactory = new SignFactory();
            for (int i = 0; i < docSigns.Length; ++i)
            {
                Sign sign = signFactory.GetSign(docSigns[i]);
                sign.Display(colors[i]);
            }
        }

        private static void RunProxy()
        {
            ProxyController controller = new ProxyController();
            

            controller.TurnOn();
            controller.SetChannel(5);
            controller.SetChannel(7);
            controller.TurnOff();
        }

        private static void RunBridge()
        {
            Bridge.IHardware tvHardware = new Bridge.TV();

            Controller controller = new Controller(tvHardware);

            controller.TurnOn();
            controller.SetChannel(5);
            controller.SetChannel(2);
            controller.SetPreviousChannel();
            controller.TurnOff();

            
        }

        private static void RunFacade()
        {
            var caffeWithCinamoneAndCitrus = FacadeClass.CaffeWithCinamoneAndSugar();
            Console.WriteLine(caffeWithCinamoneAndCitrus);
            Console.WriteLine(String.Format(" Cena: {0} zł", caffeWithCinamoneAndCitrus.Price()));

            var teaWithCitrus = FacadeClass.TeaWithCitrus(2);
            Console.WriteLine(teaWithCitrus);
            Console.WriteLine(String.Format(" Cena: {0} zł", teaWithCitrus.Price()));

            Console.ReadLine();
        }

        private static void RunDecorator()
        {
            var caffe = new Caffe();
            Console.WriteLine(caffe);
            Console.WriteLine(String.Format(" Cena: {0} zł", caffe.Price()));

            //Klient korzysta z Decorator
            var cafeeWithCinamone = new DrincWithCinamone(caffe);
            Console.WriteLine(cafeeWithCinamone);
            Console.WriteLine(String.Format(" Cena: {0} zł", cafeeWithCinamone.Price()));

            var caffeWithSugar = new DrincWithSugar(caffe, true);
            Console.WriteLine(caffeWithSugar);
            Console.WriteLine(String.Format(" Cena: {0} zł", caffeWithSugar.Price()));

            var drincWithCitrus = new DrincWithCitrus(new Tea(), 2);
            Console.WriteLine(drincWithCitrus);
            Console.WriteLine(String.Format(" Cena: {0} zł", drincWithCitrus.Price()));

            var caffeWithCitrus = new DrincWithCitrus(caffe, 2);
            Console.WriteLine(caffeWithCitrus);
            Console.WriteLine(String.Format(" Cena: {0} zł", caffeWithCitrus.Price()));

            Console.ReadLine();
        }

        private static void RunAdapter()
        {
            //Odpalamy oryginał
            Point trianglePosition = new Point(10.0f, 10.0f);
            RegularTriangle regularTriangle = new RegularTriangle(trianglePosition, 5.0f);
            Client.GetPolygonInformation(regularTriangle);

            //Odpalamy zaadaptowany prostokąt            
            Rectangle rectangle = new Rectangle(new Point(10f, 10f), new Point(20f, 20f));
            RegularRectangle regularRectangle = new RegularRectangle(rectangle);
            Client.GetPolygonInformation(regularRectangle);
            Console.ReadLine();
        }

        private static void RunSingleton()
        {
            EventLoger.Initialize(false);
            var randomNumberGenerator = new RandomNumberGenerator();
            randomNumberGenerator.NumberGenerated +=
                                                        (sender, args) =>
                                                        {
                                                            EventLoger.AddEvent(args.messageArg);
                                                        };

            randomNumberGenerator.Finished +=
                                                        (sender, args) =>
                                                        {
                                                            EventLoger.Save();
                                                        };
            randomNumberGenerator.GenerateNumbers();
        }

        private static void RunMethodFactory()
        {
            var squareFactory = new SquareFactory();
            var triangleFactory = new TriangleFactory();
            IShape squareShape = squareFactory.CreateShape();
            IShape triangleShape = triangleFactory.CreateShape();
        }
    }
}
