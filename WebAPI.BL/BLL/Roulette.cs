using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.BL.BLL.Interface;
using WebAPI.BL.DAL;
using WebAPI.DTO.RequestDTO;
using WebAPI.DTO.ResponseDTO;

namespace WebAPI.BL.BLL
{
   public class Roulette:IRoulette
    {
        public async Task<List<ViewPrevResponseDTO>> GetAllTxn()
        {
            SqliteDataAccess response = new SqliteDataAccess();

            return response.GetAllTxn();
        }

        public async Task<TransactionResponseDTO> Transaction(TransactionRequestDTO txnReq)
        {
            decimal checkWin;

            Random random = new Random();

            int num = random.Next(37);
            string[] arr = { "Black", "Red", "red", "black", "RED", "BLACK" };

            int index = random.Next(arr.Length);

            string numToString = Convert.ToString(num);

            string outcome =$"Number - {numToString}_ Colour -{arr[index]}" ;

            string win1 = $"{numToString}";
            string win2 = $"{arr[index]}";


            if (txnReq.myspin == win1)
            {
                checkWin = txnReq.stake * 35;
                
            }

            else if (txnReq.myspin.IndexOf(win2,StringComparison.OrdinalIgnoreCase)>=0)
            {
                checkWin = txnReq.stake * 2;
                
            }
            else
            {
                 checkWin = 0;
            }


            SqliteDataAccess exec = new SqliteDataAccess();
            TransactionResponseDTO txnResp = new TransactionResponseDTO();

            txnResp.spinoutcome = outcome;
            txnResp.mypick = txnReq.myspin;
            txnResp.stake = txnReq.stake;
            txnResp.payout = checkWin;

            exec.Transaction(txnResp);

            

            return txnResp;
            
        }


    }
}
