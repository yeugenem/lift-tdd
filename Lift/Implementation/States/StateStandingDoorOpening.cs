using Lift.Interfaces;


namespace Lift.Implementation.States
{
    public class StateStandingDoorOpening : BaseState
    {
        public StateStandingDoorOpening(ISensorsSet sensorsSet) : base(sensorsSet)
        {
            _speed = 0;
        }

        public StateStandingDoorOpening(BaseState prev) : base(prev)
        {
        }

        public override IState Progress()
        {
            ChooseTarget();
            if(_sensorsSet.DoorsOpen ?? false)
            {
                return new StateStandingDoorOpen(this);
            }
            return new StateStandingDoorOpening(this);
        }
    }

}
