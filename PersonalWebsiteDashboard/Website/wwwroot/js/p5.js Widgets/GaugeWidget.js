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
let speed = 0.04;

// Radius of Circle
let r = 33;

function setup() {
    createCanvas(100, 40);
    pixelDensity(2);
    drawEmptyCurvedTube();
}

function draw() {

    pctProgress += speed;

    if (pctProgress < percentTotal) {
        x = -r * cos(pctProgress) + 50;
        y = -r * sin(pctProgress) + 50;
    }

    fill("blue");
    stroke("blue");
    strokeWeight(5);
    smooth();
    circle(x, y, 20, 20);
}

function drawEmptyCurvedTube() {
    // Grey Background
    //background(211);

    // Semi Circle
    noFill();
    stroke("blue");
    circle(50, 50, 90, 70);

    // Hole in Semi Circle
    circle(50, 50, 45, 35);
}