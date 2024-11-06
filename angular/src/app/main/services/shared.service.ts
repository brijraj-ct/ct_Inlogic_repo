import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  private dataSubject = new BehaviorSubject<any>(null); // Initial value can be null
  data$ = this.dataSubject.asObservable();

  private amountSubject = new BehaviorSubject<any>(null); // Initial value can be null
  amounts$ = this.amountSubject.asObservable();

  private buttonSubject = new BehaviorSubject<any>(null); // Initial value can be null
  buttonValue$ = this.buttonSubject.asObservable();

  constructor() {}

  data: any;

  setData(data: any) {
    this.dataSubject.next(data); // Emit the new data
  }

  getData() {
    return this.dataSubject.value; // Get current data
  }

  setAmounts(data: any) {
    this.amountSubject.next(data);
  }

  getAmounts() {
    return this.amountSubject.value;
  }

  setButtonValue(data: boolean) {
    this.buttonSubject.next(data);
  }

  getButtonValue() {
    return this.buttonSubject.value;
  }
}
