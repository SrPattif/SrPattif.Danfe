﻿using System;

namespace DanfeSharp.Elementos
{
    /// <summary>
    /// Linha de campos, posiciona e muda a largura desses elementos de forma proporcional.
    /// </summary>
    internal class LinhaCampos : FlexibleLine
    {
        public Estilo Estilo { get; private set; }

        public LinhaCampos(Estilo estilo, float width, float height = Constants.FieldHeight) : base()
        {
            Estilo = estilo;
            SetSize(width, height);
        }

        public LinhaCampos(Estilo estilo) : base()
        {
            Estilo = estilo;
        }

        public virtual LinhaCampos ComCampo(String cabecalho, String conteudo, HorizontalAlignment alinhamentoHorizontalConteudo = HorizontalAlignment.Left)
        {
            var campo = new Campo(cabecalho, conteudo, Estilo, alinhamentoHorizontalConteudo);
            Elementos.Add(campo);
            return this;
        }

        public virtual LinhaCampos ComCampoNumerico(String cabecalho, double? conteudoNumerico, int casasDecimais = 2)
        {
            var campo = new CampoNumerico(cabecalho, conteudoNumerico, Estilo, casasDecimais);
            Elementos.Add(campo);
            return this;
        }
    }
}
