using Quizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.DTOs.Questions.GetById
{
    public class QuestionGetByIdResponseDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public static QuestionGetByIdResponseDto GetById(Question model)
            => new () { Id =model.Id, Text=model.Text };
    }
}
