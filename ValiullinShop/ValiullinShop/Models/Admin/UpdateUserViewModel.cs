﻿namespace ValiullinShop.Models.Admin
{
    public class UpdateUserViewModel
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
    }
}
