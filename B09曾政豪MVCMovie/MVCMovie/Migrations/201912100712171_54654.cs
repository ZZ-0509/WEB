namespace MVCMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _54654 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        MovieName = c.String(nullable: false),
                        Director = c.String(),
                        MovieLength = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Region = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MovieTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId)
                .ForeignKey("dbo.MovieTypes", t => t.MovieTypeId, cascadeDelete: true)
                .Index(t => t.MovieTypeId);
            
            CreateTable(
                "dbo.MovieTypes",
                c => new
                    {
                        MovieTypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.MovieTypeId);
            
            CreateTable(
                "dbo.Prizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Period = c.String(),
                        StarTime = c.DateTime(nullable: false),
                        Sponsor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PrizeMovies",
                c => new
                    {
                        Prize_Id = c.Int(nullable: false),
                        Movie_MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Prize_Id, t.Movie_MovieId })
                .ForeignKey("dbo.Prizes", t => t.Prize_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId, cascadeDelete: true)
                .Index(t => t.Prize_Id)
                .Index(t => t.Movie_MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrizeMovies", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.PrizeMovies", "Prize_Id", "dbo.Prizes");
            DropForeignKey("dbo.Movies", "MovieTypeId", "dbo.MovieTypes");
            DropIndex("dbo.PrizeMovies", new[] { "Movie_MovieId" });
            DropIndex("dbo.PrizeMovies", new[] { "Prize_Id" });
            DropIndex("dbo.Movies", new[] { "MovieTypeId" });
            DropTable("dbo.PrizeMovies");
            DropTable("dbo.Prizes");
            DropTable("dbo.MovieTypes");
            DropTable("dbo.Movies");
        }
    }
}
