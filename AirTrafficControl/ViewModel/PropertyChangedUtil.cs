using System.Collections.Generic;
using System.ComponentModel;

namespace AirTrafficControl.ViewModel
{
    public static class PropertyChangedUtil
    {
        public static bool SetField<T>(object sender, PropertyChangedEventHandler propertyChanged, ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            propertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
