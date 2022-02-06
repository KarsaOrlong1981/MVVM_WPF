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
    public class AddUserViewModel : UsersCollection, INotifyPropertyChanged
    {
        private int userIdAdd;
        private string firstNameAdd, lastNameAdd, cityAdd, countryAdd, stateAdd;
        public Action CloseAction { get; set; }
        #region Propertys 
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
        #region INotyfyPropertyChanged
        public new event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion //INotyfyPropertyChanged
        public AddUserViewModel()
        {
            UserIdAdd = GetNextID();
           
            AddCommand = new RelayCommand(Add);
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
        private void Add(object parameter)
        {
            bool isAnyTBEmpty = false;
            bool isIDExists = false;

            if (FirstNameAdd == null || LastNameAdd == null || CityAdd == null || CountryAdd == null || StateAdd == null)
            {
                isAnyTBEmpty = true;
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
                    UserViewModel userViewModel = new UserViewModel(Users);
                    CloseAction();
                }
                else
                {
                    int nextID = GetNextID();

                    MessageBox.Show("Diese ID Existiert bereits. die nächste Id wäre " + nextID + ".", "Users", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            else
            {
                MessageBox.Show("Es darf kein Feld leer bleiben.", "Users", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private int GetNextID()
        {
            int nextID = Users.Count - 1;
            ObservableCollection<User> getNextIdList;
            getNextIdList = new ObservableCollection<User>(Users.OrderBy(x => x.UserId));
            nextID = getNextIdList[nextID].UserId + 1;
            return nextID;
        }
       
        public ICommand AddCommand { get; set; }
    }
}
