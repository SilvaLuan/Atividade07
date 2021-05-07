using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos.ConsoleApp.Dominio
{
    #region
    /*
     Requisito 1.1: Como funcionário, Junior quer ter a possibilidade de registrar solicitantes  

             •  Deve ter um nome com no mínimo 6 caracteres;
             •  Deve ter um email
             •  Deve ter um número de telefone         
     */
    #endregion
    public class Solicitante
    {
        public int id;
        public string email;
        public string nome;
        public string numeroTelefone;

        public Solicitante()
        {
            id = GeradorId.GerarIdSolicitante();
        }

        public Solicitante(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (nome.Length < 6)
                resultadoValidacao += "O campo Nome não pode ter menos de 6 letras \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "SOLICITANTE_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Solicitante solicitante = (Solicitante)obj;

            if (id == solicitante.id)
                return true;
            else
                return false;
        }
    }
}
