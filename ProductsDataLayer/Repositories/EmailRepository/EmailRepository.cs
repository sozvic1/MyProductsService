using ProductsCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDataLayer.Repositories.EmailRepository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly EFCoreContext _dbcontext;
        public async Task<int> RegisterEmailAsync(Email email)
        {
            _dbcontext.Emails.Add(email);
            await _dbcontext.SaveChangesAsync();
            return email.Id;

        }
    }
}
