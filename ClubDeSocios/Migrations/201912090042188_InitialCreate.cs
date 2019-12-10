namespace ClubDeSocios.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afiliado",
                c => new
                    {
                        AfiliadoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Edad = c.Int(nullable: false),
                        Sexo = c.Int(nullable: false),
                        Direccion = c.String(nullable: false),
                        Telefono = c.String(),
                        SocioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AfiliadoID)
                .ForeignKey("dbo.Socio", t => t.SocioID, cascadeDelete: true)
                .Index(t => t.SocioID);
            
            CreateTable(
                "dbo.Socio",
                c => new
                    {
                        SocioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellidos = c.String(nullable: false),
                        Cedula = c.String(nullable: false),
                        Foto = c.Binary(),
                        Direccion = c.String(nullable: false),
                        TelefonoCelularFax = c.String(),
                        Sexo = c.Int(nullable: false),
                        Edad = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        TipoMembresia = c.String(nullable: false),
                        LugarTrabajo = c.String(nullable: false),
                        DireccionOficina = c.String(nullable: false),
                        TelefonoOficina = c.String(nullable: false),
                        EstadoMembresia = c.Boolean(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        FechaSalida = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SocioID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Afiliado", "SocioID", "dbo.Socio");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Afiliado", new[] { "SocioID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Socio");
            DropTable("dbo.Afiliado");
        }
    }
}
