using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGridView_Import_Excel
{
    class Saloon
    {
        public string ProjectName;
        public int FCtime;
        public int FCcount;

        public int FBtime;
        public int FBcount;

        public int RCtime;
        public int RCcount;

        public int RC40time;
        public int RC40count;

        public int RC100time;
        public int RC100count;

        public int RBtime;
        public int RBcount;

        public double Coef=1;

        public int GeneralCount()
        {
            return FCcount + FBcount + RBcount  + RCcount;
        }

        public  Saloon(string c)
        {
            ProjectName = c;
            FCcount = FCtime = FBcount = FBtime = RC40count = RC40time =RC100count=RC100time = RBtime = RBcount=0;
        }

        public double PartTime(double a, double b)
        {
            if (a != 0 && b != 0)
            {
                return a / b;
            }
            else return 0;
        }
        public double TimeSaloon()
        {
            if (RBtime == 0 || RC40time == 0  )
            {
                return ((PartTime(FCtime , FCcount))* 2 + 2 *( PartTime(FBtime , FBcount))) / 0.65;
            }
            else if(FCtime == 0 || FBcount ==0)
            {
                return (2 * (PartTime(RBtime , RBcount)) + PartTime(RC40time , RC40count)) / 0.35;
            }
            else
            {
                Double percent = (double)(RC40time / (RC40time + RC100time));
                return (PartTime(FCtime , FCcount)) * 2 + 2 * (PartTime(FBtime , FBcount)) + 2 * (PartTime(RBtime , RBcount)) + (1-percent)* (RC100time/RC100count) + percent*(2*RC40time/RC40count) ;
            }
        }
    }
}
