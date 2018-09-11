using System.IO;
using System.Collections.Generic;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class LogFileManager
    {
        private static string logFile = GameData.LogFile;

        static LogFileManager()
        {
            if (!File.Exists(logFile))
            {
                File.Create(logFile).Dispose();
            }
        }

        internal static IEnumerable<string> Read()
        {
            using (StreamReader reader = new StreamReader(logFile))
            {
                return reader.ReadToEnd().Trim().Split("\n".ToCharArray());
            }
        }

        internal static void Write(IEnumerable<string> scoreTable)
        {
            using (StreamWriter writer = new StreamWriter(logFile))
            {
                foreach (string score in scoreTable)
                {
                    writer.WriteLine(score);
                }
            }
        }
    }
}