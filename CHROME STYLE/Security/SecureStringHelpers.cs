using System;
using System.Runtime.InteropServices;
using System.Security;

namespace CHROME_STYLE
{
    static class SecureStringHelpers
    {
        public static string Unsecure(this SecureString securePassword)
        {
            if(securePassword.Length == 0)
            {
                return string.Empty;
            }

            var unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
