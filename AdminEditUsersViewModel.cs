using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MVVMCashbox
{
    class AdminEditUsersViewModel
    {
        private ObservableCollection<User> users;
        private User selectedUser;

        private Command addUserCommand;
        private Command deleteUserCommand;


        public AdminEditUsersViewModel()
        {
            Users = new ObservableCollection<User>();
        }

        public ObservableCollection<User> Users
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged("Users");
            }
        }

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }


        public Command AddUserCommand
        {
            get
            {
                return addUserCommand != null ? addUserCommand : addUserCommand = new Command((obj) =>
                {
                    User user = new User();
                    Users.Insert(0, user);
                    SelectedUser = user;
                });
            }
        }

        public Command DeleteUserCommand
        {
            get
            {
                return deleteUserCommand != null ? deleteUserCommand : deleteUserCommand = new Command((obj) =>
                {
                    User user = obj as User;
                    if (user != null)
                    {
                        Users.Remove(user);
                    }
                }, (obj) =>
                {
                    User user = obj as User;
                    if (user != null)
                    {
                        if (Users.Count > 0 && !user.IsAdmin)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                });
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
