using System;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class ScoreManager
    {
        private static string[] scores;
        private static LogFileManager logFileManager;
        private static readonly int countOfBestScores;

        static ScoreManager()
        {
            countOfBestScores = 10;
            logFileManager = new LogFileManager();
            scores = new string[countOfBestScores];

            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = "";
            }
        }

        /// There is  a lot of work ...
        internal static void DisplayScores()
        {
            logFileManager.ReadOldScoresFromFile(scores);

            var playScore = string.Format("{0:d5}  -".PadRight(14), GameData.points);
            var playDate = string.Format(DateTime.Now.ToShortDateString());

            if ((playScore + playDate).CompareTo(scores[scores.Length - 1]) >= 0)
            {
                scores[scores.Length - 1] = playScore + playDate;
            }

            Array.Sort(scores);
            Array.Reverse(scores);

            logFileManager.WriteNewScoresToFile(scores);

            Console.WriteLine(string.Join("\n", scores));
        }


        //Finish The Method !!!!!!!!!!
        internal static void DisplayCurrentScores()
        {
            //TODO да показва некви опции за резултати, класиране, да пита искаш ли рестарт или край и т.н. ...

        }

    }
}
