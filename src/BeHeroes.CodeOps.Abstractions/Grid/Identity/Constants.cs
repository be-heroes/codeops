namespace BeHeroes.CodeOps.Abstractions.Grid.Identity
{
    public class Constants
    {
        public const string REGEX_ID_CHAR = "[a-zA-Z0-9_.-]";
        public const string REGEX_PARAM_CHAR = "[a-zA-Z0-9_.:%-]";
        public const string REGEX_METHOD_NAME_CAPTURE_IDENTIFIER = "MethodName";
        public const string REGEX_METHOD_NAME = $"(?<{REGEX_METHOD_NAME_CAPTURE_IDENTIFIER}>[a-zA-Z0-9_]+)";
        public const string REGEX_METHOD_ID_CAPTURE_IDENTIFIER = "MethodId";
        public const string REGEX_METHOD_ID = $"(?<{REGEX_METHOD_ID_CAPTURE_IDENTIFIER}>{REGEX_ID_CHAR}+(:{REGEX_ID_CHAR}+)*)";
        public const string REGEX_PATH_CAPTURE_IDENTIFIER = "Path";
        public const string REGEX_PATH = $@"(?<{REGEX_PATH_CAPTURE_IDENTIFIER}>\/[^#?]*)?";
        public const string REGEX_QUERY_CAPTURE_IDENTIFIER = "Query";
        public const string REGEX_QUERY = $"(?<{REGEX_QUERY_CAPTURE_IDENTIFIER}>[?][^#]*)?";
        public const string REGEX_FRAGMENT_CAPTURE_IDENTIFIER = "Fragment";
        public const string REGEX_FRAGMENT = $@"(?<{REGEX_FRAGMENT_CAPTURE_IDENTIFIER}>\#.*)?";
        public const string REGEX_PARAM_NAME_CAPTURE_IDENTIFIER = "ParamName";
        public const string REGEX_PARAM_VALUE_CAPTURE_IDENTIFIER = "ParamValue";
        public const string REGEX_PARAMS_CAPTURE_IDENTIFIER = "Params";
        public const string REGEX_PARAM = $";(?<{REGEX_PARAM_NAME_CAPTURE_IDENTIFIER}>{REGEX_PARAM_CHAR}+)=(?<{REGEX_PARAM_VALUE_CAPTURE_IDENTIFIER}>{REGEX_PARAM_CHAR}*)";
        public const string REGEX_PARAMS = $"(?<{REGEX_PARAMS_CAPTURE_IDENTIFIER}>({REGEX_PARAM})*)";
        public const string REGEX_DID_URL = $"^did:{REGEX_METHOD_NAME}:{REGEX_METHOD_ID}{REGEX_PARAMS}{REGEX_PATH}{REGEX_QUERY}{REGEX_FRAGMENT}$";
    }
}

