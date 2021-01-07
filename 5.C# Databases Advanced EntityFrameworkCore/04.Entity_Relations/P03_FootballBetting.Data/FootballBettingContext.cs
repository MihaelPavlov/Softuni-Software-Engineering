using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {

        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions<FootballBettingContext> option)
            : base(option)
        {

        }

        //table
        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-0P0GI0P\SQLEXPRESS;Database=FootballBetting;Integrated Security=true;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //Team
            builder
                .Entity<Team>(entity =>
                {
                    entity
                    .HasKey(t => t.TeamId);

                    entity
                    .Property(t => t.Name)
                    .HasMaxLength(50);

                    //Foreign Key Team.TownId=>Towns
                    entity
                    .HasOne(t => t.Town)
                    .WithMany(t => t.Teams)
                    .HasForeignKey(t => t.TownId)
                    .OnDelete(DeleteBehavior.Restrict);

                    //Foreign Key Team.PrimaryKitColor=> Color.PrimaryKitTeams
                    entity
                    .HasOne(t => t.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                    //Foreign Key Team.SecondaryKitColor=> Color.SecondaryKitTeams
                    entity
                    .HasOne(t => t.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitTeams)
                    .HasForeignKey(t => t.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                });

            //Game

            builder
                .Entity<Game>(entity =>
                {
                    entity
                    .HasKey(g => g.GameId);


                    //Foreign Key Game.HomeTeam => Team.HomeGames
                    entity
                    .HasOne(g => g.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                    //Foreign Key Game.AwayTeam => Team.AwayTeams
                    entity
                    .HasOne(g => g.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                });

            //country
            builder
                .Entity<Country>(entity =>
                {
                    entity
                    .HasKey(c => c.CountryId);

                    entity
                     .Property(c => c.Name)
                     .HasMaxLength(50);

                });

            //Town
            builder
                .Entity<Town>(entity =>
                {
                    entity
                    .HasKey(t => t.TownId);

                    entity
                    .Property(t => t.Name)
                    .HasMaxLength(50);

                    //Foreign Key Town.Country => Country.Towns
                    //Town With One Country ... Country With Many Towns
                    entity
                    .HasOne(t => t.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(t => t.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);
                });

            //Color

            builder
                .Entity<Color>(entity =>
                {
                    entity
                    .HasKey(c => c.ColorId);

                    entity
                    .Property(c => c.Name)
                    .HasMaxLength(50);
                });

            //User

            builder
                .Entity<User>(entity =>
                {
                    entity
                    .HasKey(u => u.UserId);

                    entity
                    .Property(u => u.Username)
                    .HasMaxLength(50);

                    entity
                    .Property(u => u.Name)
                    .HasMaxLength(50);


                });

            //Bet

            builder
                .Entity<Bet>(entity =>
                {
                    entity
                    .HasKey(b => b.BetId);

                    entity
                    .Property(b => b.Prediction).IsRequired();


                    //Foreign Kye Bet.Game => Game.Bets
                    
                    entity
                    .HasOne(b => b.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(b => b.GameId)
                    .OnDelete(DeleteBehavior.Restrict);

                    entity
                    .HasOne(b => b.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                    

                });

            //Position

            builder
                .Entity<Position>(entity =>
                {
                    entity
                    .HasKey(p => p.PositionId);

                    entity
                    .Property(p => p.Name)
                    .HasMaxLength(50);

                });

            //Player

            builder
                .Entity<Player>(entity =>
                {
                    entity
                    .HasKey(p => p.PlayerId);

                    entity
                    .Property(p => p.Name)
                    .HasMaxLength(50);

                    //Foreign Key Player.Team => Team.Player
                    //Player Has One Team ... Team With Many Players
                    entity
                    .HasOne(p => p.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(p => p.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                    //Foreign Key Player.Position => Position.Players
                    entity
                       .HasOne(p => p.Position)
                       .WithMany(p => p.Players)
                       .HasForeignKey(p => p.PositionId)
                       .OnDelete(DeleteBehavior.Restrict);


                });

            //PlayerStatistic

            builder
                .Entity<PlayerStatistic>(entity =>
                {
                    entity
                    .HasKey(ps => new { ps.PlayerId, ps.GameId });

                    //Foreign Key PlayerStatistic.Player => Player.PlayerStatistics
                    entity
                    .HasOne(p => p.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(p => p.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict);

                    //Foreign Key PlayerStatistic.Game => Game.PlayerStatistics
                    entity
                    .HasOne(p => p.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(p => p.GameId)
                    .OnDelete(DeleteBehavior.Restrict);
                });
        }
    }
}
