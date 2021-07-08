window.addEventListener('resize', () => {
    console.log('Static Resize from js');
    DotNet.invokeMethodAsync("Organize.WASM", "OnResize");
});

window.blazorDimension = {
    getWidth: () => window.innerWidth
}

window.blazorResize = {
    registerReferenceForResizeEvent: (dotnetReference) => {
        console.log(blazorResize.assignments);
        window.addEventListener("resize", () => {
            console.log("HandleResize from js");
            dotnetReference.invokeMethodAsync("HandleResize", window.innerWidth, window.innerHeight);
        });
    }
}