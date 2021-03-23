import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HostComponent } from '../app/components/host/host.component';
import { GameHostComponent } from './components/game-host/game-host.component';
import { LandingComponent } from './components/landing/landing.component';
import { PlayerComponent } from './components/player/player.component';

const routes: Routes = [
  {path:'',component:LandingComponent},
  {path:'host',component:HostComponent},
  {path:'host/game',component:GameHostComponent},
  {path:'player',component:PlayerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
