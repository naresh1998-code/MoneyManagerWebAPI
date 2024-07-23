namespace MoneyManagerWebAPI.Models
{
    public class User
    {
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Transcaction> Transcactions { get; internal set; }
        public int? IdUsers { get; internal set; }
        public string? NameUser { get; internal set; }
        public string PasswordUser { get; internal set; }
        public IEnumerable<Category> Categories { get; internal set; }
    }
}