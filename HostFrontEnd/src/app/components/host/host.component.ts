import { Component, Input, OnInit } from '@angular/core';
import { HostService } from '../../services/host-service.service';

@Component({
  selector: 'app-host',
  templateUrl: './host.component.html',
  styleUrls: ['./host.component.css'],
})
export class HostComponent implements OnInit {
  RoomCode: string;
  game: string = 'Quiplash';

  constructor(private readonly service: HostService) {}



  ngOnInit(): void {

  }


}
