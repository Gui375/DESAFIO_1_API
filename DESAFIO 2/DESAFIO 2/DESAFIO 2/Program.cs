using System;
using System.Diagnostics.Metrics;
using DESAFIO_2;

Menu:
Console.WriteLine("------------------------------------");
Console.WriteLine("|  Menu:                           |");
Console.WriteLine("|  1. Procurar por moeda           |");
Console.WriteLine("|  2. Procurar por continente      |");
Console.WriteLine("|  3. Sair                         |");
Console.WriteLine("------------------------------------");
Console.Write("Escolha uma opção: ");
int menu = int.Parse(Console.ReadLine());

DADOS_DO_PAIS dados = new DADOS_DO_PAIS();

switch (menu)
{
    case 1:
        #region
        Console.WriteLine("Qual Moeda você gostaria de saber as informações ? ");
        dados.MOEDA = Console.ReadLine();
        Console.WriteLine();
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = $"https://restcountries.com/v3.1/currency/{dados.MOEDA}?fields=name,capital";

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // Fazendo o parsing da resposta JSON
                List<DADOS_DO_PAIS> dadosPaises = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DADOS_DO_PAIS>>(responseBody);

                
                foreach (var item in dadosPaises)
                {
                    Console.WriteLine("Nome do pais : " + item.name.common);
                    Console.WriteLine("Nome oficial: " + item.name.official);
                    Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                    Console.WriteLine("\n");
                }
                Console.WriteLine();
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
        Console.WriteLine("Aperte enter...");
        Console.ReadLine();
        Thread.Sleep(3000);
        goto Menu;
        #endregion
    case 2:
        Console.WriteLine("europe");
        Console.WriteLine("america");
        Console.WriteLine("oceania");
        Console.WriteLine("asia");
        Console.WriteLine("africa");
        #region
        Console.WriteLine("Digite o continente para consultar os países e suas moedas:");
        dados.REGIAO = Console.ReadLine();
        Console.WriteLine();
        using (HttpClient client = new HttpClient())
        {
            try
            {

                string url = $"https://restcountries.com/v3.1/region/{dados.REGIAO}? fields=currencies";

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                List<DADOS_DO_PAIS> dadosContinente = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DADOS_DO_PAIS>>(responseBody);

                #region
                //foreach (var item in dadosContinente)
                //{
                //    Console.WriteLine(item.currencies.BBD.name + ": " + item.currencies.BBD.symbol);
                //    Console.WriteLine("Capital :" + item.capital.FirstOrDefault());
                //}
                #endregion
                #region
                foreach (var item in dadosContinente)
                {
                    if (dados.REGIAO == "america")
                    {
                        Console.WriteLine(item.currencies.BBD.name + ": " + item.currencies.BBD.symbol);
                        Console.WriteLine("Capital do pais :" + item.capital.FirstOrDefault());
                    }
                    else if (dados.REGIAO == "oceania")
                    {
                        Console.WriteLine(item.currencies.USD.name + " " + item.currencies.USD.symbol);
                        Console.WriteLine("Capital do pais:" + item.capital.FirstOrDefault());
                    }
                    else if (dados.REGIAO == "africa")
                    {
                        Console.WriteLine(item.currencies.MWK.name + " " + item.currencies.MWK.symbol);
                        Console.WriteLine("Capital do pais:" + item.capital.FirstOrDefault());
                    }
                    else if (dados.REGIAO == "asia")
                    {
                        Console.WriteLine(item.currencies.JOD.name + " " + item.currencies.JOD.symbol);
                        Console.WriteLine("Capital do pais:" + item.capital.FirstOrDefault());
                    }
                    else if (dados.REGIAO == "europe")
                    {
                        if(item.currencies.RSD != null)
                            Console.WriteLine(item.currencies.RSD.name + " " + item.currencies.RSD.symbol);
                        else
                            Console.WriteLine("Não existe Moeda Informada!");

                        Console.WriteLine("Capital do pais:" + item.capital.FirstOrDefault());
                    }
                    //continue;
                }
                #endregion
                Console.WriteLine();
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
        Console.WriteLine("Aperte enter...");
        Console.ReadLine();
        Thread.Sleep(3000);
        
        goto Menu;
        #endregion
    case 3:
    default:
        Console.WriteLine("Saindo...");
        Thread.Sleep(1000);
        Console.WriteLine("Fim do Código!!");
        break;
}