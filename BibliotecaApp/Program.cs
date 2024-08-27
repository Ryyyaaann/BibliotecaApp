using Microsoft.EntityFrameworkCore;
using BibliotecaApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os ao container.
builder.Services.AddRazorPages();

// Configura o servi�o de contexto de banco de dados com MySQL.
// Obt�m a string de conex�o da configura��o e usa MySQL como o provedor de banco de dados.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configura o pipeline de requisi��o HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Habilita o HSTS (HTTP Strict Transport Security) para maior seguran�a em produ��o.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

// Testa a conex�o com o banco de dados antes de executar o aplicativo.
TestDatabaseConnection(app);

app.Run();

// Fun��o que testa a conex�o com o banco de dados.
void TestDatabaseConnection(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            // Verifica se � poss�vel conectar ao banco de dados.
            if (context.Database.CanConnect())
            {
                Console.WriteLine("Connection to the database successful!");
            }
            else
            {
                Console.WriteLine("Failed to connect to the database.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An exception occurred: {ex.Message}");
        }
    }
}
