using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_namespace
{
    public class User
    {
        string first_name, last_name, login, password, description, gender, photo_path;
        long id;
        int age;
        DateTime birth_date;

        public string FirstName { get { return first_name; } set { first_name = value; } }
        public string LastName { get { return last_name; } set { last_name = value; } }
        public string Login { get { return login; } set { login = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Description { get { return description; } set { description = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public string PhotoPath { get { return photo_path; } set { photo_path = value; } }
        public long Id { get { return id; } set { id = value; } }
        public int Age { get { return age; } set { age = value; } }
        public DateTime BirthDate { get { return birth_date; } set { birth_date = value; } }

        public User() { }
    }
}
