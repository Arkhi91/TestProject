using DAL.Enums;
using Model.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class User : ObservableObject
    {
        private string _lastName { get; set; }
        private string _name { get; set; }
        private string _middleName { get; set; }
        private string _email { get; set; }
        private string _phone { get; set; }
        private UserPosition _position { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged("LastName"); }
        }
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged("Name"); }
        }
        public string MiddleName
        {
            get => _middleName;
            set { _middleName = value; OnPropertyChanged("MiddleName"); }
        }
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged("Email"); }
        }
        public string Phone
        {
            get => _phone;
            set { _phone = value; OnPropertyChanged("Phone"); }
        }
        public UserPosition Position
        {
            get => _position;
            set { _position = value; OnPropertyChanged("Position"); }
        }
    }
}
