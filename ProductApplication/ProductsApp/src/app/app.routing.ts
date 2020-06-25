import {Router,Route,RouterModule,PreloadAllModules,NoPreloading, Routes} from '@angular/router';
import{ModuleWithProviders} from '@angular/core';
import { CustomerDetailComponent } from './Customers/customer-detail/customer-detail.component';
import { LoginComponent } from './Customers/login/login.component';
import { UpdateProfileComponent } from './Customers/update-profile/update-profile.component';
import { AddProductComponent } from './Products/add-product/add-product.component';
import { SearchProductComponent } from './Products/search-product/search-product.component';
import { ProductListComponent } from './Products/product-list/product-list.component';
const APP_ROUTES:Routes=[{
    path:'customer-detail',component: CustomerDetailComponent 
},{
  path:'login', component: LoginComponent
},{
  path:'update-profile', component: UpdateProfileComponent
},
{
  path:'add-product', component: AddProductComponent
},
{
  path:'product-list', component: ProductListComponent
},
{
  path:'search-product', component:SearchProductComponent
}]
export const APP_ROUTING:ModuleWithProviders=RouterModule.forRoot(APP_ROUTES,{
  preloadingStrategy:NoPreloading,
})