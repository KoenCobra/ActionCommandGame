using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ActionCommandGame.Abstractions;

namespace ActionCommandGame.Model
{
    public class Player: IIdentifiable, IHasExperience
    {
        public Player()
        {
            Inventory = new List<PlayerItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Gains { get; set; }
        public int Experience { get; set; }

        public DateTime? LastActionExecutedDateTime { get; set; }

        public string UserId { get; set; }

        public string ImageName { get; set; }

        public int? CurrentFuelPlayerItemId { get; set; }
        public PlayerItem CurrentFuelPlayerItem { get; set; }
        public int? CurrentAttackPlayerItemId { get; set; }
        public PlayerItem CurrentAttackPlayerItem { get; set; }
        public int? CurrentDefensePlayerItemId { get; set; }
        public PlayerItem CurrentDefensePlayerItem { get; set; }

        public IList<PlayerItem> Inventory { get; set; }

    }
}
