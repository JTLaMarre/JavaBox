using System.Collections.Generic;
using GameAPI.Domain.Abstracts;

namespace GameAPI.Domain.Models
{
    public class Game : AEntity
    {
        public string Name { get; set; }
        public List<Prompt> Prompts { get; set; }

        /// <summary>
        /// Default Game Constructor  
        /// </summary>
        public Game(){}
        /// <summary>
        /// Creates Game with only a Name Value
        /// </summary>
        /// <param name="Name"></param>
        public Game(string Name)
        {
            this.Name = Name;
            this.Prompts = new List<Prompt>();
        }
        /// <summary>
        /// Creates a Game with a Name and a List of Prompts
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Prompts"></param>
        public Game(string Name, List<Prompt> Prompts)
        {
            this.Name = Name;
            this.Prompts = Prompts;
        }
    }
}