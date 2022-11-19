using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ClassLibrary
{
    public static class SendMail
    {
        public static (bool, string) Send(
            string[] toAddressList,
            string subject,
            string body,
            string[] ccAddressList,
            string[] bccAddressList = null,
            string[] attachmentFilePaths = null
            )
        {
            //Biến để chứa kết quả gửi mail thành công hay thất bại
            bool isSent = false;

            //Người gửi
            string fromAddress = ConfigurationManager.AppSettings["fromAddress"];

            //Danh sách người nhận
            if (toAddressList == null)
            {
                throw new ArgumentNullException("Thiếu danh sách người nhận");
                //toAddressList = ConfigurationManager.AppSettings["toAddressList"].Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            }

            //Danh sách Carbon Copy (CC)
            if (ccAddressList == null)
            {
                ccAddressList = ConfigurationManager.AppSettings["ccAddressList"].Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            }

            //Danh sách Blind Carbon Copy (BCC)
            if (bccAddressList == null)
            {
                bccAddressList = ConfigurationManager.AppSettings["bccAddressList"].Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            }

            //Mật khẩu ứng dụng
            //string password = ConfigurationManager.AppSettings["password"];

            var password = "";
            var section = WebConfigurationManager.GetSection("secureAppSettings") as NameValueCollection;
            if (section != null && section["Password"] != null)
            {
                password = section["Password"];
            }

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    //From
                    mail.From = new MailAddress(fromAddress);

                    //To
                    foreach (var toAddress in toAddressList)
                    {
                        try
                        {
                            if (IsValid(toAddress))
                            {
                                mail.To.Add(toAddress);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }
                    }

                    //CC
                    foreach (var ccAddress in ccAddressList)
                    {
                        try
                        {
                            if (IsValid(ccAddress))
                            {
                                mail.CC.Add(ccAddress);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }
                    }

                    //BCC
                    foreach (var bccAddress in bccAddressList)
                    {
                        try
                        {
                            if (IsValid(bccAddress))
                            {
                                mail.Bcc.Add(bccAddress);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }
                    }

                    //Subject & Body
                    mail.Subject = subject;
                    mail.Body = body;

                    mail.IsBodyHtml = true;

                    //Attachments
                    if (attachmentFilePaths != null)
                    {
                        foreach (var attachmentFilePath in attachmentFilePaths)
                        {
                            try
                            {
                                if (File.Exists(attachmentFilePath))
                                {
                                    mail.Attachments.Add(new Attachment(attachmentFilePath));
                                }
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex);
                            }
                        }
                    }

                    //Send Mail
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(fromAddress, password);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }

                    //Gửi thành công
                    isSent = true;
                }

                if (isSent)
                {
                    return (isSent, "Gửi mail thành công!");
                }
                else
                {
                    return (isSent, "Gửi mail thất bại.");
                }
            }
            catch (Exception ex)
            {
                //Gửi thất bại
                isSent = false;

                return (isSent, $"Gửi mail thất bại. Lỗi: {ex.ToString()}");
            }
        }

        private static bool IsValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Console.WriteLine(ex);
                valid = false;
            }

            return valid;
        }
        public static void Test() { }
    }
}

