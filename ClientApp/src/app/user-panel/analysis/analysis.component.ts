import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-analysis',
  templateUrl: './analysis.component.html',
  styleUrls: ['./analysis.component.scss']
})
export class AnalysisComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    var can = <HTMLCanvasElement> document.getElementById('myChart');
    var ctx = can.getContext('2d');
    var myChart = new Chart(ctx, {
      type: 'bar',
      data: {
        labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
        datasets: [{
          label: '# of Votes',
          data: [12, 19, 3, 5, 2, 3],
          backgroundColor: [
            'rgba(255, 99, 132, 0.2)',
            'rgba(54, 162, 235, 0.2)',
            'rgba(255, 206, 86, 0.2)',
            'rgba(75, 192, 192, 0.2)',
            'rgba(153, 102, 255, 0.2)',
            'rgba(255, 159, 64, 0.2)'
          ],
          borderColor: [
            'rgba(255,99,132,1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 159, 64, 1)'
          ],
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
  }

  // trigger() {
  //   document.getElementById('aa').innerHTML = 'dziala';
  //   this.chart = new Chart(document.getElementById('myChart'), {
  //     type: 'line',
  //     data: {
  //       labels: ['asdas', 'fdhd'],
  //       datasets: [
  //         {
  //           data: [2, 3],
  //           borderColor: '#3cba9f',
  //           fill: false
  //         },
  //         {
  //           data: [2, 45],
  //           borderColor: '#ffcc00',
  //           fill: false
  //         },
  //       ]
  //     },
  //     options: {
  //       legend: {
  //         display: false
  //       },
  //       scales: {
  //         xAxes: [{
  //           display: true
  //         }],
  //         yAxes: [{
  //           display: true
  //         }]
  //       }
  //     }
  //   });
  // }

}
