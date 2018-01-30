using System;

public class Dinosaur
{
    class Dinosaur
    {
        public string Name { get; set; }
        public int HeightInFeet { get; set; }
        public string Status { get; set; }
    }

    class DinosaurModule : NancyModule
    {
        private static Dinosaur dinosaur = new Dinosaur()
        {
            Name = "Kierkegaard",
            HeightInFeet = 0,
            Status = "Deflated"
        };

        public DinosaurModule()
        {
            Get["/dinosaur"] = parameters => dinosaur;
        }
    }
}
