using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Model.Core
{
    public class BaseModel
    {
        public Guid GenerateGuid()
        {
            Guid guid = Guid.NewGuid();
            return guid;
        }
    }
}
