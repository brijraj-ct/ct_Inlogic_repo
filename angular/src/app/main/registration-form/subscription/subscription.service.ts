import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { CouponDto } from '../../Models/Coupon';
import { SubscriptionDto } from '../../Models/SubscriptionDto';

@Injectable({
  providedIn: 'root',
})
export class SubscriptionService {
  constructor(private http: HttpClient) {}

  getAllSubscriptions() {
    return this.http.get<any>(
      environment.apiEndPoint + 'subscription/getAll'
    );
  }

  validateCoupon(couponCode: string) {
    return this.http.post<any>(
      environment.apiEndPoint +
        'subscription/validateCoupon?couponCode=' +
        couponCode,
      null
    );
  }
}
