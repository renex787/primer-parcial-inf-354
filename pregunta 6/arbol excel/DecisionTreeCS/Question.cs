namespace DecisionTreeCS {
  class Question {
    readonly int property;
    readonly string propertyName;
    readonly Feature feature;

    public Question(int property, string propertyName, Feature feature) {
      this.property = property;
      this.propertyName = propertyName;
      this.feature = feature;
    }

    // We receive an object of type Row, which is indexable. We then
    // use the index of this Question to get the feature in that index.
    // Then we test differently depending if this value is numeric or
    // categorical.
    public bool Match(Row row) {
      Feature feature = row[property];
      if (feature.IsNumeric && this.feature.IsNumeric) {
        return feature.Value >= this.feature.Value;
      }
      return feature.Value == this.feature.Value;
    }

    public override string ToString() {
      if (feature.IsNumeric) {
        return $"¿Es {propertyName.FirstCharToLower()} >= {feature.Value}?";
      } else {
        return $"¿Es {propertyName.FirstCharToLower()} == {feature.Value}?";
      }
    }
  }
}
