using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempController
{

    class TemperatureController
    {
        public delegate void DelegateTemperatureHandler(int Tempeature);
        public delegate void DelegateTemperatureHandler2(int Tempeature);


        public static void LowTemperatureHandler(int Temperature)
        {
            Console.WriteLine("The temperature {0} is low and has crossed its threshold limit {1}", Temperature, Temperature - 5);
        }


        public static void HighTemperatureHandler(int Temperature)
        {
            Console.WriteLine("The temperature {0} is high and has crossed its threshold limit {1}", Temperature, Temperature+5);
        }


        public static void HotTemperatureTimeHandler(int Temperature)
        {
            Console.WriteLine("It's hot out there, you should relax at your home\n");
        }


        public static void LowTemperatureTimeHandler(int Temperature)
        {
            Console.WriteLine("It's cold out there, wear some woollen clothes and then only step out of the house\n");
        }



        static void Main(string[] args)
        {
            Console.WriteLine("enter the low temperature value\n");
            int LowTemperature = int.Parse(Console.ReadLine());

            Console.WriteLine("enter the high temperature  value\n");
            int HighTemperature = int.Parse(Console.ReadLine());

            DelegateTemperatureHandler LowTemperatureIndicator = new DelegateTemperatureHandler(LowTemperatureHandler);
            DelegateTemperatureHandler2 HighTemperatureIndicator = new DelegateTemperatureHandler2(HighTemperatureHandler);

            LowTemperatureIndicator += LowTemperatureTimeHandler;
            HighTemperatureIndicator += HotTemperatureTimeHandler;

            int TemperatureManyTimesCheck = 20;

            Random RandomTemperature = new Random();

            int LowTemperatureThreshold = LowTemperature - 5;
            int HighTemperatureThreshold = HighTemperature + 5;

            for (int TemperatureManyTimesIteration = 0; TemperatureManyTimesIteration < TemperatureManyTimesCheck; TemperatureManyTimesIteration++)
            {

                int Temperature = RandomTemperature.Next(60);

                if (Temperature < LowTemperatureThreshold)
                {
                    
                    TemperatureEventManager(Temperature);
                }
                if (Temperature > HighTemperatureThreshold)
                {

                    TemperatureEventManager2(Temperature);
                }


            }


            Console.WriteLine("enter any key to exit the program");
            Console.ReadLine();
        }


        public event DelegateTemperatureHandler TemperatueEvent;
        public event DelegateTemperatureHandler2 TemperatureEvent2;


        public static void TemperatureEventManager(int Temperature)
        {
            
            if (TemperatureEvent != null)
                TemperatureEvent(Temperature);

        }
        public static void TemperatureEventManager2(int Temperature)
        {

            if (TemperatureEvent2 != null)
                TemperatureEvent2(Temperature);

        }


    }
    
}

