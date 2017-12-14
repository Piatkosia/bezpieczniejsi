using System;
using System.Collections.Generic;

namespace bezpieczniejsi
{
    public class ThreeGradeRiskRowAssessmentModel : RiskAssessmentRowModel
    {
        private ThreeStageRiskScoreVale _probability;
        public ThreeGradeRiskRowAssessmentModel()
        {
            RecalculateRisk();
        }

        public override int PropNum
        {
            get
            {
                return base.PropNum + 2;
            }
        }
        public ThreeStageRiskScoreVale ThreeProbability
        {
            get { return _probability; }
            set
            {
                if (_probability != value)
                {
                    _probability = value;
                    OnPropertyChanged("ThreeProbability");
                    RecalculateRisk();
                }

            }
        }

        public override List<string> GetPrintableParameters()
        {
            return base.GetPrintableParameters();
        }
        private void RecalculateRisk()
        {

            if (_probability == ThreeStageRiskScoreVale.Rare)
            {
                if (_consequencesSeverity == ThreeStageRiskScoreVale.Often) Risk = 2;
                else Risk = 1;
            }
            if (_probability == ThreeStageRiskScoreVale.Medium)
            {
                Risk = 1 + (int)_consequencesSeverity;
            }
            if (_probability == ThreeStageRiskScoreVale.Often)
            {
                if (_consequencesSeverity == ThreeStageRiskScoreVale.Rare) Risk = 2;
                else Risk = 3;
            }
            RecalculateAcceptability();
        }

        private void RecalculateAcceptability()
        {
            if (Risk >= 3) Acceptability = false;
            else Acceptability = true;
        }

        private ThreeStageRiskScoreVale _consequencesSeverity; //ciężkość następstw

        public ThreeStageRiskScoreVale ConsequencesSeverity
        {
            get { return _consequencesSeverity; }
            set
            {
                if (_consequencesSeverity != value)
                {
                    _consequencesSeverity = value;
                    OnPropertyChanged("ConsequencesSeverity");
                    RecalculateRisk();
                }
                _consequencesSeverity = value;
            }
        }

    }

    public enum ThreeStageRiskScoreVale
    {
        Rare = 0,
        Medium = 1,
        Often = 2,
    }
}
