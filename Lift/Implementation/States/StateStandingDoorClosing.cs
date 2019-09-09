using Lift.Interfaces;


namespace Lift.Implementation.States
{
    public class StateStandingDoorClosing : BaseState
    {
        private StateStandingDoorClosing stateStandingDoorClosing;

        public StateStandingDoorClosing(ISensorsSet sensorsSet) : base(sensorsSet)
        {
            _speed = 0;
        }

        public StateStandingDoorClosing(BaseState prev) : base(prev)
        {            
        }

        public override IState Progress()
        {
            ChooseTarget();
            if(_sensorsSet.DoorsClosed ?? false)
            {
                return new StateStandingDoorClosed(this);
            }
            return new StateStandingDoorClosing(this);
        }
    }
}
