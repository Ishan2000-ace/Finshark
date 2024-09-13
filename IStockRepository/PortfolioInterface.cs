using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace IStockRepository
{
    public interface PortfolioInterface
    {
        public Task<List<Stocks>> getPortfolio(AppUser user);

        public Task<Portfolio> createPortfolio(Portfolio portfolio);

        public Task<Portfolio> DeletePortfolio(AppUser user, string symbol);
    }
}