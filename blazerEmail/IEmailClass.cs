
namespace blazerEmail
{
    public interface IEmailClass
    {
        void SendEmail(EmailModel message);
        void AtachFile(EmailModel Attach);
        void AttachPath(EmailModel PathFile, List<string> images);
        void UploadFile(EmailModel Attach);


    }

}
