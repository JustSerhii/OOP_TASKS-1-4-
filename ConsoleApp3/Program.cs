using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            Manager Serhiy = new Manager("Serhiy");
            Developer Mykola = new Developer("Mykola");
            Serhiy.FillWorkDay();

            Team teamA = new Team("K26");
            teamA.AddMember(Serhiy);
            teamA.AddMember(Mykola);
            teamA.PrintInfo();

            Developer Vitaliy = new Developer("Vitaliy");
            Vitaliy.FillWorkDay();

            Team teamB = new Team("K27");
            teamB.AddMember(Vitaliy);
            teamB.PrintNames();

            Team teamAB = teamA + teamB;
            Console.WriteLine("\nGlobal team: ");
            teamAB.PrintInfo();

        }
    }

    abstract class Worker
    {   
        private string Name;
        protected string Position;
        private string WorkDay = "8 hours";

        public Worker(string Name)
        {
            this.Name = Name;
        }

        public void Call() 
        {
            Console.WriteLine("Calling");
        }
        public void WriteCode() 
        {
            Console.WriteLine("Writing code");
        }
        public void Relax() 
        {
            Console.WriteLine("Relaxing");
        }
        public void PrintName()
        {   
            Console.WriteLine(Name);
        }
        public void PrintInfo()
        {
            Console.WriteLine(Name + "-" + Position + "-" + WorkDay);
        }
        public abstract void FillWorkDay();
    }

    class Developer : Worker
    {
        public Developer(string Position) : base(Position)
        {
            this.Position = "Developer";
        }

        public override void FillWorkDay()
        {
            Console.Write("\n");
            WriteCode(); 
            Call();
            Relax();
            WriteCode(); Console.Write("\n");
        }
    }

    class Manager : Worker
    {
        public Manager(string Position) : base(Position)
        {
            this.Position = "Manager";
        }

        static Random rand = new Random();
        private int random = rand.Next(1, 10);

        public override void FillWorkDay()
        {
            for (int i = 0; i < random; i++)
            {
                Call();
            }

            Console.Write("\n");
            Relax();

            random = rand.Next(1, 5);

            Console.Write("\n");
            for (int i = 0; i < random; i++)
            {
                Call();
            }
            Console.Write("\n");
        }
    }

    class Team
    {   
        protected string t_name;
        private List<Worker> TeamMembers = new List<Worker>();
        public Team(string t_name)
        {
            this.t_name = t_name;
        }

        public void AddMember(Worker worker)
        {
            TeamMembers.Add(worker);
        }
        public void PrintNames()
        {
            Console.WriteLine("Name of team: " + t_name);
            Console.WriteLine("Members names:");

            foreach (var member in TeamMembers)
            {
                member.PrintName();
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Name of team: " + t_name);
            Console.WriteLine("Members info:");

            foreach (var member in TeamMembers)
            {
                member.PrintInfo();
            }
        }

        public static Team operator +(Team A, Team B)
        {
            Team global = new Team(A.t_name + B.t_name);

            foreach (var worker in A.TeamMembers)
            {
                global.TeamMembers.Add(worker);
            }

            foreach (var worker in B.TeamMembers)
            {
                global.TeamMembers.Add(worker);
            }

            return global;
        }
    }
}
