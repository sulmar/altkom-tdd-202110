using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Fundamentals
{
    public class Cooler
    {
        public bool IsEnabled { get; private set; }

        public CoolerModes Mode  { get; private set; }

        public void ChangeMode()
        {
            if (!IsEnabled)
                throw new InvalidOperationException();

            if (Mode == CoolerModes.Cooling)
            {
                Mode = CoolerModes.Heating;
            }
            else
            {
                Mode = CoolerModes.Cooling;
            }
        }

        public void Start() => IsEnabled = true;

        public void Stop() => IsEnabled = false;
    }

    public enum CoolerModes
    {
        Cooling,
        Heating
    }
}
