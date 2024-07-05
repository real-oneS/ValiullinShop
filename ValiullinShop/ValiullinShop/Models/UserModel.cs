namespace ValiullinShop.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public int? Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }   
        public string Error { get; set; }

        public UserModel()
        {

        }

        public UserModel(int id, string firstname, string lastname, string middlename, string phone, string email, string? address, int? role, string login, string password, string error)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            MiddleName = middlename;
            Phone = phone;
            Email = email;
            Address = address;
            Role = role;
            Login = login;
            Password = password;
            Error = error;
        }

        public override string ToString()
        {
            return "Id: " + Id + " Имя: " + FirstName + " Login: " + Login + "Пароль: " + Password + Role;
        }
    }
}
