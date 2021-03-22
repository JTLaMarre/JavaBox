import { Component, Input, OnInit } from '@angular/core';
import { HostService } from '../../services/host-service.service';

@Component({
  selector: 'app-host',
  templateUrl: './host.component.html',
  styleUrls: ['./host.component.css']
})
export class HostComponent implements OnInit {

 RoomCode:string;

  constructor(private readonly service:HostService) { }

 getRandomString(length) {
    var randomChars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    var result = '';
    for ( var i = 0; i < length; i++ ) {
        result += randomChars.charAt(Math.floor(Math.random() * randomChars.length));
    }
    return result;
}


  ngOnInit(): void {
    this.RoomCode = this.getRandomString(4);
    this.service.setRoomCode(this.RoomCode);

    this.addRoom(this.RoomCode);

  }

  addRoom(code:string){
    this.service.PostRoom(code).subscribe(data => {
      console.log(data);
    })
  }

}
