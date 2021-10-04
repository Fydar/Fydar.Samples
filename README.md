<h1>
📦 Fydar.Samples
</h1>

**Fydar.Samples** is a library for maintaining code samples and generating documentation for **C#**.

<p align="center">
  <img src="./img/how-to-use.svg" alt="A demo of how to use Fydar.Samples to generate samples."/>
  <sup><i>A demo of how to use Fydar.Samples to generate samples.</i></sup>
</p>

Samples are kept within your project and can be presented via two mechanisms.

- *File System* sampling is used to present code samples.
- *Sample Return* is used to present the result of a method.

<p align="center">
  <img src="./img/serialization-sample.svg" alt="A sample maintained using this project."/>
  <sup><i>A demo of how to use Fydar.Samples to generate samples.</i></sup>
</p>

When the application is run, all static methods with the `SampleReturn` attribute are invoked and their results are presented in the output.

<p align="center">
  <img src="./img/serialization-sample-output.svg" alt="The formatted output of the sample."/>
  <sup><i>The formatted output of the sample.</i></sup>
</p>

## 🔧 Installation

Include a reference to the project (NuGet package coming soon) in your solution.

<p align="center">
  <img src="./img/installation-csproj.png" alt="A properly configured .csproj file."/>
  <sup><i>A properly configured .csproj file.</i></sup>
</p>

Sample `.cs` files will need to be included in the build output so the syntax highlighter will be able to operate on them.

<p align="center">
  <img src="./img/project-layout.png" alt="Solution with samples included in the samples directory."/>
  <sup><i>Solution with samples included in the samples directory.</i></sup>
</p>

## ⚖ License

This work is licensed under a [Creative Commons Attribution-NonCommercial 4.0 International License](http://creativecommons.org/licenses/by-nc/4.0/).

[![Creative Commons License](https://i.creativecommons.org/l/by-nc/4.0/88x31.png)](http://creativecommons.org/licenses/by-nc/4.0/)
