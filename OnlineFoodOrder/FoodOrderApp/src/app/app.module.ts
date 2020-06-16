import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { AppRoutingModule } from './app-routing.module';
import {APP_ROUTING} from './app.routing';
import { AppComponent } from './app.component';
import { SignupComponent } from './signup/signup.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { FoodCategoriesComponent } from './food-categories/food-categories.component';
import { RestaurantsComponent } from './restaurants/restaurants.component';
import { FoodlistComponent } from './foodlist/foodlist.component';
import { QuantitiesComponent } from './quantities/quantities.component';
import { TotalpriceComponent } from './totalprice/totalprice.component';
import { PaymentComponent } from './payment/payment.component';

@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    LoginComponent,
    FoodCategoriesComponent,
    RestaurantsComponent,
    FoodlistComponent,
    QuantitiesComponent,
    TotalpriceComponent,
    PaymentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,APP_ROUTING,Ng2SearchPipeModule,FormsModule,ReactiveFormsModule,HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
