using Organize.Shared.Contracts;
using Organize.Shared.Entities;
using Organize.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organize.TestFake
{
    public class TestData
    {
        public static User TestUser { get; private set; }

        public static void CreateTestUser(IUserItemManager userItemManager = null)
        {
            var user = new User();
            user.Id = 123;
            user.UserName = "Ben";
            user.FirstName = "Benjamin";
            user.LastName = "Proft";
            user.Password = "test";
            user.GenderType = GenderTypeEnum.Male;
            user.UserItems = new ObservableCollection<BaseItem>();

            TextItem textItem = null;
            if(userItemManager != null)
            {
                textItem = (TextItem)userItemManager.CreateNewUserItemAndAddItToUserAsync(user, ItemTypeEnum.Text).Result;
            }
            else
            {
                textItem = new TextItem();
                user.UserItems.Add(textItem);
            }

            textItem.ParentId = user.Id;
            textItem.Id = 1;
            textItem.Title = "Buy Apples";
            textItem.SubTitle = "Red | 5";
            textItem.Detail = "From New Zealand preferred";
            textItem.ItemTypeEnum = ItemTypeEnum.Text;
            textItem.Position = 1;

            UrlItem urlItem = null;
            if (userItemManager != null)
            {
                urlItem = (UrlItem)userItemManager.CreateNewUserItemAndAddItToUserAsync(user, ItemTypeEnum.Url).Result;
            }
            else
            {
                urlItem = new UrlItem();
                user.UserItems.Add(urlItem);
            }

            urlItem.ParentId = user.Id;
            user.UserItems.Add(urlItem);
            urlItem.Id = 2;
            urlItem.Title = "Buy Sunflowers";
            urlItem.Url = "https://drive.google.com/file/d/1NXiNFLEUGUiNtkyzdHDtf-HDocFh3OJ0/view?usp=sharing";
            urlItem.ItemTypeEnum = ItemTypeEnum.Url;
            urlItem.Position = 2;


            ParentItem parentItem = null;
            if (userItemManager != null)
            {
                parentItem = (ParentItem)userItemManager.CreateNewUserItemAndAddItToUserAsync(user, ItemTypeEnum.Parent).Result;
            }
            else
            {
                parentItem = new ParentItem();
                user.UserItems.Add(parentItem);
            }

            parentItem.ParentId = user.Id;
            user.UserItems.Add(parentItem);
            parentItem.Id = 3;
            parentItem.Title = "Make Birthday Present";
            parentItem.ItemTypeEnum = ItemTypeEnum.Parent;
            parentItem.Position = 3;
            parentItem.ChildItems = new ObservableCollection<ChildItem>();

            ChildItem childItem = null;
            if (userItemManager != null)
            {
                childItem = (ChildItem)userItemManager.CreateNewChildItemAndAddItToParentItemAsync(parentItem).Result;

                user.UserItems.Clear();
            }
            else
            {
                childItem = new ChildItem();
                user.UserItems.Add(childItem);
            }
            
            childItem.ParentId = parentItem.Id;
            parentItem.ChildItems.Add(childItem);
            childItem.Id = 4;
            childItem.Position = 1;
            childItem.Title = "Cut";

            TestUser = user;
        }
    }
}
