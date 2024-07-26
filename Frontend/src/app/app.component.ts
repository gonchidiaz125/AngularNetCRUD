import { Component } from '@angular/core';
import { Producto } from './models/Producto';
import { ProductoService } from './services/Producto.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {  
  producto:Producto = new Producto();
  listaDeProductos:any = [];

  constructor(private ProductoService:ProductoService) {
  }

  ngOnInit(): void {
    this.onCargarListaDeProductos();
  }

  onCargarListaDeProductos(){
    this.ProductoService.getProductos().subscribe(res => {
      this.listaDeProductos = res;      
    });    
  }

  onAgregarProducto(producto:Producto):void{
    this.ProductoService.addProducto(producto).subscribe({
      next: () => {
        alert(`El producto ${producto.nombre} se ha registrado con exito!`);
        this.limpiarSeleccionado();
        this.onCargarListaDeProductos();
      },
      error: (error) => {        
        console.log(error);
        alert(`Error ${error}`)
      }
    });
  }

  onActualizarProducto(producto:Producto):void{    
    this.ProductoService.updateProducto( producto).subscribe({
      next: () => {
        alert(`El producto número ${producto.id} se ha modificado con exito!`);
        this.limpiarSeleccionado();
        this.onCargarListaDeProductos();
      },
      error: (error) => {
        console.log(error);
        alert(`Error ${error}`)
      }
    });    
  }

  onBorrarProducto(id:number):void{
    this.ProductoService.deleteProducto(this.producto.id).subscribe({
      next: () => {
        alert(`El producto número ${id} se ha eliminado con exito!`);
        this.limpiarSeleccionado();
        this.onCargarListaDeProductos();      
      },
      error: (error) => {        
        console.log(error);
        alert(`Error ${error}`)
      }
    })
  }

  onSeleccionarProducto(producto:any) {
    // Se ejecuta cuando pulsamos el botón SELECCIONAR para un producto en la grilla
    this.producto.id = producto.id;
    this.producto.nombre = producto.nombre;    
    this.producto.descripcion = producto.descripcion;
    this.producto.codigo = producto.codigo;
    this.producto.precio = producto.precio;    
  }

  limpiarSeleccionado() {
    // Se ejecuta cuando pulsamos el botón LIMPIAR
    this.producto.id = 0;
    this.producto.nombre = "";
    this.producto.descripcion = "";
    this.producto.codigo = "";
    this.producto.precio = 0;    
  }
}
