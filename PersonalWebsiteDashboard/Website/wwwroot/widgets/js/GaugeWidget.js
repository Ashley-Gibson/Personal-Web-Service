// Declare Progress Coords
let x;
let y;

// Percent that the value display should go to
let pct = 50;

// Progress Percentage
let pctProgress = 0.0;

// Percent Total
let percentTotal = (3.1 / 100) * pct;

// Update Amount
let speed = 0.02;

// Radius of Circle
let r = 33;

function setup() {
    canvas = createCanvas(100, 40);

    pixelDensity(2);
    drawEmptyCurvedTube();
}

function draw() {

    pctProgress += speed;

    if (pctProgress < percentTotal) {
        x = -r * cos(pctProgress) + 50;
        y = -r * sin(pctProgress) + 50;
    }

    fill("#5551FA");
    stroke("#5551FA");
    strokeWeight(5);
    smooth();
    circle(x, y, 20, 20);
}

function drawEmptyCurvedTube() {
    // Grey Background
    //background(211);

    // Semi Circle
    fill("#4F4F4F");
    noStroke();
    circle(50, 50, 90, 70);

    // Hole in Semi Circle
    fill("#2E3442");
    circle(50, 50, 45, 35);
}