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
        private static GameInfo instance;
        public static GameInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameInfo();
                }

                return instance;
            }
        }

        /// <summary>
        /// Level for controlling amount of pairs.
        /// </summary>
        private int _level;

        /// <summary>
        /// Determines if the square of buttons is an odd number.
        /// </summary>
        private bool _oddLevel;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameInfo"/> class. 
        /// </summary>
        public GameInfo()
        {
            ImageList = new List<Image>();
            this.TotalTime = 0;
            this.TotalClicks = 0;
            this.Score = 0;
            this.Level = 1;
            this.LevelComplete = false;

            // Add an image to add another level. No other work needed
            // Load Images
            this.ImageList.Add(Properties.Resources.blueTetris);
            this.ImageList.Add(Properties.Resources.greenTetris);
            this.ImageList.Add(Properties.Resources.redTetris);
            this.ImageList.Add(Properties.Resources.yellowTetris);
            this.ImageList.Add(Properties.Resources.orangeTetris);
            this.ImageList.Add(Properties.Resources.purpleTetris);
            this.ImageList.Add(Properties.Resources.turquoiseTetris);

            for (int i = 1; i <= this.ImageList.Count(); ++i)
            {
                // Setting Tag property to identify similar pictures
                this.ImageList[i - 1].Tag = i.ToString();
            }
        }

        #region Get Sets
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
                return this._level;
            }

            set
            {
                this._level = value;
                if (this.LevelPlus1 % 2 == 0)
                {
                    // Even squares level
                    this._oddLevel = false;
                }
                else
                {
                    // Odd amount for squares
                    this._oddLevel = true;
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
                return this._level + 1;
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
        /// Gets a value indicating whether the level will have an odd size, thus unable to pair all images.
        /// </summary>
        public bool OddLevel
        {
            get
            {
                return this._oddLevel;
            }
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
        #endregion
             
        /// <summary>
        /// Reset variables to a fresh game.
        /// </summary>                   
        public void Reset()
        {
            this.TotalTime = this.TotalClicks = 0;
            this.Score = 0;
            this.Level = 1;
            this.LevelComplete = false;
        }
        
        /// <summary>
        /// Finds the size needed to make sure there is a pair of everything.
        /// </summary>
        /// <returns>Integer representing size</returns>
        public int GetSize()
        {
            int size;
            if (this.OddLevel)
            {
                size = (int)Math.Pow(this.LevelPlus1, 2) + this.LevelPlus1;
            }
            else
            {
                size = (int)Math.Pow(this.LevelPlus1, 2);
            }

            return size;
        }
    }
}
