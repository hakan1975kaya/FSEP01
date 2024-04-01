import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Year } from 'src/app/models/dashboard/year';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {

  constructor(
    private formBuilder: FormBuilder,
    private alertifyService: AlertifyService,
  ) { }

  corporateCodeDefault = -1

  yearDefault = -1
  years: Year[] = []

  dashboardForm!: FormGroup;

  ngOnInit() {
    this.createDashboardForm();
    this.getYears()
  }

  createDashboardForm() {
    this.dashboardForm = this.formBuilder.group({
      corporateId: ['', [Validators.required, Validators.min(0), Validators.max(Number.MAX_VALUE), Validators.pattern("^[0-9]*$")]],
      year: ['', [Validators.required, Validators.min(2000), Validators.max(Number.MAX_VALUE), Validators.pattern("^[0-9]*$")]],

    });
  }



  getYears() {
    for (let i = 0; i <= 10; i++) {
      let year: Year = new Year()
      year.name = (new Date().getFullYear() - 10 + i).toString()
      year.value = (new Date().getFullYear() - 10 + i);
      this.years.push(year)
    }
  }


  clear() {
    this.dashboardForm.controls["corporateId"].setValue(-1)
    this.dashboardForm.controls["year"].setValue(-1)
  }


}

