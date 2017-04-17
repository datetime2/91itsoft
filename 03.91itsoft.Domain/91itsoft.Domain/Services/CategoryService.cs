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
    public class CategoryService : Service<Category>, ICategoryRepository
    {
        public CategoryService(IRepository<Category> repository) : base(repository)
        {
        }
    }
}
