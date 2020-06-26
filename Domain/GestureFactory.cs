using System.Collections.Generic;

namespace Domain
{
    public class GestureFactory
    {
        private Scissors scissors;
        private Paper paper;
        private Rock rock;

        public GestureFactory()
        {
            this.paper = new Paper();
            this.rock = new Rock();
            this.scissors = new Scissors();
            
            this.paper.CanBiteGestures = new List<Gesture>(){rock};
            this.rock.CanBiteGestures = new List<Gesture>(){scissors};
            this.scissors.CanBiteGestures = new List<Gesture>(){paper};
        }

        public Gesture GetScissors() => scissors;
        public Gesture GetPaper() => paper;
        public Gesture GetRock() => rock;
    }
}