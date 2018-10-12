﻿using System.IO;
using System.Collections.Generic;
using System;

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
            return File.ReadAllText(logFile).Trim().Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        internal static void Write(IEnumerable<string> scoreTable)
        {
            File.WriteAllLines(logFile, scoreTable);
        }
    }
}