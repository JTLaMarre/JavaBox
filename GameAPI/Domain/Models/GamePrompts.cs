using GameAPI.Domain.Abstracts;

namespace GameAPI.Domain.Models
{
    public class GamePrompts : AEntity
    {
        public Prompt Prompt { get; set; }
        public Game Game { get; set; }
        
        public GamePrompts(){}
        public GamePrompts(Game Game, Prompt Prompt)
        {
            this.Game = Game;
            this.Prompt = Prompt;
        }
    }
}