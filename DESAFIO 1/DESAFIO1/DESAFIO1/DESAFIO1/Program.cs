using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using DESAFIO1;



using (HttpClient client = new HttpClient())
{
    try
    {
        Root DADOS = new Root();
        Console.WriteLine("Digite o IP:");
        DADOS.ip = Console.ReadLine();

        string url = $"https://ipapi.co/{DADOS.ip}/json/";

        HttpResponseMessage response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        // ALIMENTANDO A CLASSE COM JSON

        DADOS = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(responseBody);
            
        // EXIBINDO
        Console.WriteLine($"MEU IP: {DADOS.ip}");
        Console.WriteLine($"MINHA REDE: {DADOS.network}");
        Console.WriteLine($"MINHA VERSÃO: {DADOS.version}");
        Console.WriteLine($"MINHA CIDADE: {DADOS.city}");
        Console.WriteLine($"MINHA REGIÃO: {DADOS.region}");
        Console.WriteLine($"MEU CODIGO REGIÃO: {DADOS.region_code}");
        Console.WriteLine($"MEU PAIS: {DADOS.country}");
        Console.WriteLine($"MEU NOME DO PAIS: {DADOS.country_name}");
        Console.WriteLine($"MEU NOME DO CODIGO: {DADOS.country_code}");
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"Ocorreu um erro ao fazer a requisição HTTP: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
}