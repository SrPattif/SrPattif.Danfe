﻿using DanfeSharp.Modelo;

namespace DanfeSharp.Blocos
{
    internal class BlocoCalculoIssqn : BlocoBase
    {
        public BlocoCalculoIssqn(DanfeViewModel viewModel, Estilo estilo) : base(viewModel, estilo)
        {
            var m = viewModel.CalculoIssqn;

            AdicionarLinhaCampos()
                .ComCampo("INSCRIÇÃO MUNICIPAL", m.InscricaoMunicipal, HorizontalAlignment.Center)
                .ComCampoNumerico("VALOR TOTAL DOS SERVIÇOS", m.ValorTotalServicos)
                .ComCampoNumerico("BASE DE CÁLCULO DO ISSQN", m.BaseIssqn)
                .ComCampoNumerico("VALOR TOTAL DO ISSQN", m.ValorIssqn)
                .ComLargurasIguais();
        }

        public override BlockPosition Posicao => BlockPosition.Bottom;
        public override string Cabecalho => "CÁLCULO DO ISSQN";
    }
}
