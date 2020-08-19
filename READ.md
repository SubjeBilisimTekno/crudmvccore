> Written with [StackEdit](https://stackedit.io/).
# **CrudWithAspNetCore**

1 -  Create a DB with **SSMS**

>CREATE TABLE [dbo].[Beacons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mac] [int] NULL,
	[Type] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[Location] [nvarchar](100) NULL,
	[Date] [nvarchar](100) NULL,
	[rssi1] [int] NULL,
	[rssi2] [int] NULL,
	[rssi3] [int] NULL,
	[rssi4] [int] NULL,
 CONSTRAINT [PK_Beacons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

2- Create an Asp.Net Core with **Visual Studio**

3- Visual Studio **Package Manager Console**

--> Install-Package Microsoft.EntityFrameworkCore.SqlServer
--> Install-Package Microsoft.EntityFrameworkCore.Tools
--> Install-Package Microsoft.EntityFrameworkCore.SqlServer
--> Scaffold-DbContext “Server=localhost;Database=DashboardDB;Trusted_Connection=True;” Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables Beacons

4- remove this **OnConfiguring** method from context file(DashboardDBContext)

5- move the connection string to the **appsettings.json** file
>"ConnectionStrings" : {
"DashboardDatabase" : Server=localhost;Database=DashboardDB;Trusted_Connection=True;
}

6- register the database context service (**DashboardDBContext**) during application startup , the connection string is read from the **appsettings** file and passed to the context service with adding this to ConfigureServices method :
>var connection = Configuration.GetConnectionString("DashboardDatabase");
            services.AddDbContext<DashboardDBContext>(options => options.UseSqlServer(connection));
            
this context service is injected with the required controllers via dependency injection
            
7- add new controller **MVC Controller with views, using Entity Framework** to Controller ,choose a database **model class** and **data context class**, which were created earlier

8- change default application route to BeaconsController instead of HomeController 
> app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Beacons}/{action=Index}/{id?}");
            });

9- force to scaffold for adding a second model class:

>PM> Scaffold-DbContext “Server=localhost;Database=DashboardDB;Trusted_Connection=True;” Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Tables Gateways -force

10- add new tables in SSMS

>CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,	
	[Name] [nvarchar](100) NULL,
	
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,	
	[Name] [nvarchar](100) NULL,
	[Location] [nvarchar](100) NULL,	
	[Phone] [int] NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]