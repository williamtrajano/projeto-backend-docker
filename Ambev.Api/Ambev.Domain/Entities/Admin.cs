﻿namespace Ambev.Domain.Entities
{
    public  class Admin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
