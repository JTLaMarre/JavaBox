import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HostService {

  queryUrl:string = `https://localhost:5001`;

  players:Array<any>;
  roomCode:string;



  constructor(private http:HttpClient) { }

  // Set Room Code
  setRoomCode(roomcode:string){
    this.roomCode=roomcode;
  }

  // Post a Room
  PostRoom(code:string):Observable<any>{
    let params = new HttpParams().set('RoomCode',code);

    return this.http.post(`${this.queryUrl}/host/${code}/create`,{params:params}).pipe();
  }

  // Display a Room
  GetRoom():Observable<any>{

    let res = this.http.get<any>(`${this.queryUrl}/host/${this.roomCode}`);
    console.log(res);
    return res;
  }
  // Display players


}
