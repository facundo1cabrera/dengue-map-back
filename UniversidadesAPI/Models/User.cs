namespace UniversidadesAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public string ConfirmationCode { get; set; }

        public List<Opinion> Opiniones { get; set; }
    }
}
