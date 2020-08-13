
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CHROME_STYLE
{
    public static class PageAtomicAnims
    {
        public static async Task AddSlideFadeInFromRight(this Page page, float duration)
        {
            var sb = new Storyboard();


            sb.AddSlideInFromRight(duration, page.WindowWidth);
            sb.AddFadeIn(duration, page.WindowWidth);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)duration * 1000);
        }
        public static async Task AddSlideFadeOutFromLeft(this Page page, float duration)
        {
            var sb = new Storyboard();

            sb.AddSlideOutFromLeft(duration, page.WindowWidth);
            sb.AddFadeOut(duration, page.WindowWidth);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            await Task.Delay((int)duration * 1000);
        }
    }
}


