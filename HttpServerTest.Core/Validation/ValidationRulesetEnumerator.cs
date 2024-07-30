using System.Collections;

namespace HttpServerTest.Core.Validation;

public class ValidationRulesetEnumerator : IEnumerator<IValidationRule>
{
    readonly ValidationRuleset _initialRuleset;

    ValidationRuleset _currentRuleset;

    IValidationRule? _currentRule;

    int _currentIndex = -1;

    public IValidationRule Current => _currentRule!;

    object IEnumerator.Current => _currentRule!;

    public ValidationRulesetEnumerator(ValidationRuleset ruleset)
    {
        _initialRuleset = ruleset;
        _currentRuleset = ruleset;
    }

    public void Dispose()
    {

    }

    public bool MoveNext()
    {
        if (++_currentIndex >= _currentRuleset.Count)
        {
            if (_currentRuleset.NestedRuleset is not null and
                ValidationRuleset ruleset && ruleset.Count != 0)
            {
                _currentIndex = 0;
                _currentRuleset = _currentRuleset.NestedRuleset;
            }
            else
            {
                return false;
            }
        }

        _currentRule = _currentRuleset[_currentIndex];
        return true;
    }

    public void Reset()
    {
        _currentIndex = -1;
        _currentRuleset = _initialRuleset;
    }
}
