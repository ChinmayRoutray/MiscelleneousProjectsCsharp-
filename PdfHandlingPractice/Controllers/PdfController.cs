using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PdfHandlingPractice.Models;
using System.Text;

namespace PdfHandlingPractice.Controllers
{
    [ApiController]
    [Route("api/pdfHandler/")]
    public class PdfController : ControllerBase
    {
        private readonly pdfHandlerContext _context;
        public PdfController(pdfHandlerContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpPost("upload")]
        public IActionResult UploadFile(int jobid, string Vendor, string path, IFormFile myFile)
        {
            /*if(myFile.Length > 1024*1000 || !"application/pdf".Equals(myFile.ContentType))
            {
                return BadRequest();
            }*/
            var pdfFile = new pdfFiles();
            using (var stream = new MemoryStream())
            {
                pdfFile.ContentType = myFile.ContentType;
                pdfFile.FileName = myFile.FileName;
                myFile.CopyTo(stream);
                pdfFile.FileData = stream.ToArray();
                pdfFile.VenderName = Vendor;
                pdfFile.filePath = path;
                pdfFile.JobId = jobid;
                _context.PdfFiles.Add(pdfFile);
                _context.SaveChanges();
            }
            return Ok();
        }

        /*[HttpGet("download/{id}")]
        public string GetFile(int id)
        {
            var res = _context.PdfFiles.Where(c => c.FileId == id).FirstOrDefault();
            //FileContent fileContent = JsonConvert.DeserializeObject<FileContent>(res);
            var c = System.Text.Encoding.ASCII.GetString(res.FileData).Trim();
            return c;
        }*/

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadPdf(int id)
        {
            var pdfModel = await _context.PdfFiles.FindAsync(id);
            if (pdfModel == null)
            {
                return NotFound();
            }

            var file = File(pdfModel.FileData, "application/pdf", pdfModel.FileName);

            return file;
        }
    }
}
