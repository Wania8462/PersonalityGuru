using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonalityGuru.Server.Data;
using PersonalityGuru.Shared.Models;
using PersonalityGuru.Shared.Repository;

namespace PersonalityGuru.Server.Repositories
{
    public class QuestionnaireRepository : IQuestionnaireRepository
    {
        private readonly ApplicationDbContext appDbContext;
        public QuestionnaireRepository(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Questionnaire> GetQuestionnaireAsync(int id)
        {
            return await appDbContext.Tests
                .Include(q => q.Questions)
                .FirstAsync(t => t.Id == id);
        }
    }
}
