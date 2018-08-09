using System.IO;
using System.Collections.Generic;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class LogFile
    {
        private static string logFile = GameData.LogFile;

        static LogFile()
        {
            if (!File.Exists(logFile))
            {
                File.Create(logFile).Dispose();
            }
        }

        internal static ICollection<string> Read()
        {
            ICollection<string> scoreTable = new List<string>();

            using (StreamReader reader = new StreamReader(logFile))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    scoreTable.Add(line);
                    line = reader.ReadLine();
                }
            }

            return scoreTable;
        }

        internal static void Write(ICollection<string> scoreTable)
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