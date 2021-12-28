using ActionCommandGame.Model;
using ActionCommandGame.Repository.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ActionCommandGame.Repository
{
    public class ActionCommandGameDbContext: IdentityDbContext
    {
        public ActionCommandGameDbContext(DbContextOptions<ActionCommandGameDbContext> options): base(options)
        {
            
        }

        public DbSet<PositiveGameEvent> PositiveGameEvents { get; set; }
        public DbSet<NegativeGameEvent> NegativeGameEvents { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerItem> PlayerItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.ConfigureRelationships();

            base.OnModelCreating(modelBuilder);
        }

        public void Initialize()
        {
            var email = "bavo.ketels@vives.be";
            //Password Test123$
            var passwordHash = "AQAAAAEAACcQAAAAECp9VnV5jgDyqQqacxkrC+OcWFUM1+mavZ4+mxxhqtm/dg9UTVq1vhgAKFsblrEXDA==";
            var user = new IdentityUser
            {
                UserName = email,
                Email = email,
                NormalizedEmail = email.ToUpperInvariant(),
                NormalizedUserName = email.ToUpperInvariant(),
                PasswordHash = passwordHash
            };

            Users.Add(user);
            SaveChanges();

            GeneratePositiveGameEvents();
            GenerateNegativeGameEvents();
            GenerateAttackItems();
            GenerateDefenseItems();
            GenerateFoodItems();
            GenerateDecorativeItems();

            //God Mode Item
            Items.Add(new Item
            {
                Name = "ARNOLD MODE",
                Description = "This is almost how Arnold must feel.",
                Attack = 1000000,
                Defense = 1000000,
                Fuel = 1000000,
                ActionCooldownSeconds = 1,
                Price = 10000000,
                ImageUrl = "https://i.pinimg.com/236x/85/8f/20/858f20bc09890753ad7255223ad9b345--bodybuilding-fitness-bodybuilding-motivation.jpg"
            });

            Players.Add(new Player { UserId = user.Id, Name = "John Doe", Gains = 100, ImageName = "nerd.jpg"});
            Players.Add(new Player { UserId = user.Id, Name = "John Francks", Gains = 100000, Experience = 2000, ImageName = "Ronnie.jpg"});
            Players.Add(new Player { UserId = user.Id, Name = "Luc Doleman", Gains = 500, Experience = 5, ImageName = "nerd2.jpg"});
            Players.Add(new Player { UserId = user.Id, Name = "Emilio Fratilleci", Gains = 12345, Experience = 200, ImageName = "buffdude.jpg"});

            SaveChanges();
        }

        private void GeneratePositiveGameEvents()
        {
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Nothing but marginal gains", Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "The biggest Protein Shake you ever saw.", Description = "It slips out of your hands and rolls under a squat machine. It is out of reach.", Probability = 500 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A piece of empty paper", Description = "You hope it's a perfect workout plan, but it's empty.", Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "A drinking fountain", Description = "The water flows around your feet and creates a dirty puddle.", Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Junk-food", Gains = 1, Experience = 1, Probability = 2000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Fat Burner", Gains = 1, Experience = 1, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "BCAA", Gains = 1, Experience = 1, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Vitamin D3", Gains = 1, Experience = 1, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Omega's", Gains = 5, Experience = 3, Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Multi-Vitamin", Gains = 10, Experience = 5, Probability = 800 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Pre-workout", Gains = 10, Experience = 5, Probability = 800 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Mass Gainer", Gains = 10, Experience = 5, Probability = 800 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Creatine", Gains = 12, Experience = 6, Probability = 700 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Koala Freak", Gains = 20, Experience = 8, Probability = 650 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "FINAFLEX’s STIMUL8", Gains = 30, Experience = 10, Probability = 500 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Pro Supps Mr. Hyde ", Gains = 50, Experience = 13, Probability = 400 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "RSP Nutrition DYNO", Gains = 60, Experience = 15, Probability = 400 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "VPX Sports Redline White Heat", Gains = 100, Experience = 40, Probability = 350 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Musclepharm Wreckage", Gains = 140, Experience = 50, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Testosterone", Gains = 160, Experience = 80, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "GAT Nitraflex", Gains = 160, Experience = 80, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "BPI 1MR Vortex", Gains = 180, Experience = 80, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Pumpers", Gains = 300, Experience = 100, Probability = 110 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Jack3d: The Banned King of Them All", Gains = 300, Experience = 100, Probability = 80 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Anadrol", Gains = 400, Experience = 150, Probability = 200 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Roids.", Gains = 500, Experience = 150, Probability = 150 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Deca-durabolin", Gains = 1000, Experience = 200, Probability = 100 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "EPO", Gains = 60000, Experience = 1500, Probability = 5 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Winstrol", Gains = 3000, Experience = 400, Probability = 30 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Dianabol", Gains = 2000, Experience = 350, Probability = 30 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Oxandrin", Gains = 20000, Experience = 1000, Probability = 10 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Jack3d: The Banned King of Them All", Gains = 30000, Experience = 1500, Probability = 10 });
        }

        public void GenerateNegativeGameEvents()
        {
            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Weight drop",
                Description = "As you are lifting, you get distracted by your phone and the weight drops on your foot",
                DefenseWithGearDescription = "Your special fitness shoes allows you and your weights to escape unscathed",
                DefenseWithoutGearDescription = "For some reason, you are lifting with bare feet, and the weight cracks your foot!",
                DefenseLoss = 2,
                Probability = 100
            });
            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Ripped pants",
                Description = "As you are lifting, you hear something rip between your legs!",
                DefenseWithGearDescription = "Luckily, you're just passing some gas from all the protein shakes, and nobody at the gym noticed",
                DefenseWithoutGearDescription = "You are lifting too much heavy weight, and you rip your pants",
                DefenseLoss = 3,
                Probability = 50
            });
            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Protein shake dropped",
                Description = "As you are lifting, you accidentally knock over your protein shake",
                DefenseWithGearDescription = "Luckily the protein shake lands directly on it's bottom and stays upright, so much luck",
                DefenseWithoutGearDescription = "The protein shake drops and spills all over the floor, the gym manager is not amused",
                DefenseLoss = 2,
                Probability = 100
            });
            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Muscle sprain",
                Description = "As you are lifting, you feel a twitch in your back",
                DefenseWithGearDescription = "You invested in a very good lifting belt, and it keeps you from hurting your back",
                DefenseWithoutGearDescription = "You didn't want to pay for good equipment, so now you are on your way to the doctor",
                DefenseLoss = 3,
                Probability = 50
            });
        }

        private void GenerateAttackItems()
        {
            Items.Add(new Item { Name = "Whey Isolate", Attack = 50, Price = 50, ImageUrl = "https://xxlnutrition.com/media/catalog/product/cache/73fb52fa48b4d85cd19815f9f841ae49/w/h/whey_isolate_1kg__2021__1_5.png"});
            Items.Add(new Item { Name = "Naked Whey", Attack = 300, Price = 300, ImageUrl = "https://adaoklneoo.cloudimg.io/v7/cdn.shopify.com/s/files/1/0645/6465/products/grass-fed-whey-protein-powder_1024x1024.jpg?v=1613950823"});
            Items.Add(new Item { Name = "Anabolic Whey", Attack = 500, Price = 500, ImageUrl = "https://gymbeam.com/media/catalog/product/cache/926507dc7f93631a094422215b778fe0/m/o/monsterwhey_2000g_w_1677_l_2.jpg"});
            Items.Add(new Item { Name = "Mutant Mass", Attack = 5000, Price = 15000, ImageUrl = "https://5.imimg.com/data5/VJ/PE/MY-41800760/mutant-muscle-mass-gainer-500x500.jpg"});
            Items.Add(new Item { Name = "The Ripper...", Attack = 50, Price = 1000000, ImageUrl = "https://media.s-bol.com/Lg58v8ZB4zqD/550x580.jpg"});
        }

        private void GenerateDefenseItems()
        {
            Items.Add(new Item { Name = "Push Harder", Defense = 20, Price = 20, ImageUrl = "https://cdn.shopify.com/s/files/1/1655/5199/products/Push-Harder-Shirt-Dedicated_2048x.png?v=1481699119"});
            Items.Add(new Item { Name = "Leather Gloves", Defense = 150, Price = 200, ImageUrl = "https://img.joomcdn.net/c85f4ed1b6645b619ce379cc642b344ea56ceaac_original.jpeg"});
            Items.Add(new Item { Name = "Lifting Shoes", Defense = 500, Price = 1000, ImageUrl = "https://ae01.alicdn.com/kf/H2242a2306bd84e8e89163fb6777cdfb6p/Professional-Weightlifting-Shoes-Weight-Lifting-Shoe-Hightop-Gym-Training-Bodybuilding-Suqte-Power-Lifting-High-Tops.jpg_640x640.jpg"});
            Items.Add(new Item { Name = "Knee Sleeves", Defense = 2000, Price = 10000, ImageUrl = "https://cdn.shopify.com/s/files/1/0509/2071/8486/products/A3A0161-Edit_2048x2048.jpg?v=1623877483"});
            Items.Add(new Item { Name = "Lifting Straps", Defense = 2000, Price = 10000, ImageUrl = "https://media.s-bol.com/qQ614gZ9A33R/1124x1200.jpg"});
            Items.Add(new Item { Name = "Power Belt", Defense = 20000, Price = 10000, ImageUrl = "https://cdn.shopify.com/s/files/1/0560/0323/1943/products/1_Genuine-Leather-Weightlifting-Belt-Weight-Lifting-Back-Support-Power-Training-Belt-GYM-Fitness-Equipment-Workout-Exercise_590x_9309854d-dd99-4f1c-af2c-c9b9b2829ff0.png?v=1617730334"});
        }

        private void GenerateFoodItems()
        {
            Items.Add(new Item { Name = "Banana", ActionCooldownSeconds = 50, Fuel = 4, Price = 8, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/8a/Banana-Single.jpg"});
            Items.Add(new Item { Name = "Energy Bar", ActionCooldownSeconds = 45, Fuel = 5, Price = 10, ImageUrl = "https://www.bodymassnutrition.com/wp-content/uploads/2020/02/Energybar-nieuw.png"});
            Items.Add(new Item { Name = "Pre Made Meal", ActionCooldownSeconds = 30, Fuel = 30, Price = 300, ImageUrl = "https://mepmeals.com/data/meals/33.jpg?md=17eb6224c2fbfbe032854eacce9b435b"});
            Items.Add(new Item { Name = "High Protein Bar", ActionCooldownSeconds = 25, Fuel = 100, Price = 500, ImageUrl = "https://gymbeam.com/media/catalog/product/l/o/low-carb-high-protein-bar-latte-machiato.png"});
            Items.Add(new Item { Name = "Energy Drink", ActionCooldownSeconds = 25, Fuel = 100, Price = 500, ImageUrl = "https://www.asianfoodlovers.be/media/catalog/product/cache/9/image/750x750/9df78eab33525d08d6e5fb8d27136e95/1/1/11671_5.jpg"});
            Items.Add(new Item { Name = "Daily Meal Delivery", ActionCooldownSeconds = 15, Fuel = 500, Price = 10000, ImageUrl = "https://www.fuelyourbody.be/media/catalog/product/cache/a933d7a3783b8d88651fdd9da06e3ec3/c/h/chicken-variation-mix-pack.jpg"});
        }

        private void GenerateDecorativeItems()
        {
            Items.Add(new Item { Name = "Vegan Protein", Description = "Does nothing. Do you feel special now?", Price = 10, ImageUrl = "https://s1.thcdn.com/productimg/300/300/11654583-9984622705420877.jpg"});
            Items.Add(new Item { Name = "Tank Top Flexing", Description = "For those who cannot afford the Crown of Flexing.", Price = 100000, ImageUrl = "https://ae01.alicdn.com/kf/Hb1e16449b99b4271a7e1948b1d1ac4f6v/4-Colors-Men-Gym-Stringer-Tank-Top-Sleeveless-Bodybuilding-Fitness-Singlets-Muscle-Vest-Tee-Outfits-M.jpg"});
            Items.Add(new Item { Name = "Crown of Flexing", Description = "Yes, show everyone how much money you are willing to spend on something useless!", Price = 500000, ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTnZ78A0EUG_ukhgMmzjcWhlLqJKdlrUgR7fCU9kFmIkUChNZHAAd17iTIimUod3AIdWLo&usqp=CAU"});
        }

    }
}
