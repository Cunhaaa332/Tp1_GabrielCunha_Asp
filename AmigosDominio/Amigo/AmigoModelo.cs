using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmigosDominio
{
    public class AmigoModelo
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNasc { get; set; }
        public string Email { get; set; }

        public AmigoModelo()
        {
        }

        public AmigoModelo(String nome, string sobrenome, DateTime data, string email)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNasc = data;
            Email = email;
        }

        public override string ToString()
        {
            return " Nome Completo: " + Nome + Sobrenome +
                   "\n Data do Aniversario: " + DataNasc.Day + "/" + DataNasc.Month + "/" + DataNasc.Year +
                   "\n Email: " + Email;
        }
    }
}
