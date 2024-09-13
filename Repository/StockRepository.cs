using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using IStockRepository;
using Model;
using Model.Data;
using Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Helper;

namespace Repository
{
    public class StockRepository : StockRepositoryInterface
    {
       private readonly ApplicationDbContext _context;

       public StockRepository(ApplicationDbContext dbContext){
        this._context = dbContext;
       }
        public async Task<Stocks> CreateStock(CreateStockRequest createStockRequest)
        {
            var stock = createStockRequest.ToStockFromCreateDTO();
             await _context.Stock.AddAsync(stock);
            await  _context.SaveChangesAsync();

            return stock;
        }

        public async Task<Stocks> DeleteStock(int id)
        {
            Stocks? stock = _context.Stock.FirstOrDefault(x =>x.ID == id);
            _context.Remove(stock);
           await _context.SaveChangesAsync();

           return stock;
        }

        public async Task<List<StockDTO>> GetAll(StockQueryObject queryObject)
        {
            
            var stocklist = _context.Stock.Include(c => c.comments).AsQueryable();
            
            if(!string.IsNullOrWhiteSpace(queryObject.CompanyName)){
                stocklist = stocklist.Where(s=>s.companyname==queryObject.CompanyName);
            }

            if(!string.IsNullOrWhiteSpace(queryObject.Symboll)){
                stocklist = stocklist.Where(s=>s.symbol==queryObject.Symboll);
            }

            if(!string.IsNullOrWhiteSpace(queryObject.sortBY)){
              stocklist =  queryObject.isDscending ? stocklist.OrderByDescending(s => s.symbol) : stocklist.OrderBy(s=>s.symbol);
            }

            var skipnumber = (queryObject.PageNo-1) * queryObject.PageSize;

            List<StockDTO> stockDTos = await stocklist.Skip(skipnumber).Take(queryObject.PageSize).Select(s => s.toStockDTO()).ToListAsync();

            return stockDTos;
            
        }

        

        public async Task<StockDTO> GetByID(int id, StockQueryObject queryObject)
        {
            var skipnumber = (queryObject.PageNo-1) * queryObject.PageSize;
            var stock = await _context.Stock.Skip(skipnumber).Take(queryObject.PageSize).Include(c => c.comments).FirstOrDefaultAsync(X => X.ID==id);

            return stock.toStockDTO();
        }

        public async Task<Stocks> getBySymbol(string symbol)
        {
            return await _context.Stock.FirstOrDefaultAsync(s=>s.symbol == symbol);
        }

        public Task<bool> IsAnyStock(int id)
        {
            return _context.Stock.AnyAsync(a => a.ID == id);
        }

        public async Task<Stocks> UpDateStock(CreateStockRequest updateStock, int id)
        {
            Stocks? stockModel =await  _context.Stock.FirstOrDefaultAsync(x => x.ID==id);

            

            Stocks stocks = updateStock.ToStockFromCreateDTO();

            
            stockModel.symbol = stocks.symbol;
            stockModel.Industry = stocks.Industry;
            stockModel.LastDiv = stocks.LastDiv;
            stockModel.companyname = stocks.companyname;
            stockModel.MarketCap = stocks.MarketCap;

            _context.Update(stockModel);
            _context.SaveChanges();

            return stockModel;

        }

        
    }
}