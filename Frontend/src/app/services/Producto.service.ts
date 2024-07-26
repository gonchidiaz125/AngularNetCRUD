import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http'
import { Producto } from '../models/Producto';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  constructor(private http:HttpClient) { }

  url:string = "https://localhost:7260/api/Productos";

  getProductos() {
    return this.http.get(this.url);
  }

  addProducto(producto:Producto):Observable<Producto> {
    return this.http.post<Producto>(this.url, producto).pipe(
      catchError(this.handleError)
    );
  }

  updateProducto(producto:Producto):Observable<Producto> {
    return this.http.put<Producto>(this.url, producto).pipe(
      catchError(this.handleError)
    );
  }
  
  deleteProducto(id:number) {    
    return this.http.delete(this.url + `/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse): Observable<never> {
    let errorMessage = 'Error desconocido';
    if (error.error instanceof ErrorEvent) {
      // Error del lado del cliente
      errorMessage = `Error: ${error.error.message}`;
    } else {
      // Error del lado del servidor
      errorMessage = `Código del error: ${error.status}\nMensaje: ${error.error.mensaje}`;
    }
    return throwError(() => new Error(errorMessage));
  }

}
