# 📄 SrPattif.Danfe

**Gere DANFEs em PDF com .NET** de forma rápida e leve. Salve-os ou imprima-os... *o céu é o limite!* 🚀

> Este projeto é uma refatoração do **projeto [DanfeSharp](https://github.com/SilverCard/DanfeSharp)**, descontinuado e **arquivado em fevereiro de 2024**.

## ✨ Funcionalidades
- Desserialização do XML de Notas Fiscais para model
- Geração de PDF de DANFE customizável

<i>e mais em breve!</i>

## ⬇️ Instalação via NuGet
Instale a versão mais atual da biblioteca no NuGet:

 ```
 > Install-Package SrPattif.Danfe
 ```

## 🖇️ Exemplos de uso
### Obter model a partir de arquivo XML
O primeiro passo é instanciar a model da Nota Fiscal através de seu XML.
```csharp
// Cria o model a partir do arquivo XML da NF-e.
var nf = DanfeViewModelCreator.CreateFromXmlFile("nfe.xml");
```

### Gerar e salvar PDF da DANFE
Agora, você já pode gerar o PDF e salvá-lo onde desejar! 🚀
```csharp
// Gera o PDF da DANFE e salva-o no local indicado.
using (var danfe = new Danfe(nf))
{
	danfe.Generate();
	danfe.Save("danfe.pdf");
}
```
