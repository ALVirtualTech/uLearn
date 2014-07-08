using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace uLearn.CSharp
{
	public static class SlideParser
	{
		public static Slide ParseSlide(string filename)
		{
			SyntaxTree tree = CSharpSyntaxTree.ParseFile(filename);
			return ParseSyntaxTree(tree);
		}

		public static Slide ParseCode(string sourceCode)
		{
			SyntaxTree tree = CSharpSyntaxTree.ParseText(sourceCode);
			return ParseSyntaxTree(tree);
		}

		private static Slide ParseSyntaxTree(SyntaxTree tree)
		{
			var walker = new SlideWalker();
			walker.Visit(tree.GetRoot());
			if (walker.Exercise == null)
				return new Slide(walker.Blocks);

			return new ExerciseSlide(walker.Blocks, walker.Exercise, walker.TestBlock, walker.Hints);
		}
	}
}