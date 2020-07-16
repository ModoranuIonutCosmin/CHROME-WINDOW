using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfTreeView;

namespace CHROME_STYLE
{
    public class WindowViewModel : BaseViewModel
    {
        private Window mWindow;
        private int mOuterMarginSize = 10;
        private int mWindowRadius = 10;
        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;
        public int InnerContentPadding { get; set; } = 0;
        public Thickness InnerContentPaddingThickness => new Thickness(InnerContentPadding);
        public double WindowMinimumWidth { get; set; } = 400;
        public double WindowMinimumHeight { get; set; } = 400;
        public bool Borderless
        {
            get { return mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked; }
        }
        public WindowViewModel(Window window)
        {
            mWindow = window;
            mWindow.StateChanged += (sender, e) =>
            {
                WindowResized();
            };
            // Comenzi
            MinimizeCommand=new RelayCommand( () => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand=new RelayCommand( () => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));
            var resize = new WindowResizer(mWindow);
            resize.WindowDockChanged += (dock) =>
            {
                mDockPosition = dock;
                WindowResized();
            };

        }

        private void WindowResized()
        {
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
            OnPropertyChanged(nameof(Borderless));
        }

        #region Commands

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MenuCommand { get; set; }

        #endregion

        public int ResizeBorder
        {
            get { return Borderless ? 0 : 6; }
        }
    

        public Thickness ResizeBorderThickness 
        {
            get { return new Thickness(ResizeBorder + OuterMarginSize); }
        }

        public int OuterMarginSize
        {
            get
            {
                return this.Borderless ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }
        public Thickness OuterMarginSizeThickness
        {
            get
            {
                return new Thickness(OuterMarginSize);
            }
        }

        public int WindowRadius
        {
            get { return Borderless ? 0 : mWindowRadius; }
            set { mWindowRadius = value; }
        }

        public CornerRadius WindowCornerRadius
        {
            get
            {
                return new CornerRadius(WindowRadius);
            }
        }

        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength
        {
            get { return new GridLength(TitleHeight+ResizeBorder); }
        }
        #region Helperi
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }
        #endregion
    }
}
