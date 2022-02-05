using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WPF.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region INotyfyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region IsLoad
        private bool isLoad;

        /// <summary>
        /// 
        /// </summary>
        public bool IsLoad
        {
            get { return isLoad; }
            set
            {
                isLoad = value;
                OnPropertyChanged(nameof(IsLoad));
            }
        }
        #endregion

        #region Update
        private bool update;
        /// <summary>
        /// 
        /// </summary>
        public bool Update
        {
            get { return update; }
            set
            {
                update = value;
                OnPropertyChanged(nameof(Update));
            }
        }
        #endregion

    }
}
