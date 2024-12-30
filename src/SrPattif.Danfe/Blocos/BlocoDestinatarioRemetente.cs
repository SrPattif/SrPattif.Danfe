using DanfeSharp.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanfeSharp.Blocos
{
    internal class BlocoDestinatarioRemetente : BlocoBase
    {
        public BlocoDestinatarioRemetente(DanfeViewModel viewModel, Estilo estilo) : base(viewModel, estilo)
        {
            var destinatario = viewModel.Destinatario;

            AdicionarLinhaCampos()
            .ComCampo(Strings.RazaoSocial, destinatario.RazaoSocial)
            .ComCampo(Strings.CnpjCpf, Formatador.FormatarCpfCnpj(destinatario.CnpjCpf), HorizontalAlignment.Center)
            .ComCampo("Data de Emissão", viewModel.DataHoraEmissao.Formatar(), HorizontalAlignment.Center)
            .ComLarguras(0, 45F * Proporcao, 30F * Proporcao);

            AdicionarLinhaCampos()
            .ComCampo(Strings.Endereco, destinatario.EnderecoLinha1)
            .ComCampo(Strings.BairroDistrito, destinatario.EnderecoBairro)
            .ComCampo(Strings.Cep, Formatador.FormatarCEP(destinatario.EnderecoCep), HorizontalAlignment.Center)
            .ComCampo("Data Entrada / Saída", ViewModel.DataSaidaEntrada.Formatar(), HorizontalAlignment.Center)
            .ComLarguras(0, 45F * Proporcao, 25F * Proporcao, 30F * Proporcao);

            AdicionarLinhaCampos()
            .ComCampo(Strings.Municipio, destinatario.Municipio)
            .ComCampo(Strings.FoneFax, Formatador.FormatarTelefone(destinatario.Telefone), HorizontalAlignment.Center)
            .ComCampo(Strings.UF, destinatario.EnderecoUf, HorizontalAlignment.Center)
            .ComCampo(Strings.InscricaoEstadual, destinatario.Ie, HorizontalAlignment.Center)
            .ComCampo("Hora Entrada / Saída", ViewModel.HoraSaidaEntrada.Formatar(), HorizontalAlignment.Center)
            .ComLarguras(0, 35F * Proporcao, 7F * Proporcao, 40F * Proporcao, 30F * Proporcao);
        }

        public override string Cabecalho => "Destinatário / Remetente";
        public override BlockPosition Posicao => BlockPosition.Top;
    }
}
