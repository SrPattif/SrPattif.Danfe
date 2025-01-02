# 📄 SrPattif.Danfe

**Gere DANFEs em PDF com .NET** de forma rápida e leve. Salve-os ou imprima-os... *o céu é o limite!* 🚀

> Este projeto é uma refatoração do **projeto [DanfeSharp](https://github.com/SilverCard/DanfeSharp)**, descontinuado e **arquivado em fevereiro de 2024**.

## ✨ Funcionalidades
- Desserialização do XML de Notas Fiscais para model
- Geração de PDF de DANFE customizável

<i>e mais em breve!</i>

## ⬇️ Instalação via NuGet
[![Nuget count](http://img.shields.io/nuget/v/SrPattif.Danfe.svg)](http://www.nuget.org/packages/SrPattif.Danfe/)
[![Nuget downloads](https://img.shields.io/nuget/dt/SrPattif.Danfe.svg)](http://www.nuget.org/packages/SrPattif.Danfe/)


<b>Instale a versão mais atual da biblioteca no NuGet:</b>

<details open>
<summary><b>Package Manager</b></summary>
	
 ```
 > Install-Package SrPattif.Danfe
 ```
</details>
<details>
<summary><b>.NET CLI</b></summary>
	
 ```
 > dotnet add package SrPattif.Danfe --version 1.0.0
 ```
</details>
<details>
<summary><b>PackageReference</b></summary>
	
 ```xml
 <PackageReference Include="SrPattif.Danfe" Version="1.0.0" />
 ```
</details>

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
