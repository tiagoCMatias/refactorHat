using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace RefactorHat
{
    class Hat
    {
        private DispatcherTimer _timer;
        private Stopwatch _stopWatch;

        private String _hatName;

        public Hat(string name)
        {
            _hatName = name;
            _stopWatch = new Stopwatch();
        }

        public String GetHatName()
        {
            return _hatName;
        }

        public void StartTimer()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };            
            _stopWatch.Start();
            _timer.Start();
        }

        public void StopTimer()
        {
            _timer?.Stop();
            _stopWatch?.Stop();
        }

        public string TimerValue()
        {
            if (_stopWatch != null)
                return TimeSpan.Parse(_stopWatch.Elapsed.ToString()).TotalSeconds
                    .ToString(CultureInfo.InvariantCulture);
            else
                return "0";
        }
    }
}
