using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organize.Shared.Entities
{
    public class ParentItem : BaseItem
    {
        public ObservableCollection<ChildItem> ChildItems 
        { 
            get => _childItems; 
            set
            {
                if (value == _childItems)
                {
                    return;
                }

                _childItems = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<ChildItem> _childItems;
    }
}
