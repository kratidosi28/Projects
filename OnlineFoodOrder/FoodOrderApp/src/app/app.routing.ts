import {Router,Route,RouterModule,PreloadAllModules,NoPreloading, Routes} from '@angular/router';
import{ModuleWithProviders} from '@angular/core';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { FoodCategoriesComponent } from './food-categories/food-categories.component';
import {RestaurantsComponent} from './restaurants/restaurants.component'
import { FoodlistComponent } from './foodlist/foodlist.component';
import { QuantitiesComponent } from './quantities/quantities.component';
import { TotalpriceComponent } from './totalprice/totalprice.component';
import { PaymentComponent } from './payment/payment.component';
import { ListoffoodComponent } from './listoffood/listoffood.component';

const APP_ROUTES:Routes=[{
    path:'signup',component: SignupComponent
},{
  path:'login',component: LoginComponent
},{
  path:'food-categories/:id',component: FoodCategoriesComponent
},{
  path:'',component: RestaurantsComponent
},{
  path:'foodlist/:id',component:FoodlistComponent 
},{
  path:'quantities',component: QuantitiesComponent
},{
  path:'totalprice/:id',component: TotalpriceComponent
},{
  path:'payment',component: PaymentComponent
}]
export const APP_ROUTING:ModuleWithProviders=RouterModule.forRoot(APP_ROUTES,{
  preloadingStrategy:NoPreloading,
})

