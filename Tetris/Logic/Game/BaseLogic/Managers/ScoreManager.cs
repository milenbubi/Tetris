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
            scoreTable = LogFileManager.Read();
        }

        internal static void UpdateScores()
        {
            string playScore = $"{GameData.points,-9:d5}{"-",-5}";
            string playDate = $"{DateTime.Now:dd MMM yyyy}";

            string currentResult = playScore + playDate;
            string worstResult = scoreTable.LastOrDefault();

            ReorderScoreTable(currentResult, worstResult);

            LogFileManager.Write(scoreTable);
        }

        internal static void DisplayScores()
        {
            Console.Clear();
            Console.WriteLine($"{"Best Scores:",18}");
            Console.WriteLine();
            Console.WriteLine(string.Join("\n", scoreTable));
        }

        private static void ReorderScoreTable(string currentResult, string worstResult)
        {
            if (currentResult.CompareTo(worstResult) >= 0)
            {
                scoreTable.Remove(worstResult);
                scoreTable.Add(currentResult);

                scoreTable = scoreTable
                    .OrderByDescending(s => s)
                    .Concat(Enumerable.Repeat(defaultScore, 10))
                    .Take(countOfBestScores)
                    .ToList();
            }
        }
    }
}