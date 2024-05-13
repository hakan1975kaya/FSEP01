import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { AppRoutingModule } from './app-routing.module';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AuthService } from './services/auth/auth.service';
import { AlertifyService } from './services/alertify/alertify.service';

import { AuthenticationGuard } from './guards/authentication-guard';

import { AppComponent } from './app.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LoginComponent } from './pages/login/login.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PipeService } from './services/pipe/pipe.service';
import { WebLogService } from './services/web-log/web-log.service';
import { DemandComponent } from './pages/demand/demand.component';
import { UserProfileComponent } from './pages/user-profile/user-profile.component';
import { DemandPipe } from './pipes/demand/demand.pipe';
import { OrderService } from './services/general/order.service';
import { MenuService } from './services/menu/menu.service';
import { AuthorizationGuard } from './guards/authorization-guard';
import { MenuComponent } from './pages/menu/menu.component';
import { RoleComponent } from './pages/role/role.component';
import { UserComponent } from './pages/user/user.component';
import { MenuPipe } from './pipes/menu/menu.pipe';
import { UserRoleComponent } from './pages/user-role/user-role.component';
import { RoleDemandComponent } from './pages/role-demand/role-demand.component';
import { RoleMenuComponent } from './pages/role-menu/role-menu.component';
import { PasswordChangeComponent } from './pages/password-change/password-change.component';
@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    LoginComponent,
    DemandComponent,
    UserProfileComponent,
    DemandPipe,
    MenuComponent,
    RoleComponent,
    UserComponent,
    MenuPipe,
    UserRoleComponent,
    RoleDemandComponent,
    RoleMenuComponent,
    PasswordChangeComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    NgMultiSelectDropDownModule.forRoot(),
    NgbModule,
    BrowserAnimationsModule,
    NgxChartsModule
  ],
  providers: [
    AuthService,
    AlertifyService,
    AuthenticationGuard,
    PipeService,
    WebLogService,
    OrderService,
    MenuService,
    AuthorizationGuard
  ],
  bootstrap: [AppComponent],
  schemas: [NO_ERRORS_SCHEMA]
})
export class AppModule { }
