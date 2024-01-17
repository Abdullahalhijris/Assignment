using Assignment.Class;
using Assignment.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Assignment.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext appContext;

        public TransactionService(AppDbContext appContext)
        {
            this.appContext = appContext;
        }

        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            var CreateTransion = new Transaction
            {
                Amount = transaction.Amount,
                BankName = transaction.BankName,
                Reference = GenerateRandomReference(),
                Timestamp = DateTime.Now,
                Location = transaction.Location


            };
            appContext.Transactions.Add(CreateTransion);
            await appContext.SaveChangesAsync();
            return CreateTransion;
        }

        private string GenerateRandomReference()
        {
            Random random = new Random();
            long randomNumber = (long)(random.NextDouble() * (9999999999L - 1000000000L + 1L) + 1000000000L);

            return randomNumber.ToString();
        }



        public async Task<Transaction> DeleteTransaction(int id)
        {
            var delete = await appContext.Transactions.FirstOrDefaultAsync(a => a.TransactionID == id);
            if (delete != null)
            {
                appContext.Transactions.Remove(delete);
                await appContext.SaveChangesAsync();

            }
            return delete;

            
        }

        public async Task<List<Transaction>> GetTransactions()
        {
            var Get = await appContext.Transactions.ToListAsync();
            return Get;
        }

        public async Task<Transaction> UpdateTransaction(Transaction transaction, int id)
        {
            var update = await appContext.Transactions.FirstOrDefaultAsync(a => a.TransactionID== id);

            if (update != null)
            {

                {
                    update.Amount = transaction.Amount;
                    update.BankName = transaction.BankName;
                    update.Location = transaction.Location;
                    await appContext.SaveChangesAsync();
                    return update;

                    await appContext.SaveChangesAsync();
                }

               
            }
            return update;
        }
    }
}
