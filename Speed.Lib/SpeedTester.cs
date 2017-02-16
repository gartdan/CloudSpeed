using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        public event EventHandler ErrorEvent;

        public string RegionName { get; set; }

        public string LastDownloadSpeed { get; set; }
        public string ErrorMessage { get; set; }

        public SpeedTester(string regionName = "westus")
        {
            this.RegionName = regionName;
            this._speedProvider = new NetworkSpeedProvider(new DownloadFileUrlProvider());
            this._speedFormatter = new SpeedFormatter();
        }

        public void Start()
        {
            _stop = false;
            Test(this.RegionName);
            System.Threading.Thread.Sleep(1000);
            
        }

        public void OnTestComplete(EventArgs e)
        {
            TestCompleteEvent?.Invoke(this, e);
        }

        public void OnError(EventArgs e)
        {
            ErrorEvent?.Invoke(this, e);
        }

        public void Test(string region = "westus")
        {
            while(true)
            {
                if (_stop) return;
                try
                {
                    var speed = _speedProvider.GetInternetSpeed(region);
                    LastDownloadSpeed = _speedFormatter.GetSpeed(speed);
                    OnTestComplete(EventArgs.Empty);
                }catch(WebException ex)
                {
                    this.ErrorMessage = ex.Message;
                    OnError(EventArgs.Empty);
                }

            }

        }


        public void Stop()
        {
            _stop = true;
        }
    }
}
