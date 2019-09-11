using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPs_Review
{

    //by default all classes are PRIVATE (can't be used by anyone else)
    //for this to be used by an outside user
    //  you MUST alter the permission for this class
    //  you WILL use public

    //Object in a seperate class; incapsulate
    public class Fence_Panel
    {
        // Properties //
        // a property is associated with a single piece of data
        // a property has two sub-components
        //  get: returns a value to the calling client (outside user)
        //  set: recieves a value from the calling client
        //      a keyword "value" is used to hold the incoming
        //          data to the property
        // the property has a "return" datatype (rdt) which specifies
        //          the type of data (type; datatype) allowed 
        // The property syntax does NOT allow for a paramerter.


        //Auto Implemented Property//
        //This style does NOT need a provate data member
        //the system will create an internal data member of the
        //       rdt specified in the property definition
        //public double Height { get; set; } //what about negative numbers???

        //Assuming you wish to validate your data, then you should be using
        //  a fully implemented property
        //example: Height must have a positive non-zero value
        //         Height must not be greater than 8 feet
        private double _Height;
        public double Height
        {
            get
            {
                return _Height;
            }
            set
            {
                //validation of data
                //throw exception; is invalid
                if (value > 0.0 && value <= 8.0)//greater than Zero //Less than or equal to 8.0
                {
                    _Height = value;
                }
                else
                {
                    throw new Exception("Invalid Height.");
                }
            }
        }
        public double Width { get; set; }

        //Fully Implemented Property//
        //this style NEEDS a PRIVATE data member (need to code one)
        //the private data member will store the incoming data value
        //Usually, this form of property is used when 
        //      additional coding is required for the incoming data
        //      such as: Validation of the data

        //EXAMPLE: the string of data CAN NOT be an empty string 
        //      (can be null/numeric; one or the other)
        private string _Style; //underscore is the data member

        public string Style
        {
            //the keyword "value" holds the incoming data to
            //  the property
            get
            {
                //returns the stored data value
                return _Style;
            }
            set
            {
                //stores the incoming data in "value" to the
                //  private data member for storage
                if (string.IsNullOrEmpty(value))
                {
                    _Style = null;
                }
                else
                {
                    _Style = value;
                }//EndOfIF

            }//ENDOfSet
        }//EOP String

        //nullable numeric property for a double
        //there are only TWO possibilities
        //  a) data is missing: null
        //  b) data is present ans is of the right datatype
        public double? Price { get; set; }

        //Constructors//
        //either you code your constructors or you OMIT your
        //  constructors
        //If you OMIT constructors then the system will initialize
        //  your data memebers to the natural system defaults for
        //  that data member datatype
        //If you code any constructor, you are responsible for coding
        //  ALL constructors to be used by this class

        //Default//
        //Stimulates the system initalization of your data
        //defaults executes on a: new Fence_Panel();
        public Fence_Panel()
        {
            //nothing in it; optionally you can override the system values with your 
            //  OWN values
            Height = 6.0;
            Width = 8.0;
            //The remainder of your data values would be the system values
            //Other feilds can be blank//
        }//EOPF_P


        //Greedie
        //the constructor has a list of parameters which will recieve
        //    an argument value for each property in the class
        public Fence_Panel(double height, double width,string style, double? price)
        {
            Height = height;
            Width = width;
            Style = style; //don't use the underscore. Public not Private
            Price = price;
        }

        //Behaviours (AKA methods)
        public double EstimatedNumberOfPanels(double linearlength)
        {
            //You could use either the properties width OR the 
            //      the data member _Width
            //Using the property ensures all validation OR
            //      exessive logic is in play
            double numberofpanels = linearlength / Width; //if you want to, you can use "_Width"
            return numberofpanels;
        }

        public double FenceArea(double linearlength)
        {
            //return linearlength * Height;
            return Width * Height * EstimatedNumberOfPanels(linearlength); 
        }


    }//eoc
}//eon
