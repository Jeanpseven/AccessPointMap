import { Injectable } from '@angular/core';
import { LocalStorageOptions } from '../models/local-storage-options.model';
import { AccesspointDataService } from './accesspoint-data.service';
import { CacheManagerService } from './cache-manager.service';

const CACHE_KEY_ACCESSPOINTS = "VECTOR_LAYER_ACCESSPOINTS";
const CACHE_KEY_BRANDS = "BRANDS_ACCESSPOINTS"

@Injectable({
  providedIn: 'root'
})
export class DataFetchService {

  constructor(private accesspointDataService: AccesspointDataService, private cacheService: CacheManagerService) { }

  public localDataCheck(): void {
    this.fetchAccessPoints();
    this.fetchBrands();
  }

  private fetchAccessPoints(): void {
    const localStorageData = this.cacheService.load(CACHE_KEY_ACCESSPOINTS);
    if(localStorageData == null) {
      this.accesspointDataService.getAllAccessPoints("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImZyb250ZW5kQGFwbS5jb20iLCJyb2xlIjoiUmVhZCIsIm5iZiI6MTYwODM4MTkxOCwiZXhwIjoxNjA4Mzg5MTE4LCJpYXQiOjE2MDgzODE5MTh9.59d8Zh2qw3s68smtvr-mCOTuUb4TOKOXHU8E8X-Ke0A").toPromise()
      .then(data => {
        const options: LocalStorageOptions = { key: CACHE_KEY_ACCESSPOINTS, data: data , expirationMinutes: 60 };
        this.cacheService.delete(CACHE_KEY_ACCESSPOINTS);
        this.cacheService.save(options);
      })
      .catch(error => {
        console.log(error);
      });
    }
  }

  private fetchBrands(): void {
    const localStorageData = this.cacheService.load(CACHE_KEY_BRANDS);
    if(localStorageData == null) {
      this.accesspointDataService.getBrands("").toPromise()
      .then(data => {
        const options: LocalStorageOptions = { key: CACHE_KEY_BRANDS, data: data , expirationMinutes: 120 };
        this.cacheService.delete(CACHE_KEY_BRANDS);
        this.cacheService.save(options);
      })
      .catch(error => {
        console.log(error);
      });
    }
  }
}
