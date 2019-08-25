using Bogus;
using Bogus.Extensions.Brazil;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Cnaes;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Empresas;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.Estabelecimentos;
using ERP.Gerencial.Domain.GruposEmpresariais.Commands.GruposEmpresariais;
using ERP.Gerencial.Domain.GruposEmpresariais.Types;
using System;

namespace ERP.Tests.Unit.Gerencial.Factories
{
    public static class CommandFactory
    {
        public static SaveGrupoEmpresarialCommand GenerateValidSaveGrupoEmpresarialCommand()
        {
            return new Faker<SaveGrupoEmpresarialCommand>("pt_BR").CustomInstantiator(c => new SaveGrupoEmpresarialCommand(
                c.Company.CompanyName(), 
                c.Company.CompanyName(), 
                Guid.NewGuid()))
            .Generate();
        }

        public static SaveGrupoEmpresarialCommand GenerateInvalidSaveGrupoEmpresarialCommand()
        {
            return new Faker<SaveGrupoEmpresarialCommand>("pt_BR") .CustomInstantiator(c => new SaveGrupoEmpresarialCommand(
                (Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString()),
                c.Company.CompanyName(),
                Guid.NewGuid()))
            .Generate();
        }

        public static UpdateGrupoEmpresarialCommand GenerateValidUpdateGrupoEmpresarialCommand()
        {
            return new Faker<UpdateGrupoEmpresarialCommand>("pt_BR").CustomInstantiator(c => new UpdateGrupoEmpresarialCommand(
                Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"),
                c.Company.CompanyName(),
                c.Company.CompanyName(),
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a")))
            .Generate();
        }

        public static UpdateGrupoEmpresarialCommand GenerateInvalidUpdateGrupoEmpresarialCommand()
        {
            return new Faker<UpdateGrupoEmpresarialCommand>("pt_BR").CustomInstantiator(c => new UpdateGrupoEmpresarialCommand(
                Guid.NewGuid(),
                (Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString()),
                c.Company.CompanyName(),
                Guid.NewGuid()))
            .Generate();
        }

        public static DeleteGrupoEmpresarialCommand GenerateValidDeleteGrupoEmpresarialCommand()
        {
            return new DeleteGrupoEmpresarialCommand(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"), Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
        }

        public static DeleteGrupoEmpresarialCommand GenerateInvalidDeleteGrupoEmpresarialCommand()
        {
            return new DeleteGrupoEmpresarialCommand(Guid.NewGuid(), Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
        }

        public static SaveCnaeCommand GenerateValidSaveCnaeCommand()
        {
            return new Faker<SaveCnaeCommand>("pt_BR").CustomInstantiator(c => new SaveCnaeCommand(
                c.Company.CompanyName().Substring(0, 4),
                c.Company.CompanyName(),
                Guid.NewGuid(),
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a")))
            .Generate();
        }

        public static SaveCnaeCommand GenerateInvalidSaveCnaeCommand()
        {
            return new Faker<SaveCnaeCommand>("pt_BR").CustomInstantiator(c => new SaveCnaeCommand(
                (Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString()),
                c.Company.CompanyName(),
                Guid.NewGuid(),
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a")))
            .Generate();
        }

        public static UpdateCnaeCommand GenerateValidUpdateCnaeCommand()
        {
            return new Faker<UpdateCnaeCommand>("pt_BR").CustomInstantiator(c => new UpdateCnaeCommand(
                Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"),
                c.Company.CompanyName().Substring(0, 4),
                c.Company.CompanyName(),
                Guid.NewGuid(),
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a")))
            .Generate();
        }

        public static UpdateCnaeCommand GenerateInvalidUpdateCnaeCommand()
        {
            return new Faker<UpdateCnaeCommand>("pt_BR").CustomInstantiator(c => new UpdateCnaeCommand(
                Guid.NewGuid(),
                (Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString()),
                c.Company.CompanyName(),
                Guid.NewGuid(),
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a")))
            .Generate();
        }

        public static DeleteCnaeCommand GenerateValidDeleteCnaeCommand()
        {
            return new DeleteCnaeCommand(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"), Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
        }

        public static DeleteCnaeCommand GenerateInvalidDeleteCnaeCommand()
        {
            return new DeleteCnaeCommand(Guid.NewGuid(), Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
        }

        public static SaveEmpresaCommand GenerateValidSaveEmpresaCommand()
        {
            return new Faker<SaveEmpresaCommand>("pt_BR").CustomInstantiator(c => new SaveEmpresaCommand(
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"),
                c.Company.CompanyName().Substring(0, 4),
                c.Company.CompanyName(),
                c.Company.CompanyName(),
                c.Person.Email,
                c.Person.Website,
                DateTime.Now,
                null,
                c.Company.CatchPhrase(),
                c.Company.Cnpj().Replace(".", "").Replace("-", "").Replace("/", ""),
                TipoIdentificacao.CPF,
                Guid.NewGuid()))
            .Generate();
        }

        public static SaveEmpresaCommand GenerateInvalidSaveEmpresaCommand()
        {
            return new Faker<SaveEmpresaCommand>("pt_BR").CustomInstantiator(c => new SaveEmpresaCommand(
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"),
                (Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString()),
                c.Company.CompanyName(),
                c.Company.CompanyName(),
                c.Person.Email,
                c.Person.Website,
                DateTime.Now,
                null,
                c.Company.CatchPhrase(),
                c.Company.Cnpj().Replace(".", "").Replace("-", "").Replace("/", ""),
                TipoIdentificacao.CPF,
                Guid.NewGuid()))
            .Generate();
        }

        public static UpdateEmpresaCommand GenerateValidUpdateEmpresaCommand()
        {
            return new Faker<UpdateEmpresaCommand>("pt_BR").CustomInstantiator(c => new UpdateEmpresaCommand(
                Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"),
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"),
                c.Company.CompanyName().Substring(0, 4),
                c.Company.CompanyName(),
                c.Company.CompanyName(),
                c.Person.Email,
                c.Person.Website,
                DateTime.Now,
                null,
                c.Company.CatchPhrase(),
                c.Company.Cnpj().Replace(".", "").Replace("-", "").Replace("/", ""),
                TipoIdentificacao.CPF,
                Guid.NewGuid()))
            .Generate();
        }

        public static UpdateEmpresaCommand GenerateInvalidUpdateEmpresaCommand()
        {
            return new Faker<UpdateEmpresaCommand>("pt_BR").CustomInstantiator(c => new UpdateEmpresaCommand(
                Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"),
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"),
                (Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString()),
                c.Company.CompanyName(),
                c.Company.CompanyName(),
                c.Person.Email,
                c.Person.Website,
                DateTime.Now,
                null,
                c.Company.CatchPhrase(),
                c.Company.Cnpj().Replace(".", "").Replace("-", "").Replace("/", ""),
                TipoIdentificacao.CPF,
                Guid.NewGuid()))
            .Generate();
        }

        public static DeleteEmpresaCommand GenerateValidDeleteEmpresaCommand()
        {
            return new DeleteEmpresaCommand(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"), Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
        }

        public static DeleteEmpresaCommand GenerateInvalidDeleteEmpresaCommand()
        {
            return new DeleteEmpresaCommand(Guid.NewGuid(), Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
        }

        public static SaveEstabelecimentoCommand GenerateValidSaveEstabelecimentoCommand()
        {
            return new Faker<SaveEstabelecimentoCommand>("pt_BR").CustomInstantiator(c => new SaveEstabelecimentoCommand(
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"),
                c.Company.CompanyName(),
                c.Company.CompanyName(),
                c.Company.CompanyName(),
                "01234567890123456789",
                "01234567890123456789",
                c.Person.Email,
                c.Person.Website,
                DateTime.Now,
                null,
                true,
                c.Company.CatchPhrase(),
                c.Company.Cnpj().Replace(".", "").Replace("-", "").Replace("/", ""),
                TipoIdentificacao.CPF,
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde82a"),
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde18a")))
            .Generate();
        }

        public static SaveEstabelecimentoCommand GenerateInvalidSaveEstabelecimentoCommand()
        {
            return new Faker<SaveEstabelecimentoCommand>("pt_BR").CustomInstantiator(c => new SaveEstabelecimentoCommand(
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"),
                (Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString()),
                c.Company.CompanyName(),
                c.Company.CompanyName(),
                "01234567890123456789",
                "01234567890123456789",
                c.Person.Email,
                c.Person.Website,
                DateTime.Now,
                null,
                true,
                c.Company.CatchPhrase(),
                c.Company.Cnpj().Replace(".", "").Replace("-", "").Replace("/", ""),
                TipoIdentificacao.CPF,
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde82a"),
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde18a")))
            .Generate();
        }

        public static UpdateEstabelecimentoCommand GenerateValidUpdateEstabelecimentoCommand()
        {
            return new Faker<UpdateEstabelecimentoCommand>("pt_BR").CustomInstantiator(c => new UpdateEstabelecimentoCommand(
                Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"),
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"),
                c.Company.CompanyName(),
                c.Company.CompanyName(),
                c.Company.CompanyName(),
                "01234567890123456789",
                "01234567890123456789",
                c.Person.Email,
                c.Person.Website,
                DateTime.Now,
                null,
                true,
                c.Company.CatchPhrase(),
                c.Company.Cnpj().Replace(".", "").Replace("-", "").Replace("/", ""),
                TipoIdentificacao.CPF,
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde82a"),
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde18a")))
            .Generate();
        }

        public static UpdateEstabelecimentoCommand GenerateInvalidUpdateEstabelecimentoCommand()
        {
            return new Faker<UpdateEstabelecimentoCommand>("pt_BR").CustomInstantiator(c => new UpdateEstabelecimentoCommand(
                Guid.NewGuid(), 
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"),
                (Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString() + Guid.NewGuid().ToString()),
                c.Company.CompanyName(),
                c.Company.CompanyName(),
                "01234567890123456789",
                "01234567890123456789",
                c.Person.Email,
                c.Person.Website,
                DateTime.Now,
                null,
                true,
                c.Company.CatchPhrase(),
                c.Company.Cnpj().Replace(".", "").Replace("-", "").Replace("/", ""),
                TipoIdentificacao.CPF,
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde82a"),
                Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde18a")))
            .Generate();
        }

        public static DeleteEstabelecimentoCommand GenerateValidDeleteEstabelecimentoCommand()
        {
            return new DeleteEstabelecimentoCommand(Guid.Parse("04681edc-c9fe-4a39-97e7-c02582f5cde1"), Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
        }

        public static DeleteEstabelecimentoCommand GenerateInvalidDeleteEstabelecimentoCommand()
        {
            return new DeleteEstabelecimentoCommand(Guid.NewGuid(), Guid.Parse("e7261a1f-18e8-4de6-9b4b-a659a8fde81a"));
        }
    }
}