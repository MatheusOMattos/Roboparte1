using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Robozin
{
    public class AutomationWeb
    {
        public IWebDriver driver;

        public AutomationWeb()
        {
            driver = new ChromeDriver();
        }

        public void TestWeb()
        {
            driver.Navigate().GoToUrl("https://www.4devs.com.br/gerador_de_pessoas");

            driver.FindElement(By.Name("txt_qtde")).Clear();

            driver.FindElement(By.Name("txt_qtde")).SendKeys("10");

            driver.FindElement(By.XPath("//*[@id=\"cookiescript_accept\"]")).Click();

            driver.FindElement(By.XPath("//*[@id=\"bt_gerar_pessoa\"]")).Click();

            driver.FindElement(By.XPath("//*[@id=\"area_resposta_json\"]/div/button[1]")).Click();

        }

    }
}






















