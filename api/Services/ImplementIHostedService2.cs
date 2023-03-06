// using System.Threading.Tasks;
// using Hubs;
// using Microsoft.AspNetCore.SignalR;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Migrations;
// using Models;

// namespace Services
// {
//     // public class ImplementIHostedService : IHostedService
//     // {
//     //     public Task StartAsync(CancellationToken cancellationToken)
//     //     {
//     //         Task.Run(async () =>
//     //         {
//     //             while (!cancellationToken.IsCancellationRequested)
//     //             {
//     //                 Console.WriteLine($"Respponse from IHostedService - {DateTime.Now}");
//     //                 await Task.Delay(1000);
//     //             }
//     //         });
//     //     }

//     //     public Task StopAsync(CancellationToken cancellationToken)
//     //     {
//     //     }
//     // }

//     public class ImplementBackgroundService2 : BackgroundService
//     {

//         private List<string> mails = new List<string>();
//         int id = 0;
//         int idUser = 0;

//         private readonly IServiceProvider _serviceProvider;
//         private readonly IHubContext<ChatHub> _chatHub;

//         MigrationBuilder _migrationBuilder;
//         protected MyContext _context;
//         public ImplementBackgroundService2(IServiceProvider serviceProvider, IHubContext<ChatHub> chatHub
//         // , MigrationBuilder migrationBuilder
//         ) =>
//         (_serviceProvider, _chatHub
//         // , _migrationBuilder
//         ) = (serviceProvider, chatHub
//         // , migrationBuilder
//         );


//         protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//         {
//             await CreateAndPopulateTable();

//             // while (true)
//             // {
//             //     Console.WriteLine($"Respponse from Background Service - {DateTime.Now}");
//             //     await Task.Delay(1000);
//             // }
//         }

//         public async Task Start(int id, IFormFileCollection files, int idUser)
//         {
//             // try
//             // {
//             this.id = id;
//             this.idUser = idUser;
//             this.mails = await filesToList(files);

//             await this.StartAsync(CancellationToken.None);
//             // }
//             // catch (System.Exception e)
//             // {
//             //     await sendNotif($"Exception occured BackgroundService: {e.Message}");

//             //     Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
//             //     Console.WriteLine(e.Message);
//             //     Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
//             // }

//         }

//         private async Task<List<string>> filesToList(IFormFileCollection files)
//         {
//             var componentRecords = new List<dynamic>();

//             if (files.Count > 0)
//             {
//                 foreach (var file in files)
//                 {

//                     await using var ms = new MemoryStream();

//                     await file.CopyToAsync(ms);

//                     using var reader = new StreamReader(ms, true);

//                     var config = new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture) { Delimiter = ";", HasHeaderRecord = false };

//                     using var csv = new CsvHelper.CsvReader(reader, config);

//                     ms.Seek(0, SeekOrigin.Begin);

//                     componentRecords.AddRange(csv.GetRecords<dynamic>().ToList());
//                 }

//             }

//             return componentRecords.Select(e => e.Field1 as string).ToList();
//         }

//         private async Task CreateAndPopulateTable()
//         {
//             await using var scope = _serviceProvider.CreateAsyncScope();

//             _context = scope.ServiceProvider.GetRequiredService<MyContext>();


//             /*
//             *
//             */
//             var model = await _context.MailingLists.Where(e => e.Id == this.id).AsNoTracking().FirstOrDefaultAsync();

//             if (model == null)
//             {
//                 await sendNotif($"model of MailingLists is null");
//             }

//             await insertData2(model);

//             return;

//             await createTableIfNotExit(model.DataTableName);

//             await insertData(model);

//             /*
//             *
//             */
//             // await _context.MailingLists.Where(e => e.Id == this.id)
//             //     .ExecuteUpdateAsync(s => s.SetProperty(t => t.TotalEmails, t => t.TotalEmails + mails.Count));


//             /*
//             *
//             */
//             var message = $"Creation of {model.DataTableName} done, insert into {model.DataTableName} {mails.Count} records";

//             await sendNotif(message);
//         }

//         private async Task sendNotif(string message)
//         {
//             var connectionId = ConnectedUser.dict.Values.Where(e => e.IdUser == idUser).Select(e => e.ConnectionId).SingleOrDefault();

//             if (connectionId != null)
//             {
//                 await _chatHub.Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
//             }
//         }

//         private async Task insertData2(MailingList model)
//         {
//             _context._tableName = model.DataTableName;

//             _context.setTable(model.DataTableName);
            
//             try
//             {
//                 var m = new {
//                     Id = 0,
//                     ListId = 10,
//                     FirstName = "impossible",
//                 };

//                 var results2 = await _context.DSeedLists.FromSqlRaw(@"select * from D_my_table").ToListAsync();
//                 var results = await _context.AddAsync(m);

//                 await _context.SaveChangesAsync();
//             }
//             catch (System.Exception e)
//             {

//                 var i = e;
//             }


