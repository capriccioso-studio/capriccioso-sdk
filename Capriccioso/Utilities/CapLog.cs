using UnityEngine;
using System.Runtime.CompilerServices;
using System.IO;

namespace Capriccioso
{
    /// <summary>
    /// The advanced logging tool from the Capriccioso arsenal
    /// </summary>
    public static class CapLog : ICapLog
    {
        private bool _isInitialized = false;

        private void Init()
        {
            if (!_isInitialized)
            {
                Debug.developerConsoleVisible = true;
                _isInitialized = true;
            }
        }

        public void Log(string message, Object context = null, [CallerFilePath] string path = null, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {
            Init();
            string file = Path.GetFileName(path);
            string log = $"<color={LogColors.Log}><b>[{file} @ {caller}():{lineNumber}]</b> LOGG </color> - {message}";
            Debug.Log(log, context);
        }

        public void LogInfo(string message, Object context = null, [CallerFilePath] string path = null, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {
            Init();
            string file = Path.GetFileName(path);
            string log = $"<color={LogColors.Info}><b>[{file} @ {caller}():{lineNumber}]</b> INFO </color> - {message}";
            Debug.Log(log, context);
        }
        
        public void LogSuccess(string message, Object context = null, [CallerFilePath] string path = null, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {
            Init();
            string file = Path.GetFileName(path);
            string log = $"<color={LogColors.Success}><b>[{file} @ {caller}():{lineNumber}]</b> GOOD </color> - {message}";
            Debug.Log(log, context);
        }

        public void LogWarning(string message, Object context = null, [CallerFilePath] string path = null, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {
            Init();
            string file = Path.GetFileName(path);
            string log = $"<color={LogColors.Warning}><b>[{file} @ {caller}():{lineNumber}]</b> WARN </color> - {message}";
            Debug.Log(log, context);
        }

        public void LogError(string message, Object context = null, [CallerFilePath] string path = null, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {
            Init();
            string file = Path.GetFileName(path);
            string log = $"<color={LogColors.Error}><b>[{file} @ {caller}():{lineNumber}]</b> ERRR </color> - {message}";
            Debug.Log(log, context);
        }

        public void LogAssert(bool condition, string message, Object context = null, [CallerFilePath] string path = null, [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = null)
        {
            Init();
            string file = Path.GetFileName(path);
            string log = $"<color={LogColors.Error}><b>[{file} @ {caller}():{lineNumber}]</b> ERRR </color> - {message}";
            Debug.LogAssert(condition, message , context);
        }
    }

}