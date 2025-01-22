using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.InvoiceDTOs;
using Vet_BLL.Services.Appointments;
using Vet_DAL.Helper;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Appointments;
using Vet_DAL.Repositories.Invoices;

namespace Vet_BLL.Services.Invoices
{
    public class InvoiceService: GenericService<Invoice, InvoiceDto>, IinvoiceService
    {
        public readonly IinvoiceRepository _invoiceRepository;
        public readonly IMapper _mapper;

        public InvoiceService(IinvoiceRepository invoiceRepository, IMapper mapper) :
            base(invoiceRepository, mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public IEnumerable<WeeklyRevenueDto> GetWeeklyRevenue()
        {
            var invoices = _invoiceRepository.GetInvoicesForCurrentWeek();

            var groupedByDate = invoices
                .GroupBy(invoice => invoice.PaymentDate.Date) // Group by specific date
                .Select(group => new WeeklyRevenueDto
                {
                    PaymentDate = group.Key, // Date of the group
                    TotalAmount = group.Sum(invoice => invoice.TotalAmount) // Sum of TotalAmount
                })
                .OrderBy(g => g.PaymentDate) // Ensure results are ordered by date
                .ToList();

            // Map the grouped data to a list of InvoiceDto using AutoMapper
            var result = _mapper.Map<List<WeeklyRevenueDto>>(groupedByDate);

            return result;
        }

        public decimal GetWeeklyTotalRevenue()
        {
            var invoices = _invoiceRepository.GetInvoicesForCurrentWeek();

            var totalRevenue = invoices.Sum(invoice => invoice.TotalAmount); // Sum up all TotalAmount values

            return totalRevenue;
        }

        public decimal GetMonthlyTotalRevenue()
        {
            var invoices = _invoiceRepository.GetInvoicesForCurrentMonth();

            var totalRevenue = invoices.Sum(invoice => invoice.TotalAmount); // Sum up all TotalAmount values for the month

            return totalRevenue;
        }

        public decimal GetYearlyTotalRevenue()
        {
            var invoices = _invoiceRepository.GetInvoicesForCurrentYear();

            var totalRevenue = invoices.Sum(invoice => invoice.TotalAmount); // Sum up all TotalAmount values for the year

            return totalRevenue;
        }

        public IEnumerable<WeeklyRevenueDto> GetMonthlyRevenue()
        {
            var invoices = _invoiceRepository.GetInvoicesForCurrentMonth();

            var groupedByDate = invoices
                .GroupBy(invoice => invoice.PaymentDate.Date) // Group by specific date
                .Select(group => new WeeklyRevenueDto
                {
                    PaymentDate = group.Key, // Date of the group
                    TotalAmount = group.Sum(invoice => invoice.TotalAmount) // Sum of TotalAmount
                })
                .OrderBy(g => g.PaymentDate) // Ensure results are ordered by date
                .ToList();

            // Map the grouped data to a list of InvoiceDto using AutoMapper
            var result = _mapper.Map<List<WeeklyRevenueDto>>(groupedByDate);

            return result;
        }

        public IEnumerable<WeeklyRevenueDto> GetYearlyRevenue()
        {
            var invoices = _invoiceRepository.GetInvoicesForCurrentYear();

            var groupedByDate = invoices
                .GroupBy(invoice => invoice.PaymentDate.Date) // Group by specific date
                .Select(group => new WeeklyRevenueDto
                {
                    PaymentDate = group.Key, // Date of the group
                    TotalAmount = group.Sum(invoice => invoice.TotalAmount) // Sum of TotalAmount
                })
                .OrderBy(g => g.PaymentDate) // Ensure results are ordered by date
                .ToList();

            // Map the grouped data to a list of InvoiceDto using AutoMapper
            var result = _mapper.Map<List<WeeklyRevenueDto>>(groupedByDate);

            return result;
        }

        public decimal GetYearlyTotalRevenue(int year)
        {
            var invoices = _invoiceRepository.GetInvoicesForYear(year);

            var totalRevenue = invoices.Sum(invoice => invoice.TotalAmount); // Sum all TotalAmount values for the year

            return totalRevenue;
        }

        public YearlyComparisonDto GetYearlyRevenueComparison()
        {
            var currentYear = DateTime.Now.Year;
            var previousYear = currentYear - 1;

            var currentYearRevenue = _invoiceRepository
                .GetInvoicesForYear(currentYear)
                .Sum(invoice => invoice.TotalAmount);

            var previousYearRevenue = _invoiceRepository
                .GetInvoicesForYear(previousYear)
                .Sum(invoice => invoice.TotalAmount);

            // Use AutoMapper to map the tuple to YearlyComparisonDto
            return new YearlyComparisonDto
            {
                CurrentYear = currentYear,
                CurrentYearRevenue = currentYearRevenue,
                PreviousYear = previousYear,
                PreviousYearRevenue = previousYearRevenue
            };
        }


        public async Task<List<RevenueByDayDto>> GetMonthlyRevenueByDayAsync()
        {
            // Retrieve all invoices for the current month
            var invoices = await _invoiceRepository.GetInvoicesForCurrentMonthAsync();

            // Get the first and last date of the current month
            var startOfMonth = DateTime.Now.StartOfMonth();
            var endOfMonth = DateTime.Now.EndOfMonth();

            // Generate all days for the current month
            var allDaysInMonth = Enumerable.Range(0, (endOfMonth - startOfMonth).Days + 1)
                                            .Select(i => startOfMonth.AddDays(i))
                                            .ToList();

            // Group invoices by day and calculate the sum of invoice amounts per day
            var revenueByDay = invoices
                .GroupBy(i => i.PaymentDate.Date)  // Group by date only (ignoring time)
                .Select(g => new
                {
                    Day = g.Key, // Use DateTime for proper sorting
                    Amount = g.Sum(i => i.TotalAmount) // Sum the invoice amounts for each day
                })
                .ToList();

            // Ensure that every day is included, even if no invoices were recorded for that day
            var fullRevenueByDay = allDaysInMonth.Select(day => new RevenueByDayDto
            {
                Day = day.ToString("dd MMM yyyy"), // Change the format to "01 Jan", "02 Jan", etc.
                Amount = revenueByDay.FirstOrDefault(r => r.Day == day)?.Amount ?? 0 // Default to 0 if no data for that day
            })
            .OrderBy(r => r.Day)  // Sort by the string representation (already correctly ordered)
            .ToList();

            return fullRevenueByDay;
        }



        public async Task<PaginationResponseDto<InvoiceDto>> GetInvoicesPaginatedAsync(PaginationRequestDto paginationRequest)
        {
            var (invoices, totalRecords) = await _invoiceRepository.GetInvoicesWithPaginationAsync(paginationRequest.PageNumber, paginationRequest.PageSize);

            var invoiceDtos = _mapper.Map<IEnumerable<InvoiceDto>>(invoices);

            return new PaginationResponseDto<InvoiceDto>
            {
                Data = invoiceDtos,
                TotalRecords = totalRecords,
                PageNumber = paginationRequest.PageNumber,
                PageSize = paginationRequest.PageSize
            };
        }


        public async Task<PaginationResponseDto<InvoiceDto>> SearchInvoicesAsync(string searchTerm, int page, int pageSize)
        {
            // Get invoices based on the search term, page, and page size
            var invoices = await _invoiceRepository.GetInvoicesBySearchAsync(searchTerm, page, pageSize);

            // Map the invoices to DTOs
            var invoiceDtos = _mapper.Map<List<InvoiceDto>>(invoices);

            // If no invoices are found, return an empty response with total records set to 0
            if (invoiceDtos == null || !invoiceDtos.Any())
            {
                return new PaginationResponseDto<InvoiceDto>
                {
                    Data = new List<InvoiceDto>(),
                    TotalRecords = 0
                };
            }

            // Get the total count of invoices matching the search term
            var totalCount = await _invoiceRepository.GetTotalCountAsync();

            // Return the populated response
            return new PaginationResponseDto<InvoiceDto>
            {
                Data = invoiceDtos,
                TotalRecords = totalCount
            };
        }
    }
}
