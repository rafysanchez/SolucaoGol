import { Injectable } from '@angular/core';
import { Employee } from './employee.model';
import { HttpClient } from "@angular/common/http";
import { debug } from 'util';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  formData  : Employee;
  list : Employee[];
  readonly rootURL ="https://localhost:44313/api"

  constructor(private http: HttpClient) { }

  postEmployee(formData : Employee){
   return this.http.post(this.rootURL + '/aeroplano', formData);
    
  }

  refreshList(){
    
    this.http.get(this.rootURL + '/aeroplano')
    .toPromise().then(res => this.list = res as Employee[]);
  }

  putEmployee(formData: Employee){
    return this.http.put(this.rootURL + '/aeroplano/' + formData.EmployeeID, formData);
     
   }

   deleteEmployee(id: number){
    return this.http.delete(this.rootURL + '/aeroplano/' + id);
   }
}
