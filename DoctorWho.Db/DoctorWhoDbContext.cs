using DoctorWho.Domain;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class DoctorWhoDbContext : DbContext
    {
        public static DoctorWhoDbContext context = new DoctorWhoDbContext();
        public DbSet<Author> Authors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        public DbSet<EpisodeView> ViewEpisodes { get; set; }
        public DbSet<CompanionsSProc> ThreeMostFrequentlyAppearingCompanions { get; set; }
        public DbSet<EnemiesSProc> ThreeMostFrequentlyAppearingEnemies { get; set; }

        //CLR methods
        public string Companions_Function(int EpisodeId) => throw new NotSupportedException();
        public string Enemies_Function(int EpisodeId) => throw new NotSupportedException();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                 @"Server=DESKTOP-LQ3BMKQ;Database=DoctorWhoCore;Trusted_Connection=True;TrustServerCertificate=Yes"
            );
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Author Constraints
            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).IsRequired();

            //Seeding Author Table
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, AuthorName = "Chris Chibnall" },
                new Author { AuthorId = 2, AuthorName = "Gareth Roberts" },
                new Author { AuthorId = 3, AuthorName = "Helen Raynor" },
                new Author { AuthorId = 4, AuthorName = "James Moran" },
                new Author { AuthorId = 5, AuthorName = "James Strong" }
                );

            //Companion Constraints
            modelBuilder.Entity<Companion>().HasKey(c => c.CompanionId);
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).IsRequired();
            modelBuilder.Entity<Companion>().Property(c => c.WhoPlayed).IsRequired();

            //Seeding Companion Table
            modelBuilder.Entity<Companion>().HasData(
                new Companion { CompanionId = 1, CompanionName = "River Song", WhoPlayed = "Alex Kingston" },
                new Companion { CompanionId = 2, CompanionName = "Rory Williams", WhoPlayed = "Arthur Darvill" },
                new Companion { CompanionId = 3, CompanionName = "Wilfred Mott", WhoPlayed = "Bernard Cribbins" },
                new Companion { CompanionId = 4, CompanionName = "Rose Tyler", WhoPlayed = "Billie Piper" },
                new Companion { CompanionId = 5, CompanionName = "James Strong", WhoPlayed = "Bruno Langley" }
                );

            //Doctor Constraints
            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorId).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.BirthDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.FirstEpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.LastEpisodeDate).HasDefaultValueSql("NULL");

            //Seeding Doctor Table
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    DoctorId = 1,
                    DoctorNumber = 9,
                    DoctorName = "Christopher Eccleston",
                    BirthDate = new DateTime(1964, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    FirstEpisodeDate = new DateTime(2005, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    LastEpisodeDate = new DateTime(2005, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified)
                },
                new Doctor
                {
                    DoctorId = 2,
                    DoctorNumber = 6,
                    DoctorName = "Colin Baker",
                    BirthDate = new DateTime(1943, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    FirstEpisodeDate = new DateTime(1984, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    LastEpisodeDate = new DateTime(1986, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                },
                new Doctor
                {
                    DoctorId = 3,
                    DoctorNumber = 10,
                    DoctorName = "David Tennant",
                    BirthDate = new DateTime(1971, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    FirstEpisodeDate = new DateTime(2005, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    LastEpisodeDate = new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                },
                new Doctor
                {
                    DoctorId = 4,
                    DoctorNumber = 3,
                    DoctorName = "Jon Pertwee",
                    BirthDate = new DateTime(1930, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    FirstEpisodeDate = new DateTime(1970, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    LastEpisodeDate = new DateTime(1974, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                },
                new Doctor
                {
                    DoctorId = 5,
                    DoctorNumber = 11,
                    DoctorName = "Matt Smith",
                    BirthDate = new DateTime(1982, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    FirstEpisodeDate = new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    LastEpisodeDate = new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                });

            //Enemy Constraints
            modelBuilder.Entity<Enemy>().HasKey(e => e.EnemyId);
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).IsRequired();
            modelBuilder.Entity<Enemy>().Property(e => e.Description).HasDefaultValueSql("NULL");

            //Seeding Enemy Table
            modelBuilder.Entity<Enemy>().HasData(
                new Enemy { EnemyId = 1, EnemyName = "The Autons", Description = "Murderous mannequins" },
                new Enemy { EnemyId = 2, EnemyName = "Lady Cassandra", Description = "The last living human being" },
                new Enemy { EnemyId = 3, EnemyName = "The Gelth", Description = "An alien species comprised of gas" },
                new Enemy { EnemyId = 4, EnemyName = "The Slitheen", Description = "A baby-faced alien family" },
                new Enemy { EnemyId = 5, EnemyName = "Daleks", Description = "Armoured aliens" }
                );

            //Episode Constraints
            modelBuilder.Entity<Episode>().HasKey(e => e.EpisodeId);
            modelBuilder.Entity<Episode>().Property(e => e.SeriesNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.Title).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Episode>().Property(e => e.Notes).HasDefaultValueSql("NULL");

            //Seeding Episode Table
            modelBuilder.Entity<Episode>().HasData(
                new Episode
                {
                    EpisodeId = 1,
                    SeriesNumber = 1,
                    EpisodeNumber = 1,
                    EpisodeType = "Normal episode",
                    Title = "Rose",
                    EpisodeDate = new DateTime(2005, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    AuthorId = 1,
                    DoctorId = 1,
                    Notes = ""
                },
                new Episode
                {
                    EpisodeId = 2,
                    SeriesNumber = 1,
                    EpisodeNumber = 2,
                    EpisodeType = "Normal episode",
                    Title = "The End of the World",
                    EpisodeDate = new DateTime(2005, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    AuthorId = 2,
                    DoctorId = 2,
                    Notes = ""
                },
                new Episode
                {
                    EpisodeId = 3,
                    SeriesNumber = 1,
                    EpisodeNumber = 3,
                    EpisodeType = "Normal episode",
                    Title = "The Unquiet Dead",
                    EpisodeDate = new DateTime(2005, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    AuthorId = 3,
                    DoctorId = 3,
                    Notes = ""
                },
                new Episode
                {
                    EpisodeId = 4,
                    SeriesNumber = 1,
                    EpisodeNumber = 4,
                    EpisodeType = "Normal episode",
                    Title = "Aliens of London (Part 1)",
                    EpisodeDate = new DateTime(2005, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    AuthorId = 4,
                    DoctorId = 4,
                    Notes = ""
                },
                new Episode
                {
                    EpisodeId = 5,
                    SeriesNumber = 1,
                    EpisodeNumber = 5,
                    EpisodeType = "Normal episode",
                    Title = "World War Three (Part 2)",
                    EpisodeDate = new DateTime(2005, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    AuthorId = 5,
                    DoctorId = 5,
                    Notes = ""
                }
                );

            //EpisodeCompanion Constraints
            modelBuilder.Entity<EpisodeCompanion>().HasKey(ec => ec.CompanionId);
            modelBuilder.Entity<EpisodeCompanion>()
                .HasOne(ec => ec.Companion)
                .WithMany(e => e.EpisodeCompanions)
                .HasForeignKey(ec => ec.CompanionId);
            modelBuilder.Entity<EpisodeCompanion>()
                .HasOne(ec => ec.Episode)
                .WithMany(e => e.EpisodeCompanions)
                .HasForeignKey(ec => ec.EpisodeId);

            //Seeding EpisodeCompanion Table
            modelBuilder.Entity<EpisodeCompanion>().HasData(
                new EpisodeCompanion { EpisodeCompanionId = 1, CompanionId = 1, EpisodeId = 1 },
                new EpisodeCompanion { EpisodeCompanionId = 2, CompanionId = 2, EpisodeId = 2 },
                new EpisodeCompanion { EpisodeCompanionId = 3, CompanionId = 3, EpisodeId = 3 },
                new EpisodeCompanion { EpisodeCompanionId = 4, CompanionId = 4, EpisodeId = 4 },
                new EpisodeCompanion { EpisodeCompanionId = 4, CompanionId = 5, EpisodeId = 5 }
                );

            //EpisodeEnemy Constraints
            modelBuilder.Entity<EpisodeEnemy>().HasKey(ee => ee.EpisodeEnemyId);
            modelBuilder.Entity<EpisodeEnemy>()
                .HasOne(ee => ee.Enemy)
                .WithMany(e => e.EpisodeEnemies)
                .HasForeignKey(ee => ee.EnemyId);
            modelBuilder.Entity<EpisodeEnemy>()
                .HasOne(ee => ee.Episode)
                .WithMany(e => e.EpisodeEnemies)
                .HasForeignKey(ee => ee.EpisodeId);

            //Seeding EpisodeEnemy Table
            modelBuilder.Entity<EpisodeEnemy>().HasData(
                new EpisodeEnemy { EpisodeEnemyId = 1, EnemyId = 1, EpisodeId = 1 },
                new EpisodeEnemy { EpisodeEnemyId = 2, EnemyId = 2, EpisodeId = 2 },
                new EpisodeEnemy { EpisodeEnemyId = 3, EnemyId = 3, EpisodeId = 3 },
                new EpisodeEnemy { EpisodeEnemyId = 4, EnemyId = 4, EpisodeId = 4 },
                new EpisodeEnemy { EpisodeEnemyId = 5, EnemyId = 5, EpisodeId = 5 }
                );

            //Functions-View-SProc Constraint
            modelBuilder.HasDbFunction(typeof(DoctorWhoDbContext).GetMethod(nameof(Companions_Function), new[] { typeof(int) }))
                .HasName("fnCompanions");

            modelBuilder.HasDbFunction(typeof(DoctorWhoDbContext).GetMethod(nameof(Enemies_Function), new[] { typeof(int) }))
                .HasName("fnEnemies");

            modelBuilder.Entity<EpisodeView>().HasNoKey().ToView("ViewEpisodes");

            modelBuilder.Entity<CompanionsSProc>().HasNoKey();
            modelBuilder.Entity<EnemiesSProc>().HasNoKey();
        }
    }
}