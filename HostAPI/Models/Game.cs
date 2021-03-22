using System;
using HostAPI.Domain.Abstracts;

namespace HostAPI.Domain.Models {


// not sure a Game object needs to be an Entity or jsut a string to call the game api on front-end?

    class Game:AEntity
     { 
         string GameName {get;set;}
     }
}