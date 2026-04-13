using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Dto.DTOs.PurchaseDtos
{
    public class CreatePurchaseDto
    {
        public string UserId { get; set; }
        public int ContentId { get; set; }
        public int ContentType { get; set; }

    }
}
