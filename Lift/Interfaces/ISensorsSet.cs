using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift.Interfaces
{

    public interface ISensorsSet
    {
        bool? DoorsOpen { get; }
        bool? DoorsClosed { get; }
        int? FloorLocked { get; }
        int? FloorApproached { get; }
        int? FloorRequestedExt { get; }
        int? FloorRequestedint { get; }
    }

}
