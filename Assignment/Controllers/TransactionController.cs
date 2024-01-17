using Assignment.Class;
using Assignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transaction;

        public TransactionController(ITransactionService transactionn)
        {
            this.transaction = transactionn;
        }

        [HttpPost]

        public async Task<IActionResult> AddTransaction(Transaction transaction)
        {
            try
            {
                var result = await this.transaction.AddTransaction(transaction);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]

        public async Task<IActionResult> DeleteTransaction(int id)
        {
            try
            {
                var result = await this.transaction.DeleteTransaction(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            try
            {
                var result = await this.transaction.GetTransactions();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransaction(Transaction transaction, int id)
        {
            try
            {
                var result = await this.transaction.UpdateTransaction(transaction, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    } 
}
