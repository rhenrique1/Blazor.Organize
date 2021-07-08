using Microsoft.AspNetCore.Components;
using Organize.Shared.Enums;
using Organize.WASM.ItemEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organize.WASM.Pages
{
    public partial class ItemsOverview : ComponentBase
    {
        //[Inject]
        //private ItemEditService ItemEditService { get; set; }
        [Parameter]
        public string TypeString { get; set; }
        [Parameter]
        public int? Id { get; set; }

        private bool ShowEdit { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            //ItemEditService.EditItemChanged += HandleEditItemChanged;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (Id != null && Enum.TryParse(typeof(ItemTypeEnum), TypeString, out _))
            {
                ShowEdit = true;
            }
            else
            {
                ShowEdit = false;
            }
            
        }

        private void HandleEditItemChanged(object sender, ItemEditEventArgs e)
        {
            ShowEdit = e.Item != null;
            StateHasChanged();
        }
    }
}
