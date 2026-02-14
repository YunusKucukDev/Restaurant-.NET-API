

using Restaurant.DtoLayer.CatalogDtos.FixedExpenseDto;
using Restaurant.DtoLayer.CatalogDtos.IncomeDto;
using Restaurant.DtoLayer.CatalogDtos.OutcomeDto;

namespace Restaurant.WebUI.Models
{
    public class PeriodicalAnalysisViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PeriodTotalIncome { get; set; } // O tarihler arası toplam gelir
        public decimal PeriodTotalOutcome { get; set; } // O tarihler arası toplam kasa gideri

        public List<ResultIncomeDto> IncomeDetails { get; set; } // O dönemdeki tüm gelirler
        public List<ResultOutcomeDto> OutcomeDetails { get; set; } // O dönemdeki tüm giderler

        public List<ResultFixedExpense> AllFixedExpenses { get; set; } // Sürükle-bırak için sağ kutu
    }
}
