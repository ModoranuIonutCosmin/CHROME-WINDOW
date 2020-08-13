using System;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfTreeView;

namespace CHROME_STYLE
{
    public class LoginPageViewModel : BaseViewModel
    {
        public string Email { get; set; }

        public ICommand LoginCommand { get; set; }

        public bool LoginIsRunning { get; set; }
        public LoginPageViewModel()
        {
            LoginCommand = new RelayCommandParametrized(async (parameter) => await Login(parameter));
        }

        private async Task Login(object parameter)
        {
            await RunCommand(() => this.LoginIsRunning, async () => 
            {
            await Task.Delay(2000);
            var email = this.Email;
            var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            } );
        }
    }
}
