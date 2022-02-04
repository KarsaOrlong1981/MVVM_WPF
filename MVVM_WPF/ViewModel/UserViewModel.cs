using MVVM_WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_WPF.ViewModel
{
    class UserViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> _UsersList;
        private  bool ascUserIdIsChecked ,descUserIdIsChecked, ascFirstNameIsChecked, descFirstNameIsChecked;
        #region BOOL Propertys
        public bool AscUserIdIsChecked
        {
            get { return ascUserIdIsChecked; }
            set 
            { 
                if (value != ascUserIdIsChecked) 
                { 
                    ascUserIdIsChecked = value;
                    NotifyPropertyChanged();
                } 
            }
        }
        public bool DescUserIdIsChecked
        {
            get { return descUserIdIsChecked; }
            set
            {
                if (value != descUserIdIsChecked)
                {
                    descUserIdIsChecked = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool AscFirstNameIsChecked
        {
            get { return ascFirstNameIsChecked; }
            set
            {
                if (value != ascFirstNameIsChecked)
                {
                    ascFirstNameIsChecked = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool DescFirstNameIsChecked
        {
            get { return descFirstNameIsChecked; }
            set
            {
                if (value != descFirstNameIsChecked)
                {
                    descFirstNameIsChecked = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion //BOOL Propertys
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public UserViewModel()
        {
            _UsersList = new ObservableCollection<User> 
            {
                new User{UserId = 1,FirstName="Raj",LastName="Beniwal",City="Delhi",State="DEL",Country="INDIA"},
                new User{UserId=2,FirstName="Mark",LastName="henry",City="New York", State="NY", Country="USA"},
                new User{UserId=3,FirstName="Mahesh",LastName="Chand",City="Philadelphia", State="PHL", Country="USA"},
                new User{UserId=4,FirstName="Vikash",LastName="Nanda",City="Noida", State="UP", Country="INDIA"},
                new User{UserId=5,FirstName="Harsh",LastName="Kumar",City="Ghaziabad", State="UP", Country="INDIA"},
                new User{UserId=6,FirstName="Reetesh",LastName="Tomar",City="Mumbai", State="MP", Country="INDIA"},
                new User{UserId=7,FirstName="Deven",LastName="Verma",City="Palwal", State="HP", Country="INDIA"},
                new User{UserId=8,FirstName="Ravi",LastName="Taneja",City="Delhi", State="DEL", Country="INDIA"}
            };
            AscendingUserIdClicked = new RelayCommand(OrderByUserId);
            DescendingUserIdClicked = new RelayCommand(OrderByDescendingUserId);
            AscendingFirstNameClicked = new RelayCommand(OrderByFirstName);
            DescendingFirstNameClicked = new RelayCommand(OrderByDescendingFirstName);
        }

        public ObservableCollection<User> Users
        {
            get { return _UsersList; }
            set 
            { 
                if (value != _UsersList)
                {
                    _UsersList = value;
                    NotifyPropertyChanged();
                }
              
            }
        }
        #region OrderBy Methods
        private void OrderByUserId(object parameter)
        {
            AscUserIdIsChecked = true;
            DescUserIdIsChecked = false;
            Users = new ObservableCollection<User>(Users.OrderBy(x => x.UserId));
        }
        private void OrderByDescendingUserId(object parameter)
        {
            AscUserIdIsChecked = false;
            DescUserIdIsChecked = true;
            Users = new ObservableCollection<User>(Users.OrderByDescending(x => x.UserId));
        }
        private void OrderByFirstName(object parameter)
        {
            AscFirstNameIsChecked = true;
            DescFirstNameIsChecked = false;
            Users = new ObservableCollection<User>(Users.OrderBy(x => x.FirstName));
        }
        private void OrderByDescendingFirstName(object parameter)
        {
            AscFirstNameIsChecked = false;
            DescFirstNameIsChecked = true;
            Users = new ObservableCollection<User>(Users.OrderByDescending(x => x.FirstName));
        }
        #endregion //OrderBy Methods
        #region ICommand 
        private ICommand mUpdater;

        public ICommand AscendingUserIdClicked { get; set; }
        public ICommand DescendingUserIdClicked { get; set; }
        public ICommand AscendingFirstNameClicked { get; set; }
        public ICommand DescendingFirstNameClicked { get; set; }
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }
        private class Updater : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {

            }

            #endregion
        }
      
        #endregion
    }
}
