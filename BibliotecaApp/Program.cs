using Microsoft.EntityFrameworkCore;
using BibliotecaApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container.
builder.Services.AddRazorPages();

// Configura o serviço de contexto de banco de dados com MySQL.
// Obtém a string de conexão da configuração e usa MySQL como o provedor de banco de dados.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configura o pipeline de requisição HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Habilita o HSTS (HTTP Strict Transport Security) para maior segurança em produção.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

// Testa a conexão com o banco de dados antes de executar o aplicativo.
TestDatabaseConnection(app);

app.Run();

// Função que testa a conexão com o banco de dados.
void TestDatabaseConnection(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            // Verifica se é possível conectar ao banco de dados.
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
