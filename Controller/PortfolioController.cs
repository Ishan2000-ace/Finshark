using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IStockRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Extensions;
using Model;
using Repository;

namespace Controller
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly StockRepositoryInterface StockRepo;

        private readonly PortfolioInterface portfolio;

        public PortfolioController(UserManager<AppUser> _user, StockRepositoryInterface _repo, PortfolioInterface port)
        {
            this._userManager = _user;
            this.StockRepo = _repo;
            this.portfolio = port;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio(){
            var username = User.GetUsername(); 
            var appuser = await _userManager.FindByNameAsync(username);

            if(appuser==null){
                return BadRequest();
            }

            List<Stocks> stocks =   await portfolio.getPortfolio(appuser);   

            return Ok(stocks);   
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePortfolio(string symbol){
            var username = User.GetUsername();

            var user = await _userManager.FindByNameAsync(username);

            if(user==null){
                return BadRequest();
            }

            var stocks = StockRepo.getBySymbol(symbol);

            var userportfolio =await portfolio.getPortfolio(user);

            if(userportfolio.Any(a=> a.symbol.ToLower() == symbol.ToLower())) return BadRequest("Stock already exists");

             
            var Portfolio = new Portfolio{
                stockId = stocks.Id,
                AppUserId = user.Id
            };

            var cPortfolio = portfolio.createPortfolio(Portfolio);

            return Ok();
        }
        [HttpDelete]
        [Authorize]

        public async Task<IActionResult> DeletePortfolio(string symbol){
            var username = User.GetUsername();

            var user = await _userManager.FindByNameAsync(username);

            var stock = await StockRepo.getBySymbol(symbol);

            if(user==null){
                return BadRequest();
            }

            var userportfolio = await portfolio.getPortfolio(user);

            var filteredstock = userportfolio.Where(s => s.symbol.ToLower()==stock.symbol.ToLower());

            if(filteredstock.Count()==1){
               await  portfolio.DeletePortfolio(user, symbol);
            }

            else{
                return BadRequest();
            }

            return Ok();
        }
        
    }
}