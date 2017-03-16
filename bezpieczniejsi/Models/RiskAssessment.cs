using System.ComponentModel;

namespace bezpieczniejsi.Models
{
    public class RiskAssessment: BindingList<RiskAssessmentRowModel>
    {
        private string _companyName;

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        private string _jobName;

        public string JobName
        {
            get { return _jobName; }
            set { _jobName = value; }
        }
    }
}
