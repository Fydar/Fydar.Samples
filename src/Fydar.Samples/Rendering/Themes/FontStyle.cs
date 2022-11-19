using System;

namespace Fydar.Samples.Rendering.Themes;

[Flags]
public enum FontStyle
{
	/// <summary>
	/// 
	/// </summary>
	Normal = 0b0000000,

	/// <summary>
	/// 
	/// </summary>
	Italics = 0b0000001,

	/// <summary>
	/// 
	/// </summary>
	Superscript = 0b0000100,

	/// <summary>
	/// 
	/// </summary>
	Subscript = 0b0001000
}
