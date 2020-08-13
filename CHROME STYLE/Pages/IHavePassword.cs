using System.Security;

namespace CHROME_STYLE
{
    public interface IHavePassword
    {
        SecureString SecurePassword{ get;}
    }
}
