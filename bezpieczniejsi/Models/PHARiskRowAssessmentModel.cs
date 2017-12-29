using bezpieczniejsi.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezpieczniejsi
{
    public class PHARiskRowAssessmentModel : RiskAssessmentRowModel
    {
        private int _size;
        private int _probability;
        public PHARiskRowAssessmentModel()
        {
            PrepareData();
        }
        private void PrepareData()
        {
            RecalculateRisk();
        }
        /// <summary>
        /// Wielkość szkody
        /// </summary>
        public int Size
        {
            get { return _size; }
            set
            {
                if (_size != value)
                {
                    _size = value;
                    OnPropertyChanged("Size");
                    RecalculateRisk();
                }
            }
        }

        /// <summary>
        /// Prawdopodobieństwo
        /// </summary>

        public int Probability
        {
            get { return _probability; }
            set
            {
                if (_probability != value)
                {
                    _probability = value;
                    OnPropertyChanged("Probability");
                    RecalculateRisk();
                }
            }
        }
        public override int PropNum
        {
            get
            {
                return base.PropNum + 2;
            }
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
            " Id "," Zagrożenie "," Źródło zagrożenia "," Możliwe skutki zagrożenia "," Środki ochrony "," Wielkość szkody "," Prawdopodonieństwo powstania szkody " ," Ryzyko ",
            " Dopuszczalność " ," Uwagi ", //do zlokalizowania
        };
        BoolToAcceptabilityTextConverter conv = new BoolToAcceptabilityTextConverter();
        public override List<string> GetPrintableParameters()
        {
            List<string> parameters = new List<string>();
            parameters.Add(Id.ToString());
            parameters.Add(Threat);
            parameters.Add(RiskSource);
            parameters.Add(RiskEffects);
            parameters.Add(PersonalProtection);
            parameters.Add(SizeDescription[Size]);
            parameters.Add(ProbabilityDescription[Probability]);
            parameters.Add(Risk.ToString());
            parameters.Add(conv.Convert(Acceptability, null, null, null) as String);
            parameters.Add(Comments);

            return parameters;
        }
        protected override void RecalculateRisk()
        {
            Risk = Size * Probability;
            RecalculateAcceptability();
        }

        protected override void RecalculateAcceptability()
        {
            if (Risk >= 10)
            {
                Comments = "Zmodyfikuj ocenę! Nie można dopuścić pracownika do pracy!";
                Acceptability = false;
            }
            else
            {
                Acceptability = true;
                if (Risk >= 4) Comments = "dopuszczalna akceptowalność ryzyka po przeprowadzeniu oceny";
            }

        }

        public static readonly Dictionary<int, string> SizeDescription = new Dictionary<int, string>()
        {
            { 1, "niewielka, znikome urazy, szkody nieznaczne" },
            { 2, "lekkie obrażenia, szkody wymierne" },
            { 3, "ciężkie obrażenia, szkody znaczne" },
            { 4, "wypadek śmiertelny jednej osoby, szkody ciężkie" },
            { 5, "wypadek śmiertelny zbiorowy, bardzo ciężkie szkody na terenie firmy" },
            { 6, "wypadek śmiertelny zbiorowy, bardzo ciężkie szkody poza terenem firmy" }
        };

        public static readonly Dictionary<int, string> ProbabilityDescription = new Dictionary<int, string>()
        {
            { 1, "nieprawdopodobne (ale możliwe do wyobrażenia)" },
            { 2, "mało prawdopodobne, szkoda powstaje raz na 10 lat" },
            { 3, "szkoda może się wydarzyć raz w roku" },
            { 4, "dosyć częste, szkoda może się wydarzyć raz w miesiącue" },
            { 5, "częste, szkoda może się wydarzyć raz na tydzień" },
            { 6, "bardzo prawdopodobne" }
        };



    }
}
