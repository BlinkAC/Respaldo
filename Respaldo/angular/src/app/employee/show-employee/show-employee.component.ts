import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-employee',
  templateUrl: './show-employee.component.html',
  styleUrls: ['./show-employee.component.css']
})
export class ShowEmployeeComponent implements OnInit {
  public listOfEmployees: any = []
  constructor(private SharedService: SharedService) { }

  ngOnInit(): void {
    this.cargarData();
  }

  public cargarData() {
    this.SharedService.getEmployees()
      .subscribe(request => {
        this.listOfEmployees = request;
      })
  }
}
