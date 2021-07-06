using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Organize.Business;
using Organize.Shared.Contracts;
using Organize.Shared.Entities;

namespace Organize.WASM.Pages
{
    public class SignInBase : SignBase
    {
        protected string Day { get; set; } = DateTime.Now.DayOfWeek.ToString();

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IUserManager UserManager { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            User = new User
            {
                FirstName = "X",
                LastName = "Y",
                PhoneNumber = "123"
            };

            EditContext = new EditContext(User);
        }
        protected async void OnSubmit()
        {
            if (!EditContext.Validate())
            {
                return;
            }

            var foundUser = await UserManager.TrySignInAndGetUserAsync(User);

            if (foundUser != null)
            {
                NavigationManager.NavigateTo("items");
            }
        }
    }
}