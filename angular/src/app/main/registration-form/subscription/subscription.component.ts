import { Component, OnInit } from '@angular/core';
import { SubscriptionService } from './subscription.service';
import { SubscriptionDto } from '../../Models/SubscriptionDto';
import { SharedService } from '../../services/shared.service';
import { PackageType } from 'src/app/shared/enums/package-type.enum';
import { AmountModel } from '../../Models/Amount-Model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrls: ['./subscription.component.css'],
})
export class SubscriptionComponent implements OnInit {
  monthlySubscriptionDto: SubscriptionDto | undefined;
  annualSubscriptionDto: SubscriptionDto | undefined;
  subscriptionDtoList: SubscriptionDto[] | undefined;
  subscriptionAmountTotal: number = 0;
  numberOfBranch: number = 1;
  selectedSubscriptionDto: SubscriptionDto | undefined;
  couponCode: string = '';
  discountApplied: number = 0;
  packageType = PackageType;
  selectedMembership = this.packageType.Monthly.toString();
  amountModel: AmountModel = {};
  isCouponApplied: boolean = false;

  constructor(
    private _subscriptionService: SubscriptionService,
    private _sharedService: SharedService
  ) {}

  ngOnInit(): void {
    this._subscriptionService.getAllSubscriptions().subscribe((result) => {
      this.subscriptionDtoList = result?.data;
      this.monthlySubscriptionDto = (result?.data as any[]).find(
        (x) => x.packageType === PackageType.Monthly
      );
      this.annualSubscriptionDto = (result?.data as any[]).find(
        (x) => x.packageType === PackageType.Annual
      );
      this.setSelectedSubscription(this.selectedMembership);
      this.calculateTotalSubscriptionValue();
    });
  }

  increase(): void {
    this.numberOfBranch++;
    if (this.selectedSubscriptionDto) {
      this.selectedSubscriptionDto.numberOfBranches = this.numberOfBranch;
    }
    this.calculateTotalSubscriptionValue();
  }

  decrease(): void {
    if (this.numberOfBranch > 1) {
      this.numberOfBranch--;
      if (this.selectedSubscriptionDto) {
        this.selectedSubscriptionDto.numberOfBranches = this.numberOfBranch;
      }
      this.calculateTotalSubscriptionValue();
    }
  }

  getPackageCost(subscriptionDto?: SubscriptionDto): number {
    const packageCost = subscriptionDto?.packageCost || 0;
    const packageDiscount = subscriptionDto?.packageDiscount || 0;
    return packageCost - (packageCost * packageDiscount) / 100;
  }

  calculateTotalSubscriptionValue(): void {
    if (!this.selectedSubscriptionDto) return;

    const baseCost = this.getPackageCost(this.selectedSubscriptionDto);
    const totalCost =
      baseCost *
      (this.selectedMembership === PackageType.Annual ? 12 : 1) *
      this.numberOfBranch;

    // Apply discount from coupon
    this.subscriptionAmountTotal = totalCost - this.discountApplied;
    this.amountModel.subscriptionAmount =
      this.selectedSubscriptionDto?.packageCost;
    this.amountModel.discountAmount = this.discountApplied;
    this.amountModel.totalAmount = this.subscriptionAmountTotal;
    this._sharedService.setAmounts(this.amountModel);
  }

  setSelectedSubscription(subscription: string): void {
    this.selectedMembership = subscription;
    this.selectedSubscriptionDto =
      subscription === PackageType.Monthly
        ? this.monthlySubscriptionDto
        : this.annualSubscriptionDto;
    if (this.selectedSubscriptionDto) {
      this.selectedSubscriptionDto.numberOfBranches = this.numberOfBranch;
    }
    this._sharedService.setData(this.selectedSubscriptionDto);
    this.calculateTotalSubscriptionValue();
  }

  applyCoupon(): void {
    if (this.couponCode.length <= 0) {
      Swal.fire({
        title: 'Error',
        text: 'Please enter Coupon Code',
        icon: 'error',
      });
      return;
    }
    this._subscriptionService
      .validateCoupon(this.couponCode)
      .subscribe((result) => {
        if (result.data) {
          this.isCouponApplied = true;
          Swal.fire({
            title: 'Success',
            text: 'Coupon Code Applied',
            icon: 'success',
          });
          this.discountApplied =
            (this.subscriptionAmountTotal * result.data.discountPercentage) /
            100;
          this.calculateTotalSubscriptionValue(); // Recalculate total after applying coupon
        } else {
          this.discountApplied = 0;
        }
      });
  }

  restrictInvalidInput(event: KeyboardEvent) {
    const allowedKeys = ['Backspace', 'ArrowLeft', 'ArrowRight', 'Tab'];
    const key = event.key;

    if (allowedKeys.includes(key)) {
      return;
    }

    if (!/^[1-9]$/.test(key)) {
      event.preventDefault();
    }
  }
}
