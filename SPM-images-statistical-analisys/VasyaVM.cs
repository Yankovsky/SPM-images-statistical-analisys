using System.Windows.Media;
using System.Windows.Media.Imaging;
using Vasya.Utilities;

namespace Vasya
{
    public class VasyaVM : VM
    {
        public readonly Logic Logic;

        private BitmapSource _newTopoFilteredImage;
        private BitmapSource _originalTopoFilteredImage;
        private bool _originalTopoSelected;
        private double _value;
        private bool _valueChanged;

        public VasyaVM(Logic logic)
        {
            Logic = logic;
            Value = (MinValue + MaxValue)/2;
        }

        public BitmapSource NewTopoFilteredImage
        {
            get { return _newTopoFilteredImage; }
            set
            {
                _newTopoFilteredImage = value;
                NotifyPropertyChanged("NewTopoFilteredImage");
            }
        }

        public BitmapSource OriginalTopoFilteredImage
        {
            get { return _originalTopoFilteredImage; }
            set
            {
                _originalTopoFilteredImage = value;
                NotifyPropertyChanged("OriginalTopoFilteredImage");
            }
        }

        public bool OriginalTopoSelected
        {
            get { return _originalTopoSelected; }
            set
            {
                _originalTopoSelected = value;
                if (value && _valueChanged)
                {
                    OriginalTopoFilteredImage = Logic.OriginalImageWithFilteredPoints(Value);
                    _valueChanged = false;
                }
                NotifyPropertyChanged("OriginalTopoSelected");
            }
        }

        public double MinValue
        {
            get { return Logic.MinValue; }
        }

        public double MaxValue
        {
            get { return Logic.MaxValue; }
        }

        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                NotifyPropertyChanged("Value");
                _valueChanged = true;
                //NewTopoFilteredImage = ImageCreator.CreateBitmap(_logic.FilteredImage(value), _logic.ActualImageSize, _logic.ActualImageSize, PixelFormats.BlackWhite);
                NewTopoFilteredImage = Logic.FilteredImage(Value);
            }
        }
    }
}