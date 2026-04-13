using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
namespace MovieApi.Dto.DTOs.PurchaseDtos
{
    public class ResultPurchaseDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ContentId { get; set; }
        public int ContentType { get; set; }    // ← string değil int
        public string ContentName { get; set; }
        public string ContentImage { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int PaymentStatus { get; set; }  // ← string değil int
    }
}
