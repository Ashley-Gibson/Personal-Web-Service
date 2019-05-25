﻿// Show/Hide Blog Panels
function togglePanel(panelName) {
    var panelElement = document.getElementsByClassName(panelName)[0];
    var glyphIcon = document.getElementsByClassName('glyphicon' + panelName)[0];

    if (panelElement.style.height > 0) {
        glyphIcon.classList.remove('glyphicon-remove');
        glyphIcon.classList.add('glyphicon-plus');
        panelElement.style.height = "30%";
    }
    else {
        glyphIcon.classList.remove('glyphicon-plus');
        if (!glyphIcon.classList.contains("glyphicon-remove"))
            glyphIcon.classList.add('glyphicon-remove');
        panelElement.style.height = "30px";
    }
}