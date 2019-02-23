using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{

    #region Klasa oryginalna, korzysta ze swojego interfejsu

    public class Point
    {
        public float X, Y;

        public Point(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    /// <summary>
    /// Interfrejs dla klienta, używany przez klienta
    /// </summary>
    public interface IRegularPolygon
    {
        Point Position { get; }
        int NumberOfSides { get; }
        float LengthOfSides { get; }

        void ShowParameters();
        void ShowNameOfPolygon();
        float CalculateRound();
        float CalculateField();
    }

    /// <summary>
    /// Klasa abstrakcyjna Wielokąt foremny, implementuje interfejs
    /// </summary>
    public abstract class RegularPolygon : IRegularPolygon
    {
        public Point Position { get; private set; }

        public int NumberOfSides { get; private set; }

        public float LengthOfSides { get; private set; }

        public RegularPolygon(Point position, int numberOfSides, float lengthOfSides)
        {
            this.Position = position;
            this.NumberOfSides = numberOfSides;
            this.LengthOfSides = lengthOfSides;
        }

        public abstract float CalculateField();

        public float CalculateRound()
        {
            return NumberOfSides * LengthOfSides;
        }

        public abstract void ShowNameOfPolygon();

        public void ShowParameters()
        {
            Console.WriteLine(String.Format("Parametry x:{0}, y:{1}, liczba boków: {2}, długość boków: {3}", Position.X, Position.Y, NumberOfSides, LengthOfSides));
        }
    }

    public class RegularTriangle : RegularPolygon
    {
        public RegularTriangle(Point position, float lengthOfSides) : base(position, 3, lengthOfSides)
        {
        }

        public override float CalculateField()
        {
            return LengthOfSides * LengthOfSides * (float)(Math.Sqrt(3.0) / 4.0);
        }

        public override void ShowNameOfPolygon()
        {
            Console.WriteLine("Trójkąt równoboczny");
        }
    }

    /// <summary>
    /// Klasa klienta, korzysta z Wielokątu Foremnego
    /// </summary>
    public static class Client
    {
        public static void GetPolygonInformation(IRegularPolygon polygon)
        {
            polygon.ShowNameOfPolygon();
            Console.WriteLine();
            polygon.ShowParameters();
            Console.WriteLine(String.Format("Obwód: {0}", polygon.CalculateRound()));
            Console.WriteLine(String.Format("Pole: {0}", polygon.CalculateField()));
            Console.WriteLine();
        }
    }

    #endregion

    #region Niepasujący kod który chcemy zaadoptować

    public class Rectangle
    {
        public Point p1; //lewy-górny róg
        public Point p2; //prawy-górny róg

        protected float Width()
        {
            return p2.X - p1.X;
        }

        protected float Height()
        {
            return p2.Y - p1.Y;
        }

        public Rectangle(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public void DisplayRectangleName()
        {
            Console.WriteLine("Prostokąt");
        }

        public void GetParameters()
        {
            Console.WriteLine(String.Format("lewa krawędź: {0}, górna krawędź: {1}, szerokość: {2}, wysokość: {3}",
                p1.X, p1.Y, Width(), Height()));
        }

        public float CalculateField()
        {
            return Height() * Width();
        }
    }

    #endregion

    #region Adapter, tu będziemy adoptować niepasujący kod

    public class RegularRectangle : RegularPolygon
    {
        /// <summary>
        /// Przekazujemy do bazowego konstruktora przekonwertowane wartości
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public RegularRectangle(Rectangle rectangle) 
            : base(CalculateCenter(rectangle.p1, rectangle.p2), 4, CalculateSideWidth(rectangle.p1, rectangle.p2))
        {
            this.Rectangle = rectangle;
        }

        private static Point CalculateCenter(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }

        private static float CalculateSideWidth(Point p1, Point p2)
        {
            float sideX = p2.X - p1.X;
            float sideY = p2.Y - p1.Y;

            if (sideX != sideY) throw new ArgumentException("Podany prostokąt nie jest foremny!");
            else return sideX;
        }

        /// <summary>
        /// Referencja do Adaptee, obiekt który chcemy zaadaptować, z niego korzystamy w adapterze.
        /// </summary>
        public Rectangle Rectangle;

        #region Implemented

        public override void ShowNameOfPolygon()
        {
            this.Rectangle.DisplayRectangleName();
            Console.WriteLine(" foremny");
        }

        public override float CalculateField()
        {
            return Rectangle.CalculateField();
        }

        #endregion
    }

    #endregion
}
