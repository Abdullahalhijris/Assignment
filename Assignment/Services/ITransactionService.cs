using Assignment.Class;

namespace Assignment.Services
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetTransactions();
        Task<Transaction> AddTransaction(Transaction transaction);
        Task<Transaction> UpdateTransaction(Transaction transaction , int id);
        Task<Transaction> DeleteTransaction(int id);
        Task SaveTransactionToFile(Transaction transaction);
        

    }
}
