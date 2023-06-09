using System;

namespace HomeWeatherWeb.Server.DTO.User
{
    public class CreateUserDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
