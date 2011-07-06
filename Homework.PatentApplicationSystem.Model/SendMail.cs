using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
namespace Homework.PatentApplicationSystem.Model
{
    
    public class SendMail
    {
        //邮件的发送地址
        static string from;

        public static string From
        {
            get { return from; }
            set { from = value; }
        }

        public enum MailType
        {
            Return = 0,
            Pass = 1,
            Revise = 2,
        }

        static public void Send(string subject, string body, string to, bool isBodyHtml)
        {
            MailMessage message = new MailMessage();
            message.Subject = subject;
            message.Body = body;
            message.From = new MailAddress(from);
            message.To.Add(to);
            message.IsBodyHtml = isBodyHtml;
            new SmtpClient().Send(message);
        }

        static public void Send(MailType type, string to, string title)
        {
            string subject = string.Empty;
            string body = string.Empty;
            string toAddress = string.Empty;
            switch (type)
            {
                case MailType.Pass:
                    subject = "稿件录用通知";
                    body = "您的稿件：" + title + " 已被我们录用，欢迎查看。<br/><a href=\"#\">Wonder Boys</a>";
                    break;

                case MailType.Return:
                    subject = "退稿通知";
                    body = "您的稿件：" + title + " 已退回，请登录查看。<br/><a href=\"#\">Wonder Boys</a>";
                    break;

                case MailType.Revise:
                    subject = "稿件退回修改通知";
                    body = "您的稿件：" + title + " 需退回修改，请登录查看。<br/><a href=\"#\">Wonder Boys</a>";
                    break;
            }
            Send(subject, body, to, false);
        }
    }
}
