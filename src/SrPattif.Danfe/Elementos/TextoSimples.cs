using DanfeSharp.Graphics;
using System;

namespace DanfeSharp
{
    class TextoSimples : ElementoBase
    {
        public String Texto { get; private set; }
        public HorizontalAlignment AlinhamentoHorizontal { get; set; }
        public VerticalAlignment AlinhamentoVertical { get; set; }
        public float TamanhoFonte { get; set; }     

        public TextoSimples(Estilo estilo, String texto) : base(estilo)
        {
            Texto = texto;
            AlinhamentoHorizontal = HorizontalAlignment.Left;
            AlinhamentoVertical = VerticalAlignment.Top;
            TamanhoFonte = 6;
            
        }

        public override void Draw(Gfx gfx)
        {
            base.Draw(gfx);

            if (!String.IsNullOrWhiteSpace(Texto))
            {
                var r = BoundingBox.InflatedRetangle(0.75F);

                var tb = new TextBlock(Texto, Estilo.CriarFonteRegular(TamanhoFonte));
                tb.AlinhamentoHorizontal = AlinhamentoHorizontal;
                tb.Width = r.Width;
              
                var y = r.Y;

                if(AlinhamentoVertical == VerticalAlignment.Center)                
                    y += (r.Height - tb.Height) / 2F;                

                tb.SetPosition(r.X, y);
                tb.Draw(gfx);
            }

        }

       
    }
}
