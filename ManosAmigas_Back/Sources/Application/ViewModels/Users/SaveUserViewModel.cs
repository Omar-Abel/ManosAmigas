﻿namespace ManosAmigas_Back.Sources.Application.ViewModels.Users
{
    public class SaveUserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }
}
