//-------------------------------------------------------------
// <copyright file="CreateButtons.cs" company="Company Name">
//    Copyright message. 
// <author>Scot LaFargue</author>
// </copyright>
//-------------------------------------------------------------
namespace MemoryGameImproved.CreateGameForm
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// Creates buttons list of buttons
    /// </summary>
    public class CreateButtons
    {
        /// <summary>
        /// Padding is empty space up, down, left, and right of buttons in pixels
        /// </summary>
        private const int Padding = 5;

        /// <summary>
        /// Creates buttons in a X by X pattern. If X is an odd number it will
        /// add an extra row of X to make sure there is always an even pair of buttons.
        /// </summary>
        /// <param name="frame">Empty Label to serve as location and dimensions to spawn the buttons in.</param>
        /// <remarks>Button width is calculated from the Gameboard parameter.</remarks>
        /// <param name="gameInfo">Current game info.</param>
        /// <returns>List of buttons</returns>
        public static List<Button> SpawnButtonList(Label frame, GameInfo gameInfo)
        {
            int i = 0;
            List<Button> btnList = new List<Button>();       
            int btnCount = GameInfo.Instance.GetSize();

            int spacing = Padding * 2;

            // Generate Buttons            
            /*  MaxWidth = Total amount of width to place buttons in
             *  NumButtons = gameInfo.LevelPlus1, just buttons in one row
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

            if (gameInfo.OddLevel)
            {
                //Compensate the odd row with another row to create an even number of pairs
                btnHeight = (frame.Height - ((gameInfo.LevelPlus1 + 1) * spacing)) / (gameInfo.LevelPlus1 + 1);
            }
            else
            {
                btnHeight = (frame.Height - (gameInfo.LevelPlus1 * spacing)) / gameInfo.LevelPlus1;
            }

            btnWidth = (frame.Width - (gameInfo.LevelPlus1 * spacing)) / gameInfo.LevelPlus1;

            for (i = 0; i < btnCount; ++i)
            {
                btnList.Add(new Button());
                btnList[i].Height = btnHeight;
                btnList[i].Width = btnWidth;
                btnList[i].Tag = i;
                btnList[i].Text = string.Empty;
            }

            // Add padding for adjacent buttons. If each button has 5px padding then there will be 10 px total between them.
            btnHeight += spacing;
            btnWidth += spacing;

            /*The padding for after btn[0] and padding before btn[i+1] is added with btn[0] width.
             *Thus, the last point will be adding padding for a btn that doesn't exist
             *Therefore, it is ok to start at padding
             */
            int posX = frame.Location.X + Padding, posY = frame.Location.Y + Padding;           

            // Resetting I for Loop
            i = 0;

            // No need to change for odd since this exits when it reaches the end of btnCount
            for (int colPos = 1; colPos <= gameInfo.LevelPlus1;)
            {
                start:
                // Setting X and Y positions for a Point(x, y) structure
                // First check if variable i is out of range
                if (i == btnCount)
                {
                    goto done;
                }                
                else if (colPos == 1)
                {
                    // If beginning of Row start after the initial padding
                    posX = frame.Location.X + Padding;
                    ++colPos;
                }
                else if (colPos != gameInfo.LevelPlus1)
                {
                    posX = btnList[i - 1].Location.X + btnWidth;
                    ++colPos;
                }
                else
                {            
                    // If Last column then reset back to the first column at the next row
                    posX = btnList[i - 1].Location.X + btnWidth;
                    colPos = 1;

                    // Add button before yPos increase
                    btnList[i].Location = new Point(posX, posY);
                    ++i;
                    posY += btnHeight;

                    // skip setting button location below
                    goto start;
                }                                

                // Setting button's location
                btnList[i].Location = new Point(posX, posY);
                ++i;
            }

            done:
            return btnList;
        }
    }
}
