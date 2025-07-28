using SlimeAdventure.Data;

using var db = new GameDbContext();
db.Database.EnsureCreated();

var engine = new GameEngine(db);
engine.Start();