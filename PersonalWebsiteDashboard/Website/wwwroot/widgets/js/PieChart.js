let angleNames = ["", "", "", ""];
let angles = [30, 10, 45, 35];

let total = 0;

function setup() {
  createCanvas(720, 400);
  
  noStroke();
  
  background(100);
  
  calcPercentages();
  
  pieChart(300);
}

function pieChart(diameter) {
  let lastAngle = 0;
  for (let i = 0; i < angles.length; i++) {
    let gray = map(i, 0, angles.length, 0, 255);
    fill(gray);
    arc(
      width / 2,
      height / 2,
      diameter,
      diameter,
      lastAngle,
      lastAngle + radians(3.6 * ((angles[i] / total) * 100))
    );
    lastAngle += radians(3.6 * ((angles[i] / total) * 100));
  }
}

function calcPercentages()
{ 
  for(let i = 0; i < angles.length; i++)
  {
    total += angles[i];
  }
}