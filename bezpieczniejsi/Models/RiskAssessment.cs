﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezpieczniejsi
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
