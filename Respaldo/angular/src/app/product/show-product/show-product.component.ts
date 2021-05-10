import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { NgbModalConfig, NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';





@Component({
  selector: 'app-show-product',
  templateUrl: './show-product.component.html',
  styleUrls: ['./show-product.component.css'],
  providers: [NgbModalConfig, NgbModal]
})
export class ShowProductComponent implements OnInit {
  title='Prueba'
  public listOfProducts: any = []
  ModalTitle!: any;
  ModalTitle2!: any;
  product: any;
  @Input() productId!: number;
  @Input() name!: string;
  closeResult = '';
  alert: boolean = false;

   

 
  
  constructor(private SharedService: SharedService, config: NgbModalConfig, private modalService: NgbModal) {
    config.backdrop = 'static';
    config.keyboard = false;
  }

  
  open(content: any) {
    this.product = {
      productId: 0,
      productName: ""

    }
    this.ModalTitle = "Agregar producto"
    this.modalService.open(content);
    
  }

  
  getOne() {
    var val = this.productId;
    console.log(val);
    this.SharedService.deleteProduct(val).subscribe();
    this.alert = true;
  }

  updateClick() {
    var id = this.productId;
    var name = this.name;
    this.SharedService.updateProduct(id, name).subscribe(res => {
      console.log(res)
    })
    this.alert = true;
  }

  closeAlert() {
    this.alert = false;

  }
  ngOnInit(): void {
    this.cargarData();
  }

 
  

  public cargarData() {
    this.SharedService.getProducts()
      .subscribe(request => {
        this.listOfProducts = request;
      })
  }
}

