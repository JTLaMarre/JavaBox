using System;
using System.ComponentModel.DataAnnotations;
using HostAPI.Domain.Abstracts;

namespace HostAPI.Domain.Models{

    public class Player
     { 
         [Key]
         public string name {get;set;}

         public int score {get;set;}

         public string HostRoomcode{get;set;}
    }
}