using DanfeSharp.Modelo;

namespace DanfeSharp.Blocos
{
    internal class BlocoTransportador : BlocoBase
    {
        public const float LarguraCampoPlacaVeiculo = 22F * Proporcao;
        public const float LarguraCampoCodigoAntt = 30F * Proporcao;
        public const float LarguraCampoCnpj = 31F * Proporcao;
        public const float LarguraCampoUf = 7F * Proporcao;
        public const float LarguraFrete = 34F * Proporcao;

        public BlocoTransportador(DanfeViewModel viewModel, Estilo campoEstilo) : base(viewModel, campoEstilo)
        {
            var transportadora = viewModel.Transportadora;

            AdicionarLinhaCampos()
                .ComCampo(Strings.RazaoSocial, transportadora.RazaoSocial)
                .ComCampo("Frete", transportadora.ModalidadeFreteString, HorizontalAlignment.Center)
                .ComCampo("Código ANTT", transportadora.CodigoAntt, HorizontalAlignment.Center)
                .ComCampo("Placa do Veículo", transportadora.Placa, HorizontalAlignment.Center)
                .ComCampo(Strings.UF, transportadora.VeiculoUf, HorizontalAlignment.Center)
                .ComCampo(Strings.CnpjCpf, Formatador.FormatarCnpj(transportadora.CnpjCpf), HorizontalAlignment.Center)
                .ComLarguras(0, LarguraFrete, LarguraCampoCodigoAntt, LarguraCampoPlacaVeiculo, LarguraCampoUf, LarguraCampoCnpj);

            AdicionarLinhaCampos()
                .ComCampo(Strings.Endereco, transportadora.EnderecoLogadrouro)
                .ComCampo(Strings.Municipio, transportadora.Municipio)
                .ComCampo(Strings.UF, transportadora.EnderecoUf, HorizontalAlignment.Center)
                .ComCampo(Strings.InscricaoEstadual, transportadora.Ie, HorizontalAlignment.Center)
                .ComLarguras(0, LarguraCampoPlacaVeiculo + LarguraCampoCodigoAntt, LarguraCampoUf, LarguraCampoCnpj);

            var l = (float)(LarguraCampoCodigoAntt + LarguraCampoPlacaVeiculo + LarguraCampoUf + LarguraCampoCnpj) / 3F;

            AdicionarLinhaCampos()
                .ComCampoNumerico(Strings.Quantidade, transportadora.QuantidadeVolumes, 3)
                .ComCampo("Espécie", transportadora.Especie)
                .ComCampo("Marca", transportadora.Marca)
                .ComCampo("Numeração", transportadora.Numeracao)
                .ComCampoNumerico("Peso Bruto", transportadora.PesoBruto, 3)
                .ComCampoNumerico("Peso Líquido", transportadora.PesoLiquido, 3)
                .ComLarguras(20F / 200F * 100, 0, 0, l, l, l);

        }

        public override BlockPosition Posicao => BlockPosition.Top;
        public override string Cabecalho => "Transportador / Volumes Transportados";
    }
}
