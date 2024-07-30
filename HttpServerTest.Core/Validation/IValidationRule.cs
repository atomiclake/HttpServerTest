namespace HttpServerTest.Core.Validation;

public interface IValidationRule
{
    string Name { get; }

    bool Validate();
}
