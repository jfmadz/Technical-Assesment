using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DTO.RequestDTO;
using WebAPI.DTO.ResponseDTO;
using static Dapper.SqlMapper;

namespace WebAPI.BL.DAL
{
    public class SqliteDataAccess
    {
        private IConfiguration _configfile;

        public  List<ViewPrevResponseDTO> GetAllTxn()
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<ViewPrevResponseDTO>("select * from 'Transaction'", new DynamicParameters());
                    return output.ToList();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public TransactionResponseDTO Transaction(TransactionResponseDTO txnResp)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute($"insert into 'Transaction' (spinoutcome,spin,stake,payout) values (@spinoutcome,@mypick,@stake,@payout)  ",
                        txnResp);
                     
                }

                return null;
                
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        private string LoadConnectionString()
        {
            //string roulettedbConn= _configfile["AppSettings:rouletteDB"];
            string roulettedbConn = "Data Source=./rouletteDB.db; Version=3;";
            return roulettedbConn;
        }  
    
    }
   
}
