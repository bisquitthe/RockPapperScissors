using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class Gesture
    {
        internal Gesture()
        {
        }
        
        internal IList<Gesture> CanBiteGestures { get; set; }
        public abstract string GetEmoji();

        public bool CanBite(Gesture gesture)
        {
            return this.CanBiteGestures.Contains(gesture);
        }
    }

    public class Scissors : Gesture
    {
        public override string GetEmoji() => "Scissors";
    }

    public class Paper : Gesture
    {
        public override string GetEmoji() => "Paper";
    }

    public class Rock : Gesture
    {
        public override string GetEmoji() => "Rock";
    }
}