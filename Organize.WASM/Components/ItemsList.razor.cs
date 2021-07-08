using Microsoft.AspNetCore.Components;
using Organize.Shared.Contracts;
using Organize.Shared.Entities;
using Organize.WASM.ItemEdit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Organize.WASM.Components
{
    public partial class ItemsList : ComponentBase
    {
        [Inject]
        private ICurrentUserService _currentUserService { get; set; }
        [Inject]
        private ItemEditService ItemEditService { get; set; }
        protected ObservableCollection<BaseItem> UserItems { get; set; } = new ObservableCollection<BaseItem>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            UserItems = _currentUserService.CurrentUser.UserItems;
        }

        private void OnBackgroundClicked()
        {
            ItemEditService.EditItem = null;
        }
    }
}
