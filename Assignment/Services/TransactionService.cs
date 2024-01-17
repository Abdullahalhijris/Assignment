using Assignment.Class;
using Assignment.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System;
using System.IO;
using System.Threading.Tasks;

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
            var update = await appContext.Transactions.FirstOrDefaultAsync(a => a.TransactionID == id);

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

        public async Task SaveTransactionToFile(Transaction transaction)
        {
            {
                // Specify the path to your flat file
                string filePath = "FlatFile/transaction_data.txt";

                try
                {
                    // Open the file for appending
                    using (StreamWriter writer = File.AppendText(filePath))
                    {
                        // Write transaction data to the file
                        await writer.WriteLineAsync($"TransactionID: {transaction.TransactionID}");
                        await writer.WriteLineAsync($"Amount: {transaction.Amount}");
                        await writer.WriteLineAsync($"BankName: {transaction.BankName}");
                        await writer.WriteLineAsync($"Reference: {transaction.Reference}");
                        await writer.WriteLineAsync($"Timestamp: {transaction.Timestamp}");
                        await writer.WriteLineAsync($"Location: {transaction.Location}");
                        await writer.WriteLineAsync(new string('-', 30)); // Separator
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions, log, or throw as needed
                    Console.WriteLine($"Error saving transaction to file: {ex.Message}");
                }
            }
        }

       
        
    }
}
