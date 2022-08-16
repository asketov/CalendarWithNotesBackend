using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDomain
{
    public interface IDateRepository
    {
        public Task<int> CheckDateIsExists(int dateNumber);
    }
}
