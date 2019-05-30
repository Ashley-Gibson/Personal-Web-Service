// Show/Hide Blog Panels
function togglePanel(panelName) {
    var panelElement = document.getElementsByClassName(panelName)[0];
    var glyphIcon = document.getElementsByClassName('glyphicon' + panelName)[0];
    
    if (glyphIcon.classList.contains("glyphicon-plus"))
    {
        glyphIcon.classList.remove('glyphicon-plus');
        glyphIcon.classList.add('glyphicon-remove');
        panelElement.style.height = "30%";       
        panelElement.style.overflowY = 'scroll';    
        panelElement.style.top = '70%';
    }
    else {
        glyphIcon.classList.remove('glyphicon-remove');
        glyphIcon.classList.add('glyphicon-plus');
        panelElement.style.height = "33px";
        panelElement.style.overflow = 'hidden';
        panelElement.style.top = '96.5%';
    }
}