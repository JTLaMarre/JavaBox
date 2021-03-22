import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GameButtonComponent } from './components/game-button/game-button.component';
import { RoomCodeDisplayComponent } from './components/room-code-display/room-code-display.component';
import { PlayersDisplayComponent } from './components/players-display/players-display.component';
import { HostComponent } from './components/host/host.component';

@NgModule({
  declarations: [
    AppComponent,
    GameButtonComponent,
    RoomCodeDisplayComponent,
    PlayersDisplayComponent,
    HostComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
