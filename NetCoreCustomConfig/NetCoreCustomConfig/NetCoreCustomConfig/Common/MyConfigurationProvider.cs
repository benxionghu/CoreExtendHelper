using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace NetCoreCustomConfig.Common
{
    public class MyConfigurationProvider : ConfigurationProvider
    {
        Timer timer;
        public MyConfigurationProvider() : base()
        {
            timer = new Timer();
            timer.Elapsed += Time_Elapsed;
            timer.Interval = 3000;
            timer.Start();
        }

        private void Time_Elapsed(object sender, ElapsedEventArgs args)
        {
            Load(true);
        }

        public override void Load()
        {
            Load(false);
        }

        void Load(bool reload)
        {
            this.Data["lastTime"] = DateTime.Now.ToString();
            if (reload)
            {
                base.OnReload();
            }
        }
    }
}
