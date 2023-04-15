using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TurkcellExample.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Remote(action: "DuplicateNameControl",controller:"Product",AdditionalFields = nameof(Id))]
        [Required(ErrorMessage = "Ürün Adı Boş Olamaz!")]
        [StringLength(50,ErrorMessage ="Ürün Adı en az 10 en fazla 50 karakter olabilir .",MinimumLength =10)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Ürün Fiyatı Boş Olamaz!")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Ürün Stoğu Boş Olamaz!")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "Ürün Rengi Boş Olamaz!")]
        public string? Color { get; set; }

        public bool IsPublish { get; set; }

        public string Expire { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "Ürün Yayın Tarihi Boş Olamaz!")]
        public DateTime? CreatedTime { get; set; }
        [Required(ErrorMessage ="E-Mail Alanı Doldurulması Zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçersiz E-Mail Adresi.")]
        public string Email { get; set; }

        [RegularExpression("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[- \\s\\./0-9]*$", ErrorMessage = "Lütfen Telefon numarasını uygun formatta girin")]
        public string Phone { get; set; }
    }
}
