namespace Tmdb.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SavedMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SavedMovies",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        Title = c.String(),
                        Year = c.String(),
                        ImageUrl = c.String(),
                        Overview = c.String(),
                    })
                .PrimaryKey(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SavedMovies");
        }
    }
}
