public class ValidationResult
{
	public bool IsValid { get; set; }
	public string? ErrorMessage { get; set; }
}

public class ValidationResult<T>
{
	public bool IsValid { get; set; }
	public string? ErrorMessage { get; set; }
	public T? Value { get; set; }
}