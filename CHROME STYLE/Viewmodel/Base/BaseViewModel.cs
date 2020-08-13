using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CHROME_STYLE
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        protected async Task RunCommand(Expression<System.Func<bool>> updateFlag, Func<Task> action)
        {
            if (updateFlag.GetPropertyValue() == true)
                return;
            updateFlag.SetPropertyValue(true);
            try
            {
                await action();
            }
            finally
            {
                updateFlag.SetPropertyValue(false);
            }
            
        }
    }
}
