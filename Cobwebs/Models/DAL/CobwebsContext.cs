using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Cobwebs.Models.DAL
{
    public class CobwebsContext : DbContext
    {
        public DbSet<AlertBot> AlertBots { get; set; }
        public DbSet<AutoAccount> AutoAccounts { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<AvatarTask> AvatarTasks { get; set; }
        public DbSet<AvatarNote> AvatarNotes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Target> Targets { get; set; }
        public DbSet<AvatarAccount> AvatarAccounts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
           //TODO clean
        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(
                x => x.Entity is BaseEntity
                    && (x.State == EntityState.Added || x.State == EntityState.Modified));

            //TODO get current user name...

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).DateCreated = DateTime.Now;
                    //TODO set usercreated to current user
                }

                ((BaseEntity)entity.Entity).DateModified = DateTime.Now;
                //TODO set modidfieduser to current user
            }

            return base.SaveChanges();
        }
    }

    public class CobwebsInitializer : DropCreateDatabaseAlways<CobwebsContext>
    {
        protected override void Seed(CobwebsContext context)
        {
            CreateProjectData(context);
            CreateAvatarData(context);
            CreateTargetData(context);
            CreateTaskData(context);
            CreateNoteData(context);
            CreateAlertBotData(context);
            CreateAutoAccountData(context);
            CreateAvatarAccountData(context);
        }

        private List<Project> CreateProjectData(CobwebsContext context)
        {
            var projects = new List<Project>
            {
                new Project{
                    ID = 1,
                    Name = "Project 1",
                    Description = "A project",
                },
                new Project{
                    ID = 2,
                    Name = "Project 2",
                    Description = "Another project",
                },
            };
            projects.ForEach(p => context.Projects.Add(p));
            context.SaveChanges();
            return projects;
        }

        private List<Avatar> CreateAvatarData(CobwebsContext context)
        {
            var avatars = new List<Avatar>
            {
                new Avatar{
                    ID = 11,
                    ProjectID = 1,
                    FirstName = "Ronald",
                    LastName = "White",
                    Gender = Gender.Male,
                    AvatarType = AvatarType.Main
                },
                new Avatar{
                    ID = 12,
                    ProjectID = 1,
                    FirstName = "Gregory",
                    LastName = "Stocks",
                    Gender = Gender.Male,
                    AvatarType = AvatarType.Sub
                },
                new Avatar{
                    ID = 21,
                    ProjectID = 2,
                    FirstName = "Alyssa",
                    LastName = "Guerin",
                    Gender = Gender.Female,
                    AvatarType = AvatarType.Sub
                },
                new Avatar{
                    ID = 22,
                    ProjectID = 2,
                    FirstName = "John",
                    LastName = "Burks",
                    Gender = Gender.Male,
                    AvatarType = AvatarType.Main
                },
                new Avatar{
                    ID = 13,
                    ProjectID = 1,
                    FirstName = "Andrew",
                    LastName = "Tran",
                    Gender = Gender.Male,
                    AvatarType = AvatarType.Main
                },
                new Avatar{
                    ID = 14,
                    ProjectID = 1,
                    FirstName = "Karen",
                    LastName = "Gillmore",
                    Gender = Gender.Female,
                    AvatarType = AvatarType.Main
                }


            };
            avatars.ForEach(p => context.Avatars.Add(p));
            context.SaveChanges();
            return avatars;
        }

        private List<Target> CreateTargetData(CobwebsContext context)
        {
            var targets = new List<Target>
            {
                new Target {
                    ID = 1,
                    ProjectID = 1,
                    Name = "Mary Harris",
                },
                new Target {
                    ID = 2,
                    ProjectID = 1,
                    Name = "Katherine Young",
                },
                new Target {
                    ID = 3,
                    ProjectID = 2,
                    Name = "Aaron Williams",
                },
                new Target {
                    ID = 4,
                    ProjectID = 2,
                    Name = "Ashley Jones",
                }
            };
            targets.ForEach(p => context.Targets.Add(p));
            context.SaveChanges();
            return targets;
        }

        private List<AvatarTask> CreateTaskData(CobwebsContext context)
        {
            var tasks = new List<AvatarTask>
            {
                new AvatarTask{
                    Title = "Todo 1",
                    AvatarID = 11,
                    Content = "Some Content",
                    ScheduledDate = new DateTime(year:2015, month:1, day:14)
                },
                new AvatarTask{
                    Title = "Todo 2",
                    AvatarID = 12,
                    Content = "Some Content",
                    ScheduledDate = new DateTime(year:2020, month:4, day:20)
                },
                new AvatarTask{
                    Title = "Todo 3",
                    AvatarID = 13,
                    Content = "Some Content",
                    ScheduledDate = new DateTime(year:2016, month:1, day:1)

                },
                new AvatarTask{
                    Title = "Todo 4",
                    AvatarID = 14,
                    Content = "Some Content",
                    ScheduledDate = new DateTime(year:2015, month:12, day:18)
                },
                new AvatarTask{
                    Title = "Todo 5",
                    AvatarID = 21,
                    Content = "Some Content",
                    ScheduledDate = new DateTime(year:2015, month:7, day:18)
                },
                new AvatarTask{
                    Title = "Todo 6",
                    AvatarID = 22,
                    Content = "Some Content",
                    ScheduledDate = new DateTime(year:2015, month:2, day:2)
                },
                new AvatarTask{
                    Title = "Todo 7",
                    AvatarID = 12,
                    Content = "Some Content",
                    ScheduledDate = new DateTime(year:2015, month:3, day:10)
                },
            };
            tasks.ForEach(p => context.AvatarTasks.Add(p));
            context.SaveChanges();
            return tasks;
        }

        private List<AvatarNote> CreateNoteData(CobwebsContext context)
        {
            var notes = new List<AvatarNote>
            {
                new AvatarNote{
                    AvatarID = 11,
                    Content = "Note 1",
                },
                new AvatarNote{
                    AvatarID = 12,
                    Content = "Note 2",
                },
                new AvatarNote{
                    AvatarID = 13,
                    Content = "Note 3",
                },
                new AvatarNote{
                    AvatarID = 14,
                    Content = "Note 4",
                },
                new AvatarNote{
                    AvatarID = 21,
                    Content = "Note 5",
                },
                new AvatarNote{
                    AvatarID = 22,
                    Content = "Note 6",
                },
                new AvatarNote{
                    AvatarID = 11,
                    Content = "Note 7",
                },
                new AvatarNote{
                    AvatarID = 11,
                    Content = "Note 8",
                },
                new AvatarNote{
                    AvatarID = 12,
                    Content = "Note 9",
                },
            };
            notes.ForEach(p => context.AvatarNotes.Add(p));
            context.SaveChanges();
            return notes;
        }

        private List<AlertBot> CreateAlertBotData(CobwebsContext context)
        {
            var bots = new List<AlertBot>
            {
                new AlertBot{
                    ID = 1,
                    Name = "Facebook"
                },
                new AlertBot{
                    ID = 2,
                    Name = "Twitter"
                }
            };
            bots.ForEach(p => context.AlertBots.Add(p));
            context.SaveChanges();
            return bots;
        }

        private List<AutoAccount> CreateAutoAccountData(CobwebsContext context)
        {
            var accounts = new List<AutoAccount>
            {
                new AutoAccount {
                    Username = "fara",
                    Password = "1234",
                    AlertBotID = 1,
                    Schedule = "Some schedule"
                },
                new AutoAccount {
                    Username = "gfr",
                    Password = "12345",
                    AlertBotID = 2,
                    Schedule = "Some schedule"
                }
            };
            accounts.ForEach(p => context.AutoAccounts.Add(p));
            context.SaveChanges();
            return accounts;
        }

        private List<AvatarAccount> CreateAvatarAccountData(CobwebsContext context)
        {
            var accounts = new List<AvatarAccount>
            {
                new AvatarAccount{
                    AvatarID = 11,
                    Username = "oshik",
                    Password = "blabla",
                    Url = "www.facebook.com"
                },
                new AvatarAccount{
                    AvatarID = 21,
                    Username = "tilber",
                    Password = "req",
                    Url = "www.forum.com"
                }
            };
            accounts.ForEach(p => context.AvatarAccounts.Add(p));
            context.SaveChanges();
            return accounts;
        }
    }
}