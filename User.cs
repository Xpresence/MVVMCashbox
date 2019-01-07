using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MVVMCashbox
{
    [DataContract]
    class User
    {
        [DataMember]
        private string name;
        [DataMember]
        private string password;
        [DataMember]
        private bool isAdmin;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return isAdmin;
            }

            set
            {
                isAdmin = value;
            }
        }

        //public string Name { get => name; set => name = value; }
        //public string Password { get => password; set => password = value; }
    }
}
