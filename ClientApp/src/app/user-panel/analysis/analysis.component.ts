import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { DietService } from 'src/app/shared/services/diet.service';
import { TrainingService } from 'src/app/shared/services/training.service';

@Component({
  selector: 'app-analysis',
  templateUrl: './analysis.component.html',
  styleUrls: ['./analysis.component.scss']
})
export class AnalysisComponent implements OnInit {

  myChart: Chart;
  chart: string;
  backgroundColors = new Array<string>();
  borderColors = new Array<string>();

  dietLabels: string[];
  trainingLabels: string[];
  calories: number[];
  meals: number[];
  days: number[];


  constructor(private dietService: DietService, private trainingService: TrainingService) { this.chart = '1'; }

  ngOnInit() {
    this.dietService.getAll().subscribe(result => {
      this.dietLabels = result.map(r => r.created);
      this.calories = result.map(r => r.calories);
      this.meals = result.map(r => r.meals);
      for (let index = 0; index < result.length; index++) {
        const color = this.random_rgba();
        this.backgroundColors.push(color.background);
        this.borderColors.push(color.border);
      }
      this.draw();
    });
  }

  random_rgba() {
    const o = Math.round, r = Math.random, s = 255;
    const rgbaR = r();
    const rgbaG = r();
    const rgbaB = r();
    return {
      background: 'rgba(' + o(rgbaR * s) + ',' + o(rgbaG * s) + ',' + o(rgbaB * s) + ',' + 0.2 + ')',
      border: 'rgba(' + o(rgbaR * s) + ',' + o(rgbaG * s) + ',' + o(rgbaB * s) + ',' + 1 + ')'
    };
  }

  draw() {
    if (this.myChart != null) {
      this.myChart.destroy();
    }

    const can = <HTMLCanvasElement>document.getElementById('myChart');
    const ctx = can.getContext('2d');

    switch (this.chart) {
      case '1':
        this.myChart = new Chart(ctx, {
          type: 'bar',
          data: {
            labels: this.dietLabels,
            datasets: [{
              label: 'Ilość kalorii w diecie',
              data: this.calories,
              backgroundColor: this.backgroundColors,
              borderColor: this.borderColors,
              borderWidth: 1
            }]
          },
          options: {
            responsive: false,
            scales: {
              yAxes: [{
                ticks: {
                  beginAtZero: true
                }
              }]
            }
          }
        });
        break;
      case '2':
        this.myChart = new Chart(ctx, {
          type: 'bar',
          data: {
            labels: this.dietLabels,
            datasets: [{
              label: 'Ilość posiłków w diecie',
              data: this.meals,
              backgroundColor: this.backgroundColors,
              borderColor: this.borderColors,
              borderWidth: 1
            }]
          },
          options: {
            responsive: false,
            scales: {
              yAxes: [{
                ticks: {
                  beginAtZero: true
                }
              }]
            }
          }
        });
        break;
      case '3':
        this.trainingService.getAll().subscribe(result => {
          this.trainingLabels = result.map(r => r.created);
          this.days = result.map(r => r.days);

          this.myChart = new Chart(ctx, {
            type: 'bar',
            data: {
              labels: this.trainingLabels,
              datasets: [{
                label: 'Ilość dni treningowych w tygodniu',
                data: this.days,
                backgroundColor: this.backgroundColors,
                borderColor: this.borderColors,
                borderWidth: 1
              }]
            },
            options: {
              responsive: false,
              scales: {
                yAxes: [{
                  ticks: {
                    beginAtZero: true
                  }
                }]
              }
            }
          });
        });
        break;
      default:
        console.log('Nie ma takiego wykresku');
        break;
    }
  }
}
