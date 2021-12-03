using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    class Activity// : IComparable
    {
        public Activity()
        {

        }
        public enum ActivityType
        {
            Air,
            Water,
            Land
        }
        private string _description;
        //properties
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        public string Description { get { return _description; } set { _description = value; } }
        public ActivityType TypeOfActivity { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
        /*public int DateCompareTo(object obj)
        {
            if (this.ActivityDate > obj.AcivityDate)
            {
                return 1;
            }
            else if(this.ActivityDate < obj.AcivityDate)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }*/
    }
}
