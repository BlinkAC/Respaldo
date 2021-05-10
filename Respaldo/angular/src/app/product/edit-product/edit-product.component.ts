import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {

  constructor(private SharedService: SharedService) { }

  @Input() product: any;
  productId!: string;
  name: string = "";
  alert: boolean = false;
  

  ngOnInit(): void {
    this.productId = this.product.productId;
    this.name = this.product.name;
  }

  addProduct() {
    var val = {
      productId: this.productId,
      name: this.name
    };

    this.SharedService.addProduct(val).subscribe(res => {
      alert(res.toString());
    });
    this.alert = true;
  }
  
  closeAlert() {
    this.alert = false;

  }



  
  

}
