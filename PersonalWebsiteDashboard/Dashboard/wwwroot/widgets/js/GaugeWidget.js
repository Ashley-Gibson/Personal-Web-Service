// Global Size Control
let size = document.getElementById("guageWidgetScript").getAttribute("data-widgetSize");

// Declare Progress Coords
let x;
let y;

// Percent that the value display should go to
let pct = 50;

// Progress Percentage
let pctProgress = 0.0;

// Percent Total
let percentTotal = 3.1 / 100 * pct;

// Update Amount
let speed = 0.02;

// Radius of Circle
let r = 33 * size;

function setup() {
    canvas = createCanvas(90 * size, 50 * size);


    background(0, 0, 0, 0);

    pixelDensity(2);
    drawEmptyCurvedTube();
}

function draw() {

    pctProgress += speed;

    if (pctProgress < percentTotal) {
        x = -r * cos(pctProgress) + 46 * size;
        y = -r * sin(pctProgress) + 46 * size;
    }

    fill("#5551FA");
    stroke("#5551FA");
    strokeWeight(5);
    smooth();
    circle(x, y, 20 * size);
}

function drawEmptyCurvedTube() {
    // Semi Circle
    fill("#4F4F4F");
    noStroke();
    circle(45 * size, 45 * size, 87 * size);

    // Hole in Semi Circle
    fill("#2E3442");
    circle(45 * size, 45 * size, 45 * size);
}

function getWidgetSize() {
    return size;
}