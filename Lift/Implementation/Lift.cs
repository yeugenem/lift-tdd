using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lift.Interfaces;

namespace Lift.Implementation
{
    public class Lift : ILift
    {
        private IState _curState;
        private ISensorsSet _sensorsSet;

        public Lift(ISensorsSet sensorsSet)
        {
            if (sensorsSet == null)
                throw new ArgumentNullException("Lift sensors not specified");
            _sensorsSet = sensorsSet;            
            _curState = new States.StateStandingDoorOpening(sensorsSet);
        }
        
        public IState GetState() => _curState;
        
        public IState Progress()
        {
            return _curState.Progress();
        }
    }
}
