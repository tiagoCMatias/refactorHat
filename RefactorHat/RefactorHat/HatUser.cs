using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorHat
{
    class HatUser
    {
        private String _username;

        private String HAT_STATE_RED = "RED";
        private String HAT_STATE_GREEN = "GREEN";
        private String HAT_STATE_REFACTOR = "REFACTOR";

        public String STATE = "NO_STATE";

        private Hat _redHat;
        private Hat _greenHat;
        private Hat _refactorHat;

        public HatUser(string username)
        {
            _username = username;
            _redHat = new Hat("Red Hat");
            _greenHat = new Hat("Green Hat");
            _refactorHat = new Hat("Refactor Hat");
        }

        public String GetName()
        {
            return _username;
        }

        public void PutOnRedHat()
        {
            _redHat.StartTimer();
            _greenHat.StopTimer();
            _refactorHat.StopTimer();
            STATE = HAT_STATE_RED;
        }

        public void PutOnGreenHat()
        {
            _greenHat.StartTimer();
            _redHat.StopTimer();
            _refactorHat.StopTimer();
            STATE = HAT_STATE_GREEN;
        }

        public void PutOnRefactorHat()
        {
            _refactorHat.StartTimer();
            _greenHat.StopTimer();
            _redHat.StopTimer();
            STATE = HAT_STATE_REFACTOR;
        }

        public String GetRedHatTimerValue()
        {
            return _redHat == null ? "0" : _redHat.TimerValue();
        }

        public String GetGreenHatTimerValue()
        {
            return _greenHat == null ? "0" : _greenHat.TimerValue();
        }

        public String GetRefactorHatTimerValue()
        {
            return _refactorHat == null ? "0" : _refactorHat.TimerValue();
        }

    }
}
