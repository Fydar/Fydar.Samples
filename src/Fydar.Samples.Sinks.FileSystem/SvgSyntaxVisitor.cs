using System;

namespace Fydar.Samples.Grammars
{
	public class SvgSyntaxVisitor :
		ITokenVisitor,
		ITokenReaderClassifier
	{
		private TokenClass tokenClass;

		public void StartVisit()
		{
		}

		public void VisitTokenClass(TokenClass tokenClass)
		{
			this.tokenClass = tokenClass;
		}

		public void EndVisit(ReadOnlySpan<char> content)
		{
		}
	}
}
