using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //EXAMPLE 01
    // Product: Computer
    public class Computer
    {
        public string CPU { get; set; }
        public string RAM { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Computer Info: CPU - {CPU}, RAM - {RAM}");
        }
    }

    // Builder: ComputerBuilder
    public interface IComputerBuilder
    {
        void BuildCPU();
        void BuildRAM();
        Computer GetComputer();
    }

    // Concrete Builder: GamingComputerBuilder
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer computer = new Computer();

        public void BuildCPU()
        {
            computer.CPU = "High-end Gaming CPU";
        }

        public void BuildRAM()
        {
            computer.RAM = "32GB DDR4 RAM";
        }

        public Computer GetComputer()
        {
            return computer;
        }
    }

    // Concrete Builder: OfficeComputerBuilder
    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer computer = new Computer();

        public void BuildCPU()
        {
            computer.CPU = "Office CPU";
        }

        public void BuildRAM()
        {
            computer.RAM = "8GB DDR4 RAM";
        }

        public Computer GetComputer()
        {
            return computer;
        }
    }

    // Director: ComputerDirector
    public class ComputerDirector
    {
        public ComputerDirector(IComputerBuilder builder)
        {
            builder.BuildCPU();
            builder.BuildRAM();
        }
    }



    //EXAMPLE 2:
    //Product: House
    public class House
    {
        public int stories { get;set;}
        public int houseNo { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"House Info: House No - {houseNo}, Stories - {stories}");
        }
    }

    // Builder: HouseBuilder
    public interface IHouseBuilder
    {
        void BuildStories();
        void BuildHouseNumber();
        House GetHouse();
    }

    // Concrete Builder: SingleStoryHouseBuilder
    public class SingleStoryHouseBuilder : IHouseBuilder
    {
        private House house = new House();

        public void BuildStories()
        {
            house.stories = 1;
        }

        public void BuildHouseNumber()
        {
            house.houseNo = 123;
        }

        public House GetHouse()
        {
            return house;
        }
    }

    // Concrete Builder: MultiStoryHouseBuilder
    public class MultiStoryHouseBuilder : IHouseBuilder
    {
        private House house = new House();

        public void BuildStories()
        {
            house.stories = 2;
        }

        public void BuildHouseNumber()
        {
            house.houseNo = 456;
        }

        public House GetHouse()
        {
            return house;
        }
    }

    // Director: HouseDirector
    public class HouseDirector
    {
        public HouseDirector(IHouseBuilder builder)
        {
            builder.BuildStories();
            builder.BuildHouseNumber();
        }
    }
}
