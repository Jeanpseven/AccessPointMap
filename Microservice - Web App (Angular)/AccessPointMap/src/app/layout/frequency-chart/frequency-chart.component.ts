import { Component, OnInit } from '@angular/core';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Label } from 'ng2-charts';
import { ChartData } from 'src/app/models/chart-data.model';
import { AccesspointDataService } from 'src/app/services/accesspoint-data.service';
import { CacheManagerService } from 'src/app/services/cache-manager.service';
import { ChartPreparationService } from 'src/app/services/chart-preparation.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'frequency-chart',
  templateUrl: './frequency-chart.component.html',
  styleUrls: ['./frequency-chart.component.css']
})
export class FrequencyChartComponent implements OnInit {
  public chartLabels: Label[];
  public chartDisplayType: ChartType;
  public chartLegend: boolean;
  public chartOptions: ChartOptions;
  public chartData: ChartDataSets[];
  public chartReady: boolean;

  constructor(private cacheService: CacheManagerService, private chartPreparationService: ChartPreparationService, private accesspointDataService: AccesspointDataService) { }

  ngOnInit(): void {
    this.chartReady = false;
    this.initializeData();
  }

  private chartSetup(preparedChartData: ChartData): void {
    this.chartLabels = preparedChartData.labels;
    this.chartData = [
      { data: preparedChartData.content }
    ];
    this.chartDisplayType = 'bar';
    this.chartLegend = false;
    this.chartOptions = {
      responsive: true
    }
    this.chartReady = true;
  }

  private initializeData(): void {
    let preparedChartData: ChartData = this.cacheService.load(environment.CACHE_CHART_FREQUENCY);
    if(preparedChartData == null) {
      const accesspoints = this.cacheService.load(environment.CACHE_ACCESSPOINTS);
      if(accesspoints == null) {
        this.accesspointDataService.getAllAccessPoints('eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImZyb250ZW5kQGFwbS5jb20iLCJyb2xlIjoiUmVhZCIsIm5iZiI6MTYwODY2MzkwMCwiZXhwIjoxNjA4NjcxMTAwLCJpYXQiOjE2MDg2NjM5MDB9.AIaiWbJsWJ2jtTO9bx7lCcb08OprE83h2GUXbcCRdVg').toPromise()
          .then(x => {
            this.chartPreparationService.prepareCharts(x);
            preparedChartData = this.cacheService.load(environment.CACHE_CHART_FREQUENCY);
            this.chartSetup(preparedChartData);
          })
          .catch(error => {
            console.log(error);
          });
      } else {
        this.chartPreparationService.prepareCharts(accesspoints);
        preparedChartData = this.cacheService.load(environment.CACHE_CHART_FREQUENCY);
        this.chartSetup(preparedChartData);
      }
    } else {
      this.chartSetup(preparedChartData);
    }
  }
}
