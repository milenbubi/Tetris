using System.IO;
using System.Collections.Generic;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class LogFileManager
    {
        private static readonly string logFile = GameData.LogFile;

        static LogFileManager()
        {
            if (!File.Exists(logFile))
            {
                File.Create(logFile).Dispose();
            }
        }

        internal static IEnumerable<string> Read()
        {
            return File.ReadAllText(logFile).Trim().Split("\n".ToCharArray());
        }

        internal static void Write(IEnumerable<string> scoreTable)
        {
            File.WriteAllLines(logFile, scoreTable);
        }
    }
}