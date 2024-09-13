using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IStockRepository;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Data;

namespace Repository
{
    public class PortfolioRepository : PortfolioInterface
    {
        private readonly ApplicationDbContext _context;
        public PortfolioRepository(ApplicationDbContext con)
        {
            _context = con;
        }

        public async Task<Portfolio> createPortfolio(Portfolio portfolio)
        {
           await _context.Portfolios.AddAsync(portfolio);

            await _context.SaveChangesAsync();

            return portfolio;
        }

        public async Task<Portfolio> DeletePortfolio(AppUser user, string symbol)
        {
            var portfolio = await _context.Portfolios.FirstOrDefaultAsync(s => s.AppUserId == user.Id && s.stocks.symbol.ToLower()==symbol);

            if(portfolio==null){
                return new Portfolio();
            }

            _context.Portfolios.Remove(portfolio);

           await  _context.SaveChangesAsync();

           return portfolio;
        }

        public async Task<List<Stocks>> getPortfolio(AppUser user)
        {
            return await _context.Portfolios.Where(u => u.AppUserId == user.Id)
                         .Select(Stocks => new Stocks{
                            ID = Stocks.stockId,
                            symbol = Stocks.stocks.symbol,
                            Industry = Stocks.stocks.Industry,
                            MarketCap = Stocks.stocks.MarketCap,
                            Purchase = Stocks.stocks.Purchase,
                            companyname = Stocks.stocks.companyname,
                            LastDiv = Stocks.stocks.LastDiv
                         }).ToListAsync();
        }
    }
}