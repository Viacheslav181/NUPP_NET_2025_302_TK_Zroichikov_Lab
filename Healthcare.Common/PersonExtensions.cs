using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Common
{
    public static class PersonExtensions
    {
        //  Метод розширення
        public static bool IsRetired(this Person person)
        {
            return person.Age >= 60;
        }
    }
}
