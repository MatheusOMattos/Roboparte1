using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text;

namespace Robozin
{
    public class AutomationWeb
    {
        public IWebDriver driver;

        public AutomationWeb()
        {
            driver = new ChromeDriver();
        }

        public async void TestWeb()
        {
            driver.Navigate().GoToUrl("https://www.4devs.com.br/gerador_de_pessoas");

            driver.FindElement(By.Name("txt_qtde")).Clear();
            driver.FindElement(By.Name("txt_qtde")).SendKeys("10");

            driver.FindElement(By.XPath("//*[@id=\"cookiescript_accept\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"bt_gerar_pessoa\"]")).Click();

            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//*[@id=\"area_resposta_json\"]/div/button[1]")).Click();

            Thread.Sleep(3000);

            // Localize o caminho do arquivo JSON baixado
            string jsonFilePath = @"C:\Users\Pichau\Downloads/data.json"; // Caminho do arquivo baixado (ajuste conforme necessário)

            // Pega o diretório do arquivo JSON e cria o caminho para o CSV
            string csvFilePath = Path.ChangeExtension(jsonFilePath, ".csv");

            ConvertJsonToCsv(jsonFilePath, csvFilePath);
        }

        public void ConvertJsonToCsv(string jsonFilePath, string csvFilePath)
        {
            // Leitura do arquivo JSON
            var jsonContent = File.ReadAllText(jsonFilePath);

            // Desserializa o JSON em uma lista de objetos dinâmicos
            var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonContent);

            if (data != null && data.Any())
            {
                // Extrai os cabeçalhos do CSV (chaves do dicionário)
                var headers = data.First().Keys;

                // Constrói o CSV
                var csvContent = new StringBuilder();
                csvContent.AppendLine(string.Join(",", headers)); // Adiciona o cabeçalho

                // Adiciona as linhas de dados
                foreach (var row in data)
                {
                    var values = headers.Select(header => row[header]?.ToString() ?? string.Empty);
                    csvContent.AppendLine(string.Join(",", values));
                }

                // Salva o arquivo CSV no mesmo diretório
                File.WriteAllText(csvFilePath, csvContent.ToString());
            }
        }
    }
}
























