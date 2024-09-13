using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using IStockRepository;
using Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Data;

namespace Repository
{
    public class CommentRepository : CommentRepositoryInterface
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Comment> CreateComment(CreateCommentDTO createCommentDTO, int stockId)
        {
            var comment = createCommentDTO.toComment(stockId);
           await  _context.AddAsync(comment);
            await _context.SaveChangesAsync();

            return comment;
           
        }

        public async Task<CommentDTO> DeleteComment(int id)
        {
            var comment = await _context.comments.FirstOrDefaultAsync(f => f.ID==id);

            if(comment==null){
                return new CommentDTO();
            }


             _context.comments.Remove(comment);

             _context.SaveChanges();

             return comment.toCommentDTO();
        }

        public async Task<List<CommentDTO>> getAll()
        {
            var comment = await _context.comments.ToListAsync();
            var comment_list = comment.Select(s=>s.toCommentDTO());

            return comment_list.ToList();
        }

        public async Task<CommentDTO> getByID(int id)
        {
            var comment = await _context.comments.FindAsync(id);

            if(comment==null){
                return new CommentDTO();
            }

            return comment.toCommentDTO();
        }

        public async Task<CommentDTO> UpdateComment(CreateCommentDTO updateComment, int id)
        {
            var comment = await _context.comments.FindAsync(id);

            if(comment==null){
                return new CommentDTO();
            }

            comment.content = updateComment.content;
            comment.Title = updateComment.Title;

             _context.comments.Update(comment);

             _context.SaveChanges();

            return comment.toCommentDTO();
        }
    }
}