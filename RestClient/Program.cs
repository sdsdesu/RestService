// See https://aka.ms/new-console-template for more information
using System.Net;
using Microsoft.Extensions.Hosting;
using RestService;



Console.WriteLine("Op wellke dag ben je geboren?");
int dag = 0;
int maand = 0;

do
{
    Console.WriteLine("Vul de dag van de maand in");
    string input = Console.ReadLine();
    if (int.TryParse(input, out dag))
    {

    }
    else
    {
        Console.WriteLine("Je gaf geen geldig getal in");
    }
}
while (dag == 0);
do
{
    Console.WriteLine("Vul nu de maand in");
    string input = Console.ReadLine();
    if (int.TryParse(input, out maand))
    {

    }
    else
    {
        Console.WriteLine("Je gaf geen geldig getal in");
    }
}
while (maand == 0);




string dagEnMaand = $"{dag}-{maand}";
using var client = new HttpClient();
var response = await client.GetAsync($"http://localhost:5000/sterrebeelden/{dagEnMaand}");
switch (response.StatusCode)
{
    case HttpStatusCode.OK:
        var sterrebeeld = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Je bent een {sterrebeeld}");
        break;
    case HttpStatusCode.BadRequest:
        Console.WriteLine("Ongeldige datum: Dag moet tussen 1 en 31 zijn, maand tussen 1 en 12.");
        break;
    case HttpStatusCode.NotFound:
        Console.WriteLine("Sterrebeeld niet gevonden voor de opgegeven datum.");
        break;
    default:
        Console.WriteLine("Er is een fout opgetreden bij het ophalen van het sterrebeeld.");
        break;
}
Console.WriteLine("Druk op een toets om af te sluiten...");
Console.ReadLine();