using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Organize.Business;
using Organize.Shared.Entities;

namespace Organize.WASM.Pages
{
    public class SignInBase : SignBase
    {
        protected string Day { get; set; } = DateTime.Now.DayOfWeek.ToString();

        [Inject]
        private NavigationManager NavigationManager { get; set; }
        protected async void OnSubmit()
        {
            if (!EditContext.Validate())
            {
                return;
            }

            var userManager = new UserManager();
            var foundUser = await userManager.TrySignInAndGetUserAsync(User);

            if (foundUser != null)
            {
                NavigationManager.NavigateTo("items");
            }
        }
    }
}