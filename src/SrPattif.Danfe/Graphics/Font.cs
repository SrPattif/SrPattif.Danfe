using pcf = org.pdfclown.documents.contents.fonts;
using System;

namespace DanfeSharp.Graphics
{
    /// <summary>
    /// Define uma fonte do PDF Clown e um tamanho. 
    /// </summary>
    internal class Font
    {
        private float _size;

        /// <summary>
        /// Fonte do PDF Clown.
        /// </summary>
        public pcf.Font InternalFont { get; private set; }

        public Font(pcf.Font font, float tamanho)
        {
            InternalFont = font ?? throw new ArgumentNullException(nameof(font));
            size = tamanho;
        }

        /// <summary>
        /// Tamanho da fonte.
        /// </summary>
        public float size
        {
            get => _size;
            set
            {
                if (value <= 0) throw new InvalidOperationException("O tamanho deve ser maior que zero.");
                _size = value;
            }
        }

        /// <summary>
        /// Mede a largura ocupada por uma string.
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Largura em mm.</returns>
        public float MedirLarguraTexto(String str)
        {
            if (String.IsNullOrEmpty(str)) return 0;
            return (float)InternalFont.GetWidth(str, size).ToMm();
        }

        /// <summary>
        /// Mese a largura ocupada por um Char.
        /// </summary>
        /// <param name="c">Char</param>
        /// <returns>Largura em mm.</returns>
        public float MedirLarguraChar(char c) => (float)InternalFont.GetWidth(c, size).ToMm();
        
        /// <summary>
        /// Medida da altura da linha.
        /// </summary>
        public float LineHeight => (float)InternalFont.GetLineHeight(size).ToMm();

        public Font Clonar() => new Font(InternalFont, size);

    }
}
