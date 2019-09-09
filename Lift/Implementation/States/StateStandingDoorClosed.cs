using Lift.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift.Implementation.States
{

    public class StateStandingDoorClosed : BaseState
    {
        public StateStandingDoorClosed(ISensorsSet sensorsSet) : base(sensorsSet)
        {
            _speed = 0;
        }

        public StateStandingDoorClosed(BaseState prev) : base(prev)
        {
        }

        public override IState Progress()
        {
            ChooseTarget();
            if(_sensorsSet.FloorLocked.HasValue && _target == _sensorsSet.FloorLocked)
            {
                return new StateStandingDoorOpening(this);
            }
            return new StateStandingDoorClosed(this);
        }
    }
}
