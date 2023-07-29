using System;
using Features.Core;

namespace Features.Clientes
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Ativo { get; private set; }

        public Cliente()
        {
        }

        public Cliente(string nome, string sobrenome, string email, DateTime dataNascimento, DateTime dataCadastro, bool ativo)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Ativo = ativo;
            DataCadastro = dataCadastro;
        }

        public string ObterNomeCpleto()
        {
            return $"{Nome} {Sobrenome}";
        }

        public bool EhEspecial()
        {
            return DataCadastro < DateTime.Now.AddYears(-3) && Ativo;
        }

        public bool Inativar()
        {
            return Ativo = false;
        }

        public override bool EhValido()
        {
            ValidationResult = new ClienteValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}