using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift.Interfaces
{
    public interface IState
    {        
        int Target { get; }  //floor number
        int Speed { get; }   //0...100%       

        IState Progress();   //return new state (or same if not changed)
    }
}
