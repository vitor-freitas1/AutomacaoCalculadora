using Calculadora.Tests.PageObjects;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace Calculadora.Tests.Tests
{
    [TestClass]
    public sealed class CalculadoraSomaTests
    {
        private WindowsDriver _driver;
        private const string WinAppDriverUrl = "http://127.0.0.1:4723";
        // ID da calculadora do Windows 10/11
        private const string CalculatorAppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";

        [TestInitialize]
        public void Setup()
        {
            // Opções para iniciar a sessão com a Calculadora
            var appiumOptions = new AppiumOptions();
            appiumOptions.App = CalculatorAppId;
            appiumOptions.DeviceName = "WindowsPC";

            // Especifica que queremos usar o driver do Windows
            appiumOptions.AutomationName = "Windows";

            // Cria a sessão com a Calculadora
            _driver = new WindowsDriver(new Uri(WinAppDriverUrl), appiumOptions);

        }

        [TestCleanup]
        public void TearDown()
        { 
            // Fecha a sessão (e a Calculadora) após cada teste
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
               
        }

        [TestMethod]
        public void DeveAbrirECarregarACalculadora()
        {
            // O teste mais simples: ele apenas verifica se o título da janela é "Calculadora"
            Assert.AreEqual("Calculadora", _driver.Title);
        }

        [TestMethod]
        public void DeveSomarSeteMaisOitoEResultarEmQuinze()
        {
            // 1. Arrange: Cria uma instância da nossa tela da Calculadora
            var telaCalculadora = new CalculadoraTela(_driver);

            // 2. Act: Executa as ações usando os elementos mapeados na tela
            telaCalculadora.BotaoSete.Click();
            telaCalculadora.BotaoSomar.Click();
            telaCalculadora.BotaoOito.Click();
            telaCalculadora.BotaoIgual.Click();

            // 3. Assert: Pega o resultado do visor e verifica se está correto
            Assert.AreEqual("15", telaCalculadora.ObterResultadoDoVisor());
        }
    }
}
