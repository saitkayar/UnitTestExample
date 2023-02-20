using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplicant.Services
{
    public class IdentyValidator: IIdentyValidator
    {
        public string location => throw new NotImplementedException();

        public bool checkconnect()
        {
            throw new NotImplementedException();
        }

        public bool IsValid(string tc) { return true; }
    }

    public interface IIdentyValidator
    {
        public bool IsValid(string tc);

        bool checkconnect();

        string location { get; }
    }
}
