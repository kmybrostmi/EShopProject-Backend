using Common.Domain.Utils;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.ValueObjects;
public class NationalCode : ValueObject
{
    public NationalCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.IsText() || value.Length is < 10 or > 10 || IranianNationalIdChecker.IsValid(value))
            throw new InvalidDomainDataException("کد ملی نامعتبر است");
        Value = value;
    }

    public string Value { get; private set; }
}
