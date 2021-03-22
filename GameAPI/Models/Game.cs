namespace GameAPI.Models
{
    public class Game : AEntity
    {
        public string Name { get; set; }
        public List<Promt> Prompts { get; set; }

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
            this.Prompts = new List<Promt>();
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