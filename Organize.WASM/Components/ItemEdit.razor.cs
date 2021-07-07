using Organize.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organize.WASM.Components
{
    public partial class ItemEdit
    {
        private BaseItem Item { get; set; } = new BaseItem();
        private int TotalNumber { get; set; }
    }
}
