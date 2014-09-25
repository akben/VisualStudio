using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class LoggingService : ServiceBase
    {
        public LoggingService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (!System.Diagnostics.EventLog.SourceExists("DenemeLog"))
                System.Diagnostics.EventLog
                    .CreateEventSource("DenemeLog", "DenemeProcessing");
            eventLog1.Source = "DenemeLog";
            eventLog1.Log = "DenemeProcessing";
            eventLog1.WriteEntry("Servis Çalışmaya Başladı?");
            timer1.Start();
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Servis Durduruldu");
        }
    }
}
