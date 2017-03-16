using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace bezpieczniejsi.Models
{
    public class RiskAssessmentRowModel : INotifyPropertyChanged
    {
        public RiskAssessment Parent { get; set; }

        public int Id
        {
            get
            {
                if (Parent == null) return 0;
                return Parent.IndexOf(this);
            }
          
        }
        private string _threat; //zagrożenie

        public string Threat
        {
            get { return _threat; }
            set { _threat = value; }
        }


        private int _risk;

        public int Risk //ryzyko
        {
            get { return _risk; }
            set
            {
                if (_risk != value)
                {
                    _risk = value;
                    OnPropertyChanged("Risk");
                }
            }
        }

        private string _riskSource; //źródło

        public string RiskSource
        {
            get { return _riskSource; }
            set
            {
                if (_riskSource != value)
                {
                    _riskSource = value;
                    OnPropertyChanged("RiskSource");
                }
               
            }
        }

        private string _riskEffects; //skutki

        public string RiskEffects
        {
            get { return _riskEffects; }
            set
            {
                if (_riskEffects != value)
                {
                    _riskEffects = value;
                    OnPropertyChanged("RiskEffects");
                }
                
            }
        }

        private string _personalProtection; //środki ochrony

        public string PersonalProtection
        {
            get { return _personalProtection; }
            set
            {
                if (_personalProtection != value)
                {
                    _personalProtection = value;
                    OnPropertyChanged("PersonalProtection");
                }
            }
        }
        private bool _acceptability; //dopuszczaoność

        public bool Acceptability
        {
            get { return _acceptability; }
            set
            {
                if(_acceptability != value)
                {
                    _acceptability = value;
                    OnPropertyChanged("Acceptability");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
