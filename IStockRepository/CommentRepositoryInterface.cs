using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Model;

namespace IStockRepository
{
    public interface CommentRepositoryInterface
    {
        public Task<List<CommentDTO>> getAll();

        public Task<CommentDTO> getByID(int id);
        
        public Task<Comment> CreateComment(CreateCommentDTO createCommentDTO, int stockId);

        public Task<CommentDTO> UpdateComment(CreateCommentDTO updateComment, int id);

        public Task<CommentDTO> DeleteComment(int id);
    }
}