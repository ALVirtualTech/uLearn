namespace uLearn
{
	public interface ISolutionValidator
	{
		///<summary>�������� ����, ��� ��� �� �������� ������ ����������</summary>>
		string FindFullSourceError(string userCode);

		///<summary>�������� ����� ������� �� ���������������</summary>
		string FindSyntaxError(string solution);

		///<summary>�������� ������������ ����, ������� ������� �������</summary>
		string FindValidatorError(string userCode, string solution);
	}
}