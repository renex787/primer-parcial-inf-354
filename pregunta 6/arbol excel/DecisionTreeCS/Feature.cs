namespace DecisionTreeCS {
  class Feature {
    public dynamic Value {
      get; private set;
    }

    // We should only allow creation of Features with explicit strings
    // or decimal values, even though we can save any type of value
    // due to the dynamic data type.
    public Feature(string value) => Value = value;
    public Feature(decimal value) => Value = value;

    // This property can be used to get if this Feature is a decimal.
    public bool IsNumeric => Value is decimal;

    // The following methods are provided to allow comparisons
    // when using HashSets with this class
    public override int GetHashCode() {
      if (Value is decimal number)
        return number.GetHashCode();
      else if (Value is string str)
        return str.GetHashCode();
      else
        return base.GetHashCode();
    }

    public override bool Equals(object obj) {
      if (obj is Feature feature) {
        if (Value is decimal number)
          return number.Equals(feature.Value);
        else if (Value is string str)
          return str.Equals(feature.Value);
      }
      return base.Equals(obj);
    }

    public override string ToString() {
      if (Value is decimal number)
        return number.ToString();
      else
        return Value;
    }

    // This method can be used to parse values from a string,
    // either a decimal value or a categorical one.
    public static Feature ParseFromString(string value) {
      // Try parsing the value as a number, if successful use that
      if (decimal.TryParse(value, out decimal num))
        return new Feature(num);
      // If parsing as number wasn't successful, use it as-is
      else
        return new Feature(value);
    }

    // This function is used to parse dynamic values from the CSV file
    // This method CAN throw during the type assertion, so this should
    // only be used inside a try-catch block.
    public static Feature ParseFromCsv(dynamic feature) {
      // Try casting (this might fail, an outer try-catch block should prevent the app from dying)
      string value = feature.Value as string;
      return ParseFromString(value);
    }
  }
}
