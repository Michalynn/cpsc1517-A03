using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    class Program
    {
        //assume you now how to obtain user entered data
        static void Main(string[] args)
        {
            double height = 6.5;
            double width = 8.0;
            double linearlength = 135.0;
            string style = "Neighbour Friendly: Spruce";
            double price = 108.00;

            //Store fence area
            //declare storage area for the fence data

            //create a "static" instance of a class
            //      (static doesn't change)
            //use the "new" command reference the class constructor

            Fence_Panel fenceInfo = new Fence_Panel(height, width, style, price); //order matters

            //obtain and store gate data
            Gate gateInfo;
            List<Gate> gatelist = new List<Gate>();

            //assuming looping to optain all gate data
            //each loop is one gate

            //Pass #1
            gateInfo = new Gate(); //system constructor since Gate has NO constructors
            height = 6.25;
            width = 4.0;
            style = "Neighbour Friendly 1/2 Picket: Spruce";
            price = 86.45;

            //name of the instance, the "." operator, the Property name = value;
            gateInfo.Height = height;
            gateInfo.Width = width;
            gateInfo.Style = style;
            gateInfo.Price = price;
            gatelist.Add(gateInfo);

            //Pass #2
            gateInfo = new Gate(); //system constructor since Gate has NO constructors
            height = 6.25;
            width = 3.25;
            style = "Neighbour Friendly: Spruce";
            price = 86.45;
            gateInfo.Height = height;
            gateInfo.Width = width;
            gateInfo.Style = style;
            gateInfo.Price = price;
            gatelist.Add(gateInfo);

            //Assume end of gate looping

            //create the Estimate
            Estimate theEstimate = new Estimate();//class default constructor
            theEstimate.LinearLength = linearlength;
            theEstimate.Panel = fenceInfo;
            theEstimate.Gates = gatelist;

            //name of the instance the "." operator, the behaviour name
            theEstimate.CalculatePrice();

            //client desires the output of the estimate
            Console.WriteLine("The fence is to be a " +theEstimate.Panel.Style+ " style");
            //dot operator (".") is like file explorer
            Console.WriteLine("\nTotal linear length requested: {0} ", theEstimate.LinearLength);
            Console.WriteLine("Number of required panels: {0} ", 
                theEstimate.Panel.EstimatedNumberOfPanels(theEstimate.LinearLength));
            Console.WriteLine("Number of gates: {0}", theEstimate.Gates.Count);
            double fenceArea = theEstimate.Panel.FenceArea(theEstimate.LinearLength);
            foreach (var item in theEstimate.Gates)
            {
                fenceArea += item.GateArea();
            }//OFFE
            Console.WriteLine(string.Format("\nTotal fence surface area {0:0.00}", fenceArea * 2));

            Console.ReadLine();


        }//eom
    }//eoc
}//eon
