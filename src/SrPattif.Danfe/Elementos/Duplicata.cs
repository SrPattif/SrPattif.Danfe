using DanfeSharp.Graphics;
using DanfeSharp.Modelo;
using System;

namespace DanfeSharp
{
	[AlturaFixa]
    internal class Duplicata : ElementoBase
    {
        public Font FonteA { get; private set; }
        public Font FonteB { get; private set; }
        public DuplicataViewModel ViewModel { get; private set; }

        private static readonly String[] Chaves = { "Número", "Vencimento:", "Valor:" };

        public Duplicata(Estilo estilo, DuplicataViewModel viewModel) : base(estilo)
        {
            ViewModel = viewModel;
            FonteA = estilo.CriarFonteRegular(7.5F);
            FonteB = estilo.CriarFonteNegrito(7.5F);
        }

        public override void Draw(Gfx gfx)
        {
            base.Draw(gfx);

            var r = BoundingBox.InflatedRetangle(Estilo.PaddingSuperior, Estilo.PaddingInferior, Estilo.PaddingHorizontal);

            String[] valores = { ViewModel.Numero, ViewModel.Vecimento.Formatar(), ViewModel.Valor.FormatarMoeda() };

            for (int i = 0; i < Chaves.Length; i++)
            {
                gfx.DrawString(Chaves[i], r, FonteA, HorizontalAlignment.Left);
                gfx.DrawString(valores[i], r, FonteB, HorizontalAlignment.Right);
                r = r.CutTop(FonteB.LineHeight);
            }    

        }

        public override float Height {
            get => 3*FonteB.LineHeight + Estilo.PaddingSuperior + Estilo.PaddingInferior;
            set => throw new NotSupportedException(); }
    }
}
