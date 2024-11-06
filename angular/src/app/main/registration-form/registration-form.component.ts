import { Component, OnInit } from '@angular/core';
import { SharedService } from '../services/shared.service';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css'],
})
export class RegistrationFormComponent implements OnInit {
  constructor(private _sharedService: SharedService) {}
  paymentClicked() {
    this._sharedService.setButtonValue(true);
  }
  ngOnInit(): void {}
}
