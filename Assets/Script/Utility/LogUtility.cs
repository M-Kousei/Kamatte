using UnityEngine;

namespace Kamatte.Utility
{
    public static class LogUtility
    {
        public static LogLevel CurrentLogLevel =
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        LogLevel.Debug;
#else
        LogLevel.Warning;
#endif

        public static void Log(string message, LogLevel level = LogLevel.Info)
        {
            if (level < CurrentLogLevel) return;

            switch (level)
            {
                case LogLevel.Error:
                    Debug.LogError($"[LogLevel: {level}] {message}");
                    break;
                case LogLevel.Warning:
                    Debug.LogWarning($"[LogLevel: {level}] {message}");
                    break;
                default:
                    Debug.Log($"[LogLevel: {level}] {message}");
                    break;
            }
        }
    }
}