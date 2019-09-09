using Lift.Interfaces;
using System;



namespace Lift.Implementation.States
{
    public class BaseState : IState
    {
        protected ISensorsSet _sensorsSet;        
        protected int _speed;
        protected int _target;

        public BaseState(ISensorsSet sensorsSet)
        {
            if (sensorsSet == null)
                throw new ArgumentNullException("State sensors not specified");
            _sensorsSet = sensorsSet;
            _target = sensorsSet.FloorRequestedExt ?? sensorsSet.FloorLocked ?? -1;
            _speed = 0;            
        }

        protected BaseState(BaseState prev)
        {
            _sensorsSet = prev._sensorsSet;            
            _speed = prev._speed;
            _target = prev._target;
        }

        public int Target => _target;

        public int Speed => _speed;

        protected void ChooseTarget()
        {
            if (_target == -1 && _sensorsSet.FloorRequestedExt.HasValue)
                _target = _sensorsSet.FloorRequestedExt.Value;
        }

        public virtual IState Progress()
        {
            throw new NotImplementedException();
        }
    }
}
