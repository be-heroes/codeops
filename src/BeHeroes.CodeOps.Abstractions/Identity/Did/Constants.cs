namespace BeHeroes.CodeOps.Abstractions.Identity.Did
{
    public class Constants
    {
        public const string REGEX_DID_ID_CHAR = "[a-zA-Z0-9_.-]";
        public const string REGEX_DID_PARAM_CHAR = "[a-zA-Z0-9_.:%-]";
        public const string REGEX_DID_METHOD_NAME_CAPTURE_IDENTIFIER = "MethodName";
        public const string REGEX_DID_METHOD_NAME = $"(?<{REGEX_DID_METHOD_NAME_CAPTURE_IDENTIFIER}>[a-zA-Z0-9_]+)";
        public const string REGEX_DID_METHOD_ID_CAPTURE_IDENTIFIER = "MethodId";
        public const string REGEX_DID_METHOD_ID = $"(?<{REGEX_DID_METHOD_ID_CAPTURE_IDENTIFIER}>{REGEX_DID_ID_CHAR}+(:{REGEX_DID_ID_CHAR}+)*)";
        public const string REGEX_DID_PATH_CAPTURE_IDENTIFIER = "Path";
        public const string REGEX_DID_PATH = $@"(?<{REGEX_DID_PATH_CAPTURE_IDENTIFIER}>\/[^#?]*)?";
        public const string REGEX_DID_QUERY_CAPTURE_IDENTIFIER = "Query";
        public const string REGEX_DID_QUERY = $"(?<{REGEX_DID_QUERY_CAPTURE_IDENTIFIER}>[?][^#]*)?";
        public const string REGEX_DID_FRAGMENT_CAPTURE_IDENTIFIER = "Fragment";
        public const string REGEX_DID_FRAGMENT = $@"(?<{REGEX_DID_FRAGMENT_CAPTURE_IDENTIFIER}>\#.*)?";
        public const string REGEX_DID_PARAM_NAME_CAPTURE_IDENTIFIER = "ParamName";
        public const string REGEX_DID_PARAM_VALUE_CAPTURE_IDENTIFIER = "ParamValue";
        public const string REGEX_DID_PARAMS_CAPTURE_IDENTIFIER = "Params";
        public const string REGEX_DID_PARAM = $";(?<{REGEX_DID_PARAM_NAME_CAPTURE_IDENTIFIER}>{REGEX_DID_PARAM_CHAR}+)=(?<{REGEX_DID_PARAM_VALUE_CAPTURE_IDENTIFIER}>{REGEX_DID_PARAM_CHAR}*)";
        public const string REGEX_DID_PARAMS = $"(?<{REGEX_DID_PARAMS_CAPTURE_IDENTIFIER}>({REGEX_DID_PARAM})*)";
        public const string REGEX_DID_URL = $"^did:{REGEX_DID_METHOD_NAME}:{REGEX_DID_METHOD_ID}{REGEX_DID_PARAMS}{REGEX_DID_PATH}{REGEX_DID_QUERY}{REGEX_DID_FRAGMENT}$";
    }
}

