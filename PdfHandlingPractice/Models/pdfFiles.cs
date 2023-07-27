using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PdfHandlingPractice.Models
{
    public class pdfFiles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResumeID { get; set; }

        public int JobId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(12)")]
        public string? VenderName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(12)")]
        public string? filePath { get; set; }
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set;}
    }
}
