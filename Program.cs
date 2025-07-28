using SlimeAdventure.Data;

using var db = new GameDbContext();
db.Database.EnsureCreated();

Seeder.Seed(db);

var engine = new GameEngine(db);
engine.Start();