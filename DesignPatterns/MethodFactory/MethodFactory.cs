using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodFactory
{

    public interface IShape
    {
        
    }

    public class Square : IShape
    {

    }

    public class Triangle : IShape
    {

    }

    public abstract class ShapeFactory
    {
        public abstract IShape CreateShape();
    }

    public class SquareFactory : ShapeFactory
    {
        public override IShape CreateShape()
        {
            return new Square();
        }
    }

    public class TriangleFactory : ShapeFactory
    {
        public override IShape CreateShape()
        {
            return new Triangle();
        }
    }
    

}
