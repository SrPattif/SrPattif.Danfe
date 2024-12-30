using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanfeSharp.Modelo;

namespace DanfeSharp.Blocos
{
    abstract class BlocoLocalEntregaRetirada : BlocoBase
    {
        public LocalEntregaRetiradaViewModel Model { get; private set; }

        public BlocoLocalEntregaRetirada(DanfeViewModel viewModel, Estilo estilo, LocalEntregaRetiradaViewModel localModel) : base(viewModel, estilo)
        {
            Model = localModel ?? throw new ArgumentNullException(nameof(localModel));
            
            AdicionarLinhaCampos()
            .ComCampo(Strings.NomeRazaoSocial, Model.NomeRazaoSocial)
            .ComCampo(Strings.CnpjCpf, Formatador.FormatarCpfCnpj(Model.CnpjCpf), HorizontalAlignment.Center)
            .ComCampo(Strings.InscricaoEstadual, Model.InscricaoEstadual, HorizontalAlignment.Center)
            .ComLarguras(0, 45F * Proporcao, 30F * Proporcao);

            AdicionarLinhaCampos()
            .ComCampo(Strings.Endereco, Model.Endereco)
            .ComCampo(Strings.BairroDistrito, Model.Bairro)
            .ComCampo(Strings.Cep, Formatador.FormatarCEP(Model.Cep), HorizontalAlignment.Center)
            .ComLarguras(0, 45F * Proporcao, 30F * Proporcao);

            AdicionarLinhaCampos()
            .ComCampo(Strings.Municipio, Model.Municipio)
            .ComCampo(Strings.UF, Model.Uf, HorizontalAlignment.Center)
            .ComCampo(Strings.FoneFax, Formatador.FormatarTelefone(Model.Telefone), HorizontalAlignment.Center)
            .ComLarguras(0, 7F * Proporcao, 30F * Proporcao);
        }

        public override BlockPosition Posicao => BlockPosition.Top;

    }
}
