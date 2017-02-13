using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speed.Lib
{
    public class SpeedTester
    {
        private bool _stop = false;
        private NetworkSpeedProvider _speedProvider;
        private SpeedFormatter _speedFormatter;
        public event EventHandler TestCompleteEvent;
        public event EventHandler StopEvent;
        public event EventHandler StartEvent;
        public string LastDownloadSpeed { get; set; }


        public SpeedTester()
        {
            this._speedProvider = new NetworkSpeedProvider(new DownloadFileUrlProvider());
            this._speedFormatter = new SpeedFormatter();
        }

        public void Start()
        {
            _stop = false;
            Test();
            System.Threading.Thread.Sleep(1000);
            
        }

        public void OnTestComplete(EventArgs e)
        {
            TestCompleteEvent?.Invoke(this, e);
        }

        public void Test()
        {
            while(true)
            {
                if (_stop) return;
                var speed = _speedProvider.GetInternetSpeed("westus");
                LastDownloadSpeed = _speedFormatter.GetSpeed(speed);
                OnTestComplete(EventArgs.Empty);
            }

        }


        public void Stop()
        {
            _stop = true;
        }
    }
}
