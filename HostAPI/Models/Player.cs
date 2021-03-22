using System;
using HostAPI.Domain.Abstracts;

namespace HostAPI.Domain.Models{

    class Player:AEntity
     { 
         string name {get;set;}

         int score {get;set;}

         long HostId{get;set;}
    }
}