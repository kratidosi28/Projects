import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { AppRoutingModule } from './app-routing.module';
import {APP_ROUTING} from './app.routing';

import { AppComponent } from './app.component';
import { CustomerDetailComponent } from './Customers/customer-detail/customer-detail.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { LoginComponent } from './Customers/login/login.component';
import { UpdateProfileComponent } from './Customers/update-profile/update-profile.component';
import { AddProductComponent } from './Products/add-product/add-product.component';
import { SearchProductComponent } from './Products/search-product/search-product.component';
import { ProductListComponent } from './Products/product-list/product-list.component';



@NgModule({
  declarations: [
    AppComponent,
    CustomerDetailComponent,
    LoginComponent,
    UpdateProfileComponent,
    AddProductComponent,
    SearchProductComponent,
    ProductListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,APP_ROUTING,Ng2SearchPipeModule,FormsModule,ReactiveFormsModule,HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