//         }
//         private async Task insertData(MailingList model)
//         {
//             /*
//             *
//             */
//             var insertionQuery = @$"insert into {model.DataTableName} (ListID,FirstName,LastName,Email,EmailMD5,OptInWebSite,AddOn
//             ,UpdatedOn,Region,RegionName,City,ZipCode,Country,isClean,isActive,isOpener,isClicker,isLeader,isUnsubscriber
//             ,isOptedOut,Verticals,TotalOpens,TotalClicks,TotalLeads,TotalUnsubscribes,Comments ) 
//             select 
//             ListID,FirstName,LastName,Email,EmailMD5,OptInWebSite,AddOn
//             ,UpdatedOn,Region,RegionName,City,ZipCode,Country,isClean,isActive,isOpener,isClicker,isLeader,isUnsubscriber
//             ,isOptedOut,Verticals,TotalOpens,TotalClicks,TotalLeads,TotalUnsubscribes,Comments 
//             from ( values
//             ";

//             mails.ForEach(e =>
//             {
//                 insertionQuery += $@"({model.Id}, '', '', '{e}', '{CreateMD5Hash(e)}', '', '{DateTime.Now}', '{DateTime.Now}', '', '', '', ''
//                 , '', 0, 0, 0, 0, 0, 0, 0, '', 0, 0 , 0, 0, ''),";
//             });

//             insertionQuery = insertionQuery.Remove(insertionQuery.Length - 1);
//             insertionQuery += @") x (ListID,FirstName,LastName,Email,EmailMD5,OptInWebSite,AddOn
//             ,UpdatedOn,Region,RegionName,City,ZipCode,Country,isClean,isActive,isOpener,isClicker,isLeader,isUnsubscriber
//             ,isOptedOut,Verticals,TotalOpens,TotalClicks,TotalLeads,TotalUnsubscribes,Comments )";

//             await _context.Database.ExecuteSqlRawAsync(insertionQuery);
//         }

//         private async Task createTable(string tableName) {

//             _migrationBuilder.CreateTable(
//                 name: tableName,
//                 columns: table => new
//                 {
//                     Id = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("SqlServer:Identity", "1, 1"),
//                     ListId = table.Column<int>(type: "int", nullable: true),
//                     FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                     LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                     Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                     EmailMd5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                     OptInWebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                     AddOn = table.Column<DateTime>(type: "datetime2", nullable: true),
//                     UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
//                     Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                     RegionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                     City = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                     ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                     Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                     IsClean = table.Column<bool>(type: "bit", nullable: true),
//                     IsActive = table.Column<bool>(type: "bit", nullable: true),
//                     IsOpener = table.Column<bool>(type: "bit", nullable: true),
//                     IsClicker = table.Column<bool>(type: "bit", nullable: true),
//                     IsLeader = table.Column<bool>(type: "bit", nullable: true),
//                     IsUnsubscriber = table.Column<bool>(type: "bit", nullable: true),
//                     IsOptedOut = table.Column<bool>(type: "bit", nullable: true),
//                     Verticals = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                     TotalOpens = table.Column<int>(type: "int", nullable: true),
//                     TotalClicks = table.Column<int>(type: "int", nullable: true),
//                     TotalLeads = table.Column<int>(type: "int", nullable: true),
//                     TotalUnsubscribes = table.Column<int>(type: "int", nullable: true),
//                     Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_DSeedLists", x => x.Id);
//                 });
//         }

//         private async Task createTableIfNotExit(string tableName)
//         {

//             /*
//            *
//            */
//             var tableExistQuery = @$"
//             SELECT COUNT(*) 
//             FROM sys.tables t 
//                 JOIN sys.schemas s ON (t.schema_id = s.schema_id) 
//             WHERE s.name = 'dbo' AND t.name = '{tableName}'
//             ";

//             var test = (await _context.Database.SqlQueryRaw<int>(tableExistQuery).ToListAsync()).First();

//             if (test > 0)
//             {
//                 await sendNotif($"{tableName} already exist");
//             }
//             else
//             {
//                 /*
//                 *
//                 */
//                 var creationQuery = @$"CREATE TABLE {tableName}(
//                     ID int IDENTITY(1,1) NOT NULL,
//                     ListID int FOREIGN key(ListID) REFERENCES MailingLists(ID),
//                     FirstName nvarchar(200),
//                     LastName nvarchar(200),
//                     Email nvarchar(150),
//                     EmailMD5 nvarchar(150),
//                     OptInWebSite nvarchar(300),
//                     AddOn datetime,
//                     UpdatedOn datetime,
//                     Region nvarchar(150),
//                     RegionName nvarchar(150),
//                     City nvarchar(50),
//                     ZipCode nvarchar(50),
//                     Country nvarchar(80),
//                     isClean bit,
//                     isActive bit,
//                     isOpener bit,
//                     isClicker bit,
//                     isLeader bit,
//                     isUnsubscriber bit,
//                     isOptedOut bit,
//                     Verticals nvarchar(150),
//                     TotalOpens int,
//                     TotalClicks int,
//                     TotalLeads int,
//                     TotalUnsubscribes int,
//                     Comments nvarchar(250),
//                     PRIMARY KEY(ID)
//                 );
//                 ";

//                 await _context.Database.ExecuteSqlRawAsync(creationQuery);
//             }

//         }

//         public string CreateMD5Hash(string input)
//         {
//             // Step 1, calculate MD5 hash from input
//             var md5 = System.Security.Cryptography.MD5.Create();
//             byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
//             byte[] hashBytes = md5.ComputeHash(inputBytes);

//             // Step 2, convert byte array to hex string
//             var sb = new System.Text.StringBuilder();
//             for (int i = 0; i < hashBytes.Length; i++)
//             {
//                 sb.Append(hashBytes[i].ToString("X2"));
//             }
//             return sb.ToString();
//         }
//     }
// }