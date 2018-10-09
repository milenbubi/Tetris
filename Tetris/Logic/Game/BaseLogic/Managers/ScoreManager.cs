using System;
using System.Linq;
using System.Collections.Generic;

namespace Tetris.Logic.Game.BaseLogic.Managers
{
    internal static class ScoreManager
    {
        private static IEnumerable<string> scoreTable;
        private const int countOfBestScores = 10;

        static ScoreManager()
        {
            scoreTable = LogFileManager.Read();
        }

        internal static void UpdateScores()
        {
            string playScore = $"{GameData.points,-9:d5}{"-",-5}";
            string playDate = $"{DateTime.Now:dd MMM yyyy}";

            string score = playScore + playDate;

            ReorderScoreTable(score);
            LogFileManager.Write(scoreTable);
        }

        internal static void DisplayScores()
        {
            Console.Clear();
            Console.WriteLine($"\n{"Best Scores:",17}\n");
            Console.WriteLine(string.Join("\n", scoreTable));
            Console.WriteLine(Environment.NewLine);
        }

        private static void ReorderScoreTable(string score)
        {
            scoreTable = scoreTable
                .Concat(Enumerable.Repeat(score, 1))
                .OrderByDescending(s => s)
                .Take(countOfBestScores);
        }
    }
}