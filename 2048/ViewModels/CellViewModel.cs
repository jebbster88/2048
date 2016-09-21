using _2048.Utilities;
using System.Windows.Media;

namespace _2048.ViewModels
{
    public class CellViewModel : ObservableObject
    {
        private int _value;
        private int _x;
        private int _y;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value; RaisePropertyChangedEvent("Value");
                _value = value; RaisePropertyChangedEvent("DisplayValue");
                _value = value; RaisePropertyChangedEvent("Background");
                _value = value; RaisePropertyChangedEvent("BorderBrush");
                _value = value; RaisePropertyChangedEvent("TextColour");
            }
        }
        public string DisplayValue
        {
            get { return _value.ToString("#"); }
        }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        public SolidColorBrush BorderBrush
        {
            get { return ThemeManager.GetBorder(_value); }
        }

        public SolidColorBrush Background
        {
            get { return ThemeManager.GetBackground(_value); }
        }
        public SolidColorBrush TextColour
        {
            get { return ThemeManager.GetText(_value); }
        }

        public CellViewModel(int value, int x, int y)
        {
            _value = value;
            _x = x;
            _y = y;
        }
    }
}