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
        ����Ա,
        �ʼ�Ա,
        ��������,
        �참Ա,
        ������Ա
    }
}