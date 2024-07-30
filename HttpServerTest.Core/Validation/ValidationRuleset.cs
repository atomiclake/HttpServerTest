using System.Collections;

namespace HttpServerTest.Core.Validation;

public class ValidationRuleset : IList<IValidationRule>
{
    readonly List<IValidationRule> _rules;

    public ValidationRuleset? NestedRuleset { get; }

    public int Count => _rules.Count;

    public bool IsReadOnly => false;

    public IValidationRule this[int index] { get => _rules[index]; set => _rules[index] = value; }

    public ValidationRuleset()
    {
        _rules = [];
    }

    public ValidationRuleset(ValidationRuleset nestedRuleset)
        : this()
    {
        NestedRuleset = nestedRuleset;
    }

    public void Add(IValidationRule item)
    {
        if (_rules.Any(rule => rule.Name == item.Name))
        {
            throw new ArgumentException($"A rule already exists with the name '{item.Name}'", nameof(item));
        }

        _rules.Add(item);
    }

    public void Clear()
    {
        _rules.Clear();
    }

    public bool Contains(IValidationRule item)
    {
        return _rules.Contains(item);
    }

    public void CopyTo(IValidationRule[] array, int arrayIndex)
    {
        _rules.CopyTo(array, arrayIndex);
    }

    public bool Remove(IValidationRule item)
    {
        return _rules.Remove(item);
    }

    public IEnumerator<IValidationRule> GetEnumerator()
    {
        return new ValidationRulesetEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new ValidationRulesetEnumerator(this);
    }

    public int IndexOf(IValidationRule item)
    {
        return _rules.IndexOf(item);
    }

    public void Insert(int index, IValidationRule item)
    {
        _rules.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        _rules.RemoveAt(index);
    }
}
