import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthenticationGuard } from './guards/authentication-guard';

import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LoginComponent } from './pages/login/login.component';
import { AppComponent } from './app.component';
import { DemandComponent } from './pages/demand/demand.component';
import { UserProfileComponent } from './pages/user-profile/user-profile.component';
import { RecipeComponent } from './pages/recipe/recipe.component';
import { AuthorizationGuard } from './guards/authorization-guard';
import { MenuComponent } from './pages/menu/menu.component';
import { RoleComponent } from './pages/role/role.component';
import { UserComponent } from './pages/user/user.component';
import { UserRoleComponent } from './pages/user-role/user-role.component';
import { RoleDemandComponent } from './pages/role-demand/role-demand.component';
import { RoleMenuComponent } from './pages/role-menu/role-menu.component';
import { PasswordChangeComponent } from './pages/password-change/password-change.component';
import { ContactRollComponent } from './pages/contact-roll/contact-roll.component';
import { DefinationComponent } from './pages/defination/defination.component';
import { DensityComponent } from './pages/density/density.component';
import { EventComponent } from './pages/event/event.component';
import { HeadTailScrapComponent } from './pages/head-tail-scrap/head-tail-scrap.component';
import { LubracationRollComponent } from './pages/lubracation-roll/lubracation-roll.component';
import { TramRollComponent } from './pages/tram-roll/tram-roll.component';
import { UsageAreaComponent } from './pages/usage-area/usage-area.component';

const routes: Routes = [
  { path: 'app', component: AppComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'user-profile', component: UserProfileComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthenticationGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'demand', component: DemandComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'recipe', component: RecipeComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'menu', component: MenuComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'role', component: RoleComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'user', component: UserComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'user-role', component: UserRoleComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'role-demand', component: RoleDemandComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'role-menu', component: RoleMenuComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'password-change', component: PasswordChangeComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'contact-roll', component:ContactRollComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'defination', component:DefinationComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'density', component:DensityComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'event', component:EventComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'head-tail-scrap', component:HeadTailScrapComponent , canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'lubracation-roll', component:LubracationRollComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'tram-roll', component:TramRollComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: 'usage-area', component:UsageAreaComponent, canActivate: [AuthenticationGuard, AuthorizationGuard] },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
