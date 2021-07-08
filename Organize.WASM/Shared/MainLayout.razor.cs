using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Organize.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Organize.WASM.Shared
{
    public partial class MainLayout : LayoutComponentBase, IDisposable
    {
        private DotNetObjectReference<MainLayout> _dotNetReference;

        [Inject]
        private ICurrentUserService _currentUserService { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        public bool UseShortNavText { get; set; }
        protected void SignOut()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var width = await JSRuntime.InvokeAsync<int>("blazorDimension.getWidth");
            CheckUseShortNavText(width);
            Console.WriteLine(width);

            _dotNetReference = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("blazorResize.registerReferenceForResizeEvent", _dotNetReference);
        }

        [JSInvokable]
        public static void OnResize()
        {
            Console.WriteLine("Onresize in C# .NET");
        }

        [JSInvokable]
        public void HandleResize(int width, int height)
        {
            CheckUseShortNavText(width);
        }

        private void CheckUseShortNavText(int width)
        {
            var oldValue = UseShortNavText;
            UseShortNavText = width < 700;
            if (oldValue != UseShortNavText)
            {
                StateHasChanged();
            }
        }

        public void Dispose()
        {
            _dotNetReference?.Dispose();
        }
    }
}
