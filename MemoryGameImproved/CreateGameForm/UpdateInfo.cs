using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGameImproved.CreateGameForm
{
    class UpdateInfo
    {
        /// <summary>
        /// Updates gameInfo class values.
        /// </summary>
        public static void UpdateGameInfo(double score, int totalClicks, double totalTime)
        {
            GameInfo.Instance.Score += score;
            GameInfo.Instance.TotalClicks += totalClicks;
            GameInfo.Instance.TotalTime += totalTime;
        }
    }
}
