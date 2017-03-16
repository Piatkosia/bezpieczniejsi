namespace bezpieczniejsi.Models
{
    public class ThreeGradeRiskRowAssessmentModel : RiskAssessmentRowModel
    {
        private Probability _threeProbability;

        public Probability ThreeProbability  
        {
            get { return _threeProbability; }
            set { _threeProbability = value; }
        }

    }

    public enum Probability
    {
        Rare = 0,
        Medium = 1,
        Often = 2,
    }
}
