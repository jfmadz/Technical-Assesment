using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.DTO.ResponseDTO
{
   public class ViewPrevResponseDTO
    {
        public int id { get; set; }

        public string spinoutcome { get; set; }

        public string spin { get; set; }

        public decimal stake { get; set; }

        public decimal payout { get; set; }
    }
}
