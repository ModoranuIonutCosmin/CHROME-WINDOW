﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace CHROME_STYLE
{

  
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {;
            var passwordBox = (PasswordBox) sender;

            if (passwordBox == null)
            {
                return;
            }

            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            if ((bool) e.NewValue)
            {
                HasTextProperty.SetValue(passwordBox);
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
                HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        public static void SetValue(DependencyObject sender)
        {
            HasTextProperty.SetValue(sender, ((PasswordBox) sender).SecurePassword.Length > 0);
        }
    }
}
