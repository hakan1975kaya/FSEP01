import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthenticationGuard } from './guards/authentication-guard';

import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LoginComponent } from './pages/login/login.component';
import { AppComponent } from './app.component';
import { DemandComponent } from './pages/demand/demand.component';
import { UserProfileComponent } from './pages/user-profile/user-profile.component';
import { AuthorizationGuard } from './guards/authorization-guard';
import { MenuComponent } from './pages/menu/menu.component';
import { RoleComponent } from './pages/role/role.component';
import { UserComponent } from './pages/user/user.component';
import { UserRoleComponent } from './pages/user-role/user-role.component';
import { RoleDemandComponent } from './pages/role-demand/role-demand.component';
import { RoleMenuComponent } from './pages/role-menu/role-menu.component';
import { PasswordChangeComponent } from './pages/password-change/password-change.component';

const routes: Routes = [
  { path: 'app', component: AppComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'user-profile', component: UserProfileComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthenticationGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'demand', component: DemandComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'menu', component: MenuComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'role', component: RoleComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'user', component: UserComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'user-role', component: UserRoleComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'role-demand', component: RoleDemandComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'role-menu', component: RoleMenuComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'password-change', component: PasswordChangeComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
