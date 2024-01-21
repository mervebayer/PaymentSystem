using PaymentSystem.Base.Enum;

namespace PaymentSystem.Schema
{
    public class FileDetails
    {
      public int ID { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public FileTypeEnum FileType { get; set; }  
    }
}