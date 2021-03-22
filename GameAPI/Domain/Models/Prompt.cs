using System.Collections.Generic;
using GameAPI.Domain.Abstracts;

namespace GameAPI.Domain.Models
{
    public class Prompt : AEntity
    {
        public string Answer { get; set; }
        public string Question { get; set; }
        public List<Game> Games { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Prompt(){}
        /// <summary>
        /// Create Prompt with No answer and Single Game
        /// </summary>
        /// <param name="Question"></param>
        /// <param name="Game"></param>
        public Prompt(string Question, Game Game)
        {
            this.Question = Question;
            this.Games = new List<Game>{Game};
        }
        /// <summary>
        /// Create Prompt with Answer and Single Game
        /// </summary>
        /// <param name="Question"></param>
        /// <param name="Answer"></param>
        /// <param name="Game"></param>
        public Prompt(string Question, string Answer, Game Game)
        {
            this.Question = Question;
            this.Answer = Answer;
            this.Games = new List<Game>{Game};
        }
        /// <summary>
        /// Create Prompt with no Answer and List of Games
        /// </summary>
        /// <param name="Question"></param>
        /// <param name="Games"></param>
        public Prompt(string Question, List<Game> Games)
        {
            this.Question = Question;
            this.Games = Games;
        }
        /// <summary>
        /// Create Prompt with Answer and List of Games
        /// </summary>
        /// <param name="Question"></param>
        /// <param name="Answer"></param>
        /// <param name="Games"></param>
        public Prompt(string Question, string Answer, List<Game> Games)
        {
            this.Question = Question;
            this.Answer = Answer;
            this.Games = Games;
        }
    }
}