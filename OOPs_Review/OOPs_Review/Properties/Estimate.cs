using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Estimate
    {
        public double TotalPrice { get; private set; }

        //LinearLength is a variable of datatype double
        public double LinearLength { get; set; }

        //Panel is a variable of datatype FencePanel
        public Fence_Panel Panel { get; set; }

        public List<Gate> Gates { get; set; }

        public Estimate() //nothing in the brackets
        {
            //this constructor emulates the system constructor
        }

        //greedie constructor
        public Estimate(double linearlength, Fence_Panel panel, List<Gate> gates)//no price
        {
            LinearLength = linearlength;
            Panel = panel;
            Gates = gates;

            //optional
            CalculatePrice();
        }

        public double CalculatePrice()
        {
            //assuming the Panel and Gate instances exist and are correct
            //there is no validation inside this example


            double numberofpanels = Panel.EstimatedNumberOfPanels(LinearLength);
            if ((int)(numberofpanels * 10.0) > ((int)numberofpanels * 10))
            {
                numberofpanels = (int)numberofpanels + 1;
            }
            //summing calculated prices
            if (Panel.Price == null)
            {
                throw new Exception("Panel price is needed to create estimate");
            }
            else
            {
                TotalPrice += numberofpanels * (double)Panel.Price;
                foreach (var item in Gates)
                {
                    TotalPrice += item.Price;
                }
            }
            return TotalPrice;
        }
    }
}
