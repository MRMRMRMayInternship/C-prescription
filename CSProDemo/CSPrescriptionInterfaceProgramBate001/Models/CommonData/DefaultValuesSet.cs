using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPrescriptionInterfaceProgramBate001.Models.CommonData
{
    public static class DefaultValuesSet
    {
        public const string DrugsFilePathKey = "drugsPath";
        public const string prescriptionPathKey = "prescriptionPath";
        public static readonly string[] UsageComboBoxValues = {"", "내복", "외용", "정맥 주사" };
        public static readonly string[] DosageUnitComboBoxValues = {"", "ml", "l", "개" };
        //readonly string[] KEYS = { "수정/증가", "약품 ID", "약품 명칭", "충 투약일수", "1일 투약횟수", "1회 투약 량", "용법", "Col8", "Col9" };
        
        //private const string drugNameCellTitle = "DrugNameColumn";
        //public static string DrugNameCellTitle { get { return drugNameCellTitle; } }

        //private const string timesPerDayCellTitle = "TimesPerDayColumn";
        //public static string TimesPerDayCellTitle { get { return timesPerDayCellTitle; } }

        //private const string timeDurationCellTitle = "TimeDurationColumn";
        //public static string TimeDurationCellTitle { get { return timeDurationCellTitle; } }

        //private const string morningCheckBoxCellTitle = "MorningCheckBoxColumn";
        //public static string MorningCheckBoxCellTitle { get { return morningCheckBoxCellTitle; } }
    }
}
