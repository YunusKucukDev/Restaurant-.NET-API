
using Restaurant.DtoLayer.CatalogDtos.IncomeDto;
using Restaurant.DtoLayer.CatalogDtos.OutcomeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DtoLayer.CatalogDtos.FinalReportDtos
{
    public class CreateFinalReportDto
    {
        public string ReportName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<CostItemDtos> SelectedCosts { get; set; }
        public decimal NetTotal { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalExpenses { get; set; }

        public List<ResultIncomeDto> IncomeDetails { get; set; } // O dönemdeki tüm gelirler
        public List<ResultOutcomeDto> OutcomeDetails { get; set; } // O dönemdeki tüm giderler



        public string ShiftType { get; set; } // "Gunduz" veya "Gece"
    }
}
