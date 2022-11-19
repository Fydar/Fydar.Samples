namespace Fydar.Samples.Grammars.Json;

internal class WriterNode
{
	internal TokenKind tokenKind;
	internal int nodeIndex;
	internal int startLexicalToken;
	internal ushort leadingLexicalTokens;
	internal ushort totalChildNodesCounter;
	internal ushort totalLexicalTokensCounter;
}
