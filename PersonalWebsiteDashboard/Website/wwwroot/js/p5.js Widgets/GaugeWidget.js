// Global Variables
let progressX = 16.5;
let progressY = 40;

function setup() {
    createCanvas(100, 40);

    drawEmptyCurvedTube();

    frameRate(30);
}

function draw() {
    updateProgress(progressX, progressY);

    progressX = progressX + 0.1;
    progressY = progressY - 0.1;
}

function drawEmptyCurvedTube() {
    // Semi Circle
    noFill();
    stroke("black");
    ellipse(50, 40, 90, 70);

    // Hole in Semi Circle
    fill("white");
    stroke("black");
    ellipse(50, 40, 45, 35);
}

function updateProgress(progressX, progressY) {
    // Draw First Circle to start loading animation progress
    fill("black");
    noStroke();
    ellipse(progressX, progressY, 20, 20);
}