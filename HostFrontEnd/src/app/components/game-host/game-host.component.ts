import { Component, OnInit } from '@angular/core';
import { HostService } from '../../services/host-service.service';

@Component({
  selector: 'app-game-host',
  templateUrl: './game-host.component.html',
  styleUrls: ['./game-host.component.css']
})
export class GameHostComponent implements OnInit {

  RoomCode:string;

  constructor(private readonly service:HostService) { }

  ngOnInit(): void {
  this.RoomCode=this.getRandomString(4);
  this.addRoom(this.RoomCode);

  }

  getRandomString(length) {
    var randomChars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    var result = '';
    for (var i = 0; i < length; i++) {
      result += randomChars.charAt(
        Math.floor(Math.random() * randomChars.length)
      );
    }
    return result;
  }

  addRoom(code: string) {
    this.service.PostRoom(code).subscribe((data) => {
      console.log(data);
    });
  }

}
