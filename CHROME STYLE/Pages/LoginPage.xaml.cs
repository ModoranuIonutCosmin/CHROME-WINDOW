using System.Security;
using System.Windows.Controls;

namespace CHROME_STYLE
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginPageViewModel>, IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public SecureString SecurePassword => PassBox.SecurePassword;
    }
}
