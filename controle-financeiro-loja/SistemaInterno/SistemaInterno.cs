using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using controle_financeiro_loja.Empregados;
using controle_financeiro_loja.Produtos;

namespace controle_financeiro_loja.SistemaInterno
{
    public class SistemaInterno
    {        
        public string VerificarSenha(string senhaDigitada, List<Empregado> empregados)
        {
            foreach (Empregado empregado in empregados)
            {
                if (senhaDigitada == empregado.Senha)
                {
                    return empregado.Nome;
                }
            }
            return null;            
        }
    }
}
