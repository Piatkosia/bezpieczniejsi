using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bezpieczniejsi
{
    public class TextfileLoader : LoadingProvider
    {
        public RiskBank loadRisks(object source)
        {
            if (source is string)
            {
                Encoding code;
                RiskBank bank = new RiskBank();
                bank.Title = Path.GetFileNameWithoutExtension((string)source);
                string line;
                System.IO.StreamReader file =
                   new System.IO.StreamReader((string)source);
                while ((line = file.ReadLine()) != null)
                {
                    bank.risks.Add(line);
                }
                return bank;
            }
            else return null;
        }

    }
}
