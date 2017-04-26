namespace ITsoft.Infrastructure.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Url = c.String(),
                        Module = c.String(),
                        SortOrder = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        ActionUrl = c.String(),
                        SortOrder = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Menu_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.Menu_Id, cascadeDelete: true)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        SortOrder = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        RoleGroup_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoleGroup", t => t.RoleGroup_Id, cascadeDelete: true)
                .Index(t => t.RoleGroup_Id);
            
            CreateTable(
                "dbo.RoleGroup",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        SortOrder = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        LoginName = c.String(),
                        LoginPwd = c.String(),
                        PwdSalt = c.String(),
                        Email = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastLoginToken = c.String(),
                        LastLogin = c.DateTime(nullable: false),
                        Role_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Role_Permission",
                c => new
                    {
                        Role_Id = c.Guid(nullable: false),
                        Permission_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Permission_Id })
                .ForeignKey("dbo.Role", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Permission", t => t.Permission_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Permission_Id);
            
            CreateTable(
                "dbo.RoleGroup_User",
                c => new
                    {
                        User_Id = c.Guid(nullable: false),
                        RoleGroup_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.RoleGroup_Id })
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.RoleGroup", t => t.RoleGroup_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.RoleGroup_Id);
            
            CreateTable(
                "dbo.User_Permission",
                c => new
                    {
                        User_Id = c.Guid(nullable: false),
                        Permission_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Permission_Id })
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Permission", t => t.Permission_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Permission_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Permission", "Menu_Id", "dbo.Menu");
            DropForeignKey("dbo.User", "Role_Id", "dbo.Role");
            DropForeignKey("dbo.Role", "RoleGroup_Id", "dbo.RoleGroup");
            DropForeignKey("dbo.User_Permission", "Permission_Id", "dbo.Permission");
            DropForeignKey("dbo.User_Permission", "User_Id", "dbo.User");
            DropForeignKey("dbo.RoleGroup_User", "RoleGroup_Id", "dbo.RoleGroup");
            DropForeignKey("dbo.RoleGroup_User", "User_Id", "dbo.User");
            DropForeignKey("dbo.Role_Permission", "Permission_Id", "dbo.Permission");
            DropForeignKey("dbo.Role_Permission", "Role_Id", "dbo.Role");
            DropIndex("dbo.User_Permission", new[] { "Permission_Id" });
            DropIndex("dbo.User_Permission", new[] { "User_Id" });
            DropIndex("dbo.RoleGroup_User", new[] { "RoleGroup_Id" });
            DropIndex("dbo.RoleGroup_User", new[] { "User_Id" });
            DropIndex("dbo.Role_Permission", new[] { "Permission_Id" });
            DropIndex("dbo.Role_Permission", new[] { "Role_Id" });
            DropIndex("dbo.User", new[] { "Role_Id" });
            DropIndex("dbo.Role", new[] { "RoleGroup_Id" });
            DropIndex("dbo.Permission", new[] { "Menu_Id" });
            DropTable("dbo.User_Permission");
            DropTable("dbo.RoleGroup_User");
            DropTable("dbo.Role_Permission");
            DropTable("dbo.User");
            DropTable("dbo.RoleGroup");
            DropTable("dbo.Role");
            DropTable("dbo.Permission");
            DropTable("dbo.Menu");
        }
    }
}
