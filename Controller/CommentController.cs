using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using IStockRepository;
using Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Controller
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentRepositoryInterface _Repo;
        private readonly StockRepositoryInterface _stockRepo;

        public CommentController(CommentRepositoryInterface _CRepo, StockRepositoryInterface _Srepo)
        {
            this._Repo = _CRepo;
            this._stockRepo = _Srepo;
        }

        [HttpGet]
        [Route("get-all-comments")]

        public async Task<IActionResult> GetAllComments()
        {
            var list = await _Repo.getAll();
            return Ok(list);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _Repo.getByID(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [HttpPost("{stockId}")]

        public async Task<IActionResult> CreateComment([FromRoute] int stockId, CreateCommentDTO createComment)
        {
            if (!await _stockRepo.IsAnyStock(stockId))
            {
                return NotFound();
            }

            if (createComment == null)
            {
                return BadRequest();
            }

            var CommentModel = await _Repo.CreateComment(createComment, stockId);

            if (CommentModel == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while creating the comment." });
            }

            return CreatedAtAction(nameof(GetById), new { id = CommentModel }, CommentModel.toCommentDTO);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] CreateCommentDTO updateComment){
            var comment = await _Repo.UpdateComment(updateComment, id);

            if(comment==null){
                return NotFound();
            }

            return Ok(comment);
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id){
            var comment = await _Repo.DeleteComment(id);

            if(comment==null){
                return NotFound();
            }

            return Ok(comment);
        }


    }
}