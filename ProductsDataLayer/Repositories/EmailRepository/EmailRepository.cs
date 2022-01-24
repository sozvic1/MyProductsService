using Microsoft.EntityFrameworkCore;
using ProductsCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDataLayer.Repositories.EmailRepository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly EFCoreContext _dbcontext;

        public async Task ConfirmEmailAsync(string email)
        {
            var emailEntity = await _dbcontext.Emails.
                Where(x => x.PostName == email).
                FirstOrDefaultAsync();
            emailEntity.IsConfirmed = true;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<string> GetConfirmMessageAsync(string email)
            => await _dbcontext.Emails.
            Where(x => x.PostName == email).
            Select(x => x.ConfirmationString).FirstOrDefaultAsync();
        

        public async Task<int> RegisterEmailAsync(Email email)
        {
            _dbcontext.Emails.Add(email);
            await _dbcontext.SaveChangesAsync();
            return email.Id;

        }
    }
}
