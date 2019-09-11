using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs_Review.Properties
{
    public class Estimate
    {
        public double TotalPrice { get; private set; }

        //"LinearLength" is a variable of the datatype "double"
        public double LinearLength { get; set; }

        //"Panel" is the variable of the datatype "Fence_Panel"
        public Fence_Panel Panel {get;set;}

        public List<Fence_Gate> Gates { get; set; } //need conection from the other class "Fence_Gate"

        public double CalculatePrice()
        {
            //assuming the Panel and Gate instances exists and are correct
            //there is no validation inside this example


            double numberofpanels = Panel.EstimatedNumberOfPanels(LinearLength);
            if ((int)(numberofpanels * 10) > ((int)numberofpanels * 10))
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
