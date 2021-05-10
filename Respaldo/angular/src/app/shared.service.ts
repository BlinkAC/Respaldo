import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "https://localhost:44327/api"
  constructor(private http: HttpClient) { }

  

  public getProducts(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+'/product'); // GET-https://localhost:5001/api/Product
  }

  public getProduct(id: number): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/product/'+id); // GET-https://localhost:5001/api/Product
  }

  public addProduct(val: any) {
    return this.http.post(this.APIUrl + '/product', val);
  }

  public updateProduct(val: any,val2:any) {
    return this.http.put(this.APIUrl + '/product/' +val+'?name='+val2,val2); 
  }

  public deleteProduct(val: any) {
    return this.http.delete(this.APIUrl + '/product?id='+ val); 
  }

  public getEmployees(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/employee'); // GET-https://localhost:5001/api/employee
  }

  public addEmployee(val: any) {
    return this.http.post(this.APIUrl + '/employee', val);
  }

  public updateEmployee(val: any) {
    return this.http.put(this.APIUrl + '/employee', val);
  }

  public deleteEmploye(val: any) {
    return this.http.delete(this.APIUrl + '/employee', val);
  }
}
