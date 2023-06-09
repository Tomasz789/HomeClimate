using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWeatherWeb.Shared
{
    public class LogsService
    {
        private readonly IList<LogInfo> _logs;

        public LogsService()
        {
            _logs = new List<LogInfo>()
            {
                new LogInfo()
                {
                    Text = "Unable to connect",
                    IsError = true,
                },

                new LogInfo()
                {
                    Text = "Connected",
                    IsError= false,
                }
            };

        }

        public IEnumerable<LogInfo> GetLogs()
        {
            return _logs.AsEnumerable();
        }
    }
}
