using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Model;

namespace Mapper
{
   
    public static class StockMapper
    {
        public static StockDTO toStockDTO(this Stocks StockModel){
             return new StockDTO{
                ID = StockModel.ID,
                symbol = StockModel.symbol,
                companyname = StockModel.companyname,
                Purchase = StockModel.Purchase,
                LastDiv = StockModel.LastDiv,
                Industry = StockModel.Industry,
                MarketCap = StockModel.MarketCap,
                comments = StockModel.comments.Select(s=>s.toCommentDTO()).ToList()
             };
        }

        public static Stocks ToStockFromCreateDTO(this CreateStockRequest createStock ){
            
              return new Stocks{
                  
                   symbol = createStock.symbol,
                   companyname = createStock.companyname,
                   Purchase = createStock.Purchase,
                   LastDiv = createStock.LastDiv,
                   Industry = createStock.Industry,
                   MarketCap = createStock.MarketCap
                   
              };
        }
    }
}