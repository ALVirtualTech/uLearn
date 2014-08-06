using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace uLearn.CSharp
{
	public interface ISolutionValidator
	{
		string FindError(SyntaxTree userSolution);
	}

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class IsStaticMethodAttribute : Attribute, ISolutionValidator
	{
		public const string ShouldBeMethod = "������� ������ ���� ���������� ������������ ������������ ������";
		public const string ShouldBeSingleMethod = "������� ������ �������� ����� �� ������ ������";

		public string FindError(SyntaxTree userSolution)
		{
			var cu = userSolution.GetRoot() as CompilationUnitSyntax;
			if (cu == null) return ShouldBeMethod;
			if (cu.Members.Count > 1) return ShouldBeSingleMethod;
			var method = cu.Members[0] as MethodDeclarationSyntax;
			if (method == null) return ShouldBeMethod;
			return FindError(method);
		}

		protected virtual string FindError(MethodDeclarationSyntax method)
		{
			return null;
		}
	}

	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class SingleStatementMethodAttribute : IsStaticMethodAttribute
	{
		public const string ShouldBeSingleMethodMessage = "������� ������ ���� � ���� ���������";

		protected override string FindError(MethodDeclarationSyntax method)
		{
			return method.Body.Statements.Count != 1 ? ShouldBeSingleMethodMessage : null;
		}
	}
}