using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using CEP;

using (HttpClient client = new HttpClient())
{
    try
    {
        FORMATO_DADOS_CEP MEU_CEP = new FORMATO_DADOS_CEP(); //Criando o objeto da classe do mesmo formato da api
        Console.WriteLine("Digite o CEP :");
        MEU_CEP.cep = Console.ReadLine(); // alimentando a variavel que recebe o formato do cep para fazer o get na api
        string url = "https://cep.awesomeapi.com.br/json/" + MEU_CEP.cep; // linha responsavel por montar o request pra api

        HttpResponseMessage response = await client.GetAsync(url); //linha que define uma variavel como o retorno do request
        response.EnsureSuccessStatusCode(); // Método gerará uma exceção se a resposta HTTP não tiver sido bem-sucedida
        string responseBody = await response.Content.ReadAsStringAsync(); 
        FORMATO_DADOS_CEP Dados_do_Ip = Newtonsoft.Json.JsonConvert.DeserializeObject<FORMATO_DADOS_CEP>(responseBody);

        Console.WriteLine($"Retorno\n" +
            $"{responseBody}\n\n");
        Console.WriteLine($"Meu CEP: {Dados_do_Ip.cep}");
                             
        Console.WriteLine($"Meu Logradouro: {Dados_do_Ip.address}");

        Console.WriteLine($"Meu Bairro: {Dados_do_Ip.district}");

        Console.WriteLine($"Minha Cidade: {Dados_do_Ip.city}");

        Console.WriteLine($"Meu Estado: {Dados_do_Ip.state}");
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