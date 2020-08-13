using System;
using System.Windows;

namespace CHROME_STYLE
{
    public abstract class BaseAttachedProperty<Parent, Property>
    where Parent: BaseAttachedProperty<Parent, Property>, new()
    {
        #region Public events
        /// <summary>
        /// Fired when the value changed
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> valueChanged = (sender, e) => { };

        #endregion 
        #region Public members
        public static Parent Instance = new Parent();
        #endregion

        #region Attached property definitions
        
        /// <summary>
        ///  Attached property 
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property),typeof(BaseAttachedProperty<Parent, Property>),new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));
        /// <summary>
        /// Callback event when the value property has changed
        /// </summary>
        /// <param name="d">The UI element that had it's property changed</param>
        /// <param name="e"> Args for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Instance.OnValueChanged(d,e);
            Instance.valueChanged(d, e);

        }
         /// <summary>
         /// Get the attached property's value
         /// </summary>
         /// <param name="d"> The element of the UI whose property needs getting</param>
         /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);
        /// <summary>
        /// Sets the attached property 
        /// </summary>
        /// <param name="d">The element of the UI whose property needs setting</param>
        /// <param name="value"> Value it's set to</param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);

        #endregion

        #region Event methods

        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
        #endregion
    }
}
