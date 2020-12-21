import { Injectable } from '@angular/core';
import { Accesspoint } from '../models/accesspoint.model';
import { ChartData } from '../models/chart-data.model';
import { CacheManagerService } from './cache-manager.service';

@Injectable({
  providedIn: 'root'
})
export class ChartPreparationService {

  constructor(private cacheService: CacheManagerService) { }

  public prepareSecurityChart(accesspoints: Array<Accesspoint>): ChartData {
    const WPA2 = { name: 'WPA2', count: 0 };
    const WPA = { name: 'WPA', count: 0 };
    const WPS = { name: 'WPS', count: 0 };
    const WEP = { name: 'WEP', count: 0 };
    const None = { name: 'None', count: 0 };

    accesspoints.forEach(x => {
      const securityData: Array<string> = JSON.parse(x.securityData);

      if(securityData.includes(WPA2.name)) WPA2.count++;
      else if(securityData.includes(WPA.name)) WPA.count++;
      else if(securityData.includes(WPS.name)) WPS.count++;
      else if(securityData.includes(WEP.name)) WEP.count++;
      else None.count++;
    });

    return {
      type: 'bar',
      labels: [WPA2.name, WPA.name, WPS.name, WEP.name, None.name],
      content: [WPA2.count, WPA.count, WPS.count, WEP.count, None.count],
      colors: ['#000000', '#000000', '#000000', '#000000', '#000000']
    };
  }

  public prepareFrequencyChart(accesspoints: Array<Accesspoint>): ChartData {
    const freqCount: Array<any> = [];
    accesspoints.forEach(x => {
      if(freqCount.length < 1) freqCount.push({ freq: x.frequency, count: 1}); 
      if(freqCount.find(item => item.freq == x.frequency)) {
        freqCount.find(item => item.freq == x.frequency).count++;
      } else {
        freqCount.push({ freq: x.frequency, count: 1 });
      }
    });

    freqCount.sort((a, b) => (a.count < b.count) ? 1 : -1);

    const labels: Array<string> = [];
    const values: Array<number> = [];
    for(let i=0; i<5; i++) { 
      labels.push(freqCount[i].freq.toString());
      values.push(freqCount[i].count);
    }

    return {
      type: 'bar',
      labels: labels,
      content: values,
      colors: ['#000000', '#000000', '#000000', '#000000', '#000000']
    }
  }

  public prepareAreaChart(accesspoints: Array<Accesspoint>): ChartData {
    accesspoints.sort((a, b) => (a.signalArea < b.signalArea) ? 1 : -1);
    const labels: Array<string> = [];
    const values: Array<number> = [];
    for(let i=0; i<5; i++) {
      labels.push(accesspoints[i].ssid);
      values.push(accesspoints[i].signalArea);
    }

    return {
      type: 'bar',
      labels: labels,
      content: values,
      colors: ['#000000', '#000000', '#000000', '#000000', '#000000']
    }
  }

  public prepareBrandChartStatic(accesspoints: Array<Accesspoint>): ChartData {
    const tplink = { name: 'tp-link', count: 0 };
    const dasan = { name: 'dasan', count: 0 };
    const dlink = { name: 'd-link', count: 0 };
    const sagem = { name: 'sagemcom', count: 0 };
    const ubiquiti = { name: 'ubiquiti', count: 0 };

    accesspoints.forEach(x => {
      const brandName = x.brand.toLowerCase();

      if(brandName.includes(tplink.name)) tplink.count++;
      else if(brandName.includes(dasan.name)) dasan.count++;
      else if(brandName.includes(dlink.name)) dlink.count++;
      else if(brandName.includes(sagem.name)) sagem.count++;
      else if(brandName.includes(ubiquiti.name)) ubiquiti.count++;
    });

    return {
      type: 'bar',
      labels: [ tplink.name, dasan.name, dlink.name, sagem.name, ubiquiti.name ],
      content: [ tplink.count, dasan.count, dlink.count, sagem.count, ubiquiti.count ],
      colors: ['#000000', '#000000', '#000000', '#000000', '#000000']
    }
  }

  public prepareBrandChartDynamic(accesspoints: Array<Accesspoint>): ChartData {
    //Changes to the API
    return null;
  }
}
