namespace DecisionTreeCS {
  // This class is used to add methods to the native string class.
  // See more: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
  public static class StringExtensions {
    public static string FirstCharToUpper(this string input) {
      if (string.IsNullOrEmpty(input))
        return string.Empty;

      char[] str = input.ToCharArray();
      str[0] = char.ToUpper(str[0]);
      return new string(str);
    }

    public static string FirstCharToLower(this string input) {
      if (string.IsNullOrEmpty(input))
        return string.Empty;

      char[] str = input.ToCharArray();
      str[0] = char.ToLower(str[0]);
      return new string(str);
    }
  }
}
