using bezpieczniejsi.Converters;
using System;
using System.Collections.Generic;

namespace bezpieczniejsi
{
    public class ThreeGradeRiskRowAssessmentModel : RiskAssessmentRowModel
    {
        private ThreeStageRiskScoreVale _probability;
        public ThreeGradeRiskRowAssessmentModel()
        {
            PrepareData();
        }
        public override List<string> Headers
        {
            get
            {
                return _h;
            }
        }
        private List<string> _h = new List<string>()
        {
            " Id "," Zagrożenie "," Źródło zagrożenia "," Możliwe skutki zagrożenia "," Środki ochrony "," Prawdopodonieństwo "," Ciężkość następstw" ," Ryzyko ",
            " Dopuszczalność " ," Uwagi ", //do zlokalizowania
        };
        private void PrepareData()
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

        RiskThreeToReturnString conv1 = new RiskThreeToReturnString();
        BoolToAcceptabilityTextConverter conv2 = new BoolToAcceptabilityTextConverter();
        public override List<string> GetPrintableParameters()
        {
            List<string> parameters = new List<string>();
            parameters.Add(Id.ToString());
            parameters.Add(Threat);
            parameters.Add(RiskSource);
            parameters.Add(RiskEffects);
            parameters.Add(PersonalProtection);
            parameters.Add(conv1.Convert(ThreeProbability, null, null, null) as String);
            parameters.Add(conv1.Convert(ConsequencesSeverity, null, null, null) as String);
            parameters.Add(GetRiskText(Risk));
            parameters.Add(conv2.Convert(Acceptability, null, null, null) as String);
            parameters.Add(Comments);

            return parameters;
        }

        protected virtual string GetRiskText(int risk)
        {
            if (risk == 1) return " Małe ";
            else if (risk == 2) return " Średnie ";
            else if (risk == 3) return " Duże ";
            else return " Błąd ";
        }

        protected override void RecalculateRisk()
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

        protected override void RecalculateAcceptability()
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
