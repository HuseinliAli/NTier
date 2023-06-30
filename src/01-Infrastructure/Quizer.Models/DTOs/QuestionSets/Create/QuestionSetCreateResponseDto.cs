using Quizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.DTOs.QuestionSets.Create
{
    public class QuestionSetCreateResponseDto
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public static QuestionSetCreateResponseDto Create(QuestionSet entity)
        {
            return new QuestionSetCreateResponseDto { Id = entity.Id, Subject = entity.Subject };
        }
    }
}
