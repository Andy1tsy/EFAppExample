
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace EFAppExample
{
    /// <summary>
    /// base class which determins binding interface for properties
    /// </summary>
    public class BaseForBinding : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseForBinding()
        {
            PropertyChanged += (sender, e) => { };
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
