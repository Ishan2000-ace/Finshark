using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Helper;
using IStockRepository;
using Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Data;
using Repository;

namespace Controller
{

    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
       private readonly StockRepositoryInterface repo;

       public StockController(StockRepositoryInterface _repo){
          this.repo = _repo;
       }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetALL([FromQuery] StockQueryObject queryObject){
            var stocklist = await repo.GetAll(queryObject);
            return Ok(stocklist);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetByID([FromRoute] int id, [FromQuery] StockQueryObject queryObject){
            var stock = await repo.GetByID(id, queryObject);
            if(stock==null){
                return NotFound();
            }

            return Ok(stock);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockRequest Createstock){
              var stock = await repo.CreateStock(Createstock);
              
              return CreatedAtAction(nameof(GetByID), new {id=stock.ID}, stock.toStockDTO());
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] CreateStockRequest updateStock){
            var updatedstock = await repo.UpDateStock(updateStock, id);
            if(updatedstock==null){
                return NotFound();
            }
            return Ok(updatedstock);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]

        public async Task<IActionResult> DeleteStock([FromRoute] int id){
            var stock = await repo.DeleteStock(id);

            if(stock==null){
                return NotFound();
            }

            

            return Ok();
        }

        

    }
}