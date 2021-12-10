using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    class Activity : IComparable
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
        public string Description { get { return _description + $". Cost - €{Cost}"; } set { _description = value; } }
        public ActivityType TypeOfActivity { get; set; }
        public override string ToString()
        {
            return $"{Name} - {ActivityDate.ToShortDateString()}";
        }
        public int CompareTo(object obj)
        {
            if(obj==null)
            {
                return 1;
            }
            Activity otherActivityDate = obj as Activity;
            if(otherActivityDate != null)
            {
                return this.ActivityDate.CompareTo(otherActivityDate.ActivityDate);
            }
            else
            {
                throw new ArgumentException("Is not a sortable date");
            }
        }
    }
}
