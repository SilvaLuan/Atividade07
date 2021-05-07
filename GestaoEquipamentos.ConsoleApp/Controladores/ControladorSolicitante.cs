using GestaoEquipamentos.ConsoleApp.Dominio;
using System;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorSolicitante : ControladorBase
    {
        public Solicitante SelecionarSolicitantePorId(int id)
        {
            return (Solicitante)SelecionarRegistroPorId(new Solicitante(id));
        }

        public string RegistrarSolicitante(int id, string nome, string email, string numeroTel)
        {
            Solicitante solicitante = null;

            int posicao;

            if (id == 0)
            {
                solicitante = new Solicitante();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Solicitante(id));
                solicitante = (Solicitante)registros[posicao];
            }

            solicitante.nome = nome;
            solicitante.email = email;
            solicitante.numeroTelefone = email;
            solicitante.numeroTelefone = numeroTel;

            string resultadoValidacao = solicitante.Validar();

            if (resultadoValidacao == "SOLICITANTE_VALIDO")
                registros[posicao] = solicitante;

            return resultadoValidacao;
        }
       
        public bool ExcluirSolicitante(int idSelecionado)
        {
            return ExcluirRegistro(new Solicitante(idSelecionado));
        }

        public Solicitante[] SelecionarTodosSolicitantes()
        {
            Solicitante[] solicitanteAux = new Solicitante[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), solicitanteAux, solicitanteAux.Length);

            return solicitanteAux;
        }
    }
}
