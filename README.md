<h1>
Fydar.Samples
</h1>

**Fydar.Samples** is a library for maintaining code samples and generating documentation for **C#**.

<p align="center">
  <img src="./img/HowToUse.svg" alt="A demo of how to use Fydar.Samples to generate samples."/>
  <sup><i>A demo of how to use Fydar.Samples to generate samples.</i></sup>
</p>

Samples are kept within your project and can be presented via two mechanisms.

- *File System* sampling is used to present code samples.
- *Sample Return* is used to present the result of a method.

<p align="center">
  <img src="./img/SerializationSample.svg" alt="A sample maintained using this project."/>
  <sup><i>A demo of how to use Fydar.Samples to generate samples.</i></sup>
</p>

When the application is run, all static methods with the `SampleReturn` attribute are invoked and their results are presented in the output.

<p align="center">
  <img src="./img/Serialized.svg" alt="The formatted output of the sample."/>
  <sup><i>The formatted output of the sample.</i></sup>
</p>

## License

This work is licensed under a [Creative Commons Attribution-NonCommercial 4.0 International License](http://creativecommons.org/licenses/by-nc/4.0/).

[![Creative Commons License](https://i.creativecommons.org/l/by-nc/4.0/88x31.png)](http://creativecommons.org/licenses/by-nc/4.0/)
