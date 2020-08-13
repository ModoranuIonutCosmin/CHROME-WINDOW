using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CHROME_STYLE
{
    public class BasePage<VM> : Page
        where VM:BaseViewModel, new()
    {
        private VM m_viewmodel;
        public PageAnimation LoadAnimation { get; set; } = PageAnimation.SlideInAndFadeFromRight;
        public PageAnimation UnloadAnimation { get; set; } = PageAnimation.SlideOutAndFadeFromLeft;

        public float SlideSeconds { get; set; } = 0.8f;

        public VM ViewModel
        {
            get
            {
                return m_viewmodel;
            }
            set
            {
                if (value == m_viewmodel) return;
                m_viewmodel = value;
                this.DataContext = m_viewmodel;
            }
        }

        public BasePage()
        { 
            if(LoadAnimation != PageAnimation.None)
            {
                this.Visibility = Visibility.Collapsed;
            }
            this.Loaded += BasePage_Loaded;

            this.ViewModel = new VM();
        }

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
           await AnimateIn();
        }

        private async Task AnimateIn()
        {
            if (this.LoadAnimation == PageAnimation.None)
                return;

            switch (LoadAnimation)
            {
                case PageAnimation.SlideInAndFadeFromRight:
                    await this.AddSlideFadeInFromRight(this.SlideSeconds);
                    break;
            } 
        } 
        private async Task AnimateOut()
        {
            if (this.UnloadAnimation == PageAnimation.None)
                return;
            switch (UnloadAnimation)
            {
                case PageAnimation.SlideOutAndFadeFromLeft:
                    await this.AddSlideFadeOutFromLeft(this.SlideSeconds);
                    break;
            }
        }
    }

}

