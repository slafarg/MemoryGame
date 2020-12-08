namespace MemoryGameImproved
{    
    using System;
    using System.Collections.Generic;
    using System.Drawing;    
    using System.Linq;       

    /// <summary>
    /// Class containing information on Matching Pairs game.
    /// </summary>
    public partial class GameInfo
    {
        private static GameInfo _instance;
        

        /// <summary>
        /// Level for controlling amount of pairs.
        /// </summary>
        private int _level;

        /// <summary>
        /// Determines if the square of buttons is an odd number.
        /// </summary>
        private bool _oddLevel;

        private int _levelPlus1;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameInfo"/> class. 
        /// </summary>
        public GameInfo()
        {
            ImageList = new List<Image>();
            TotalTime = 0;
            TotalClicks = 0;
            Score = 0;
            //Level sets _oddLevel and _levelPlus1
            Level = 1;
            LevelComplete = false;

            // Add an image to add another level. No other work needed
            // Load Images
            ImageList.Add(Properties.Resources.blueTetris);
            ImageList.Add(Properties.Resources.greenTetris);
            ImageList.Add(Properties.Resources.redTetris);
            ImageList.Add(Properties.Resources.yellowTetris);
            ImageList.Add(Properties.Resources.orangeTetris);
            ImageList.Add(Properties.Resources.purpleTetris);
            ImageList.Add(Properties.Resources.turquoiseTetris);

            for (int i = 1; i <= this.ImageList.Count(); ++i)
            {
                // Setting Tag property to identify similar pictures
                ImageList[i - 1].Tag = i.ToString();
            }
        }

        public static GameInfo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameInfo();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Gets or sets time.
        /// </summary>
        public double TotalTime
        {
            get;
            set;          
        }

        /// <summary>
        /// Gets or sets total clicks.
        /// </summary>
        public int TotalClicks
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets points.
        /// </summary>
        public double Score
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets points.
        /// <remarks>Setting also sets <see cref="OddLevel"/> </remarks>
        /// </summary>
        public int Level
        {
            get
            {
                return _level;
            }

            set
            {
                _level = value;
                _levelPlus1 = _level + 1;

                if (LevelPlus1 % 2 == 0)
                {
                    // Even squares level
                    _oddLevel = false;
                }
                else
                {
                    // Odd amount for squares
                    _oddLevel = true;
                }
            }
        }

        /// <summary>
        /// Gets level + 1, because of how often calculation appears in Memory Pairs.
        /// </summary>
        public int LevelPlus1
        {
            get
            {
                return _levelPlus1;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the level will have an odd size, thus unable to pair all images.
        /// </summary>
        public bool OddLevel
        {
            get
            {
                return _oddLevel;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the level is complete.
        /// </summary>
        public bool LevelComplete
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Player ID.
        /// </summary>
        public string PlayerID
        {
            get;
            set;
        }
                
        /// <summary>
        /// Gets or sets the Image list containing all images for matching pairs of.
        /// The amount of levels are determined by this minus one.
        /// </summary>
        public List<Image> ImageList
        {
            get;
            set;
        }        
             
        /// <summary>
        /// Reset variables to a fresh game.
        /// </summary>                   
        public void Reset()
        {
            TotalTime = this.TotalClicks = 0;
            Score = 0;
            Level = 1;
            LevelComplete = false;
        }
        
        /// <summary>
        /// Finds the size needed to make sure there is a pair of everything.
        /// </summary>
        /// <returns>Integer representing size</returns>
        public int GetSize()
        {
            int size;
            if (OddLevel)
            {
                size = (int)Math.Pow(LevelPlus1, 2) + LevelPlus1;
            }
            else
            {
                size = (int)Math.Pow(LevelPlus1, 2);
            }

            return size;
        }
    }
}
