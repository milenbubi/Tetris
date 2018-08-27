using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class ScoreManager
    {
        private static IEnumerable<string> scoreTable;
        private const int countOfBestScores = 10;
        private const string defaultScore = "0";

        static ScoreManager()
        {
            scoreTable = LogFileManager.Read();
        }

        internal static void UpdateScores()
        {
            string playScore = $"{GameData.points,-9:d5}{"-",-5}";
            string playDate = $"{DateTime.Now:dd MMM yyyy}";

            string currentResult = playScore + playDate;

            ReorderScoreTable(currentResult);

            LogFileManager.Write(scoreTable);
        }

        internal static void DisplayScores()
        {
            Console.Clear();
            Console.WriteLine($"\n{"Best Scores:", 17}\n");
            Console.WriteLine(string.Join("\n", scoreTable));
            Console.WriteLine(Environment.NewLine);
        }

        private static void ReorderScoreTable(string currentResult)
        {
            scoreTable = scoreTable
                .Concat(new string[] { currentResult })
                .OrderByDescending(s => s)
                .Concat(Enumerable.Repeat(defaultScore, countOfBestScores))
                .Take(countOfBestScores)
                .ToList();
        }
    }
}