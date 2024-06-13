using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Models;

public class Size:BaseEntity
{
    public string Name { get; set; }

    public List<ProductSize> ProductSizes { get; set; }
}


