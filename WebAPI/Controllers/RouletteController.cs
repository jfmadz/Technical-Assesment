using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.BL.BLL.Interface;
using WebAPI.DTO.RequestDTO;
using WebAPI.DTO.ResponseDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRoulette _roulette;

        public RouletteController(IRoulette roulette)
        {
            _roulette = roulette;
        }

        [HttpPost("v1/roulette/trans", Name = "Transaction")]
        public async Task<ActionResult<TransactionResponseDTO>> Transaction(TransactionRequestDTO txnReq)
        {
            
            return await _roulette.Transaction(txnReq);

        }

        [HttpGet("v1/roulette/getall", Name = "PreviousSpins")]
        public async Task<ActionResult<List<ViewPrevResponseDTO>>> GetAllTxn()
        {

            return await _roulette.GetAllTxn();

        }

    }
}
