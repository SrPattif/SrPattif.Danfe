using DanfeSharp.Graphics;
using System;
using System.Drawing;

namespace DanfeSharp
{
    /// <summary>
    /// Campo de única linha.
    /// </summary>
    internal class Campo : ElementoBase
    {
        public virtual String Cabecalho { get; set; }
        public virtual String Conteudo { get; set; }

        public HorizontalAlignment AlinhamentoHorizontalConteudo { get; set; }

        public Boolean IsConteudoNegrito { get; set; }

        public Campo(String cabecalho, String conteudo, Estilo estilo, HorizontalAlignment alinhamentoHorizontalConteudo = HorizontalAlignment.Left) : base(estilo)
        {
            Cabecalho = cabecalho;
            this.Conteudo = conteudo;
            AlinhamentoHorizontalConteudo = alinhamentoHorizontalConteudo;
            IsConteudoNegrito = true;
            Height = Constants.FieldHeight;
        }

        protected virtual void DesenharCabecalho(Gfx gfx)
        {
            if (!String.IsNullOrWhiteSpace(Cabecalho))
            {
                gfx.DrawString(Cabecalho.ToUpper(), RetanguloDesenhvael, Estilo.FonteCampoCabecalho, HorizontalAlignment.Left, VerticalAlignment.Top);
            }
        }

        protected virtual void DesenharConteudo(Gfx gfx)
        {
            var rDesenhavel = RetanguloDesenhvael;
            var texto = Conteudo;

            var fonte = IsConteudoNegrito ? Estilo.FonteCampoConteudoNegrito : Estilo.FonteCampoConteudo;
            fonte = fonte.Clonar();

            if (!String.IsNullOrWhiteSpace(Conteudo))
            {
                var textWidth = fonte.MedirLarguraTexto(Conteudo);

                // Trata o overflown
                if (textWidth > rDesenhavel.Width)
                {
                    fonte.size = rDesenhavel.Width * fonte.size / textWidth;

                    if (fonte.size < Estilo.FonteTamanhoMinimo)
                    {
                        fonte.size = Estilo.FonteTamanhoMinimo;

                        texto = "...";
                        String texto2;

                        for (int i = 1; i <= Conteudo.Length; i++)
                        {
                            texto2 = Conteudo.Substring(0, i) + "...";
                            if (fonte.MedirLarguraTexto(texto2) < rDesenhavel.Width)
                            {
                                texto = texto2;
                            }
                            else
                            {
                                break;
                            }

                        }
                    }
                }

                gfx.DrawString(texto, rDesenhavel, fonte, AlinhamentoHorizontalConteudo, VerticalAlignment.Bottom);

            }
        }


        public override void Draw(Gfx gfx)
        {
            base.Draw(gfx);
            DesenharCabecalho(gfx);
            DesenharConteudo(gfx);
        }

        public RectangleF RetanguloDesenhvael => BoundingBox.InflatedRetangle(Estilo.PaddingSuperior, Estilo.PaddingInferior, Estilo.PaddingHorizontal);

        public override string ToString()
        {
            return Cabecalho;
        }
    }
}
