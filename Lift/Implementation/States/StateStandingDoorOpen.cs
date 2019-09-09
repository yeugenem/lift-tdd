using System;
using Lift.Interfaces;


namespace Lift.Implementation.States
{
    public class StateStandingDoorOpen : BaseState
    {
        public StateStandingDoorOpen(ISensorsSet sensorsSet) : base(sensorsSet)
        {
            _speed = 0;
        }

        public StateStandingDoorOpen(BaseState prev) : base(prev)
        {
        }

        public override IState Progress()
        {
            ChooseTarget();
            if(_sensorsSet.FloorLocked.HasValue && _target != _sensorsSet.FloorLocked && _target != -1)
            {
                return new StateStandingDoorClosing(this);
            }                
            return new StateStandingDoorOpen(this);
        }
    }
}
