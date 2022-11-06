using System;
using System.Collections.Generic;
using System.Text;

namespace Punjab_Ornaments.models
{
    public class Mortgagemodel
    {
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
        public TimeSpan Daydiff { get; set; }
        public int IntrestRate { get; set; } = 3;
        public int Validity { get; set; } = 0;
        public int PrincipalAmount { get; set;}
        public float IntrestAmount { get; set;} = 0;
        public float TotaltAmount { get; set; } = 0;

    }
}