﻿namespace MemoryGameImproved.CreateGameForm
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Creates a list of buttons
    /// </summary>
    public class CreateButtons
    {
        /// <summary>
        /// Padding is empty space up, down, left, and right of buttons in pixels.
        /// </summary>
        private const int padding = 5;

        /// <summary>
        /// Creates buttons in a X by X pattern. If X is an odd number it will
        /// add an extra row of X to make sure there is always an even pair of buttons.
        /// </summary>
        /// <param name="frame">Empty Label to serve as location and dimensions to spawn the buttons in.</param>
        /// <remarks>Button width is calculated from the Gameboard parameter.</remarks>
        public static List<Button> SpawnButtonList(Label frame)
        {
            /// <summary>
            /// Spacing is the space above and below or left and right of a button.
            /// </summary>
            int spacing = padding * 2;

            List<Button> btnList = new List<Button>();       
            int btnCount = GameInfo.Instance.GetSize();

            // Generate Button width and height algebra 
            /*  MaxWidth = Total amount of width to place buttons in
             *  NumButtons = GameInfo.Instance.LevelPlus1, just buttons in one row
             *  Spacing = Padding * 2, the space before and after the ButtonWidth
             *  ButtonWidth = unknown
             * 
             * MaxWidth = NumButtons * (ButtonWidth + Spacing)
             * MaxWidth = NumButtons * ButtonWidth + NumButtons * Spacing
             * MaxWidth - (NumButtons * Spacing) = NumButtons * ButtonWidth
             * (MaxWidth - (NumButtons * Spacing)) / NumButtons = ButtonWidth
             */
            int btnWidth;
            int btnHeight;

            if (GameInfo.Instance.OddLevel)
            {
                //Compensate the odd row with another row to create an even number of pairs
                btnHeight = (frame.Height - ((GameInfo.Instance.LevelPlus1 + 1) * spacing)) / (GameInfo.Instance.LevelPlus1 + 1);
            }
            else
            {
                btnHeight = (frame.Height - (GameInfo.Instance.LevelPlus1 * spacing)) / GameInfo.Instance.LevelPlus1;
            }

            btnWidth = (frame.Width - (GameInfo.Instance.LevelPlus1 * spacing)) / GameInfo.Instance.LevelPlus1;

            for (int i = 0; i < btnCount; ++i)
            {
                btnList.Add(new Button());
                btnList[i].Height = btnHeight;
                btnList[i].Width = btnWidth;
                btnList[i].Tag = i;
                btnList[i].Text = string.Empty;
            }

            // Add spacing distance for adjacent buttons to find X and Y positions.
            int btnHeightPlusSpacing = btnHeight + spacing;
            int btnWidthPlusSpacing = btnWidth + spacing;
            
            int index = 0;
            for (int yPos = frame.Location.Y + padding; yPos <= frame.Location.Y + frame.Height; yPos += btnHeightPlusSpacing)
            {
                for (int xPos = frame.Location.X + padding; xPos <= frame.Location.X + frame.Width; xPos += btnWidthPlusSpacing)
                {
                    if (!(xPos == frame.Location.X + padding))
                    {
                        // If not the beginning
                        xPos = btnList[index - 1].Location.X + btnWidthPlusSpacing;
                    }

                    btnList[index].Location = new Point(xPos, yPos);
                    ++index;
                }
            }

            return btnList;
        }
    }
}
