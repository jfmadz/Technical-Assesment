using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DTO.RequestDTO;
using WebAPI.DTO.ResponseDTO;

namespace WebAPI.BL.BLL.Interface
{
    public interface IRoulette
    {
        Task<TransactionResponseDTO> Transaction(TransactionRequestDTO txnReq);

        Task<List<ViewPrevResponseDTO>> GetAllTxn();
 

    }

        
}
