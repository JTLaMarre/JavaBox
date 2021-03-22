using System;
using System.Collections.Generic;
using HostAPI.Domain.Abstracts;

namespace HostAPI.Domain.Models
{
    class Host : AEntity
    {
        string RoomCode { get; set; }

        List<Player> Players { get; set; }

        Game game { get; set; }
    }
}
