using Quizer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.DTOs.QuestionSets.Create
{
    public class QuestionSetCreateDto
    {
        public string Subject { get; set; }
        public QuestionSet ToEntity()
        {
            return new QuestionSet
            {
                Id = Guid.NewGuid(),
                Subject = this.Subject
            };
        }
    }
}
