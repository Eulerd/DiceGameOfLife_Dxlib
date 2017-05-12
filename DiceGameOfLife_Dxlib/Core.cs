using System;

namespace DiceGameOfLife_Dxlib
{
    class Core
    {
        private const double MinInterval = 1;

        double interval = MinInterval;

        public double Interval
        {
            get { return interval; }
            set
            {
                if (interval < 0)
                    interval = MinInterval;
                else if (interval > int.MaxValue)
                    interval = int.MaxValue;
                else
                    interval = value;
            }
        }
    }
}
