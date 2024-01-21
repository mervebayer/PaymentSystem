using PaymentSystem.Base.Enum;

namespace PaymentSystem.Schema
{
    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
        public FileTypeEnum FileType { get; set; }
    }
}