using System.ComponentModel.DataAnnotations;

namespace MyWebFormApp.BLL.DTOs
{
    public class ArticleCreateDTO
    {
        [Range(1, 1000, ErrorMessage = "Category Belum dipilih")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Title harus diisi")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Details harus diisi")]
        [StringLength(100, MinimumLength = 5)]
        public string Details { get; set; }


        public bool IsApproved { get; set; }

        public string Pic { get; set; }
    }
}
