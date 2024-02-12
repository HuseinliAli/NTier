using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizer.Models.Common;
public class BaseEntity<TKey>
    where TKey:unmanaged
{
    public TKey Id { get; set; }
}
