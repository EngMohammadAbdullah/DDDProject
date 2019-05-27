using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meubilair.Core.DomainBase
{
    public interface IEntity
    {
        object Key { get; }
    }
}
