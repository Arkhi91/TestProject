using DAL.Models;
using DAL.Repositories;
using GalaSoft.MvvmLight.Command;
using Model.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TestProject.Views;

namespace ViewModel
{
    public class UserViewModel : ObservableObject
    {
        private ICommand _addUser;
        private ICommand _editUser;
        private ICommand _deleteUser;
        private User _selectedUser;
        private UserRepository _repository;
        private ObservableCollection<User> _users;

        public User SelectedUser 
        { 
            get => _selectedUser;
            set { _selectedUser = value; OnPropertyChanged("SelectedUser"); } 
        }

        public UserViewModel()
        {
            _repository = new UserRepository();
            _users = new ObservableCollection<User>(_repository
                .GetAll()
                .ToList());
        }

        public ObservableCollection<User> GetAllUsers
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged("GetAllUsers");
            }
        }
        
        public ICommand DeleteUser
        {
            get => new RelayCommand(() => Delete());
        }

        public ICommand AddUser
        {
            get => new RelayCommand(() => Add());
        }

        public ICommand EditUser
        {
            get => new RelayCommand(() => Edit());
        }

        private void Delete()
        {
            if (_selectedUser != null)
            {
                _repository.Delete(_selectedUser);
                _users.Remove(_selectedUser);
                OnPropertyChanged("DeleteUser");
            }
        }

        private void Add()
        {
            var user = new User();
            var window = new PutWindow(user);
            window.Closing -= Window_Closing;
            window.Closing += Window_Closing;
            window.Show();        
        }

        private void Edit()
        {
            if (_selectedUser != null)
            {
                var window = new PutWindow(_selectedUser);
                window.Show();
                window.Closing -= Window_Closing;
                window.Closing += Window_Closing;  
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var window = sender as PutWindow;
            var user = window.User;

            if(user.Id == default(int))
            {
                _repository.Create(user);
                _users.Add(user);
                OnPropertyChanged("AddUser");
            }
            else
            {
                _repository.Update(_selectedUser);
                OnPropertyChanged("EditUser");
            }
        }
    }
}
