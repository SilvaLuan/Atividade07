using GestaoEquipamentos.ConsoleApp.Controladores;
using System;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaPrincipal
    {
        ControladorChamado controladorChamado;
        ControladorEquipamento controladorEquipamento;
        ControladorSolicitante controladorSolicitante;
        TelaEquipamento telaEquipamento;         
        TelaSolicitante telaSolicitante;

        public TelaPrincipal(ControladorChamado controladorChamado, ControladorEquipamento controladorEquipamento, ControladorSolicitante controladorSolicitante, TelaEquipamento telaEquipamento, TelaSolicitante telaSolicitante)
        {
            this.controladorChamado = controladorChamado;
            this.controladorEquipamento = controladorEquipamento;
            this.controladorSolicitante = controladorSolicitante;
            this.telaEquipamento = telaEquipamento;
            this.telaSolicitante = telaSolicitante;
        }

        public TelaBase ObterOpcao()
        {
            TelaBase telaSelecionada = null;
            string opcao;
            do
            {
                Console.Clear();

                Console.WriteLine("Digite 1 para o Cadastro de Equipamentos");
                Console.WriteLine("Digite 2 para o Controle de Chamados");
                Console.WriteLine("Digite 3 para o Controle de Solicitantes");

                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();

                if (opcao == "1")
                    telaSelecionada = new TelaEquipamento(controladorEquipamento);
                else if (opcao == "2")
                    telaSelecionada = new TelaChamado(telaEquipamento,telaSolicitante, controladorChamado);
                else if (opcao == "3")
                    telaSelecionada = new TelaSolicitante(controladorSolicitante);

                else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    telaSelecionada = null;

            } while (OpcaoInvalida(opcao));

            return telaSelecionada;
        }

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "S" && opcao != "s")
            {
                Console.WriteLine("Opção inválida");
                Console.ReadLine();
                return true;
            }
            else
                return false;
        }
    }
}
