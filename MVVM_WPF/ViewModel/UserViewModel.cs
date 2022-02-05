using MVVM_WPF.Model;
using MVVM_WPF.View;
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
    class UserViewModel : UsersCollection, INotifyPropertyChanged
    {
        private Visibility isVisisble, isVisibleNewUserBTN;
        private  bool ascUserIdIsChecked ,descUserIdIsChecked, ascFirstNameIsChecked, 
                      descFirstNameIsChecked, ascLastNameIsChecked, descLastNameIsChecked;
        private int userIdAdd;
        private string firstNameAdd, lastNameAdd, cityAdd, countryAdd, stateAdd;
        public Visibility IsVisible
        {
            get { return isVisisble; }
            set { isVisisble = value; NotifyPropertyChanged(); }
        }
        public Visibility IsVisibleNewUserBTN
        {
            get { return isVisibleNewUserBTN; }
            set { isVisibleNewUserBTN = value; NotifyPropertyChanged(); }
        }
        #region Propertys UserViewModel
        public int UserIdAdd
        {
            get { return userIdAdd; }
            set
            {
                userIdAdd = value;
                NotifyPropertyChanged();
            }
        }
        public string FirstNameAdd
        {
            get { return firstNameAdd; }
            set { firstNameAdd = value; NotifyPropertyChanged(); }
        }
        public string LastNameAdd
        {
            get { return lastNameAdd; }
            set { lastNameAdd = value; NotifyPropertyChanged(); }
        }
        public string CityAdd
        {
            get { return cityAdd; }
            set { cityAdd = value; NotifyPropertyChanged(); }
        }
        public string CountryAdd
        {
            get { return countryAdd; }
            set { countryAdd = value; NotifyPropertyChanged(); }
        }
        public string StateAdd
        {
            get { return stateAdd; }
            set { stateAdd = value; NotifyPropertyChanged(); }
        }

        #endregion //Propertys

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
        public bool AscLastNameIsChecked
        {
            get { return ascLastNameIsChecked; }
            set
            {
                if (value != ascLastNameIsChecked)
                {
                    ascLastNameIsChecked = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public bool DescLastNameIsChecked
        {
            get { return descLastNameIsChecked; }
            set
            {
                if (value != descLastNameIsChecked)
                {
                    descLastNameIsChecked = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion //BOOL Propertys
        #region INotyfyPropertyChanged
        public new event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion //INotyfyPropertyChanged
       
      
        public UserViewModel() 
        {
            
            Users = GetTemplateUserList();
            UserIdAdd = 1;
            isVisisble = Visibility.Hidden ;
            isVisibleNewUserBTN = Visibility.Visible;
            AscendingUserIdClicked = new RelayCommand(OrderByUserId);
            DescendingUserIdClicked = new RelayCommand(OrderByDescendingUserId);
            AscendingFirstNameClicked = new RelayCommand(OrderByFirstName);
            DescendingFirstNameClicked = new RelayCommand(OrderByDescendingFirstName);
            AscendingLastNameClicked = new RelayCommand(OrderByLastName);
            DescendingLastNameClicked = new RelayCommand(OrderByDescendingLastName);
            AddCommand = new RelayCommand(Add);
            AddNewUserCommand = new RelayCommand(AddnewUser);

        }
        private bool CheckIdExisting()
        {
            bool isIDExists = false;
            foreach (var item in Users)
            {
                if (item.UserId == UserIdAdd)
                {
                    isIDExists = true;
                    break;
                }
            }
            return isIDExists;
        }
        private void AddnewUser(object parameter)
        {
            IsVisible = Visibility.Visible;
            IsVisibleNewUserBTN = Visibility.Hidden;
        }
        private void Add(object parameter)
        {
            bool isAnyTBEmpty = false;
            bool isIDExists = false;
            
            if (FirstNameAdd == null || LastNameAdd == null || CityAdd == null || CountryAdd == null || StateAdd == null)
            {
                isAnyTBEmpty=true;
            }
            if (isAnyTBEmpty == false)
            {
                if (isIDExists = CheckIdExisting() == false)
                {
                    User user = new User();
                    user.UserId = UserIdAdd;
                    user.FirstName = FirstNameAdd;
                    user.LastName = LastNameAdd;
                    user.City = CityAdd;
                    user.Country = CountryAdd;
                    user.State = StateAdd;
                    Users.Add(user);
                }
                else
                {
                    int nextID = Users.Count - 1;
                    ObservableCollection<User> getNextIdList;
                    getNextIdList = new ObservableCollection<User>( Users.OrderBy(x => x.UserId));
                    nextID = getNextIdList[nextID].UserId + 1;
                    
                    MessageBox.Show("Diese ID Existiert bereits. die nächste Id wäre " + nextID + ".", "Users", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
              
            }
            else
            {
                MessageBox.Show("Es darf kein Feld leer bleiben.", "Users", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }
        #region OrderBy Functions
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
        private void OrderByLastName(object parameter)
        {
            AscLastNameIsChecked = true;
            DescLastNameIsChecked = false;
            Users = new ObservableCollection<User>(Users.OrderBy(x => x.LastName));
        }
        private void OrderByDescendingLastName(object parameter)
        {
            AscLastNameIsChecked = false;
            DescLastNameIsChecked = true;
            Users = new ObservableCollection<User>(Users.OrderByDescending(x => x.LastName));
        }
        #endregion //OrderBy Functions
        #region ICommand 
        private ICommand mUpdater;

        public ICommand AscendingUserIdClicked { get; set; }
        public ICommand DescendingUserIdClicked { get; set; }
        public ICommand AscendingFirstNameClicked { get; set; }
        public ICommand DescendingFirstNameClicked { get; set; }
        public ICommand AscendingLastNameClicked { get; set; }
       
        public ICommand DescendingLastNameClicked { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand AddNewUserCommand { get; set; }
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
            public Updater()
            {

            }
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                
            }

        }
      
        #endregion //ICommand
    }
}
