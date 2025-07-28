using Calculadora.Tests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Tests.Steps
{
    public class CalculadoraSteps
    {
        private readonly CalculadoraTela _telaCalculadora;

        // O construtor recebe a tela para poder interagir com ela
        public CalculadoraSteps(CalculadoraTela tela)
        {
            _telaCalculadora = tela;
        }

        // Método de alto nível que descreve uma ação
        public void SomarDoisNumeros(string num1, string num2)
        {
            // Lógica de cliques
            _telaCalculadora.ObterBotaoPeloNome(num1).Click();
            _telaCalculadora.BotaoSomar.Click();
            _telaCalculadora.ObterBotaoPeloNome(num2).Click();
            _telaCalculadora.BotaoIgual.Click();
        }
    }
}
