using System;

namespace bezpieczniejsi
{
    public class ThreeGradeRiskRowAssessmentModel : RiskAssessmentRowModel
    {
        private ThreeStageRiskScoreVale _probability;

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
            set { _probability = value; }
        }

        private ThreeStageRiskScoreVale _consequencesSeverity; //ciężkość następstw

        public ThreeStageRiskScoreVale ConsequencesSeverity
        {
            get { return _consequencesSeverity; }
            set { _consequencesSeverity = value; }
        }
    }

    public enum ThreeStageRiskScoreVale
    {
        Rare = 0,
        Medium = 1,
        Often = 2,
    }
}
