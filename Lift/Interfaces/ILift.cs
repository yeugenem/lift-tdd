using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift.Interfaces
{
    public interface ILift
    {        
        IState GetState();
        IState Progress();
    }




    //    public interface IControlPanelInternal
    //    {
    //        bool[] Targets { get; }
    //        void SetTarget(int floor);
    //    }

    //public interface IHardware
    //{
    //    int ReadValue(int pin);
    //    void WriteValue(int pin, int val);             
    //}

}
