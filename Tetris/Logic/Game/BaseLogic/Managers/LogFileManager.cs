using System.IO;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal class LogFileManager
    {
        private  string logFile;

        internal LogFileManager()
        {
            this.logFile = GameData.logFile;
        }

        internal  void ReadOldScoresFromFile(string[] scores)
        {
            if (!File.Exists(logFile))
            {
                File.Create(logFile);
            }

            var reader = new StreamReader(logFile);
            string line = reader.ReadLine();

            for (int i = 0; i < scores.Length; i++)
            {
                if (line != null)
                {
                    scores[i] = line;
                    line = reader.ReadLine();
                }
            }

            reader.Close();
        }

        internal  void WriteNewScoresToFile(string[]scores)
        {
            var writer = new StreamWriter(logFile);
            for (int i = 0; i < scores.Length; i++)
            {
                writer.WriteLine(scores[i]);
            }

            writer.Close();
        }
    }
}
