﻿using ActionCommandGame.Abstractions;

namespace ActionCommandGame.Services.Model.Results
{
    public class PositiveGameEventResult : IHasProbability
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Gains { get; set; }
        public int Experience { get; set; }
        public int Probability { get; set; }
    }
}
