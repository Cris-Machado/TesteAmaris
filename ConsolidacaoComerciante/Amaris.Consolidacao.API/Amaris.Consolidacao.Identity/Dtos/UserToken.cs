﻿namespace Amaris.Consolidacao.Identity.Dtos
{
    public class UserToken
    {
        public string AccessToken { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime Expires { get; set; }
    }
}
