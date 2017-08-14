//--------------------------------------------------------------------
// <copyright file="SetButtonImagesRandomly.cs" company="Company Name">
//    Copyright message. 
// <author>Scot LaFargue</author>
// </copyright>
//--------------------------------------------------------------------
namespace MemoryGameImproved.CreateGameForm
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    /// <summary>
    /// Set equal amounts of images randomly to a list of buttons.
    /// </summary>
    public class SetButtonImagesRandomly
    {
        /// <summary>
        /// Sets images systematically in an randomized list of indexes
        /// </summary>
        /// <param name="buttonList">List of buttons to assign images to</param>
        /// <param name="gameInfo">Current game info</param>
        public static void RandomizeImages(List<Button> buttonList, GameInfo gameInfo)
        {
            int size = gameInfo.GetSize();
            List<int> tiles = CreateListOfRandomIndexes(gameInfo);

            for (int i = 0; i < size;)
            {
                for (int f = 0; f < gameInfo.LevelPlus1 && i < size; ++f)
                {
                    // Assigns image to int contained in the randomized index list
                    int index = tiles[i];

                    buttonList[index].BackgroundImage = gameInfo.ImageList[f];
                    buttonList[index].BackgroundImageLayout = ImageLayout.Stretch;
                    ++i;
                }
            }
        }

        /// <summary>
        /// Creates a list of integers, representing indexes, and randomizes them.
        /// </summary>
        /// <param name="info">Current game info</param>
        /// <returns>List of randomized indexes</returns>
        private static List<int> CreateListOfRandomIndexes(GameInfo info)
        {
            int size = info.GetSize();
            Random rand = new Random();

            // Create list of indexes
            List<int> tiles = new List<int>();
            for (int i = 0; i < size; ++i)
            {
                tiles.Add(i);
            }

            // Shuffle indexes in list
            for (int i = size - 1; i > 0; --i)
            {
                int temp;

                int j = rand.Next(0, i);
                temp = tiles[i];
                tiles[i] = tiles[j];
                tiles[j] = temp;
            }

            return tiles;
        }        
    }
}
