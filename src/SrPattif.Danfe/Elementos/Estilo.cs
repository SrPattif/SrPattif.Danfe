using DanfeSharp.Graphics;
using System;
using pcf = org.pdfclown.documents.contents.fonts;

namespace DanfeSharp
{
    /// <summary>
    /// Coleção de fontes e medidas a serem compartilhadas entre os elementos básicos.
    /// </summary>
    internal class Estilo 
    {
        public float PaddingSuperior { get; set; }
        public float PaddingInferior { get; set; }
        public float PaddingHorizontal { get; set; }
        public float FonteTamanhoMinimo { get; set; }

        public pcf.Font FonteInternaRegular { get; set; }
        public pcf.Font FonteInternaNegrito { get; set; }
        public pcf.Font FonteInternaItalico { get; set; }

        public Font FonteCampoCabecalho { get; private set; }
        public Font FonteCampoConteudo { get; private set; }
        public Font FonteCampoConteudoNegrito { get; private set; }
        public Font FonteBlocoCabecalho { get; private set; }
        public Font FonteNumeroFolhas { get; private set; }

        public Estilo(pcf.Font fontRegular, pcf.Font fontBold, pcf.Font fontItalic, float tamanhoFonteCampoCabecalho = 6, float tamanhoFonteConteudo = 10)
        {
            PaddingHorizontal = 0.75F;
            PaddingSuperior = 0.65F;
            PaddingInferior = 0.3F;

            FonteInternaRegular = fontRegular;
            FonteInternaNegrito = fontBold;
            FonteInternaItalico = fontItalic;

            FonteCampoCabecalho = CriarFonteRegular(tamanhoFonteCampoCabecalho);
            FonteCampoConteudo = CriarFonteRegular(tamanhoFonteConteudo);
            FonteCampoConteudoNegrito = CriarFonteNegrito(tamanhoFonteConteudo);
            FonteBlocoCabecalho = CriarFonteRegular(7);
            FonteNumeroFolhas = CriarFonteNegrito(10F);
            FonteTamanhoMinimo = 5.75F;
        }

        public Font CriarFonteRegular(float emSize) => new Font(FonteInternaRegular, emSize);
        public Font CriarFonteNegrito(float emSize) => new Font(FonteInternaNegrito, emSize);
        public Font CriarFonteItalico(float emSize) => new Font(FonteInternaItalico, emSize);

    }
}
