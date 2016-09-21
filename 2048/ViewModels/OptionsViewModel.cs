using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2048.Models;

namespace _2048.ViewModels
{
    class OptionsViewModel
    {
        public int MinWidth { get { return GameGrid.MinWidth; } }
        public int MinHeight { get { return GameGrid.MinHeight; } }
        public int MaxWidth { get { return GameGrid.MaxWidth; } }
        public int MaxHeight { get { return GameGrid.MaxHeight; } }

        public int Width
        {
            get
            {
                return Properties.Settings.Default.Width;
            }
            set
            {
                if (value <= GameGrid.MaxWidth && value >= GameGrid.MinWidth)
                {
                    Properties.Settings.Default.Width = value;
                    Properties.Settings.Default.Save();
                }
            }
        }
        public int Height
        {
            get
            {
                return Properties.Settings.Default.Height;
            }
            set
            {
                if (value <= GameGrid.MaxHeight && value >= GameGrid.MinHeight)
                {
                    Properties.Settings.Default.Height = value;
                    Properties.Settings.Default.Save();
                }
            }
        }
    }
}
