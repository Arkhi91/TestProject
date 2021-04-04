using DAL.Enums;
using DAL.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace TestProject.Views
{
    /// <summary>
    /// Interaction logic for PutWindow.xaml
    /// </summary>
    public partial class PutWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private UserPosition _userPosition;
        public User User { get; set; }

        public UserPosition UserPosition 
        { 
            get => _userPosition;
            set {_userPosition = value; OnPropertyChanged("UserPosition"); } 
        }
        public ObservableCollection<UserPosition> UserPositions { get; set; } = new ObservableCollection<UserPosition>();

        public PutWindow(User user)
        {
            User = user;
            InitializeComponent();
            DataContext = this;
            if (User != null)
            {
                tbxName.Text = User.Name;
                tbxLastName.Text = User.LastName;
                tbxMiddleName.Text = User.MiddleName;
                tbxEmail.Text = User.Email;
                tbxPhone.Text = User.Phone;
                UserPosition = User.Position;
            }

            foreach (UserPosition type in Enum.GetValues(typeof(UserPosition)))
                UserPositions.Add(type);
        }

        private void cmbType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _userPosition = (UserPosition)e.AddedItems[0];
        }

        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            User.Name = tbxName.Text;
            User.MiddleName = tbxMiddleName.Text;
            User.LastName = tbxLastName.Text;
            User.Email = tbxEmail.Text;
            User.Phone = tbxPhone.Text;
            User.Position = _userPosition;
            Close();
        }
    }
}
