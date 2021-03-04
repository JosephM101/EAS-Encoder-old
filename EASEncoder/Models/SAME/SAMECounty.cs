using System;

namespace EASEncoder.Models.SAME
{
    [Serializable]
    public class SAMECounty
    {
        public SAMECounty(int id, string name, SAMEState State)
        {
            Id = id;
            Name = name;
            this.State = State;
        }

        public int Id { private set; get; }
        public string Name { private set; get; }
        public SAMEState State { private set; get; }
        public string Value => Name;
    }
}