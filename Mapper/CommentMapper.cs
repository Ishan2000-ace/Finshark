using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs;
using Model;

namespace Mapper
{
    public static class CommentMapper
    {
        public static CommentDTO toCommentDTO(this Comment comment){
            return new CommentDTO{
                ID = comment.ID,
                Title = comment.Title,
                content = comment.content,
                dateTime = comment.dateTime,
                stockId = comment.stockId
            };
        }

        public static Comment toComment(this CreateCommentDTO createComment, int stockId){
            return new Comment{
                Title = createComment.Title,
                content = createComment.content,
                stockId = stockId
            };
        }
    }
}