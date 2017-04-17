using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _91itsoft.Domain.Services.Common;
using _91itsoft.Domain.Entities;
using _91itsoft.Domain.Interfaces.Repository;

namespace _91itsoft.Domain.Services
{
    public class ArticleService : Service<Article>, IArticleRepository
    {
        public ArticleService(IRepository<Article> repository) : base(repository)
        {
        }
    }
}
