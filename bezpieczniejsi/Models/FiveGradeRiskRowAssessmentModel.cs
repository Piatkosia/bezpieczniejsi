using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezpieczniejsi
{
    public class FiveGradeRiskRowAssessmentModel : ThreeGradeRiskRowAssessmentModel
    {
        public FiveGradeRiskRowAssessmentModel()
        {
            PrepareData();
        }
        private void PrepareData()
        {
            RecalculateRisk();
        }
        protected override string GetRiskText(int risk)
        {
            if (risk == 1) return " Bardzo Małe ";
            else if (risk == 2) return " Małe ";
            else if (risk == 3) return " Średnie ";
            else if (risk == 4) return " Duże ";
            else if (risk == 5) return " Bardzo duże ";
            else return " Błąd ";
        }
        protected override void RecalculateAcceptability()
        {
            if (Risk >= 4) Acceptability = false;
            else Acceptability = true;
        }
        protected override void RecalculateRisk()
        {
            if (ThreeProbability == ThreeStageRiskScoreVale.Rare)
            {
                if (ConsequencesSeverity == ThreeStageRiskScoreVale.Rare) Risk = 1;
                if (ConsequencesSeverity == ThreeStageRiskScoreVale.Medium) Risk = 2;
                if (ConsequencesSeverity == ThreeStageRiskScoreVale.Often) Risk = 3;

            }
            if (ThreeProbability == ThreeStageRiskScoreVale.Medium)
            {
                if (ConsequencesSeverity == ThreeStageRiskScoreVale.Rare) Risk = 2;
                if (ConsequencesSeverity == ThreeStageRiskScoreVale.Medium) Risk = 3;
                if (ConsequencesSeverity == ThreeStageRiskScoreVale.Often) Risk = 4;

            }
            if (ThreeProbability == ThreeStageRiskScoreVale.Often)
            {
                if (ConsequencesSeverity == ThreeStageRiskScoreVale.Rare) Risk = 3;
                if (ConsequencesSeverity == ThreeStageRiskScoreVale.Medium) Risk = 4;
                if (ConsequencesSeverity == ThreeStageRiskScoreVale.Often) Risk = 5;
            }
            RecalculateAcceptability();
        }
    }
}
