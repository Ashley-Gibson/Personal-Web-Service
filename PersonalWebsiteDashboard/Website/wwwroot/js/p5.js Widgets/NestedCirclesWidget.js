/* GLOBAL */

// Update Amount
speed = 0.02;
// Circle Fill Colour
let fillColour = "";

/* INNER */

// Declare Progress Coords
let innerX;
let innerY;

// Percent that the value display should go to
let innerPct = 30;

// Progress Percentage
let innerPctProgress = 0.0;

// Percent Total
let innerPercentTotal = (3.1 / 100) * innerPct;

// Radius of Circle
let innerRadius = 25;

/* MIDDLE */

// Declare Progress Coords
let middleX;
let middleY;

// Percent that the value display should go to
let middlePct = 50;

// Progress Percentage
let middlePctProgress = 0.0;

// Percent Total
let middlePercentTotal = (3.1 / 100) * middlePct;

// Radius of Circle
let middleRadius = 40;

/* OUTER */

// Declare Progress Coords
let outerX;
let outerY;

// Percent that the value display should go to
let outerPct = 80;

// Progress Percentage
let outerPctProgress = 0.0;

// Percent Total
let outerPercentTotal = (3.1 / 100) * outerPct;

// Radius of Circle
let outerRadius = 55;

function setup() {
    let canvas = createCanvas(140, 140);

    // Move the canvas so it’s inside the widget container
    canvas.parent('widgetTwo');
    canvas.class('nestedCirclesWidget');

    pixelDensity(2);
    smooth();

    noFill();

    drawInitialCircles();
}

function draw() {
    // Draw Circles  
    strokeWeight(5);

    innerCircle();
    middleCircle();
    outerCircle();
}

function innerCircle() {
    fillColour = "blue";

    innerPctProgress += speed;

    if (innerPctProgress < innerPercentTotal) {
        innerX = -innerRadius * cos(innerPctProgress) + 70;
        innerY = -innerRadius * sin(innerPctProgress) + 70;
    }

    fill(fillColour);
    stroke(fillColour);
    circle(innerX, innerY, 5, 5);
}

function middleCircle() {
    fillColour = "green";

    middlePctProgress += speed;

    if (middlePctProgress < middlePercentTotal) {
        middleX = -middleRadius * cos(middlePctProgress) + 70;
        middleY = -middleRadius * sin(middlePctProgress) + 70;
    }

    fill(fillColour);
    stroke(fillColour);
    circle(middleX, middleY, 5, 5);
}

function outerCircle() {
    fillColour = "pink";

    outerPctProgress += speed;

    if (outerPctProgress < outerPercentTotal) {
        outerX = -outerRadius * cos(outerPctProgress) + 70;
        outerY = -outerRadius * sin(outerPctProgress) + 70;
    }

    fill(fillColour);
    stroke(fillColour);
    circle(outerX, outerY, 5, 5);
}

function drawInitialCircles() {
    noFill();
    stroke("#4F4F4F");
    strokeWeight(10);
    smooth();

    //Inner Circle
    circle(70, 70, 50, 50);
    // Middle Circle
    circle(70, 70, 80, 80);
    // Outer Circle
    circle(70, 70, 110, 110);
}