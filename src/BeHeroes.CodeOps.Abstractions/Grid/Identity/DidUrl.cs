using System.Text.RegularExpressions;

namespace BeHeroes.CodeOps.Abstractions.Grid.Identity
{
    public sealed class DidUrl
    {
        private static Regex regEx = new Regex(Constants.REGEX_DID_URL, RegexOptions.IgnoreCase);
        
        public string Did => $"did:{Method}:{Id}";

        public Uri Url { get; init; }

        public string Method { get; init; }

        public string Id { get; init; }

        public string Path { get; init; }

        public string Fragment { get; init; }

        public string Query { get; init; }

        public Dictionary<string, string> Parameters { get; init; }

        public DidUrl(Uri url, string method, string id, string path, string fragment, string query, Dictionary<string, string>? parameters)
        {
            Parameters = parameters ?? new Dictionary<string, string>();            
            Url = url;
            Method = method;
            Id = id;
            Path = path;
            Fragment = fragment;
            Query = query;
        }

        public static DidUrl? Parse(Uri url)
        {
            if (!string.IsNullOrWhiteSpace(url.AbsoluteUri))
            {
                var regExMatches = regEx.Matches(url.AbsoluteUri);

                if (regExMatches.Any())
                {
                    var firstMatch = regExMatches.First();

                    Dictionary<string, string>? parameters = null;

                    var methodName = firstMatch.Groups[Constants.REGEX_METHOD_NAME_CAPTURE_IDENTIFIER].Captures[0].Value;
                    var methodId = firstMatch.Groups[Constants.REGEX_METHOD_ID_CAPTURE_IDENTIFIER].Captures[0].Value;                
                    var path = (firstMatch.Groups[Constants.REGEX_PATH_CAPTURE_IDENTIFIER].Captures.Count > 0) ? firstMatch.Groups[Constants.REGEX_PATH_CAPTURE_IDENTIFIER].Captures[0].Value : string.Empty;
                    var fragment = (firstMatch.Groups[Constants.REGEX_FRAGMENT_CAPTURE_IDENTIFIER].Captures.Count > 0) ? firstMatch.Groups[Constants.REGEX_FRAGMENT_CAPTURE_IDENTIFIER].Captures[0].Value.Substring(1) : string.Empty;
                    var query = (firstMatch.Groups[Constants.REGEX_QUERY_CAPTURE_IDENTIFIER].Captures.Count > 0) ? firstMatch.Groups[Constants.REGEX_QUERY_CAPTURE_IDENTIFIER].Captures[0].Value.Substring(1) : string.Empty;
                    
                    if (firstMatch.Groups[Constants.REGEX_PARAMS_CAPTURE_IDENTIFIER].Length > 0)
                    {
                        parameters = new Dictionary<string, string>();

                        var paramNames = firstMatch.Groups[Constants.REGEX_PARAM_NAME_CAPTURE_IDENTIFIER];
                        var paramValues = firstMatch.Groups[Constants.REGEX_PARAM_VALUE_CAPTURE_IDENTIFIER];

                        for (var i = 0; i < paramNames.Captures.Count; i++)
                        {
                            parameters[paramNames.Captures[i].Value] = paramValues.Captures[i].Value;
                        }
                    }

                    return new DidUrl(url, methodName, methodId, path, fragment, query, parameters);
                }
            }

            return null;
        }
    }
}