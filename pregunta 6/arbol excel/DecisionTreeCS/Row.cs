using System.Collections;
using System.Collections.Generic;

namespace DecisionTreeCS {
  // We extend IEnumerable here to allow
  // iteration using foreach loops
  class Row : IEnumerable<Feature> {
    readonly List<Feature> features;

    public Row() => features = new List<Feature>();

    public Row(int capacity) => features = new List<Feature>(capacity);

    public Row(IEnumerable<Feature> collection) => features = new List<Feature>(collection);

    public int Count => features.Count;

    public void Add(Feature item) => features.Add(item);

    public void AddRange(IEnumerable<Feature> collection) => features.AddRange(collection);

    public void Clear() => features.Clear();

    // This allows us to use the index operator in this class
    public Feature this[int index] {
      get => features[index];
      set => features[index] = value;
    }

    // This method parses tries to parse a record using Feature.ParseFromCsv.
    public static Row ParseFromCsv(dynamic record) {
      if (record is IEnumerable enumerable) {
        Row row = new Row();
        // This will probably be a Dictionary<string, string>,
        // therefore, feature should be KeyValuePair<string, string>.
        foreach (var feature in enumerable) {
          // Try parsing this record as a feature
          Feature parsedFeature = Feature.ParseFromCsv(feature);
          // If successful, add it to the feature list
          if (parsedFeature != null)
            row.Add(parsedFeature);
        }
        return row;
      }

      return null;
    }

    public IEnumerator<Feature> GetEnumerator() => features.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
  }
}
