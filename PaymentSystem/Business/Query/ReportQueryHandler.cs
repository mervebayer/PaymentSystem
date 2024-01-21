using AutoMapper;
using Dapper;
using MediatR;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using PaymentSystem.Base.Response;
using PaymentSystem.Business.Cqrs;
using PaymentSystem.Data;
using PaymentSystem.Schema;



namespace PaymentSystem.Business.Query;

public class ReportQueryHandler : IRequestHandler<GetRequestStatusCountsQuery, ApiResponse<IEnumerable<RequestStatusCountsResponse>>>,
                                  IRequestHandler<GetExpensesByTimeQuery, ApiResponse<IEnumerable<ExpenseSummary>>>

{
    private readonly PaymentSystemDbContext dbContext;
    private readonly IMapper mapper;

    public ReportQueryHandler(PaymentSystemDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<IEnumerable<RequestStatusCountsResponse>>> Handle(GetRequestStatusCountsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = "EXEC [dbo].[GetRequestStatusCounts]";
            using (var multipleResults = await dbContext.Database.GetDbConnection().QueryMultipleAsync(query, cancellationToken))
            {
                var dailyCounts = multipleResults.Read<RequestStatusCountsResponse>().ToList();
                var weeklyCounts = multipleResults.Read<RequestStatusCountsResponse>().ToList();
                var monthlyCounts = multipleResults.Read<RequestStatusCountsResponse>().ToList();

                var result = new List<RequestStatusCountsResponse>
            {
                dailyCounts.FirstOrDefault(),
                weeklyCounts.FirstOrDefault(),
                monthlyCounts.FirstOrDefault()
            };

                return new ApiResponse<IEnumerable<RequestStatusCountsResponse>>(result);
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<RequestStatusCountsResponse>>($"Error: {ex.Message}");
        }
    }

    public async Task<ApiResponse<IEnumerable<ExpenseSummary>>> Handle(GetExpensesByTimeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = "EXEC [dbo].[GetExpensesByTime]";
            using (var multipleResults = await dbContext.Database.GetDbConnection().QueryMultipleAsync(query, cancellationToken))
            {
                var dailyCounts = multipleResults.Read<ExpenseSummary>().ToList();
                var weeklyCounts = multipleResults.Read<ExpenseSummary>().ToList();
                var monthlyCounts = multipleResults.Read<ExpenseSummary>().ToList();

                var result = new List<ExpenseSummary>
            {
                dailyCounts.FirstOrDefault(),
                weeklyCounts.FirstOrDefault(),
                monthlyCounts.FirstOrDefault()
            };

                return new ApiResponse<IEnumerable<ExpenseSummary>>(result);
            }
        }
        catch (Exception ex)
        {
            return new ApiResponse<IEnumerable<ExpenseSummary>>($"Error: {ex.Message}");
        }
    }
}