using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle(1);
            Square s1 = new Square(1);

            AreaCalculator a1 = new AreaCalculator(c1);
            ValuePrinter v1 = new ValuePrinter(a1);
            v1.PrintArea();
            AreaCalculator a2 = new AreaCalculator(s1);
            ValuePrinter v2 = new ValuePrinter(a2);
            v2.PrintArea();
            Console.ReadLine();
        }
    }

    interface IShapes
    {
        double Area();
    }

    interface I3Dshapes
    {
        double Volume();
    }

    interface IManageShapes
    {
        double Calculate();
    }

    class Square : IShapes, IManageShapes
    {
        private double length;

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public Square(int _length)
        {
            this.Length = _length;
        }

        public double Area()
        {
            return Length * Length;
        }

        public double Calculate()
        {
            return this.Area();
        }
    }

    class Circle : IShapes, IManageShapes
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public Circle(double _radius)
        {
            this.Radius = _radius;
        }

        public double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public double Calculate()
        {
            return this.Area();
        }
    }

    class Cubeoid : IShapes, I3Dshapes, IManageShapes
    {
        private double length;

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public Cubeoid(double _length)
        {
            this.Length = _length;
        }

        public double Area()
        {
            return 6 * Length * Length;
        }

        public double Volume()
        {
            return Length * Length * Length;
        }

        public double Calculate()
        {
            return this.Area();
        }
    }

    class AreaCalculator
    {
        private IManageShapes shape;
        public IManageShapes Shape { get { return shape; } set { shape = value; } }
        public AreaCalculator(IManageShapes _shape)
        {
            this.Shape = _shape;
        }

        public virtual double GetValue()
        {
            return Shape.Calculate();
        }
    }

    class VolumeCalculator : AreaCalculator
    {
        public VolumeCalculator(IManageShapes _shape) : base(_shape)
        { }
        public override double GetValue()
        {
            return Shape.Calculate();
        }
    }

    class ValuePrinter
    {
        private AreaCalculator calculator;

        public AreaCalculator Calculator
        {
            get { return calculator; }
            set { calculator = value; }
        }

        public ValuePrinter(AreaCalculator _calculator)
        {
            this.Calculator = _calculator;
        }

        public void PrintArea()
        {
            Console.WriteLine("Area is " + this.Calculator.GetValue());
        }
    }

    /*dependency inversion Principle example*/
    interface DBConnectionInterface
    {
        void Connect();
    }

    class MySQLConnection : DBConnectionInterface
    {
        public void Connect()
        {
            // handle the database connection
            Console.WriteLine("Database connection");
        }
    }

    class PasswordReminder
    {
        private DBConnectionInterface dbConnection;

        public PasswordReminder(DBConnectionInterface _dbConnection)
        {
            dbConnection = _dbConnection;
        }
    }
}
