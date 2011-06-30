namespace Homework.PatentApplicationSystem.Model
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }

    public enum Role
    {
        立案员,
        质检员,
        代理部主管,
        办案员,
        代理部文员
    }
}