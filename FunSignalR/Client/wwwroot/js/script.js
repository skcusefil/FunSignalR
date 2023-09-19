
function getSVGBBox() {
    var svg = document.getElementById("svg");
    var bbox = svg.getBoundingClientRect();
    return bbox
}

function windowResize(dotNetObject) {

    window.addEventListener('resize', e => {

        var bbox = getSVGBBox()
        dotNetObject.invokeMethodAsync('WindowResize', bbox);
    })

    //window.addEventListener("unload", (event) => {
    //    localStorage.removeItem("elment_circle");
    //});
}
