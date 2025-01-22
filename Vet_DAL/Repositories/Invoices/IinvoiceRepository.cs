using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Invoices
{
    public interface IinvoiceRepository: IGenericRepository<Invoice>
    {
        public IEnumerable<Invoice> GetInvoicesForCurrentWeek();
        public IEnumerable<Invoice> GetInvoicesForCurrentMonth();
        public IEnumerable<Invoice> GetInvoicesForCurrentYear();
        public IEnumerable<Invoice> GetInvoicesForYear(int year);
        public Task<List<Invoice>> GetInvoicesForCurrentMonthAsync();
        Task<(IEnumerable<Invoice> invoices, int totalRecords)> 
            GetInvoicesWithPaginationAsync(int pageNumber, int pageSize);

        public Task<IEnumerable<Invoice>> GetInvoicesBySearchAsync
            (string searchTerm, int page, int pageSize);

        public Task<int> GetTotalCountAsync();


    }
}
