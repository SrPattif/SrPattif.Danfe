using DanfeSharp.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DanfeSharp
{
    /// <summary>
    /// Define uma pilha de texto.
    /// </summary>
    internal class TextStack : DrawableBase
    {
        public const float DefaultLineHeightScale = 1.25F;

        private List<String> _Lines;
        private List<Graphics.Font> _Fonts;
        public HorizontalAlignment AlinhamentoHorizontal { get; set; }
        public VerticalAlignment AlinhamentoVertical { get; set; }
        public float LineHeightScale { get; set; }

        public TextStack(RectangleF boundingBox)
        {
            SetPosition(boundingBox.Location);
            SetSize(boundingBox.Size);
            _Lines = new List<string>();
            _Fonts = new List<Graphics.Font>();
            AlinhamentoHorizontal = HorizontalAlignment.Center;
            AlinhamentoVertical = VerticalAlignment.Center;
            LineHeightScale = DefaultLineHeightScale;
        }

        public TextStack AddLine(String text, Graphics.Font font)
        {
            _Lines.Add(text);
            _Fonts.Add(font);
            return this;
        }

        public override void Draw(Gfx gfx)
        {
            var fonts = new Graphics.Font[_Fonts.Count];

            //adjust font size to prevent horizontal overflown
            for (int i = 0; i < _Lines.Count; i++)
            {
                var w = _Fonts[i].MedirLarguraTexto(_Lines[i]);

                if (w > BoundingBox.Width)
                {
                    fonts[i] = new Graphics.Font(_Fonts[i].InternalFont, BoundingBox.Width * _Fonts[i].size / w);
                }
                else
                {
                    fonts[i] = _Fonts[i];
                }
            }

            float totalH = (float)fonts.Last().LineHeight;

            for (int i = 0; i < _Lines.Count - 1; i++)
            {
                totalH += (float)fonts[i].LineHeight * LineHeightScale;
            }

            // float totalH = (float)fonts.Sum(x => x.AlturaEmMm());
            var h2 = (BoundingBox.Height - totalH) / 2D;
            var r = BoundingBox;

            if (AlinhamentoVertical == VerticalAlignment.Center)
                r.Y += (float)h2;
            else if (AlinhamentoVertical == VerticalAlignment.Bottom)
                r.Y = r.Bottom - totalH;

            for (int i = 0; i < _Lines.Count; i++)
            {
                var l = _Lines[i];
                var f = fonts[i];

                gfx.DrawString(l, r, f, AlinhamentoHorizontal);
                r.Y += f.LineHeight * LineHeightScale;
            }

        }

    }
}
