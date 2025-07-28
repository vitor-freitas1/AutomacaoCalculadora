using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace Calculadora.Tests.PageObjects
{
    public class CalculadoraTela
    {
        private readonly WindowsDriver _driver;

        public CalculadoraTela(WindowsDriver driver)
        {
            _driver = driver;
        }

        // Mapeamento dos elementos da tela usando a sintaxe completa
        public AppiumElement BotaoSete => _driver.FindElement(By.XPath("//Button[@AutomationId='num7Button']"));
        public AppiumElement BotaoOito => _driver.FindElement(By.XPath("//Button[@AutomationId='num8Button']"));
        public AppiumElement BotaoSomar => _driver.FindElement(By.XPath("//Button[@AutomationId='plusButton']"));
        public AppiumElement BotaoIgual => _driver.FindElement(By.XPath("//Button[@AutomationId='equalButton']"));
        public AppiumElement VisorResultado => _driver.FindElement(By.XPath("//Text[@AutomationId='CalculatorResults']"));

        public string ObterResultadoDoVisor()
        {
            return VisorResultado.Text.Replace("A exibição é", "").Trim();
        }
    }
}

