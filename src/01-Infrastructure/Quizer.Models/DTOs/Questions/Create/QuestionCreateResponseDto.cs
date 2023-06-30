using Quizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.DTOs.Questions.Create
{
    public class QuestionCreateResponseDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public byte Point { get; set; }
        public static QuestionCreateResponseDto Create(Question model)
        {
            return new QuestionCreateResponseDto
            {
                Id=model.Id,
                Text=model.Text,
                Point=model.Point,
            };
        }
    }
}
