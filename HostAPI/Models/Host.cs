using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HostAPI.Domain.Models
{
    public class Host 
    {
        [Key]
        public string RoomCode {get; set;}

        public List<Player> Players { get; set; }

       public Game game { get; set; }

       

       public Host(string roomCode)
       {  
           RoomCode = roomCode; 
        }
    }
}
