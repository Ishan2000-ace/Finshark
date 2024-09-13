using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Helper;
using Model;

namespace IStockRepository
{
    public interface StockRepositoryInterface
    {
        public Task<List<StockDTO>> GetAll(StockQueryObject queryObject);

        public Task<StockDTO> GetByID(int id, StockQueryObject queryObject);

        public Task<Stocks> getBySymbol(string symbol);

        public Task<Stocks> CreateStock(CreateStockRequest createStockRequest);

        public Task<Stocks> UpDateStock(CreateStockRequest createStockRequest, int id);

        public Task<Stocks> DeleteStock(int id);

        public Task<bool> IsAnyStock(int id);

        
    }
}