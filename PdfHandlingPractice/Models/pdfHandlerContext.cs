using Microsoft.EntityFrameworkCore;

namespace PdfHandlingPractice.Models
{
    public class pdfHandlerContext : DbContext
    {
        public pdfHandlerContext(DbContextOptions<pdfHandlerContext> options) : base(options) { }
        public DbSet<pdfFiles> PdfFiles { get; set; }
    }
}
