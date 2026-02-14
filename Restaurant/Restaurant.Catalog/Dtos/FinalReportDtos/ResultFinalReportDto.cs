using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Restaurant.Catalog.Dtos.IncomeDtos;
using Restaurant.Catalog.Dtos.OutcomeDtos;
using Restaurant.Catalog.Entities;


namespace Restaurant.Catalog.Dtos.FinalReportDtos
{
    public class ResultFinalReportDto
    {
        public string Id { get; set; }
        public string ReportName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<CostItem> SelectedCosts { get; set; }


        public List<ResultIncomeDto> IncomeDetails { get; set; } // O dönemdeki tüm gelirler
        public List<ResultOutcomeDto> OutcomeDetails { get; set; } // O dönemdeki tüm giderler

        public decimal NetTotal { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpenses { get; set; }
        public string ShiftType { get; set; }
    }
}




