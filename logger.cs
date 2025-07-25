using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minecraftServer_snyc_client_UWP_
{
    public static class Logger
    {
        // 定义一个委托和事件，用于通知 UI 层更新日志
        public delegate void LogEventHandler(string message);
        public static event LogEventHandler OnLog;
        // 静态构造函数，确保在应用程序启动时就可以使用日志功能
        // 提供一个 Log 方法供全局调用
        public static void Log(string message)
        {
            OnLog?.Invoke(message);
        }
    }
}
