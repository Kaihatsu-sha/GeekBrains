using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.Core.Abstraction.Services
{
    public interface ILoggerService<T> 
    {
        void LogTrace(string message);
        void LogTrace<T0>(string message, T0 arg0);
        //void LogTrace<T0, T1>(string message, T0 arg0, T1 arg1);
        //void LogTrace<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

        //void LogDebug(string message);
        //void LogDebug<T0>(string message, T0 arg0);
        //void LogDebug<T0, T1>(string message, T0 arg0, T1 arg1);
        //void LogDebug<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

        //void LogInformation(string message);
        //void LogInformation<T0>(string message, T0 arg0);
        //void LogInformation<T0, T1>(string message, T0 arg0, T1 arg1);
        //void LogInformation<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

        //void LogWarning(string message);
        //void LogWarning<T0>(string message, T0 arg0);
        //void LogWarning<T0, T1>(string message, T0 arg0, T1 arg1);
        //void LogWarning<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

        //void LogError(string message);
        //void LogError<T0>(string message, T0 arg0);
        //void LogError<T0, T1>(string message, T0 arg0, T1 arg1);
        //void LogError<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);

        //void LogCritical(string message);
        //void LogCritical<T0>(string message, T0 arg0);
        //void LogCritical<T0, T1>(string message, T0 arg0, T1 arg1);
        //void LogCritical<T0, T1, T2>(string message, T0 arg0, T1 arg1, T2 arg2);     
    }
}
