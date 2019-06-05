let cmsNames = ["Kentico", "Sitecore", "Sitefinity", "Umbraco"];
let colours = ["#F14B00", "#EE3524", "#5CE500", "#00BEC1"];
let angles = [70, 5, 25, 5];

let total = 0;

function setup() {
    createCanvas(160, 160);

    noStroke();
    smooth();
    pixelDensity(2);

    calcPercentages();

    pieChart(300);
}

function pieChart(diameter) {
    let lastAngle = 0;
    for (let i = 0; i < angles.length; i++) {
        fill(colours[i]);
        arc(
            width / 2,
            height / 2,
            diameter / 2,
            diameter / 2,
            lastAngle,
            lastAngle + radians(3.6 * ((angles[i] / total) * 100))
        );
        lastAngle += radians(3.6 * ((angles[i] / total) * 100));
    }
}

function calcPercentages() {
    for (let i = 0; i < angles.length; i++) {
        total += angles[i];
    }
}