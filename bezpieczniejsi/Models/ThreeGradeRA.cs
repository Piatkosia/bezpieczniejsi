using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezpieczniejsi
{
    public class ThreeGradeRa : RiskAssessment<ThreeGradeRiskRowAssessmentModel>, IRiskAssessment
    {
     
        public override int GetChildID(object obj)
        {
            if (obj == null) throw new NullReferenceException("obj is null:(");
            if (obj is ThreeGradeRiskRowAssessmentModel)
            {
                return IndexOf(obj as ThreeGradeRiskRowAssessmentModel);
            }
            else throw new ArgumentException("Argument must be ThreeGradeRiskRowAssessmentModel");
        }
    }
}
