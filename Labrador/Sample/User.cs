using System;

namespace Labrador.Sample
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; set; }
        public bool Active { get; set; }
    }
}
