using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.InvoiceDTOs;

namespace Vet_BLL.Services.Invoices
{
    public interface IinvoiceService: IGenericService<InvoiceDto>
    {
        public IEnumerable<WeeklyRevenueDto> GetWeeklyRevenue();
        public decimal GetWeeklyTotalRevenue();
        public decimal GetMonthlyTotalRevenue();
        public IEnumerable<WeeklyRevenueDto> GetMonthlyRevenue();
        public IEnumerable<WeeklyRevenueDto> GetYearlyRevenue();

        public decimal GetYearlyTotalRevenue();
        public decimal GetYearlyTotalRevenue(int year);
        public YearlyComparisonDto GetYearlyRevenueComparison();
        public Task<List<RevenueByDayDto>> GetMonthlyRevenueByDayAsync();

        Task<PaginationResponseDto<InvoiceDto>>
        GetInvoicesPaginatedAsync(PaginationRequestDto paginationRequest);

        public Task<PaginationResponseDto<InvoiceDto>>
            SearchInvoicesAsync(string searchTerm, int page, int pageSize);



    }
}
