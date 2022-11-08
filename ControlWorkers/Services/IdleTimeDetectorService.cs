using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorkers.Services
{
    /// <copyright>
    /// © Dmitry Yalchik 2022. All rights are protected by the law of the Russian Federation
    /// </copyright>
    public static class IdleTimeDetectorService
    {
        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        public static IdleTimeInfoService GetIdleTimeInfo()
        {
            int systemUptime = Environment.TickCount,
                lastInputTicks = 0,
                idleTicks = 0;

            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            if (GetLastInputInfo(ref lastInputInfo))
            {
                lastInputTicks = (int)lastInputInfo.dwTime;

                idleTicks = systemUptime - lastInputTicks;
            }

            return new IdleTimeInfoService
            {
                LastInputTime = DateTime.Now.AddMilliseconds(-1 * idleTicks),
                IdleTime = new TimeSpan(0, 0, 0, 0, idleTicks),
                SystemUptimeMilliseconds = systemUptime,
            };
        }
    }

    public class IdleTimeInfoService
    {
        public DateTime LastInputTime { get; internal set; }
        public TimeSpan IdleTime { get; internal set; }
        public int SystemUptimeMilliseconds { get; internal set; }
    }

    internal struct LASTINPUTINFO
    {
        public uint cbSize;
        public uint dwTime;
    }
}