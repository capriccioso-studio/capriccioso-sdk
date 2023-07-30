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
    }

}