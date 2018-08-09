using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class ScoreManager
    {
        private static ICollection<string> scoreTable;
        private const int countOfBestScores = 10;
        private static string defaultScore = "0";

        static ScoreManager()
        {
            scoreTable = LogFile.Read();
        }

        internal static void UpdateScores()
        {
            string playScore = $"{GameData.points,-9:d5}{"-",-5}";
            string playDate = $"{DateTime.Now:dd MMM yyyy}";

            string currentResult = playScore + playDate;

            ReorderScoreTable(currentResult);

            LogFile.Write(scoreTable);
        }

        internal static void DisplayScores()
        {
            Console.Clear();
            Console.WriteLine($"\n{"Best Scores:",18}\n");
            Console.WriteLine(string.Join("\n", scoreTable));
            Console.WriteLine(Environment.NewLine);
        }

        private static void ReorderScoreTable(string currentResult)
        {
            scoreTable.Add(currentResult);

            scoreTable = scoreTable
                .OrderByDescending(s => s)
                .Concat(Enumerable.Repeat(defaultScore, 10))
                .Take(countOfBestScores)
                .ToList();
        }
    }
}