using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Composite - Przykład reprezentuje drzewko relacji zatrudnionych pracowników. Odwiedzający - dodajemy czynności do liścia
/// </summary>
namespace Composite
{
    /// <summary>
    /// Komponent
    /// </summary>
    public interface IEmployee
    {
        //void AcceptVisitor(int depth);
        void AcceptVisitor(IVisitor visitor, int depth);
        void Reset();
    }

    public interface IVisitor
    {
        void Visit(IEmployee employee);
    }

    public class VisitorDisplayInformation : IVisitor
    {
        public void Visit(IEmployee employee)
        {
            Console.WriteLine(employee.ToString());
        }
    }

    public class VisitorCounting : IVisitor
    {
        private int allCounter = 0;
        private int bossCounter = 0;
        public void Visit(IEmployee employee)
        {
            allCounter++;
            if (employee is Boss) bossCounter++;
        }

        public void DisplayEmployeeCount()
        {
            Console.WriteLine("Liczba pracowników: "+allCounter + " Kierowników "+ bossCounter);
        }
    }

    /// <summary>
    /// Liść
    /// </summary>
    public class Employee : IEmployee
    {
        private string FirstName;
        private string LastName;
        private string Role;
        protected internal bool Visited;
        protected internal bool Reseted;

        public virtual void Reset()
        {
            Visited = false;
            Reseted = true;
        }

        public Employee(string firstName, string lastName, string role)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
            Reset();
        }

        public virtual void AcceptVisitor(IVisitor visitor, int depth)
        {
            // Komponent
            //MakeInd(depth);
            //Console.WriteLine(ToString());
            //Visited = true;
            //Reseted = false;

            //Odwiedzajacy
            visitor.Visit(this);
            Visited = true;
            Reseted = false;
        }

        protected void MakeInd(int depth)
        {
            for (int i = 0; i < depth; ++i)
            {
                Console.Write(' ');
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} ({2})", FirstName, LastName, Role);
        }

    }

    public class Boss : Employee
    {
        private string FirstName;
        private string LastName;
        private string Role;

        /// <summary>
        /// Kierownik posiada referencję do listy pracowników których jest szefem.
        /// </summary>
        private List<IEmployee> employees = new List<IEmployee>();

        public Boss(string firstName, string lastName, string role) : base(firstName, lastName, role)
        {
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }

        public override void AcceptVisitor(IVisitor visitor, int depth = 0)
        {
            base.AcceptVisitor(visitor, depth);
            MakeInd(depth);
            Console.WriteLine("Lista podwładnych:");
            foreach (Employee employee in employees)
            {
                if (!employee.Visited)
                {
                    employee.AcceptVisitor(visitor, depth + 1);
                }
                else
                {
                    Console.WriteLine("Cykl!");
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1} ({2})", FirstName, LastName, Role);
        }

        public void AddEmployee(IEmployee employee)
        {
            employees.Add(employee);
        }

        public override void Reset()
        {
            base.Reset();
            foreach (Employee emp in employees)
            {
                if (!emp.Reseted)
                {
                    emp.Reset();
                }
            }
        }
    }

}
