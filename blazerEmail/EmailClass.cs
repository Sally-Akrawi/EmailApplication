
using MudBlazor;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace blazerEmail;

public class EmailClass : IEmailClass
{

    public EmailClass(ISnackbar snackbar)
    {
        _snackbar = snackbar;
    }

    string SendersAddress = "****";
    const string SendersPassword = "***";
    private readonly ISnackbar _snackbar;

    /// <summary>
    /// This function is to send email with an attachment file that is saved in the application
    /// </summary>
    /// <param name="Attach"></param>
    public void AtachFile(EmailModel Attach)
    {
        try
        {
            string[] folder = Directory.GetFiles("wwwroot//sss//");
            MailMessage message = new MailMessage(SendersAddress, Attach.ReceiversAddress, Attach.subject, Attach.body);

            foreach (var item in folder)
            {

                Attachment data = new Attachment(item, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(item);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(item);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(item);

                message.Attachments.Add(data);
            }

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(SendersAddress, SendersPassword),
                Timeout = 25000
            };

            smtp.Send(message);
            Console.WriteLine("Message Sent Successfully");
            _snackbar.Add("Message Sent Successfully", Severity.Success);
        }

        catch (Exception ex)
        {
            _snackbar.Add(ex.Message.ToString(), Severity.Error);
            Console.WriteLine("your massage is not sended");
        }
    }

    /// <summary>
    /// This function is to send a message email
    /// </summary>
    /// <param name="modeling"></param>
    public void SendEmail(EmailModel modeling)
    {
        try
        {

            MailMessage message = new MailMessage(SendersAddress, modeling.ReceiversAddress, modeling.body, modeling.subject);


            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(SendersAddress, SendersPassword),
                Timeout = 25000
            };

            smtp.Send(message);
            Console.WriteLine("Message Sent Successfully");
            _snackbar.Add("Message Sent Successfully", Severity.Success);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            _snackbar.Add(ex.Message.ToString(), Severity.Error);
        }
    }
    /// <summary>
    /// This function is to send images by selecting any of the exict images.
    /// </summary>
    /// <param name="PathFile" ></param>
    /// <param name="Images"></param>
    public void AttachPath(EmailModel PathFile, List<string> Images)

    {
        try
        {

            MailMessage message = new MailMessage(SendersAddress, PathFile.ReceiversAddress, PathFile.subject, PathFile.body);

            foreach (var item in Images)
            {
                string AddPath = "wwwroot\\" + item;


                Attachment data = new Attachment(AddPath, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(AddPath);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(AddPath);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(AddPath);

                message.Attachments.Add(data);
            }

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(SendersAddress, SendersPassword),
                Timeout = 25000
            };


            smtp.Send(message);
            _snackbar.Add("Message Sent Successfully", Severity.Success);
            Console.WriteLine("Message Sent Successfully");
        }
        catch (Exception ex)
        {
            _snackbar.Add(ex.Message.ToString(), Severity.Error);
            Console.WriteLine("your massage is not sended");
        }
    }
    /// <summary>
    /// This function is to send an attachment by upload it from your device.
    /// </summary>
    /// <param name="Attach"></param>
    public void UploadFile(EmailModel Attach)
    {
        try
        {
            string[] folder = Directory.GetFiles("wwwroot//blank//");
            MailMessage message = new MailMessage(SendersAddress, Attach.ReceiversAddress, Attach.subject, Attach.body);

            foreach (var item in folder)
            {

                Attachment data = new Attachment(item, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(item);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(item);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(item);

                message.Attachments.Add(data);
            }

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(SendersAddress, SendersPassword),
                Timeout = 25000
            };

            smtp.Send(message);
            Console.WriteLine("Message Sent Successfully");
            _snackbar.Add("Message Sent Successfully", Severity.Success);
        }

        catch (Exception ex)
        {
            _snackbar.Add(ex.Message.ToString(), Severity.Error);
            Console.WriteLine("your massage is not sended");
        }
    }

}






