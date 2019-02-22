using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodFactory;
using Singleton;
using Adapter;

namespace DesignPatterns
{
    class MainClass
    {
        static void Main(string[] args)
        {
            //RunMethodFactory();
            //RunSingleton();
            RunAdapter();
        }

        private static void RunAdapter()
        {
            //Odpalamy oryginał
            Point trianglePosition = new Point(10.0f, 10.0f);
            RegularTriangle regularTriangle = new RegularTriangle(trianglePosition, 5.0f);
            Client.GetPolygonInformation(regularTriangle);

            //Odpalamy zaadaptowany prostokąt
            Point rectanglePosition = new Point(10.0f, 20.0f);
            RegularRectangle rectangle = new RegularRectangle(rectanglePosition, 5.0f);
            Client.GetPolygonInformation(rectangle);
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
