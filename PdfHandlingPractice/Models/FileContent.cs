using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace PdfHandlingPractice.Models
{
    public class FileContent
    {
        [JsonProperty("FileId")]
        public int FileId { get; set; }
        [JsonProperty("FileData")]
        public byte[] FileData { get; set; }
    }
}
