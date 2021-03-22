import { Component, Input, OnInit } from '@angular/core';
import { HostService } from '../../services/host-service.service';

@Component({
  selector: 'app-room-code-display',
  templateUrl: './room-code-display.component.html',
  styleUrls: ['./room-code-display.component.css']
})
export class RoomCodeDisplayComponent implements OnInit {

  @Input() RoomCode:string;
  postId:any;

  constructor(private readonly service:HostService) { }

  ngOnInit(): void {

 this.service.GetRoom().subscribe(data=>
      {console.log(data)});


    console.log(this.service.roomCode);
  }

}
