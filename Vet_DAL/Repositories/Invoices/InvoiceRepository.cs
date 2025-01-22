using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Helper;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Invoices
{
    public class InvoiceRepository : GenericRepository<Invoice>, IinvoiceRepository
    {
        private readonly VetClinicContext _context;
        public InvoiceRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public IEnumerable<Invoice> GetInvoicesForCurrentWeek()
        {
            DateTime startOfWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            DateTime endOfWeek = DateTime.Now.EndOfWeek(DayOfWeek.Monday);

            return _context.Invoices
                .Where(invoice => invoice.PaymentDate >= startOfWeek && invoice.PaymentDate <= endOfWeek)
                .ToList();
        }

        public IEnumerable<Invoice> GetInvoicesForCurrentMonth()
        {
            var startOfMonth = DateTime.Now.StartOfMonth();
            var endOfMonth = DateTime.Now.EndOfMonth();

            return _context.Invoices
                .Where(invoice => invoice.PaymentDate >= startOfMonth && invoice.PaymentDate <= endOfMonth)
                .ToList();
        }

        public IEnumerable<Invoice> GetInvoicesForCurrentYear()
        {
            var startOfYear = new DateTime(DateTime.Now.Year, 1, 1); // January 1st of the current year
            var endOfYear = new DateTime(DateTime.Now.Year, 12, 31); // December 31st of the current year

            return _context.Invoices
                .Where(invoice => invoice.PaymentDate >= startOfYear && invoice.PaymentDate <= endOfYear)
                .ToList();
        }

        public IEnumerable<Invoice> GetInvoicesForYear(int year)
        {
            var startOfYear = new DateTime(year, 1, 1); // January 1st of the given year
            var endOfYear = new DateTime(year, 12, 31); // December 31st of the given year

            return _context.Invoices
                .Where(invoice => invoice.PaymentDate >= startOfYear && invoice.PaymentDate <= endOfYear)
                .ToList();
        }

        public async Task<List<Invoice>> GetInvoicesForCurrentMonthAsync()
        {
            var startOfMonth = DateTime.Now.StartOfMonth();
            var endOfMonth = DateTime.Now.EndOfMonth();

            // Get all invoices for the current month
            var invoices = await _context.Invoices
                .Where(i => i.PaymentDate >= startOfMonth && i.PaymentDate <= endOfMonth)
                .ToListAsync();  // This requires the Microsoft.EntityFrameworkCore package

            return invoices;
        }


        public async Task<(IEnumerable<Invoice> invoices, int totalRecords)> 
            GetInvoicesWithPaginationAsync(int pageNumber, int pageSize)
        {
            var totalRecords = await _context.Invoices.CountAsync();
            var invoices = await _context.Invoices
                .OrderBy(i => i.PaymentDate) // Sort by a relevant column
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (invoices, totalRecords);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesBySearchAsync(string searchTerm, int page, int pageSize)
        {
            var query = _context.Invoices.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(i => i.OwnerName.ToLower().Contains(searchTerm.ToLower()));
            }

            var invoices = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return invoices;
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Invoices.CountAsync();
        }

    }
}
