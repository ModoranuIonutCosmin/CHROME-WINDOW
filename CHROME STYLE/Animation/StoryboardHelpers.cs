
using System.Windows;
using System.Windows.Media.Animation;
namespace CHROME_STYLE
{
    public static class StoryboardHelpers
    {
            public static void AddSlideInFromRight(this Storyboard sb, float seconds, double offset, float deceleration = 0.9f)
            {
                var slideAnimation = new ThicknessAnimation()
                {
                    Duration = new Duration(System.TimeSpan.FromSeconds(seconds)),
                    From = new Thickness(offset, 0, -offset, 0),
                    To = new Thickness(0),
                    DecelerationRatio = deceleration
                };
                Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
                sb.Children.Add(slideAnimation);
            } 
            public static void AddFadeIn(this Storyboard sb, float seconds, double offset, float deceleration = 0.9f)
            {
                var slideAnimation = new DoubleAnimation()
                {
                    Duration = new Duration(System.TimeSpan.FromSeconds(seconds)),
                    From = 0,
                    To = 1,
                    DecelerationRatio = deceleration
                };
                Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Opacity"));
                sb.Children.Add(slideAnimation);
            }
            public static void AddFadeOut(this Storyboard sb, float seconds, double offset, float deceleration = 0.9f)
            {
                var slideAnimation = new DoubleAnimation()
                {
                    Duration = new Duration(System.TimeSpan.FromSeconds(seconds)),
                    From = 1,
                    To = 0,
                    DecelerationRatio = deceleration
                };
                Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Opacity"));
                sb.Children.Add(slideAnimation);
            }
             public static void AddSlideOutFromLeft(this Storyboard sb, float seconds, double offset, float deceleration = 0.9f)
             {
                 var slideAnimation = new ThicknessAnimation()
                 {
                     Duration = new Duration(System.TimeSpan.FromSeconds(seconds)),
                     From = new Thickness(-offset, 0, offset, 0),
                     To = new Thickness(0),
                     DecelerationRatio = deceleration
                 };
                 Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
                 sb.Children.Add(slideAnimation);
             }
    }
}

